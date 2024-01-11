using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using amorphie.workflow.service.Zeebe;
using Microsoft.AspNetCore.Http;

namespace amorphie.workflow.service.SchemaValidation;
public class SchemaValdationMiddleware
{
    private readonly RequestDelegate _next;

    public SchemaValdationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext, IHttpClientFactory httpClientFactory)
    {
        if (httpContext.Request.Method == HttpMethods.Post)
        {
            var bpmnProcessId = httpContext.Request.Headers["X-Zeebe-Bpmn-Process-Id"];
            var zeebeElementId = httpContext.Request.Headers["X-Zeebe-Element-Id"];
            if (!string.IsNullOrEmpty(bpmnProcessId) && !string.IsNullOrEmpty(zeebeElementId))
            {
                string body = await GetBodyFromRequest(httpContext);
                if (!string.IsNullOrEmpty(body))
                {
                    var client = httpClientFactory.CreateClient("schemaValidationService");
                    var bodyContent = new StringContent(body, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync($"{bpmnProcessId}/{zeebeElementId}", bodyContent);
                    if (!response.IsSuccessStatusCode)
                    {
                        httpContext.Response.StatusCode = 500;
                        var content = await response.Content.ReadAsStringAsync();
                        await httpContext.Response.WriteAsync(content);
                        httpContext.Response.Body = await response.Content.ReadAsStreamAsync();
                        return;
                    }
                }
            }
        }
        await _next(httpContext);

    }
    private async Task<string> GetBodyFromRequest(HttpContext httpContext)
    {
        var request = httpContext.Request;
        if (request.ContentLength > 0)
        {

            request.EnableBuffering();
            var buffer = new byte[Convert.ToInt32(request.ContentLength)];
            await request.Body.ReadAsync(buffer, 0, buffer.Length);

            var requestContent = Encoding.UTF8.GetString(buffer);
            var dynamicContent = JsonSerializer.Deserialize<JsonObject>(requestContent);
            var bodyInRequestBody = dynamicContent["body"]?.ToJsonString();

            request.Body.Position = 0;  //rewinding the stream to 0
            return bodyInRequestBody;
        }
        return "";
    }

}
