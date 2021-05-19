using GPSInformation.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GPSInformation.Views
{
    [TableDB(IsMappedByLabels = false, IsStoreProcedure = false)]
    public class View_EmpleadoJefe
    {
        [ColumnDB(IsMapped = true, IsKey = false)]
        public int IdOrganigramaVersion { get; set; }
        [ColumnDB(IsMapped = true, IsKey = false)]
        public int EIdPuesto { get; set; }
        [ColumnDB(IsMapped = true, IsKey = false)]
        public string EPuestoNombre { get; set; }
        [ColumnDB(IsMapped = true, IsKey = false)]
        public int EIdPersona { get; set; }
        [ColumnDB(IsMapped = true, IsKey = false)]
        public string ENombreCompleto { get; set; }
        [ColumnDB(IsMapped = true, IsKey = false)]
        public string ECorreo { get; set; }


        [ColumnDB(IsMapped = true, IsKey = false)]
        public string Separador { get; set; }
        [ColumnDB(IsMapped = true, IsKey = false)]
        public int JIdPuesto { get; set; }
        [ColumnDB(IsMapped = true, IsKey = false)]
        public string JPuestoNombre { get; set; }
        [ColumnDB(IsMapped = true, IsKey = false)]
        public int JIdpersona { get; set; }
        [ColumnDB(IsMapped = true, IsKey = false)]
        public string JNombreCompleto { get; set; }
        [ColumnDB(IsMapped = true, IsKey = false)]
        public string JCorreo { get; set; }
    }
}
