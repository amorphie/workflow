
using System.Text.Json.Nodes;
using amorphie.core.Enums;
using amorphie.workflow.core.Dtos;
using amorphie.workflow.core.Enums;
using amorphie.workflow.core.Helper;
using amorphie.workflow.service.Db.Abstracts;
using amorphie.workflow.service.SignalR;
using amorphie.workflow.service.Variable;
using Dapr.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

public static class SimpleStateManagerModule
{

    public static void MapSimpleStateManagerManagerEndpoints(this WebApplication app)
    {
        app.MapPost("/amorphie-workflow-simplestate", SimpleState)
            .Produces(StatusCodes.Status200OK)
            .WithOpenApi(operation =>
            {
                operation.Summary = "Maps amorphie-workflow-simplestate service worker on Zeebe";
                operation.Tags = new List<OpenApiTag> { new() { Name = "Zeebe" } };
                return operation;
            });
    }

    static async ValueTask<IResult> SimpleState(
            [FromBody] JsonObject jsonBody,
            [FromServices] IInstanceService instanceService,
            HttpRequest request,
             IConfiguration configuration,
            [FromServices] DaprClient daprClient,
            CancellationToken cancellationToken
        )
    {
        WorkerBody body = JsonObjectConverter.JsonToWorkerBody(jsonBody);
        var targetState = request.Headers["TARGET_STATE"].ToString();
        string pageUrl = request.Headers["PAGE_URL"].ToString();
        if (string.IsNullOrEmpty(pageUrl))
            pageUrl = body.PageUrl;
        string pageOperationTypeString = request.Headers["PAGE_OPERATION_TYPE"].ToString();
        string pageTypeString = request.Headers["PAGE_TYPE"].ToString();
        string viewSource = request.Headers["VIEW_SOURCE"].ToString();
        string timeoutString = request.Headers["PAGE_TIMEOUT"].ToString();
        int timeout = 0;

        string pageLanguage = request.Headers["PAGE_LANGUAGE"].ToString();
        if (!string.IsNullOrEmpty(pageUrl) && string.IsNullOrEmpty(pageOperationTypeString))
        {
            pageOperationTypeString = PageOperationType.Open.ToString();
        }
        if (!string.IsNullOrEmpty(pageUrl) && string.IsNullOrEmpty(pageTypeString))
        {
            pageTypeString = EnumHelper.GetDescription<NavigationType>(NavigationType.PushReplacement);
        }
        if (!string.IsNullOrEmpty(pageUrl) && !string.IsNullOrEmpty(timeoutString))
        {
            try
            {
                timeout = Convert.ToInt32(timeoutString);
            }
            catch (Exception)
            {
                timeout = 0;
            }
        }
        Boolean.TryParse(request.Headers["NOTIFY_CLIENT"].ToString(), out bool notifyClient);
        if (!string.IsNullOrEmpty(pageUrl) && string.IsNullOrEmpty(pageLanguage))
        {
            pageLanguage = "en-EN";
        }

        if (!string.IsNullOrEmpty(viewSource))
        {
            if (viewSource.ToLower() != amorphie.workflow.core.Helper.EnumHelper.GetDescription<ViewSourceEnum>((ViewSourceEnum)ViewSourceEnum.State)
            && viewSource.ToLower() != amorphie.workflow.core.Helper.EnumHelper.GetDescription<ViewSourceEnum>(((ViewSourceEnum)ViewSourceEnum.Transition))
            && viewSource.ToLower() != amorphie.workflow.core.Helper.EnumHelper.GetDescription<ViewSourceEnum>(((ViewSourceEnum)ViewSourceEnum.Page))
            )
            {
                viewSource = string.Empty;
            }
        }


        var data = body.WorkerBodyTrxDataList!.GetValueOrDefault($"TRX{body.LastTransition.DeleteUnAllowedCharecters()}");
        //Data is null for -got-first-
        if (data == null)
        {
            data = body.WorkerBodyTrxDataList!.FirstOrDefault().Value;
        }
        var response = await instanceService.ChangeInstanceState(body.InstanceId, targetState, data.Data, data.TriggeredBy, data.TriggeredByBehalfOf, cancellationToken);
        if (response.Result.Status != "Success")
        {
            return Results.Problem(response.Result.Message);
        }
        var instance = response.Data as Instance;
        if (notifyClient)
        {
            string hubUrl = configuration["hubUrl"]!.ToString();

            await SignalRService.SendSignalRDataAsync(instance, data.Data, "worker-completed", body.Message ?? "", hubUrl, daprClient, body.Headers);
        }

        dynamic variables = VariableService.CreateMessageVariables(instance, data);
        return Results.Ok(variables);
    }


}
