using amorphie.workflow.core.Dtos;
using amorphie.workflow.core.Enums;
using Dapr.Client;
using Serilog;

namespace amorphie.workflow.service.SignalR;
public class SignalRService
{
    public static async Task SendSignalRDataAsync(Instance instance, WorkerBodyTrxInnerDatas request, string eventInfo, string message, string hubUrl, DaprClient client, WorkerBodyHeaders headerParameters, string viewsource)
    {
        var targetState = instance.State;
        var mfaType = targetState.MFAType.GetValueOrDefault(MFATypeEnum.Public).ToString().ToLower();
        try
        {
            var responseSignalRMFAtype = client.CreateInvokeMethodRequest<SignalRRequest>(
                      HttpMethod.Post,
                      hubUrl,
                      "sendMessage/" + mfaType,
                      CreateSignalRRequest(instance, request, eventInfo, message, viewsource)
                          );
            responseSignalRMFAtype.Headers.Add("X-Device-Id", headerParameters.XDeviceId);
            responseSignalRMFAtype.Headers.Add("X-Token-Id", headerParameters.XTokenId);
            responseSignalRMFAtype.Headers.Add("A-Customer", headerParameters.ACustomer);
            var generarlSignalR = await client.InvokeMethodAsync<string>(responseSignalRMFAtype);

        }
        catch (Exception ex)
        {
            Log.Fatal($"Error while sending siganlr request: {ex}");
        }

    }
    //TODO:transitiona bağlı bir sürü bilgi var nereden alacağız???
    //???
    public static async Task SendSignalRDataAsync(Instance instance, WorkerBodyTrxInnerDatas request, string eventInfo, string message, string hubUrl, DaprClient client, Dictionary<string, string> headerParameters)
    {
        var targetState = instance.State;
        var mfaType = targetState.MFAType.GetValueOrDefault(MFATypeEnum.Public).ToString().ToLower();
        try
        {
            var responseSignalRMFAtype = client.CreateInvokeMethodRequest<SignalRRequest>(
                      HttpMethod.Post,
                      hubUrl,
                      "sendMessage/" + mfaType,
                      CreateSignalRRequest(instance, request, eventInfo, message, "transition")
                          );

            if (headerParameters.TryGetValue("xdeviceid", out string deviceID))
                responseSignalRMFAtype.Headers.Add("X-Device-Id", deviceID);
            if (headerParameters.TryGetValue("xtokenid", out string tokenID))
                responseSignalRMFAtype.Headers.Add("X-Token-Id", tokenID);
            if (headerParameters.TryGetValue("acustomer", out string customer))
                responseSignalRMFAtype.Headers.Add("A-Customer", customer);
            var generarlSignalR = await client.InvokeMethodAsync<string>(responseSignalRMFAtype);
        }
        catch (Exception ex)
        {
            Log.Fatal($"InstanceId {instance.Id}. Error while sending signalr request: {ex}");
        }

    }
    private static SignalRRequest CreateSignalRRequest(Instance instance, WorkerBodyTrxInnerDatas request, string eventInfo, string message, string viewsource)
    {
        var targetState = instance.State;
        string pageTypeStringBYTransition = string.Empty;
        if (targetState.Page != null)
        {

            try
            {

                pageTypeStringBYTransition = amorphie.workflow.core.Helper.EnumHelper.GetDescription<NavigationType>(((NavigationType)targetState.Page.Type));
            }
            catch (Exception)
            {
                pageTypeStringBYTransition = string.Empty;
            }
        }

        bool routeChange = false;
        if (eventInfo == "worker-started" || targetState.Page == null)
        {
            routeChange = false;
        }
        else if (targetState.Page != null && targetState.Page.Pages != null && targetState.Page.Pages.Count > 0)
        {
            routeChange = true;
        }

        return new SignalRRequest()
        {
            data = new PostSignalRData(
                UserId: instance.ModifiedBy,
                recordId: instance.RecordId,
                eventInfo: eventInfo,
                instanceId: instance.Id,
                entityName: instance.EntityName,
                data: request.EntityData,
                DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc),
                state: instance.StateName,
                transition: instance.State.Name,
                stateTransitions: null,
                baseStatus: instance.BaseStatus,
                page: CreatePostPage(targetState, eventInfo, pageTypeStringBYTransition),
                message: message,
                errorCode: string.Empty,
                additionalData: request.AdditionalData,
                workflowName: instance.WorkflowName,
                viewSource: targetState.IsPublicForm == true ? "state" : viewsource,
                requireData: targetState.requireData.GetValueOrDefault(false),
                buttonType: targetState.transitionButtonType == 0 ? TransitionButtonType.Forward.ToString() : targetState.transitionButtonType.GetValueOrDefault(TransitionButtonType.Forward).ToString()

                      ),
            source = "workflow",
            type = "workflow",
            subject = eventInfo,
            id = instance.Id.ToString(),
            routeChange = routeChange
        };
    }
    private static PostPageSignalRData? CreatePostPage(State targetState, string eventInfo, string pageTypeStringBYTransition)
    {
        if (targetState.Page == null)
            return null;
        if (eventInfo == "worker-started")
            return null;

        return new PostPageSignalRData(
                            targetState.Page.Operation.ToString(),
                            pageTypeStringBYTransition,
                            targetState.Page.Pages == null || targetState.Page.Pages.Count == 0 ? null : new MultilanguageText(targetState.Page.Pages!.FirstOrDefault()!.Language, targetState.Page.Pages!.FirstOrDefault()!.Label),
                        targetState.Page.Timeout
                        );
    }
}

