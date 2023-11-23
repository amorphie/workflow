using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using amorphie.workflow.core.Enums;
using Dapr.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

namespace amorphie.workflow.zeebe.Modules
{

    public static class HttpServiceManagerModule
    {

        public static void MapHttpServiceManagerEndpoints(this WebApplication app)
        {
            app.MapPost("/amorphie-http-worker", HttpWorker)
                .Produces(StatusCodes.Status200OK)
                .WithOpenApi(operation =>
                {
                    operation.Summary = "Maps amorphie-workflow-set-state service worker on Zeebe";
                    operation.Tags = new List<OpenApiTag> { new() { Name = "Zeebe" } };
                    return operation;
                });
        }
        static async ValueTask<IResult> HttpWorker(
               [FromBody] dynamic body,
               [FromServices] WorkflowDBContext dbContext,
               HttpRequest request,
               HttpContext httpContext,
               [FromServices] DaprClient client,
                CancellationToken cancellationToken,
                IConfiguration configuration
           )
        {
            var instanceIdAsString = body.GetProperty("InstanceId").ToString();
            Guid instanceId;
            if (!Guid.TryParse(instanceIdAsString, out instanceId))
            {
                return Results.BadRequest("InstanceId not provided or not as a GUID");
            }
            var url = body.GetProperty("url").ToString();
            if (string.IsNullOrEmpty(url))
            {
                return Results.BadRequest("Header parameter 'url' is mandatory");
            }

            HttpMethodEnum httpMethodEnum = HttpMethodEnum.get;
            try
            {
                var method = request.Headers["method"].ToString();
                if (!string.IsNullOrEmpty(method))
                    Enum.TryParse(method, out httpMethodEnum);

            }
            catch (Exception ex)
            {
                return Results.BadRequest("Header parameter 'method' value is not allowed Try one of them this values => post | get | put | delete | patch");
            }
            bool headerContext = true;
            var headerContextString = request.Headers["headerContext"].ToString();
            if (headerContextString == "false")
                headerContext = false;
            string failureCodes = "5xx";
            try
            {
                failureCodes = request.Headers["failureCodes"].ToString();
                if (string.IsNullOrEmpty(failureCodes))
                    failureCodes = "5xx";
            }
            catch (Exception ex)
            {

            }
            string responseBody = string.Empty;
            string statusCode = string.Empty;
            HttpResponseMessage response;
            string content = string.Empty;
            string requestBody = string.Empty;
            try
            {
                //var httpClientDapr = DaprClient.CreateInvokeHttpClient();
                var handler = new HttpClientHandler();
                handler.ClientCertificateOptions = ClientCertificateOption.Manual;
                handler.ServerCertificateCustomValidationCallback =
                    (httpRequestMessage, cert, cetChain, policyErrors) =>
                {
                    return true;
                };
                HttpClient httpClient = new HttpClient(handler);

                try
                {
                    content = body.GetProperty("body").ToString();
                    requestBody = content.ToString();


                }
                catch (Exception ex)
                {

                }

                var serialized = new StringContent(content, System.Text.Encoding.UTF8, "application/json");
                try
                {
                    var authorization = body.GetProperty("authorization").ToString();
                    if (!string.IsNullOrEmpty(authorization))
                        httpClient.DefaultRequestHeaders.Add("Authorization",authorization);
                }
                catch (Exception ex)
                {
                }
                if (httpMethodEnum == HttpMethodEnum.post)
                {
                    response = await httpClient.PostAsync(url, serialized);
                }
                else if (httpMethodEnum == HttpMethodEnum.delete)
                {
                    response = await httpClient.DeleteAsync(url);
                }
                else if (httpMethodEnum == HttpMethodEnum.put)
                {
                    response = await httpClient.PutAsJsonAsync(new Uri(url), serialized);
                }
                else if (httpMethodEnum == HttpMethodEnum.patch)
                {
                    response = await httpClient.PatchAsJsonAsync(new Uri(url), serialized);
                }
                else
                {
                    response = await httpClient.GetAsync(url);
                }
                int statusCodeInt = (int)response!.StatusCode;
                statusCode = statusCodeInt.ToString();
                if (FailureCodesControl(failureCodes, statusCode))
                    return Results.Problem("Fail Code" + statusCode);
                responseBody = await response.Content.ReadAsStringAsync();

            }
            catch (Exception ex)
            {
                return Results.Problem("Unexpected problem:" + ex.ToString());
            }


            return Results.Ok(createMessageVariables(responseBody, statusCode, requestBody));
        }
        private static bool FailureCodesControl(string failureCodes, string statusCode)
        {

            string[] failCodes = failureCodes.Split(',');
            return failCodes.Any(a => { var match = Regex.Match(statusCode, a.Replace("x", @"\d")); return match.Success; });

        }
        private static dynamic createMessageVariables(string body, string statuscode, string requestBody)
        {
            dynamic variables = new Dictionary<string, dynamic>();

            variables.Add("bodyHttpWorker", body);
            variables.Add("statuscode", statuscode);
            variables.Add("requestBody", requestBody);


            return variables;
        }
    }

}