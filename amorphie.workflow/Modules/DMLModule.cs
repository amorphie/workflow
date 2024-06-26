using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Dapr.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using System.Runtime.InteropServices.WindowsRuntime;
using Microsoft.Toolkit.HighPerformance;
namespace amorphie.workflow.Modules;
public static class DMLModule
{
    public static void MapDMLEndpoints(this WebApplication app)
    {
        app.MapPost("/workflow/dml/insertfile", DeployProcess)
            .Produces(StatusCodes.Status204NoContent)
            .WithOpenApi(operation =>
            {
                operation.Summary = "Insert a DML";

                operation.Tags = new List<OpenApiTag> { new() { Name = "DML" } };

                operation.Responses["200"].Description = "Success DML Insert tyo Zeebe.";

                return operation;
            });

    }
        public async static Task<amorphie.workflow.core.Dtos.Dml.DeployProcessResponse> DeployProcess([FromForm] amorphie.workflow.core.Dtos.Dml.DeployProcessRequest request,
        [FromServices] DaprClient client)
    {
        await using var memoryStream = new MemoryStream();
        var (fileContent, fileName) = request;
        await fileContent.OpenReadStream().CopyToAsync(memoryStream);
        var bindingRequest = new BindingRequest("command", amorphie.workflow.core.Dtos.Dml.DMLCommands.DeployProcess)
        {
            Data = memoryStream.ToArray().AsMemory()
        };
        bindingRequest.Metadata.Add("fileName", fileName);
 
        var bindingResponse = await client.InvokeBindingAsync(bindingRequest);
        var responseJson = await JsonSerializer.DeserializeAsync<amorphie.workflow.core.Dtos.Dml.DeployProcessResponse>(
            bindingResponse.Data.AsStream());
 
        return responseJson;
    }
}
