using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionPersonal.Areas.v2.Models
{
    public class CF_FormacionEva_addModel
    {
        public int IdCF_Version { get; set; }
        public int IdCF_EvaluacionVersion { get; set; }
        public int? IdCF_EvaluacionSeccion { get; set; }
    }
}
