using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace amorphie.workflow.core.Helper
{
    public static class TemplateEngineHelper
    {
        public static dynamic? TemplateEngineForm(string templateName, string entityData, string templateUrlFromVault, string? transitionName, int? json)
        {
            string form = string.Empty;
            var clientHttp = new HttpClient();
            var response = new HttpResponseMessage();
            string entityDataAfterHistory = entityData;
            if (!string.IsNullOrEmpty(transitionName))
            {
                var dynamicObject = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(entityData)!;
                dynamicObject.transitionNameHeader = transitionName;
                entityDataAfterHistory = Newtonsoft.Json.JsonConvert.SerializeObject(dynamicObject);
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
                Customer = ""
            };
            var serializeRequest = JsonSerializer.Serialize(request);
            try
            {

                response = clientHttp.PostAsync(templateUrlFromVault, new StringContent(serializeRequest, System.Text.Encoding.UTF8, "application/json")).Result;
                var twiceSerialize = response!.Content!.ReadAsStringAsync().Result;
                form = Newtonsoft.Json.JsonConvert.DeserializeObject<string>(twiceSerialize)!;
            }
            catch (Exception ex)
            {
                form = string.Empty;
            }
            if (string.IsNullOrEmpty(form))
                return new { };
            if (Enums.JsonEnum.Json.GetHashCode() == json)
                return System.Text.Json.JsonSerializer.Deserialize<dynamic>(form);
            else return form;
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
}