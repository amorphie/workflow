using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace amorphie.workflow.core.Dtos.Dml;
public record ProcessMetadata(
    string BpmnProcessId,
    int Version,
    long ProcessDefinitionKey,
    string ResourceName);