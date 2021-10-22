using GPSInformation.Attributes;
using GPSInformation.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GPSInformation.Models
{
    [TableDB(IsMappedByLabels = false, IsStoreProcedure = false)]
    public class SalaReservacion
    {
        [ColumnDB(IsMapped = true, IsKey = true)]
        public int IdSalaReservacion { get; set; }

        [Display(Name = "Sala seleccionada")]
        [Required]
        [ColumnDB(IsMapped = true, IsKey = false)]
        public int IdSala { get; set; }

        [Display(Name = "Titulo")]
        [Required]
        [ColumnDB(IsMapped = true, IsKey = false)]
        public string Motivo { get; set; }

        [Display(Name = "Comentarios")]
        [ColumnDB(IsMapped = true, IsKey = false)]
        public string Comentarios { get; set; }

        [Display(Name = "Fecha de reservación")]
        [Required]
        [ColumnDB(IsMapped = true, IsKey = false)]
        public DateTime FechaInicio { get; set; }

        [Display(Name = "Hora de inicio de uso de la sala")]
        [Required]
        [ColumnDB(IsMapped = true, IsKey = false)]
        public TimeSpan HoraIncio { get; set; }

        [Display(Name = "Hora de termino de uso de la sala")]
        [Required]
        [ColumnDB(IsMapped = true, IsKey = false)]
        public TimeSpan HolaFin { get; set; }

        [Display(Name = "Creado por")]
        [Required]
        [ColumnDB(IsMapped = true, IsKey = false)]
        public int IdPersona { get; set; }

        [Display(Name = "Activa")]
        //[Required]
        [ColumnDB(IsMapped = true, IsKey = false)]
        public bool Activa { get; set; }

        [ColumnDB(IsMapped = false, IsKey = false)]
        public string CreadaPor { get; set; }
    }


}
