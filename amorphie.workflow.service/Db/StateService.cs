using amorphie.core.Base;
using amorphie.workflow.core.Dtos;
using amorphie.workflow.core.Dtos.Definition;
using amorphie.workflow.core.Dtos.DefinitionLegacy;
using amorphie.workflow.core.Enums;
using amorphie.workflow.core.Mapper;
using amorphie.workflow.core.Models;
using amorphie.workflow.service.Db.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace amorphie.workflow.service.Db;
public partial class StateService : IStateService
{
    private readonly WorkflowDBContext _dbContext;
    private readonly DbSet<State> _dbSet;
    private readonly VersionService _versionService;

    public StateService(WorkflowDBContext dbContext, VersionService versionService)
    {
        _versionService = versionService;
        _dbContext = dbContext;
        _dbSet = dbContext.Set<State>();
    }

    public async Task<Response> SaveBulkAsync(List<StateCreateDto> states, string workflowName, CancellationToken token)
    {
        //First Save States
        foreach (var item in states)
        {
            var stateSaveResponse = await SaveAsync(item, workflowName, token);
        }

        //Than save state routes
        foreach (var item in states)
        {
            var routesToBeSaved = new StateRoutesDto(item.Name, item.ToStates);
            var stateRoutesSaveResponse = await SaveStateRoutesAsync(routesToBeSaved);
        }
        return Response.Success("");
    }


    public async Task<Response> SaveAsync(StateCreateDto data, string workflowName, CancellationToken token)
    {
        var existingRecord = await _dbSet
            .Include(s => s.Titles)
            .Include(s => s.Transitions)
            .Include(s => s.PublicForms)
            .Include(s => s.UiForms)
            .ThenInclude(s => s.Forms)
            .FirstOrDefaultAsync(w => w.WorkflowName == workflowName && w.Name == data.Name)
           ;
        Workflow? workflow = await _dbContext.Workflows.FirstOrDefaultAsync(f => f.Name == workflowName);
        bool minor = true;
        if (existingRecord == null)
        {
            minor = false;
            await Insert(data, workflowName);
        }
        else
        {
            Update(data, existingRecord);
        }
        if (await _dbContext!.SaveChangesAsync() > 0)
        {
            if (string.IsNullOrEmpty(workflow!.SemVer))
            {
                workflow.SemVer = new Semver.SemVersion(1, 0, 0).ToString();
            }
            Semver.SemVersion version = Semver.SemVersion.Parse(workflow!.SemVer, Semver.SemVersionStyles.Any);
            if (minor)
            {

                version = version.WithMinor(version.Minor + 1);
                workflow!.SemVer = version.ToString();
                await _dbContext!.SaveChangesAsync();
                await _versionService.SaveVersionWorkflow(workflow!.Name, version.ToString(), token);
            }
            return Response.Success("");
        }
        else
        {
            return Response.Success("Not Modified");
        }

    }
    public async Task<Response> SaveStateRoutesAsync(StateRoutesDto data)
    {
        var existingRecord = await _dbSet
            .FirstOrDefaultAsync(s => s.Name == data.Name);
        if (existingRecord == null)
        {
            return Response.Error($"{data.Name} state is not defined");
        }
        else
        {

            var toStates = data.ToStates.Select(p => p.ToStateName);
            _dbContext.StateToStates.Where(p => toStates.Contains(p.ToStateName) && p.FromStateName == data.Name).ExecuteDelete();

            foreach (var toState in data.ToStates)
            {
                var stateToStates = new StateToState
                {
                    CreatedAt = DateTime.UtcNow,
                    CreatedByBehalfOf = Guid.NewGuid(),
                    FromStateName = existingRecord.Name,
                    ToStateName = toState.ToStateName, //StateName
                    IsDefault = toState.IsDefault ?? false
                };
                _dbContext.StateToStates.Add(stateToStates);
            }
            await _dbContext.SaveChangesAsync();
            return Response.Success($"{data.Name} state. Inserted or updated state routes :  {String.Join(", ", toStates)}.");
        }

    }

