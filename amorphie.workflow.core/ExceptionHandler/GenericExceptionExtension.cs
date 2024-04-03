// using Microsoft.AspNetCore.Builder;
// using Microsoft.Extensions.DependencyInjection.Extensions;
// using Microsoft.Extensions.DependencyInjection;
// using Microsoft.Extensions.Logging;
// using Serilog.Core;
// using Serilog;
// using Microsoft.AspNetCore.HttpLogging;
// using Microsoft.Extensions.Hosting;


// namespace amorphie.workflow.core.ExceptionHandler;
// public static class GenericExceptionExtension
// {
//     public static void UseExceptionMiddleware(this IApplicationBuilder app)
//     {
//         app.UseMiddleware<ExceptionMiddleware>();
//     }


//     public static void AddSeriLogWithHttpLogging<TEnricher>(this WebApplicationBuilder builder, List<string>? headersToBeLogged = null) where TEnricher : class, ILogEventEnricher
//     {
//         var defaultHeadersToBeLogged = new List<string>
//         {
//             "Content-Type",
//             "Host",
//             "X-Zeebe-Job-Key",
//             "xdeviceid",
//             "X-Device-Id",
//             "xtokenid",
//             "X-Token-Id",
//             "Transfer-Encoding",
//             "X-Forwarded-Host",
//             "X-Forwarded-For"
//         };
//         if (headersToBeLogged != null)
//             defaultHeadersToBeLogged = defaultHeadersToBeLogged.Concat(headersToBeLogged).ToList();


//         builder.Services.AddHttpLogging(logging =>
//         {
//             //logs just props and headers in prod mode
//             logging.LoggingFields = builder.Environment.IsProduction() ? HttpLoggingFields.RequestPropertiesAndHeaders | HttpLoggingFields.ResponsePropertiesAndHeaders : HttpLoggingFields.All;
//             //logging.RequestHeaders.Concat(headersToBeLogged);
//             defaultHeadersToBeLogged.ForEach(p => logging.RequestHeaders.Add(p));

//             logging.MediaTypeOptions.AddText("application/javascript");
//             logging.RequestBodyLogLimit = 4096;
//             logging.ResponseBodyLogLimit = 4096;
//             logging.CombineLogs = true;
//         });
//         builder.Services.AddHttpContextAccessor();
//         builder.Services.TryAddSingleton<ILogEventEnricher, TEnricher>();

//         builder.Logging.ClearProviders();

//         builder.Host.UseSerilog((_, serviceProvider, loggerConfiguration) =>
//         {
//             var enricher = serviceProvider.GetRequiredService<ILogEventEnricher>();
//             loggerConfiguration
//             //.Enrich.FromLogContext()
//                 .ReadFrom.Configuration(builder.Configuration)
//                 .Enrich.With(enricher)
//                 ;
//             //.Enrich.When(p => p.Exception != null, x => x.With(enricher))
//         });
//         builder.Services.AddHttpLoggingInterceptor<HeaderCheckHttpLoggingInterceptor>();
//     }
// }



