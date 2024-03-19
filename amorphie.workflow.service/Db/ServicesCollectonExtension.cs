using amorphie.workflow.service.Db.Abstracts;
using Microsoft.Extensions.DependencyInjection;

namespace amorphie.workflow.service.Db;
    public static class ServicesCollectonExtension
{
    public static void AddBussinessServices(this IServiceCollection services)
    {
        services.AddScoped<IInstanceService, InstanceService>();
        services.AddScoped<IInstanceTransitionService, InstanceTransitionService>();
        services.AddScoped<IStateService, StateService>();
        services.AddScoped<IWorkflowService, WorkflowService>();
        services.AddScoped<MigrateService>();
    }
}

