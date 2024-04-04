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

    public async Task<Response<WorkflowCreateDto>> GetDefinitionBulkAsync(string workflowName,  CancellationToken cancellationToken)
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
        if (workflow.States.SelectMany(p => p.FromStates).Count() > 0)
        {
            workflowDto.NewStates = StateMapper.Map(workflow.States);
        }
        else
        {
            workflowDto.States = StateMapperLegacy.Map(workflow.States);
        }
        workflowDto.Hash = Md5.Generate(workflowDto);
        return new Response<WorkflowCreateDto>
        {
            Data = workflowDto,
            Result = new Result(amorphie.core.Enums.Status.Success, "")
        };
    }

    public async Task<Response<WorkflowCreateDto>> GetDefinitionFromLegacyToNewBulkAsync(string workflowName, CancellationToken cancellationToken)
    {
        var workflow = await GetWorkflowForLegacyAsync(workflowName, cancellationToken);

        if (workflow == null)
        {
            return new Response<WorkflowCreateDto>
            {
                Result = new Result(amorphie.core.Enums.Status.Error, "Workflow Not found")
            };
        }
        var stateNames = workflow.States.Select(s => s.Name).ToList();

        //Add transition as state
        var transitionFromState = await _dbContext.Transitions
        .Include(p => p.FromState)
        .Include(p => p.Titles)
        .Include(p => p.Forms)
        .Include(p => p.Flow)

        .Where(p => stateNames.Contains(p.FromStateName) || stateNames.Contains(p.ToStateName)).ToListAsync();
        List<StateCreateDto> statesList = new List<StateCreateDto>();
        if (transitionFromState.Any())
        {
            foreach (var trx in transitionFromState)
            {
                //Trx -> To State
                var newState = MapStateCreateDtoFromTrx(trx);
                //From State -> To Trx
                if (trx.Name != trx.FromStateName)
                {

                    var fromState = statesList.FirstOrDefault(p => p.Name == trx.FromStateName);
                    if (fromState == null)
                    {
                        fromState = StateMapper.Map(trx.FromState);

                        statesList.Add(fromState);
                    }
                    var isDefault = fromState.ToStates.Count == 0;
                    var stateRouteForFrom = new StateRouteDto(trx.Name!, isDefault);
                    fromState.ToStates.Add(stateRouteForFrom);


                }
                statesList.Add(newState);
            }
        }

        var workflowDto = new WorkflowCreateDto
        {

            Name = workflow.Name,
            NewStates = statesList
        };

        return new Response<WorkflowCreateDto>
        {
            Data = workflowDto,
            Result = new Result(amorphie.core.Enums.Status.Success, "")
        };
    }

    public async Task<Response<TransferResultDto>> SaveTransferRequestAsync(WorkflowCreateDto workflowDto, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(workflowDto.Hash))
        {
            return new Response<TransferResultDto>
            {
                Result = new Result(amorphie.core.Enums.Status.Error, "Hash must be provided")
            };
        }
        var transferHistroy = new TransferHistory
        {
            Hash = workflowDto.Hash,
            RequestBody = JsonSerializer.Serialize(workflowDto),
            SubjectName = workflowDto.Name,
            TransferStatus = TransferStatus.WaitingForApproval,
            TransferringType = nameof(Workflow)
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
            if (!Md5.Check(workflowDto))
            {
                return Response.Error("Request body must not be modified before save");
            }
            var saveResponse = await _workflowService.SaveAsync(workflowDto!);
            transferHistroy.TransferStatus = TransferStatus.Approved;
        }
        else
        {
            transferHistroy.TransferStatus = TransferStatus.Cancelled;
        }
        await _dbContext!.SaveChangesAsync();
        return Response.Success("");
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

