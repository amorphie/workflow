using System;
using AutoMapper;

public class ObjectMapper
{
    private static readonly Lazy<IMapper> lazy = new Lazy<IMapper>(() =>
{
    var config = new MapperConfiguration(cfg =>
    {
         cfg.AddProfile<amorphie.workflow.core.Mapper.WorkflowMapper>();
             cfg.AddProfile<amorphie.workflow.core.Mapper.PageComponentMapper>();
    });

    return config.CreateMapper();
});

    public static IMapper Mapper => lazy.Value;
}