using AutoMapper;
using GestionPersonal.Areas.v2.Entities;
using GestionPersonal.Areas.v2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionPersonal.Areas.v2.Helpers
{
    public class CF_FormacionMapperProfile: Profile
    {
        public CF_FormacionMapperProfile()
        {
            CreateMap<CF_Formacion_addModel, CF_Formacion>();
            CreateMap<CF_Formacion_updModel, CF_Formacion>();
        }
    }
    public class CF_VersionMapperProfile: Profile
    {
        public CF_VersionMapperProfile()
        {
            CreateMap<CF_Version_addModel, CF_Version>();
            CreateMap<CF_Version_updModel, CF_Version>();
        }
    }

    public class CF_PaginaContentMapperProfile : Profile
    {
        public CF_PaginaContentMapperProfile()
        {
            CreateMap<CF_PaginaContent_addModel, CF_PaginaContent>();
            CreateMap<CF_PaginaContent_updModel, CF_PaginaContent>();
        }
    }

    public class CF_EvaluacionMapperProfile: Profile
    {
        public CF_EvaluacionMapperProfile()
        {
            CreateMap<CF_Evaluacion_addModel, CF_Evaluacion>();
            CreateMap<CF_Evaluacion_updModel, CF_Evaluacion>();

            CreateMap<CF_EvaluacionVersion_addModel, CF_EvaluacionVersion>();
            CreateMap<CF_EvaluacionVersion_updModel, CF_EvaluacionVersion>();

            CreateMap<CF_EvaluacionSeccion_addModel, CF_EvaluacionSeccion>();
            CreateMap<CF_EvaluacionSeccion_updModel, CF_EvaluacionSeccion>();

            CreateMap<CF_EvaluacionPreg_addModel, CF_EvaluacionPreg>();
            CreateMap<CF_EvaluacionPreg_updModel, CF_EvaluacionPreg>();

            CreateMap<CF_EvaluacionPregRes_addModel, CF_EvaluacionPregRes>();
            CreateMap<CF_EvaluacionPregRes_updModel, CF_EvaluacionPregRes>();

        }
    }
}
