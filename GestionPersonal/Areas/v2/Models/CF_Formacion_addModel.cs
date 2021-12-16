using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestionPersonal.Areas.v2.Models
{
    public class CF_Formacion_addModel
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Descripcion { get; set; }
        public bool Activa { get; set; }
    }
    public class CF_Formacion_updModel
    {
        public int IdCF_Formacion { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Descripcion { get; set; }
        public bool Activa { get; set; }
    }
}
