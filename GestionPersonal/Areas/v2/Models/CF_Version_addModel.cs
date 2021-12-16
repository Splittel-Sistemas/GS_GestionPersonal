using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestionPersonal.Areas.v2.Models
{
    public class CF_Version_addModel
    {
        [Required]
        public string Comentarios { get; set; }
        public bool Activa { get; set; }
        public int IdCF_Formacion { get; set; }
        public int NoVersion { get; set; }
    }
    public class CF_Version_updModel
    {
        public int IdCF_Version { get; set; }
        [Required]
        public string Comentarios { get; set; }
        public bool Activa { get; set; }
        public int IdCF_Formacion { get; set; }
        public int NoVersion { get; set; }
    }
}
