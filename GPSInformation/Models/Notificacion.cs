using GPSInformation.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GPSInformation.Models
{
    [TableDB(IsMappedByLabels = false, IsStoreProcedure = false, Created_at = "Creado")]
    public class Notificacion
    {
        [ColumnDB(IsMapped = true, IsKey = true, IsKeyNotIdenti = true)]
        public int IdNotificacion { get; set; }

        [ColumnDB(IsMapped = true, IsKey = false)]
        public string Descripcion { get; set; }

        [ColumnDB(IsMapped = true, IsKey = false)]
        public string URL { get; set; }

        [ColumnDB(IsMapped = true, IsKey = false)]
        public string Categoria { get; set; }
        
        [ColumnDB(IsMapped = true, IsKey = false)]
        public string Titulo { get; set; }

        [ColumnDB(IsMapped = true, IsKey = false)]
        public DateTime Creado { get; set; }
    }
}
