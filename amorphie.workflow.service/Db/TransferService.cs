﻿using amorphie.core.Base;
using amorphie.workflow.core.Dtos;
using amorphie.workflow.core.Enums;
using amorphie.workflow.core.Models;
using Microsoft.EntityFrameworkCore;
using amorphie.workflow.core.Dtos.Definition;
using amorphie.workflow.core.Mapper;
using amorphie.workflow.service.Db.Abstracts;
using amorphie.workflow.core.Token;
using System.Text.Json;
using amorphie.workflow.core.Models.Transfer;
using amorphie.workflow.core.Dtos.Transfer;
using System.Diagnostics;
using amorphie.core.Extension;

namespace amorphie.workflow.service.Db;
public class TransferService
{
    private readonly WorkflowDBContext _dbContext;
    private readonly DbSet<Workflow> _dbSet;
    private readonly IWorkflowService _workflowService;
    private readonly IStateService _stateService;

    public TransferService(WorkflowDBContext dbContext, IWorkflowService workflowService, IStateService stateService)
    {
        _dbContext = dbContext;
        _dbSet = dbContext.Set<Workflow>();
        _workflowService = workflowService;
        _stateService = stateService;
    }


    public async Task<Response<Workflow>> MigrateTransitionAsync(string workflowName)
    {
        var workFlows = await _dbSet
            .Include(s => s.Entities)
            .Include(s => s.States)
            .Where(w => w.Name == workflowName)
            .FirstOrDefaultAsync();

        if (workFlows == null)
        {
            return new Response<Workflow>
            {
                Result = new Result(amorphie.core.Enums.Status.Error, "Workflow Not found")
            };
        }
        var stateNames = workFlows.States.Select(s => s.Name).ToList();
        var transitionFromState = await _dbContext.Transitions
        .Include(p => p.FromState)
        .Where(p => stateNames.Contains(p.FromStateName) || (p.ToStateName != null && stateNames.Contains(p.ToStateName))).ToListAsync();
        if (transitionFromState.Any())
        {
            foreach (var trx in transitionFromState)
            {
                //is there state that has same name with transition
                var trxState = await _dbContext.States.Where(p => p.Name == trx.Name).FirstOrDefaultAsync();
                if (trxState != null)
                {
                    trxState.Kind = StateKind.Transition;
                    trxState.PageId = trx.PageId;
                    trxState.transitionButtonType = trx.transitionButtonType;
                }
                else
                {
                    var newState = MapStateFromTrx(workflowName, trx);
                    _dbContext.States.Add(newState);
                }
                var stateToStates = await _dbContext.StateToStates.Where(p => p.FromStateName == trx.Name && p.ToStateName == trx.ToStateName).FirstOrDefaultAsync();
                if (stateToStates == null)
                {
                    var newStateRoute = MapStateRouteFromTrx(trx);
                    _dbContext.StateToStates.Add(newStateRoute);
                }
            }
        }
        await _dbContext.SaveChangesAsync();

        return new Response<Workflow>
        {
            Data = workFlows,
            Result = new Result(amorphie.core.Enums.Status.Success, "")
        };
    }

    public async Task<Response<WorkflowCreateDto>> GetDefinitionBulkAsync(string workflowName, CancellationToken cancellationToken)
    {
        var workflow = await GetWorkflowForLegacyAsync(workflowName, cancellationToken);

        if (workflow == null)
        {
            return new Response<WorkflowCreateDto>
            {
                Result = new Result(amorphie.core.Enums.Status.Error, "Workflow Not found")
            };
        }
        var workflowDto = SetWorkflowCreateDtoBaseProps(workflow);

        workflowDto.States = StateMapperLegacy.Map(workflow.States);

        workflowDto.Hash = Md5.Generate(workflowDto);
        return new Response<WorkflowCreateDto>
        {
            Data = workflowDto,
            Result = new Result(amorphie.core.Enums.Status.Success, "")
        };
    }