    public async Task<Response<State>> GetAsync(string workflowName, string stateName)
    {
        var states = await _dbSet
            .Include(s => s.FromStates)
            .Where(w => w.WorkflowName == workflowName && w.Name == stateName)
            .FirstOrDefaultAsync();

        if (states == null)
        {
            return new Response<State>
            {
                Result = new Result(amorphie.core.Enums.Status.Error, "Not found")
            };
        }
        else
        {
            return new Response<State>
            {
                Data = states,
                Result = new Result(amorphie.core.Enums.Status.Success, "")
            };
        }

    }

    public async Task<Response<List<StateCreateDto>>> GetAllAsync(string workflowName)
    {
        var states = await _dbContext.States
            .Include(s => s.FromStates)
            .Where(w => w.WorkflowName == workflowName)
            .ToListAsync();

        var statesResult = StateMapper.Map(states);

        if (statesResult == null || !statesResult.Any())
        {
            return new Response<List<StateCreateDto>>
            {
                Result = new Result(amorphie.core.Enums.Status.Error, "Not found")
            };
        }
        else
        {
            return new Response<List<StateCreateDto>>
            {
                Data = statesResult,
                Result = new Result(amorphie.core.Enums.Status.Success, "")
            };
        }

    }


    private async Task Insert(StateCreateDto data, string workflowName)
    {
        var newRecord = StateMapper.MapStateFromStateCreateDto(data);
        newRecord.WorkflowName = workflowName;
        await _dbContext!.States!.AddAsync(newRecord);

    }
    private void Update(StateCreateDto data, State existingRecord)
    {
        if (existingRecord.BaseStatus != data.BaseStatus || existingRecord.Type != data.Type)
        {
            existingRecord.BaseStatus = data.BaseStatus;
            existingRecord.Type = data.Type;
        }
        if (!string.IsNullOrEmpty(data.SubWorkflowName) &&
        data.Type == StateType.SubWorkflow &&
        existingRecord.SubWorkflowName != data.SubWorkflowName)
        {
            existingRecord.SubWorkflowName = data.SubWorkflowName;
        }
        if (!string.IsNullOrEmpty(data.InitPageName) &&
        data.Type == StateType.Start &&
        existingRecord.InitPageName != data.InitPageName)
        {
            existingRecord.InitPageName = data.InitPageName;
        }
        if (data.Titles != null)
        {
            SaveTitle(existingRecord, data.Titles);
        }
        if (data.MfaType != null && data.MfaType != existingRecord.MFAType)
        {
            existingRecord.MFAType = data.MfaType;
        }
        if (data.UiForms != null)
        {
            SaveUiForm(existingRecord, data.UiForms);
        }
        if (data.IsPublicForm == true && data.PublicForms != null)
        {
            SavePublicForm(existingRecord, data.PublicForms);
        }
        if (data.Transition != null)
        {
            existingRecord.Kind = StateKind.Transition;
            existingRecord.TypeofUi = data.Transition.TypeofUi;
            existingRecord.transitionButtonType = data.Transition.ButtonType;
            existingRecord.ServiceName = data.Transition.ServiceName;
            UpdatePage(existingRecord, data.Transition);
        }
        else
        {
            existingRecord.Kind = StateKind.State;
        }

    }

    private void SaveTitle(State state, List<core.Dtos.MultilanguageText>? titles)
    {
        if (titles == null)
        {
            return;
        }
        foreach (var languageForm in titles)
        {
            Translation? translation = state.Titles?.FirstOrDefault(f => f.Language == languageForm.language);
            if (translation != null && translation.Label != languageForm.label)
            {
                translation.Label = languageForm.label;
            }
            else if (translation == null)
            {
                var newTranslation = InsertTranslation(state.Titles, languageForm);
            }
        }
    }

    private void SaveTitle(Transition trx, List<core.Dtos.MultilanguageText>? titles)
    {
        if (titles == null)
        {
            return;
        }
        foreach (var languageForm in titles)
        {
            Translation? translation = trx.Titles?.FirstOrDefault(f => f.Language == languageForm.language);
            if (translation != null && translation.Label != languageForm.label)
            {
                translation.Label = languageForm.label;
            }
            else if (translation == null)
            {
                var newTranslation = InsertTranslation(trx.Titles, languageForm);
            }
        }
    }

