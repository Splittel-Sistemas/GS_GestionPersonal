using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionPersonal.Areas.v2.Entities
{
    public class View_formacion_evaluacion
    {
        [Key]
        public int IdCF_FormacionEval { get; set; }
        public int FormVersion { get; set; }
        public int EvaVersion { get; set; }
        public string EvaNombre { get; set; }
        public int EvaVersionNum { get; set; }
        public int? EvaSeccion { get; set; }
        public string? EvaSeccionName { get; set; }
    }
}
