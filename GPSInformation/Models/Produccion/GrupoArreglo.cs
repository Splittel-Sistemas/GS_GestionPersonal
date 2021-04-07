using GPSInformation.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GPSInformation.Models.Produccion
{
    [TableDB(IsMappedByLabels = false, IsStoreProcedure = false)]
    public class GrupoArreglo
    {
        [ColumnDB(IsMapped = true, IsKey = true)]
        public int IdGrupoArreglo { get; set; }

        [ColumnDB(IsMapped = true, IsKey = false)]
        public int IdPersona { get; set; }

        [ColumnDB(IsMapped = true, IsKey = false)]
        public int IdEvent { get; set; }

        [ColumnDB(IsMapped = true, IsKey = false)]
        public DateTime FechaHora { get; set; }

        [ColumnDB(IsMapped = true, IsKey = false)]
        public bool EsIgnorado { get; set; }

        [ColumnDB(IsMapped = true, IsKey = false)]
        public string Comentarios { get; set; }

        [ColumnDB(IsMapped = true, IsKey = false)]
        public DateTime Creado { get; set; }

        [ColumnDB(IsMapped = true, IsKey = false)]
        public DateTime Modificado { get; set; }
    }

    [TableDB(IsMappedByLabels = false, IsStoreProcedure = false)]
    public class GrupoIncidencia
    {

        [ColumnDB(IsMapped = true, IsKey = true)]
        public int IdGrupoIncidencia { get; set; }

        [ColumnDB(IsMapped = true, IsKey = false)]
        public int IdPersona { get; set; }

        [ColumnDB(IsMapped = true, IsKey = false)]
        public DateTime Fecha { get; set; }

        [ColumnDB(IsMapped = true, IsKey = false)]
        public string Descripcion { get; set; }

        [ColumnDB(IsMapped = true, IsKey = false)]
        public string TipoIncidencia { get; set; }

        [ColumnDB(IsMapped = true, IsKey = false)]
        public int TipoPermiso { get; set; }

        [ColumnDB(IsMapped = true, IsKey = false)]
        public string CreadoPor { get; set; }

        [ColumnDB(IsMapped = true, IsKey = false)]
        public DateTime Creado { get; set; }
        [ColumnDB(IsMapped = false, IsKey = false)]
        public string DescPermiso { get; set; }
        [ColumnDB(IsMapped = true, IsKey = false)]
        public string Adjunto { get; set; }
        [ColumnDB(IsMapped = true, IsKey = false)]
        public bool EsScoreGeneral { get; set; }
    }

    [TableDB(IsMappedByLabels = false, IsStoreProcedure = false)]
    public class GrupoIncidenciaDetalle
    {

        [ColumnDB(IsMapped = true, IsKey = true)]
        public int IdGrupoIncidenciaDetalle { get; set; }

        [ColumnDB(IsMapped = true, IsKey = false)]
        public int IdGrupoIncidencia { get; set; }

        [ColumnDB(IsMapped = true, IsKey = false)]
        public DateTime Fecha { get; set; }

        [ColumnDB(IsMapped = true, IsKey = false)]
        [DisplayFormat(DataFormatString = "{0:#,##0.0#} (hrs)")]
        public double Horas { get; set; }

    }
}