    private void SavePublicForm(State state, List<core.Dtos.MultilanguageText> publicForms)
    {
        foreach (var languageForm in publicForms)
        {
            Translation? translation = state.PublicForms?.FirstOrDefault(f => f.Language == languageForm.language);
            if (translation != null && translation.Label != languageForm.label)
            {
                translation.Label = languageForm.label;
            }
            else if (translation == null)
            {
                var newTranslation = InsertTranslation(state.PublicForms, languageForm);
            }
        }
    }
    private void SaveForm(Transition transition, ICollection<core.Dtos.MultilanguageText> forms)
    {
        foreach (var languageForm in forms)
        {
            Translation? translation = transition.Forms?.FirstOrDefault(f => f.Language == languageForm.language);
            if (translation != null && translation.Label != languageForm.label)
            {
                translation.Label = languageForm.label;
            }
            else if (translation == null)
            {
                var newTranslation = InsertTranslation(transition.Forms, languageForm);
            }
        }
    }
    private void SaveZeebeMessage(Transition transition, TransitionCreateDtoLegacy trxDto, string workflowName)
    {
        if (trxDto.Message == null || _dbContext.ZeebeMessages.Local.Any(e => e.Name == trxDto.Message))
        {
            return;
        }

        ZeebeMessage? zeebeMessage = _dbContext.ZeebeMessages!.FirstOrDefault(f => f.Name == trxDto.Message);
        if (zeebeMessage == null)
        {

            ZeebeMessage flow = new ZeebeMessage()
            {
                Name = trxDto.Message!,
                Gateway = trxDto.Gateway!,
                CreatedAt = DateTime.UtcNow,
                Message = trxDto.Message!,
                Process = workflowName,
            };
            _dbContext.ZeebeMessages.Add(flow);
            transition.FlowName = flow.Name;
            transition.Flow = flow;
        }
        if (zeebeMessage != null)
        {
            transition.Flow = zeebeMessage;
            transition.FlowName = zeebeMessage.Name;
        }
    }

    private void SaveUiForm(State state, List<UiFormDto>? uiFormDto)
    {
        if (uiFormDto == null)
        {
            return;
        }
        foreach (var languageForm in uiFormDto)
        {
            UiForm? uiForm = state.UiForms?.FirstOrDefault(f => languageForm.typeofUi == f.TypeofUiEnum);
            if (uiForm == null)
            {
                uiForm = UiFormMapper.Map(languageForm);
                uiForm.StateName = state.Name;
                _dbContext.UiForms.Add(uiForm);
            }
            else
            {
                if (languageForm.forms != null && languageForm.forms.Any())
                {
                    foreach (var languagePF in languageForm.forms)
                    {
                        Translation? translation = uiForm.Forms?.FirstOrDefault(f => f.Language == languagePF.language);
                        if (translation?.Label != languagePF.label)
                        {
                            translation.Label = languagePF.label;
                        }
                        if (translation == null)
                        {
                            var newTranslation = InsertTranslation(uiForm.Forms, languagePF);
                        }
                    }
                }
                if (uiForm.Navigation != languageForm.navigationType)
                {
                    uiForm.Navigation = languageForm.navigationType;
                }
            }
        }
    }

    private void SaveUiForm(Transition transition, List<UiFormDto>? uiFormDto)
    {
        if (uiFormDto == null)
        {
            return;
        }
        foreach (var languageForm in uiFormDto)
        {
            UiForm? uiForm = transition.UiForms?.FirstOrDefault(f => languageForm.typeofUi == f.TypeofUiEnum);
            if (uiForm == null)
            {
                uiForm = UiFormMapper.Map(languageForm);
                uiForm.StateName = transition.Name;
                _dbContext.UiForms.Add(uiForm);
            }
            else
            {
                if (languageForm.forms != null && languageForm.forms.Any())
                {
                    SaveForm(transition, languageForm.forms);
                }
                if (uiForm.Navigation != languageForm.navigationType)
                {
                    uiForm.Navigation = languageForm.navigationType;
                }
            }
        }
    }

