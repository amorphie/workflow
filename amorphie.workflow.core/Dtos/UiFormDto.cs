using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using amorphie.workflow.core.Enums;

namespace amorphie.workflow.core.Dtos
{
    public class UiFormDto
    {
        public TypeofUiEnum typeofUi {get;set;}=TypeofUiEnum.Formio;
        public MultilanguageText[]? forms {get;set;}

    }
}