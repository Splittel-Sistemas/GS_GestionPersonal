using GPSInformation.Attributes;
using GPSInformation.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GPSInformation.Models
{
    [TableDB(IsMappedByLabels = false, IsStoreProcedure = false)]
    public class ReporteAccss
    {
        [Display(Name = "Folio")]
        [DisplayFormat(DataFormatString = "RE{0:0000}", ApplyFormatInEditMode = false)]
        [ColumnDB(IsMapped = true, IsKey = true, IsKeyNotIdenti = true)]
        public int IdReporteAccss { get; set; }

        [ColumnDB(IsMapped = true, IsKey = false)]
        public int IdReporte { get; set; }

        [ColumnDB(IsMapped = true, IsKey = false)]
        public int IdUsuario { get; set; }

        [ColumnDB(IsMapped = true, IsKey = false)]
        public bool Access { get; set; }

        [ColumnDB(IsMapped = true, IsKey = false)]
        public DateTime Editado { get; set; }
    }
}
