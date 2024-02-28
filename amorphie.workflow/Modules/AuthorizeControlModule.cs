using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using amorphie.core.IBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace amorphie.workflow.Modules;

public static class AuthorizeControlModule
{
    public static void MapAuthorizeEndpoints(this WebApplication app)
    {
        app.MapGet("/workflow/check/instance/{instanceId}/tckn/{tckn}", CheckAuthWithoutTransition)

          .WithOpenApi(operation =>
          {
              operation.Summary = "Check Authentication With Instance Id";
              operation.Tags = new List<OpenApiTag> { new() { Name = "Authorize" } };

              return operation;
          });
        app.MapGet("/workflow/check/transition/{transition}/role/{role}", CheckAuthWithTransition)

       .WithOpenApi(operation =>
       {
           operation.Summary = "Check Authentication With Instance Id";
           operation.Tags = new List<OpenApiTag> { new() { Name = "Authorize" } };

           return operation;
       });
        app.MapGet("/workflow/control/fixAllStateToPrivate", fixAllStateToPrivate)
        .WithOpenApi(operation =>
        {
            operation.Summary = "Check Authentication With Instance Id";
            operation.Tags = new List<OpenApiTag> { new() { Name = "Authorize Control" } };

            return operation;
        });

    }
    static async Task<IResult> CheckAuthWithoutTransition(
         [FromServices] WorkflowDBContext dbContext,
          [FromRoute(Name = "instanceId")] Guid instanceId,
            CancellationToken cancellationToken,
            [FromRoute(Name = "tckn")] string tckn

     )
    {
        var instance = await dbContext.Instances!.Include(s => s.State).FirstOrDefaultAsync(w => w.Id == instanceId, cancellationToken);
        if (instance == null)
        {
            return Results.Ok();
        }
        if (instance != null)
        {
            if (instance.State.MFAType.GetValueOrDefault(core.Enums.MFATypeEnum.Public) == core.Enums.MFATypeEnum.Private)
            {
                if (instance.UserReference == tckn)
                    return Results.Ok();
                if (instance.UserReference != tckn)
                {
                    return Results.Unauthorized();
                }
            }
            if (instance.State.MFAType.GetValueOrDefault(core.Enums.MFATypeEnum.Public) != core.Enums.MFATypeEnum.Private)
            {
                return Results.Ok();
            }

        }
        return Results.Unauthorized();
    }
    static async Task<IResult> CheckAuthWithTransition(
     [FromServices] WorkflowDBContext dbContext,
      [FromRoute(Name = "transition")] string transitionName,
        [FromRoute(Name = "role")] string role,
        CancellationToken cancellationToken


 )
    {
        try
        {
            var transition = await dbContext.Transitions!.Include(s => s.TransitionRoles).FirstOrDefaultAsync(w => w.Name == transitionName, cancellationToken);
            if (transition == null)
            {
                return Results.Unauthorized();
            }
            if (transition.TransitionRoles.Any())
            {
                var IsHasRole = transition.TransitionRoles.Any(a => a.Role == role);
                if (IsHasRole)
                {
                    return Results.Ok();
                }
                else
                {
                    return Results.Unauthorized();
                }
            }
            if (!transition.TransitionRoles.Any())
            {
                return Results.Ok();
            }
        }
        catch (Exception ex)
        {
            return Results.Unauthorized();
        }
        return Results.Unauthorized();

    }

    static async Task<IResult> fixAllStateToPrivate(
         [FromServices] WorkflowDBContext dbContext,
            CancellationToken cancellationToken


     )
    {
        List<string> ExcludeFlows = new List<string>(){
            "OpenBanking-Register",
            "user-register",
            "login",
            "amorphie-login-mobile",
            "amorphie-mobile-login",
            "Amorphie Mobile Login"
        };
        bool isUpdate = false;
        List<State> statesForUpdate = await dbContext.States.Where(w => !ExcludeFlows.Contains(w.WorkflowName) && w.MFAType == null).ToListAsync(cancellationToken);
        foreach (State stateForUpdate in statesForUpdate)
        {
            stateForUpdate.MFAType = core.Enums.MFATypeEnum.Private;
            isUpdate = true;
        }
        if (isUpdate)
            await dbContext.SaveChangesAsync(cancellationToken);

        return Results.Ok(isUpdate);
    }
}
