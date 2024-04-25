using amorphie.core.Base;
using amorphie.workflow.core.Dtos.Definition;
using amorphie.workflow.core.Dtos.DefinitionLegacy;
using amorphie.workflow.core.Enums;
using amorphie.workflow.core.Mapper;
using Microsoft.EntityFrameworkCore;

namespace amorphie.workflow.service.Db;
public partial class StateService
{
    public async Task<Response> LegacySaveBulkAsync(WorkflowCreateDto workflowDto)
    {
        //First Save States
        foreach (var stateDto in workflowDto.States)
        {
            var existingRecord = await _dbSet
            .Include(s => s.Titles)
            .Include(s => s.Transitions)
            .Include(s => s.PublicForms)
            .Include(s => s.UiForms)
            .ThenInclude(s => s.Forms)
            .FirstOrDefaultAsync(w => w.WorkflowName == workflowDto.Name && w.Name == stateDto.Name);
            if (existingRecord == null)
            {
                LegacyInsert(stateDto, workflowDto.Name);
            }
            else
            {
                LegacyUpdate(stateDto, existingRecord);
            }
        }

        //Than trxs
        var trxToBeSaved = workflowDto.States.Where(p => p.Transitions != null).SelectMany(p => p.Transitions!);
        if (trxToBeSaved != null)
        {
            foreach (var trxDto in trxToBeSaved)
            {
                await LegacyInsertOrUpdateTrxAsync(trxDto, workflowDto.Name);
            }
        }
        await _dbContext!.SaveChangesAsync();
        return Response.Success("");
    }




    private void LegacyInsert(StateCreateDtoLegacy data, string workflowName)
    {
        var newRecord = StateMapperLegacy.Map(data);
        newRecord.WorkflowName = workflowName;
        _dbContext!.States!.Add(newRecord);


    }
    private void LegacyUpdate(StateCreateDtoLegacy data, State existingRecord)
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
        existingRecord.Kind = StateKind.State;
    }

    private async Task LegacyInsertOrUpdateTrxAsync(TransitionCreateDtoLegacy trxDto, string workFlowName)
    {
        Transition? trx = await _dbContext.Transitions.Include(s => s.Titles).Include(s => s.Forms).Include(s => s.Flow)
        .Include(s => s.Page).ThenInclude(t => t.Pages)
        .Include(tu => tu.UiForms).ThenInclude(tuf => tuf.Forms)
        .FirstOrDefaultAsync(db => db.Name == trxDto.Name);
        if (trx == null)
        {
            trx = new Transition
            {
                Name = trxDto.Name,
                ToStateName = trxDto.ToState,
                FlowName = trxDto.Message,
                ServiceName = trxDto.ServiceName,
                TypeofUi = trxDto.TypeofUi,
                FromStateName = trxDto.FromState,
                CreatedAt = DateTime.UtcNow,
                CreatedByBehalfOf = Guid.NewGuid(),
            };
            _dbContext.Transitions.Add(trx);
        }
        else
        {
            trx.ToStateName = trxDto.ToState;
            trx.FlowName = trxDto.Message;
            trx.ServiceName = trxDto.ServiceName;
            trx.TypeofUi = trxDto.TypeofUi;
            trx.FromStateName = trxDto.FromState;
        }
        SaveTitle(trx, trxDto.Titles);

        SaveForm(trx, trxDto.Forms);
        SaveUiForm(trx, trxDto.UiForms);
        SaveZeebeMessage(trx, trxDto, workFlowName);
        UpdatePage(trx, trxDto);


    }
}

