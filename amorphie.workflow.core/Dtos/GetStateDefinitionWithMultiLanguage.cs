using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace amorphie.workflow.core.Dtos
{
    public record GetStateDefinitionWithMultiLanguage(string name, MultilanguageText[] title, amorphie.core.Enums.StatusType baseStatus, PostTransitionWithMultiLanguage[] transitions);
    public record PostTransitionWithMultiLanguage(string name, MultilanguageText[] title, string? toState, MultilanguageText[]? form, string fromState, string? serviceName, string? message, string? gateway, PostPageDefinitionRequest? page);
}