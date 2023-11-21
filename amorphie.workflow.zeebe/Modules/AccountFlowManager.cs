using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Dapr.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

namespace amorphie.workflow.zeebe.Modules
{

    public static class AccountFlowManager
    {

        public static void MapAccountFlowManagerEndpoints(this WebApplication app)
        {
            app.MapPost("/amorphie-account-create-with-worker", SendAccount)
                .Produces(StatusCodes.Status200OK)
                .WithOpenApi(operation =>
                {
                    operation.Summary = "Maps amorphie-workflow-set-state service worker on Zeebe";
                    operation.Tags = new List<OpenApiTag> { new() { Name = "Zeebe" } };
                    return operation;
                });
        }
        static async ValueTask<IResult> SendAccount(
            [FromBody] dynamic body,
            [FromServices] WorkflowDBContext dbContext,
            HttpRequest request,
            HttpContext httpContext,
            [FromServices] DaprClient client,
             CancellationToken cancellationToken,
             IConfiguration configuration
        )
        {

            var entityData = body.GetProperty($"TRXaccountcreatestarttest").GetProperty("Data").GetProperty("entityData").ToString();
            AccountRequest requestBody = JsonSerializer.Deserialize<AccountRequest>(entityData, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            var handler = new HttpClientHandler();
            HttpResponseMessage response;
            string content = string.Empty;
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


            }
            catch (Exception ex)
            {

            }

            var serialized = new StringContent(content, System.Text.Encoding.UTF8, "application/json");
            response = await httpClient.PostAsync("https://test-integration-apisix-gw.apps.nonprod.ebt.bank/ebank/accounts/saving/new/15059003384", serialized);
            string? responseBody = await response.Content.ReadAsStringAsync();
            int statusCodeInt = (int)response!.StatusCode;
            string   statusCode = statusCodeInt.ToString();
            return Results.Ok(createMessageVariables(responseBody, statusCode));
        }
        private static dynamic createMessageVariables(string body, string statuscode)
        {
            dynamic variables = new Dictionary<string, dynamic>();

            variables.Add("bodyHttpWorker", body);
            variables.Add("statuscode", statuscode);
            return variables;
        }
    }

    public class AccountRequest
    {
        public string identityNumber { get; set; }
        public string branchCode { get; set; }
        public string currencyCode { get; set; }
        public string name { get; set; }
        public string productCode { get; set; }

    }
}