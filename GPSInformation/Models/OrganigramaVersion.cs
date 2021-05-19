using GPSInformation.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GPSInformation.Models
{
    [TableDB(IsMappedByLabels = false, IsStoreProcedure = false)]
    public class OrganigramaVersion
    {
        [Display(Name = "#")]
        [DisplayFormat(DataFormatString = "OR-{0:0000}", ApplyFormatInEditMode = true)]
        [ColumnDB(IsMapped = true, IsKey = true)]
        public int IdOrganigramaVersion { get; set; }

        [Display(Name = "Creado")]
        [ColumnDB(IsMapped = true, IsKey = false)]
        public DateTime FechaCreacion { get; set; }

        [Display(Name = "Actualizado")]
        [ColumnDB(IsMapped = true, IsKey = false)]
        public DateTime FechaActualizacion { get; set; }

        [Display(Name = "Autorizado")]
        [ColumnDB(IsMapped = true, IsKey = false)]
        public int Autirizada { get; set; }

        [Display(Name = "Comentarios")]
        [ColumnDB(IsMapped = true, IsKey = false)]
        public string Comentarios { get; set; }

        [Display(Name = "Eliminado")]
        [ColumnDB(IsMapped = true, IsKey = false)]
        public bool Eliminado { get; set; }
    }
}
