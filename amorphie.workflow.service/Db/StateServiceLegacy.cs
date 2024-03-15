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
public partial class StateService
{

    public async Task<Response> LegacySaveBulkAsync(WorkflowCreateDtoLegacy data)
    {
        //First Save States
        foreach (var item in data.States)
        {
            var stateSaveResponse = await LegacySaveAsync(item, data.Name);
        }

        //Than trxs
        var trxToBeSaved = data.States.Where(p => p.Transitions != null).SelectMany(p => p.Transitions!);
        if (trxToBeSaved != null)
        {
            foreach (var trxDto in trxToBeSaved)
            {
                await LegacyInsertOrUpdateTrxAsync(trxDto, data.Name);
            }
            await _dbContext.SaveChangesAsync();
        }
        return Response.Success("");
    }


    public async Task<Response> LegacySaveAsync(StateCreateDtoLegacy data, string workflowName)
    {
        var existingRecord = await _dbSet
            .Include(s => s.Titles)
            .Include(s => s.Transitions)
            .Include(s => s.PublicForms)

            .Include(s => s.UiForms)
            .ThenInclude(s => s.Forms)
            .FirstOrDefaultAsync(w => w.WorkflowName == workflowName && w.Name == data.Name)
           ;
        if (existingRecord == null)
        {
            LegacyInsert(data, workflowName);
        }
        else
        {
            LegacyUpdate(data, existingRecord);
        }
        // await _dbContext!.SaveChangesAsync();
        if (await _dbContext!.SaveChangesAsync() > 0)
        {
            return Response.Success("");
        }
        else
        {
            return Response.Success("Not Modified");
        }

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
        existingRecord.Kind = StateKind.SimpleState;
    }

    private async Task LegacyInsertOrUpdateTrxAsync(TransitionCreateDtoLegacy trxDto, string workFlowName)
    {
        Transition? trx = await _dbContext.Transitions.Include(s => s.Titles).Include(s => s.Forms).Include(s => s.Flow)
        .Include(s => s.Page).ThenInclude(t => t.Pages)
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