    private void UpdatePage(State existingRecord, TransitionCreateDto transition)
    {
        if (transition.Page == null)
        {
            return;
        }
        Page? page = existingRecord.Page;
        if (page != null)
        {
            existingRecord.Page!.Operation = transition.Page.Operation;
            existingRecord.Page!.Type = transition.Page.Type;
            existingRecord.Page!.Timeout = transition.Page.Timeout;
            Translation? translation = existingRecord.Page!.Pages!.FirstOrDefault();
            if (translation != null && transition.Page.PageRoute != null && translation.Label != transition.Page.PageRoute.label)
            {
                translation.Label = transition.Page.PageRoute.label;
            }

            else if ((translation == null && transition.Page.PageRoute != null) ||
            (translation != null && transition.Page.PageRoute == null))
            {
                Page pageNew = new Page()
                {
                    Id = Guid.NewGuid(),
                    Operation = transition.Page!.Operation,
                    Type = transition.Page!.Type,
                    Pages = transition.Page.PageRoute == null ? null : new List<Translation>(){
                            new Translation{
                             Language=transition.Page.PageRoute.language,
                             Label=transition.Page.PageRoute.label
                            }

                        },
                    Timeout = transition.Page!.Timeout
                };
                _dbContext.Pages.Add(pageNew);
                existingRecord.Page = pageNew;
                existingRecord.PageId = pageNew.Id;
            }
        }
        else
        {
            Page pageNew = new Page()
            {
                Id = Guid.NewGuid(),
                Operation = transition.Page!.Operation,
                Type = transition.Page!.Type,
                Pages = transition.Page.PageRoute == null ? null : new List<Translation>(){
                            new Translation{
                             Language=transition.Page.PageRoute.language,
                             Label=transition.Page.PageRoute.label
                            }
                        },
                Timeout = transition.Page!.Timeout
            };
            _dbContext.Pages.Add(pageNew);
            existingRecord.Page = pageNew;
            existingRecord.PageId = pageNew.Id;
        }
    }

    private void UpdatePage(Transition existingRecord, TransitionCreateDtoLegacy trxDto)
    {
        if (trxDto.Page == null)
        {
            return;
        }
        Page? page = existingRecord.Page;
        if (page != null)
        {
            existingRecord.Page!.Operation = trxDto.Page.Operation;
            existingRecord.Page!.Type = trxDto.Page.Type;
            existingRecord.Page!.Timeout = trxDto.Page.Timeout;
            Translation? translation = existingRecord.Page!.Pages!.FirstOrDefault();
            if (translation != null && trxDto.Page.PageRoute != null && translation.Label != trxDto.Page.PageRoute.label)
            {
                translation.Label = trxDto.Page.PageRoute.label;
            }

            else if ((translation == null && trxDto.Page.PageRoute != null) ||
            (translation != null && trxDto.Page.PageRoute == null))
            {
                Page pageNew = new Page()
                {
                    Id = Guid.NewGuid(),
                    Operation = trxDto.Page!.Operation,
                    Type = trxDto.Page!.Type,
                    Pages = trxDto.Page.PageRoute == null ? null : new List<Translation>(){
                            new Translation{
                             Language=trxDto.Page.PageRoute.language,
                             Label=trxDto.Page.PageRoute.label
                            }

                        },
                    Timeout = trxDto.Page!.Timeout
                };
                _dbContext.Pages.Add(pageNew);
                existingRecord.Page = pageNew;
                existingRecord.PageId = pageNew.Id;
            }
        }
        else
        {
            Page pageNew = new Page()
            {
                Id = Guid.NewGuid(),
                Operation = trxDto.Page!.Operation,
                Type = trxDto.Page!.Type,
                Pages = trxDto.Page.PageRoute == null ? null : new List<Translation>(){
                            new Translation{
                             Language=trxDto.Page.PageRoute.language,
                             Label=trxDto.Page.PageRoute.label
                            }
                        },
                Timeout = trxDto.Page!.Timeout
            };
            _dbContext.Pages.Add(pageNew);
            existingRecord.Page = pageNew;
            existingRecord.PageId = pageNew.Id;
        }
    }
    private Translation InsertTranslation(ICollection<Translation>? translations, core.Dtos.MultilanguageText language)
    {
        var newTranslation = ManuelMultilanguageMapper.Map(language);
        _dbContext.Set<Translation>().Add(newTranslation);

        if (translations == null)
        {
            translations = new List<Translation>();
        }
        translations.Add(newTranslation);

        return newTranslation;
    }
}