    public async Task<Response<TransferResultDto>> SaveTransferRequestAsync(WorkflowCreateDto workflowDto, CancellationToken cancellationToken)
    {
        var transferHistroy = new TransferHistory
        {
            Hash = "",
            RequestBody = JsonSerializer.Serialize(workflowDto),
            SubjectName = workflowDto.Name,
            TransferStatus = TransferStatus.WaitingForApproval,
            TransferringType = nameof(Workflow),
            SemVer = workflowDto.SemVer

        };
        _dbContext.TransferHistories.Add(transferHistroy);
        await _dbContext.SaveChangesAsync();
        return new Response<TransferResultDto>
        {
            Data = new TransferResultDto
            {
                TransferId = transferHistroy.Id
            },
            Result = new Result(amorphie.core.Enums.Status.Success, "")
        };
    }

    public async Task<Response> ApproveOrCancelTransferOfDefinitionAsync(TransferResultDto transferDto, TransferStatus transferStatus, CancellationToken cancellationToken)
    {
        var transferHistroy = await _dbContext.TransferHistories.FirstOrDefaultAsync(p => p.Id == transferDto.TransferId && p.TransferStatus == TransferStatus.WaitingForApproval);
        if (transferHistroy == null)
        {
            return Response.Error("Transfer request not found nor it is in WaitingForApproval state");
        }
        if (transferStatus == TransferStatus.Approved)
        {
            var workflowDto = JsonSerializer.Deserialize<WorkflowCreateDto>(transferHistroy.RequestBody);
            if (workflowDto == null)
            {
                return Response.Error($"Transfer request could not be parsed to {nameof(WorkflowCreateDto)}");
            }
            var saveResponse = await _workflowService.SaveAsync(workflowDto!, cancellationToken);
            transferHistroy.TransferStatus = TransferStatus.Approved;
        }
        else
        {
            transferHistroy.TransferStatus = TransferStatus.Cancelled;
        }
        await _dbContext!.SaveChangesAsync();
        return Response.Success("");
    }
    public async Task<Response<TemplateEngineTemplateDefinitions>> SaveTemplatesFromLegacyBulkAsync(TemplateEngineTransferModel transferModel, CancellationToken cancellationToken)
    {
        try
        {
            var clientHttp = new HttpClient();
            HttpResponseMessage responseFrom = await clientHttp.GetAsync(transferModel.TransferFromUrl + "/0/10?query=" + transferModel.TemplateName);
            bool saveFlag = false;
            TemplateEngineTemplateDefinitions? formFrom = null;
            if (responseFrom.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var twiceSerializeFrom = await responseFrom!.Content!.ReadAsStringAsync();
                TemplateEngineGetDefinitionResponseModel formFromRM = System.Text.Json.JsonSerializer.Deserialize<TemplateEngineGetDefinitionResponseModel>(twiceSerializeFrom)!;
                formFrom = formFromRM.templateDefinitions![0];
                HttpResponseMessage responseTo = await clientHttp.GetAsync(transferModel.TransferToUrl + "/0/10?query=" + transferModel.TemplateName);
                if (responseTo.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var twiceSerializeTo = await responseTo!.Content!.ReadAsStringAsync();
                    TemplateEngineGetDefinitionResponseModel formToRM = System.Text.Json.JsonSerializer.Deserialize<TemplateEngineGetDefinitionResponseModel>(twiceSerializeTo)!;
                    TemplateEngineTemplateDefinitions formTo = formToRM.templateDefinitions![0];
                    if (formFrom.semanticVersion != formTo.semanticVersion)
                    {
                        saveFlag = true;
                    }
                }
                if (responseTo.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    saveFlag = true;
                }

            }
            if (saveFlag && formFrom != null)
            {
                var serializeRequest = JsonSerializer.Serialize(formFrom);

                HttpResponseMessage response = await clientHttp.PostAsync(transferModel.TransferToUrl, new StringContent(serializeRequest, System.Text.Encoding.UTF8, "application/json"));
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var transferHistroy = new TransferHistory
                    {
                        Hash = "",
                        RequestBody = serializeRequest,
                        SubjectName = formFrom.name,
                        TransferStatus = TransferStatus.Approved,
                        TransferringType = nameof(TemplateEngineRequest),
                        SemVer = formFrom.semanticVersion

                    };
                    await _dbContext.TransferHistories.AddAsync(transferHistroy);
                    await _dbContext.SaveChangesAsync(cancellationToken);
                    return new Response<TemplateEngineTemplateDefinitions>
                    {
                        Data = formFrom,
                        Result = new Result(amorphie.core.Enums.Status.Success, string.Empty)
                    };
                }
            }


        }
        catch (Exception ex)
        {
            return new Response<TemplateEngineTemplateDefinitions>
            {
                Result = new Result(amorphie.core.Enums.Status.Error, ex.Message)
            };
        }
        return new Response<TemplateEngineTemplateDefinitions>
        {
            Result = new Result(amorphie.core.Enums.Status.Success, "Not Modified")
        };

    }
    public async Task<Response<List<string>>> GetTemplatesFromLegacyBulkAsync(TemplateListRequestModel requestModel, CancellationToken cancellationToken)
    {
        List<string> templateList = new List<string>();
        if (requestModel.workflowNames != null && requestModel.workflowNames.Any())
        {
            foreach (string workflowName in requestModel.workflowNames)
            {
                templateList.AddRange(await GetTemplatesFromLegacyAsync(workflowName, requestModel.IsPage, cancellationToken));
            }
        }

        if (requestModel.extraTemplates != null && requestModel.extraTemplates.Any())
        {
            templateList.AddRange(requestModel.extraTemplates);
        }

        return new Response<List<string>>
        {
            Data = templateList.Distinct().ToList(),
            Result = new Result(amorphie.core.Enums.Status.Success, "")
        };

    }
    public async Task<Response<List<TransferHistoryResponseDto>>> GetTransferHistoryAsync(TransferHistoryRequestDto dataSearch, CancellationToken cancellationToken)
    {

        var query = _dbContext!.TransferHistories!.Where(a => a.TransferStatus == TransferStatus.Approved).AsQueryable();
        query = await query.Sort<TransferHistory>(dataSearch.SortColumn ?? "ModifiedAt", dataSearch.SortDirection);
        query = query.Skip(dataSearch.Page * dataSearch.PageSize)
        .Take(dataSearch.PageSize);
        List<TransferHistoryResponseDto> response = new List<TransferHistoryResponseDto>();

        if (!string.IsNullOrEmpty(dataSearch.Keyword))
        {
            query = query.AsNoTracking().Where(p => p.SubjectName == dataSearch.Keyword);
        }
        if (!string.IsNullOrEmpty(dataSearch.TransferringType))
        {
            query = query.AsNoTracking().Where(p => p.TransferringType == dataSearch.TransferringType);
        }
        if (await query.CountAsync(cancellationToken) > 0)
        {
            response = await query.Select(s => new TransferHistoryResponseDto()
            {
                CreatedAt = s.CreatedAt,
                FinishedAt = s.ModifiedAt,
                SubjectName = s.SubjectName,
                TransferringType = s.TransferringType,
                SemVer = s.SemVer,
                CreatedBy = s.CreatedBy

            }).ToListAsync(cancellationToken);

        }
        return new Response<List<TransferHistoryResponseDto>>
        {
            Data = response,
            Result = new Result(amorphie.core.Enums.Status.Success, "")
        };

    }
    private List<string> GetTemplateFromUiForms(IEnumerable<UiForm> uiForms)
    {
        return uiForms.Where(s => s.Forms != null).SelectMany(s => s.Forms!).Select(s => s.Label).ToList();
    }
    private List<string> GetTemplateFromPages(IEnumerable<Page> pages)
    {
        return pages.Where(s => s.Pages != null).SelectMany(s => s.Pages!).Select(s => s.Label).ToList();
    }
    private async Task<List<string>> GetTemplatesFromLegacyAsync(string workflowName, bool IsPage, CancellationToken cancellationToken)
    {

        var stateList = await GetWorkflowForTemplateLegacyAsync(workflowName, cancellationToken);
        List<string> templateList = new List<string>();
        if (stateList == null || !stateList.Any())
        {
            return templateList;
        }
        foreach (State state in stateList)
        {
            if (state.UiForms != null)
            {
                List<string> uiFormTemplates = GetTemplateFromUiForms(state.UiForms);

                if (state.AllowedSuffix != null && state.AllowedSuffix.Any())
                {
                    foreach (string suffix in state.AllowedSuffix)
                    {
                        string suffixWith = "-" + suffix;
                        uiFormTemplates.AddRange(uiFormTemplates.Select(s => s + suffixWith).ToList());
                    }
                }
                templateList.AddRange(uiFormTemplates);
            }
            if (state.Transitions != null && state.Transitions.Any())
            {
                var uiForms = state.Transitions.Where(s => s.UiForms != null)
                .SelectMany(s => s.UiForms!).Distinct().ToList();
                templateList.AddRange(GetTemplateFromUiForms(uiForms));
                var pages = state.Transitions.Where(s => s.Page != null)
                .Select(s => s.Page!).Distinct().ToList();
                templateList.AddRange(GetTemplateFromPages(pages));
            }
        }
        if (IsPage)
        {
            List<string> InstanceIdList = await _dbContext.Instances.Where(w => w.WorkflowName == workflowName).Select(s =>
            s.Id.ToString()).ToListAsync(cancellationToken);
            // string workflowNameFromPage = "\"workflowName\":\""+workflowName+"\"";
            templateList.AddRange(await _dbContext.SignalRResponses.Where(w => w.routeChange == true && !string.IsNullOrEmpty(w.data)
              && InstanceIdList.Any(a => a == w.InstanceId)
            && !string.IsNullOrEmpty(w.pageUrl))
            .Select(s => s.pageUrl ?? string.Empty).Distinct().ToListAsync(cancellationToken));
        }
        return templateList;
    }
    private async Task<List<State>?> GetWorkflowForTemplateLegacyAsync(string workflowName, CancellationToken cancellationToken)
    {
        return await _dbContext.States.Where(w => w.WorkflowName == workflowName).Include(s => s.UiForms).ThenInclude(s => s.Forms)
        .Include(s => s.Transitions).ThenInclude(s => s.UiForms).ThenInclude(s => s.Forms).ToListAsync(cancellationToken);
    }
    private async Task<Workflow?> GetWorkflowForLegacyAsync(string workflowName, CancellationToken cancellationToken)
    {
        return await _dbSet
             .Include(d => d.Titles)
             .Include(d => d.Entities)
             .Include(x => x.States).ThenInclude(s => s.Titles)
             .Include(x => x.States).ThenInclude(s => s.Transitions).ThenInclude(s => s.Forms)
             .Include(x => x.States).ThenInclude(s => s.Transitions).ThenInclude(s => s.Titles)
             .Include(x => x.States).ThenInclude(s => s.Transitions).ThenInclude(s => s.Flow)
             .Include(x => x.States).ThenInclude(s => s.Transitions).ThenInclude(s => s.UiForms).ThenInclude(s => s.Forms)
             .Include(x => x.States).ThenInclude(s => s.UiForms).ThenInclude(s => s.Forms)
             .Include(x => x.States).ThenInclude(s => s.PublicForms)
             .Include(x => x.States).ThenInclude(s => s.Transitions).ThenInclude(s => s.Page).ThenInclude(s => s!.Pages)
             .Include(s => s.States).ThenInclude(ss => ss.FromStates)
             .Where(w => w.Name == workflowName).FirstOrDefaultAsync(cancellationToken);
    }

    private State MapStateFromTrx(string workflowName, Transition trx)
    {
        return new State
        {
            Name = trx.Name,
            WorkflowName = workflowName,
            IsPublicForm = false,
            OnEntryFlow = trx.FromState.OnEntryFlow,
            OnExitFlow = trx.FromState.OnExitFlow,
            BaseStatus = trx.FromState.BaseStatus,
            Type = trx.FromState.Type,
            MFAType = trx.FromState.MFAType,

            Kind = StateKind.Transition,
            CreatedAt = trx.CreatedAt,
            CreatedBy = trx.CreatedBy,
            CreatedByBehalfOf = trx.CreatedByBehalfOf,
            ModifiedAt = trx.ModifiedAt,
            ModifiedBy = trx.ModifiedBy,
            ModifiedByBehalfOf = trx.ModifiedByBehalfOf,
            SubWorkflowName = trx.FromState.SubWorkflowName,
            InitPageName = trx.FromState.InitPageName,
            ServiceName = trx.ServiceName,
            TypeofUi = trx.TypeofUi,
            requireData = trx.requireData,
            transitionButtonType = trx.transitionButtonType,
            FlowName = trx.FlowName
        };
    }
    private StateCreateDto MapStateCreateDtoFromTrx(Transition trx)
    {
        var dto = new StateCreateDto
        {
            Name = trx.Name,
            IsPublicForm = false,
            BaseStatus = trx.FromState.BaseStatus,
            Type = trx.FromState.Type,
            MfaType = trx.FromState.MFAType,

            Kind = StateKind.Transition,

            SubWorkflowName = trx.FromState.SubWorkflowName,
            InitPageName = trx.FromState.InitPageName,
            Transition = new TransitionCreateDto
            {
                ServiceName = trx.ServiceName,
                TypeofUi = trx.TypeofUi,
                ButtonType = trx.transitionButtonType,
                Message = trx.FlowName,
                Gateway = trx.Flow?.Gateway
            }
        };
        //Trx's UiForms = State's Public forms
        if (trx.UiForms != null)
        {
            dto.UiForms = trx.UiForms.Select(x => new UiFormDto
            {
                typeofUi = x.TypeofUiEnum,
                navigationType = x.Navigation,
                forms = x.Forms?.Select(f => new amorphie.workflow.core.Dtos.MultilanguageText(f.Language, f.Label)).ToArray()
            }).ToList();
        }

        // dto.PublicForms = dto.Transition.Form;

        dto.Titles = trx.Titles.Select(p => new core.Dtos.MultilanguageText(p.Language, p.Label)).ToList();
        //State route can be list but it has only one item when converting from legacy

        var stateRoute = new StateRouteDto(trx.ToStateName!, true);
        dto.ToStates = new List<StateRouteDto>();
        dto.ToStates.Add(stateRoute);


        return dto;
    }
    private StateToState MapStateRouteFromTrx(Transition trx)
    {
        return new StateToState
        {
            Id = Guid.NewGuid(),
            FromStateName = trx.Name,
            ToStateName = trx.ToStateName,
            CreatedAt = trx.CreatedAt,
            CreatedBy = trx.CreatedBy,
            CreatedByBehalfOf = trx.CreatedByBehalfOf,
            ModifiedAt = trx.ModifiedAt,
            ModifiedBy = trx.ModifiedBy,
            ModifiedByBehalfOf = trx.ModifiedByBehalfOf,
            IsDefault = true

        };
    }
    private WorkflowCreateDto SetWorkflowCreateDtoBaseProps(Workflow workflow)
    {
        return new WorkflowCreateDto
        {
            Name = workflow.Name,
            Titles = workflow.Titles.Select(title => ManuelMultilanguageMapper.Map(title)).ToList(),
            Tags = workflow.Tags,
            SemVer = workflow.SemVer,
            RecordId = workflow.RecordId.HasValue ? workflow.RecordId.Value : Guid.Empty,
            Entities = workflow.Entities.Select(e => new WorkflowEntityDto
            {
                Name = e.Name,
                IsStateManager = e.IsStateManager,
                AvailableInStatus = e.AvailableInStatus,
            }).ToList()
        };
    }
}

