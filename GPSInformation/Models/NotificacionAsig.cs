using GPSInformation.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GPSInformation.Models
{
    [TableDB(IsMappedByLabels = false, IsStoreProcedure = false)]
    public class NotificacionAsig
    {
        [ColumnDB(IsMapped = true, IsKey = true, IsKeyNotIdenti = true)]
        public int IdNotificacionAsig { get; set; }

        [ColumnDB(IsMapped = true, IsKey = false)]
        public int IdNotificacion { get; set; }

        [ColumnDB(IsMapped = true, IsKey = false)]
        public int IdPersona { get; set; }

        [ColumnDB(IsMapped = true, IsKey = false)]
        public bool Revisado { get; set; }

        [ColumnDB(IsMapped = true, IsKey = false)]
        public DateTime FechaRevision { get; set; }
    }
}
