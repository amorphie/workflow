using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Refit;

public interface ICallSerciveAPI
{
    [Post("/")]
    Task<ApiResponse<GenericResponse<dynamic>>> PostModel([Body] amorphie.workflow.core.Dtos.SendTransitionInfoRequest model);
}