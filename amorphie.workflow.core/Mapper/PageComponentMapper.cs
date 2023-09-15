using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace amorphie.workflow.core.Mapper;

      public class PageComponentMapper : Profile
{
    public PageComponentMapper()
    {


        CreateMap<PageComponent, DtoPageComponents>()
         .ConstructUsing(x => new DtoPageComponents
         {
             pageRoute = x.PageName,
             components = new List<DtoComponent>(){
                new DtoComponent(){
                    componentName=x.componentName,
                     transitionName=x.transitionName,
                      type= x.type,
                       visibility=x.visibility,
                       uiModel=x.uiModel!=null&&x.uiModel.buttonText!=null?new DtoPageComponentUiModel(){
                        buttonText=new amorphie.workflow.core.Dtos.MultilanguageText(x.uiModel.buttonText.FirstOrDefault().Language,x.uiModel.buttonText.FirstOrDefault().Label)
                       }:null,
                       childComponents=x.ChildComponents!=null?x.ChildComponents.Select(s=>new DtoComponent{
                       componentName=s.componentName,
                        transitionName=s.transitionName,
                      type= s.type,
                       visibility=s.visibility,
                       componentJson=s.componentJson
                       }).ToList():null
                }
             }

         });
    }
}
