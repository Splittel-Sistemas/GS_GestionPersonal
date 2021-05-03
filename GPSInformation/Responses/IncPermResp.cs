using GPSInformation.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
namespace GPSInformation.Responses
{
    public class IncPermResp
    {
        [Display]
        public IncidenciaPermiso IncidenciaPermiso { get; set; }
        public string Asunto { get; set; }
        public string pago { get; set; }
        public string Empleado { get; set; }
        public string Estatus { get; set; }
    }
    public class InAutorizacion
    {
        [Required]
        [Display]
        public int IdIncidencia { get; set;}
        [Required]
        [Display]
        public bool Autoriza { get; set; }
        [Required]
        [Display(Name = "Comentarios")]
        public string Comentarios { get; set; }
        [Required]
        [Display]
        public int Mode { get; set; }
        [Display(Name = "Aprobador")]
        public int IdAutorizante { get; set; }
        [Display(Name = "Aprobador")]
        public string NombreApro { get; set; }

    }
}
