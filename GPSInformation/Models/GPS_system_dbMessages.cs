using System;
using System.Collections.Generic;
using System.Text;
using GPSInformation.Attributes;

namespace GPSInformation.Models
{
    [TableDB(IsMappedByLabels = false, IsStoreProcedure = false, Created_at = "Creado")]
    public class GPS_system_dbMessages
    {
        [ColumnDB(IsMapped = true, IsKey = true)]
        public int Id { get; set; }

        [ColumnDB(IsMapped = true)]
        public DateTime Creado { get; set; }

        [ColumnDB(IsMapped = true)]
        public string Tipo { get; set; }

        [ColumnDB(IsMapped = true)]
        public string Detonante { get; set; }

        [ColumnDB(IsMapped = true)]
        public string Detalle { get; set; }

        [ColumnDB(IsMapped = true)]
        public int IdPersona { get; set; }

        [ColumnDB(IsMapped = true)]
        public string PersonaName { get; set; }
        
        [ColumnDB(IsMapped = true)]
        public string Mensaje { get; set; }
    }
}
