using System.Text.Json;

//TODO: Bu sayfada hem system.text.json hem de hewtonsoft var test et düzelt.
namespace amorphie.workflow.core.Helper;

public static class TemplateEngineHelper
{
    public static dynamic? TemplateEngineForm(string templateName, string entityData, string templateUrlFromVault, string? transitionName, int? json)
    {
        var jsonOptions = new System.Text.Json.JsonSerializerOptions { MaxDepth = 256 };
        var newtonSoftOpt = new Newtonsoft.Json.JsonSerializerSettings { MaxDepth = 256 };
        string form = string.Empty;
        var clientHttp = new HttpClient();
        var response = new HttpResponseMessage();
        string entityDataAfterHistory = entityData;
        if (!string.IsNullOrEmpty(transitionName))
        {
            var dynamicObject = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(entityData, newtonSoftOpt)!;
            dynamicObject.transitionNameHeader = transitionName;
            entityDataAfterHistory = Newtonsoft.Json.JsonConvert.SerializeObject(dynamicObject, newtonSoftOpt);
        }


        amorphie.workflow.core.Dtos.TemplateEngineRequest request = new amorphie.workflow.core.Dtos.TemplateEngineRequest()
        {
            RenderId = Guid.NewGuid(),
            Name = templateName,
            RenderData = entityDataAfterHistory,
            RenderDataForLog = entityDataAfterHistory,
            ProcessName = "Workflow Get Transition",
            ItemId = string.Empty,
            Action = "TemplateEngineForm",
            Identity = string.Empty,
            Customer = "",
            IsSchribanRender = false
        };
        var serializeRequest = JsonSerializer.Serialize(request, jsonOptions);
        try
        {

            response = clientHttp.PostAsync(templateUrlFromVault, new StringContent(serializeRequest, System.Text.Encoding.UTF8, "application/json")).Result;
            var twiceSerialize = response!.Content!.ReadAsStringAsync().Result;
            form = Newtonsoft.Json.JsonConvert.DeserializeObject<string>(twiceSerialize, newtonSoftOpt)!;
        }
        catch (Exception ex)
        {
            form = string.Empty;
        }
        if (string.IsNullOrEmpty(form))
            return new { };
        if (Enums.JsonEnum.Json.GetHashCode() == json)
            return System.Text.Json.JsonSerializer.Deserialize<dynamic>(form, jsonOptions);
        if (Enums.JsonEnum.Json.GetHashCode() != json)
            return form;
        return form;
    }
    public static string TemplateEngineFormWithoutJson(string templateName, string entityData, string templateUrlFromVault, string? transitionName)
    {
        var responseDynamic = TemplateEngineForm(templateName, entityData, templateUrlFromVault, transitionName, amorphie.workflow.core.Enums.JsonEnum.NotJson.GetHashCode());
        if (responseDynamic == null)
        {
            return string.Empty;
        }
        return Convert.ToString(responseDynamic);
    }
}
