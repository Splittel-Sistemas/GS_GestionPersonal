using GPSInformation.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GPSInformation.Views
{
    [TableDB(IsMappedByLabels = false, IsStoreProcedure = false)]
    public class View_notificacionEmp
    {
        [ColumnDB(IsMapped = true, IsKey = true)]
        public int IdNotificacion { get; set; }

        [ColumnDB(IsMapped = true, IsKey = false)]
        public int IdPersona { get; set; }

        [ColumnDB(IsMapped = true, IsKey = false)]
        public string Categoria { get; set; }

        [ColumnDB(IsMapped = true, IsKey = false)]
        public string Descripcion { get; set; }

        [ColumnDB(IsMapped = true, IsKey = false)]
        public string URL { get; set; }
        
        [ColumnDB(IsMapped = true, IsKey = false)]
        public string Titulo { get; set; }

        [ColumnDB(IsMapped = true, IsKey = false)]
        public DateTime Creado { get; set; }

        [ColumnDB(IsMapped = true, IsKey = false)]
        public bool Revisado { get; set; }

        [ColumnDB(IsMapped = true, IsKey = false)]
        public DateTime FechaRevision { get; set; }
    }
}
