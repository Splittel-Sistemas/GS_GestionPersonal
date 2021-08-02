using GPSInformation.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GPSInformation.Models
{
    [TableDB(IsMappedByLabels = false, IsStoreProcedure = false)]
    public class IncidenciaAuthAux
    {

        [Display(Name = "#")]
        [ColumnDB(IsMapped = true, IsKey = true)]
        public int IdIncidenciaAuthAux { get; set; }

        [Display(Name = "Empleado")]
        [ColumnDB(IsMapped = true, IsKey = false)]
        public int IdPersona { get; set; }

        [Display(Name = "Jefe auxiliar")]
        [ColumnDB(IsMapped = true, IsKey = false)]
        public int IdPersonaAuth { get; set; }

        [Display(Name = "Comentarios")]
        [ColumnDB(IsMapped = true, IsKey = false)]
        public string Comentaros { get; set; }
        
        [Display(Name = "Nombre del jefe auxiliar")]
        [ColumnDB(IsMapped = true, IsKey = false)]
        public string NombreAuth { get; set; }

        [Display(Name = "Activa")]
        [ColumnDB(IsMapped = true, IsKey = false)]
        public bool Activa { get; set; }

        [Display(Name = "Creado")]
        [ColumnDB(IsMapped = true, IsKey = false)]
        public DateTime Creada { get; set; }

        [Display(Name = "Modificado")]
        [ColumnDB(IsMapped = true, IsKey = false)]
        public DateTime Modificada { get; set; }
    }
}
