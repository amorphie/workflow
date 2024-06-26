using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace amorphie.workflow.core.Dtos.Dml;


public record DeployProcessRequest(
    [Required] IFormFile FileContent,
    [Required] string FileName);
public record DeployProcessResponse(long Key, IList<ProcessMetadata> Processes);
 

