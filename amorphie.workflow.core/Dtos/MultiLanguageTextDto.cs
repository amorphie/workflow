using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace amorphie.workflow.core.Dtos
{
    public record MultilanguageText
         (
             string language,
             string label
         );
}