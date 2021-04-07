using GPSInformation.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GPSInformation.Models.Produccion
{
    [TableDB(IsMappedByLabels = false, IsStoreProcedure = false)]
    public class GrupoProdCorte
    {
        [ColumnDB(IsMapped = true, IsKey = true)]
        public int IdGrupoProdCorte { get; set; }

        [ColumnDB(IsMapped = true, IsKey = false)]
        public int IdPersona { get; set; }

        [ColumnDB(IsMapped = true, IsKey = false)]
        public DateTime FechaCorte { get; set; }

        [ColumnDB(IsMapped = true, IsKey = false)]
        public string Comentarios { get; set; }

        [ColumnDB(IsMapped = true, IsKey = false)]
        public double HorasMeta { get; set; }

        [ColumnDB(IsMapped = true, IsKey = false)]
        public double HorasReal { get; set; }

        [ColumnDB(IsMapped = true, IsKey = false)]
        public double HorasJusti { get; set; }

        [ColumnDB(IsMapped = true, IsKey = false)]
        public double Score { get; set; }

        [ColumnDB(IsMapped = true, IsKey = false)]
        public DateTime Creado { get; set; }

        [ColumnDB(IsMapped = true, IsKey = false)]
        public DateTime Modificado { get; set; }
    }
    [TableDB(IsMappedByLabels = false, IsStoreProcedure = false)]
    public class GrupoCorte
    {
        [ColumnDB(IsMapped = true, IsKey = true)]
        public int IdGrupoCorte { get; set; }

        [ColumnDB(IsMapped = true, IsKey = false)]
        public int IdPersona { get; set; }

        [ColumnDB(IsMapped = true, IsKey = false)]
        public DateTime Fecha { get; set; }

        [ColumnDB(IsMapped = true, IsKey = false)]
        public string Comentarios { get; set; }

        [ColumnDB(IsMapped = true, IsKey = false)]
        [DisplayFormat(DataFormatString = "{0:#,##0.0#} hrs")]
        [Display(Name = "Hrs.Grupo")]
        public double HrsGrupo { get; set; }

        [ColumnDB(IsMapped = true, IsKey = false)]
        [DisplayFormat(DataFormatString = "{0:#,##0.0#} hrs")]
        [Display(Name = "Hrs.Reales")]
        public double HrsReal { get; set; }

        [ColumnDB(IsMapped = true, IsKey = false)]
        [DisplayFormat(DataFormatString = "{0:#,##0.0#} hrs")]
        [Display(Name = "Hrs.Nomina")]
        public double HrsNomina { get; set; }

        [ColumnDB(IsMapped = true, IsKey = false)]
        [DisplayFormat(DataFormatString = "{0:#,##0.0#} hrs")]
        [Display(Name = "Hrs a TxT")]
        public double HrsTxT { get; set; }

        [ColumnDB(IsMapped = true, IsKey = false)]
        [DisplayFormat(DataFormatString = "{0:#,##0.0#} hrs")]
        [Display(Name = "Hrs.Extras")]
        public double HrsExtra { get; set; }

        [ColumnDB(IsMapped = true, IsKey = false)]
        [DisplayFormat(DataFormatString = "{0:#,##0.0#} hrs")]
        [Display(Name = "Hrs a Score general")]
        public double HrsScoreGen { get; set; }

        [ColumnDB(IsMapped = true, IsKey = false)]
        public bool EsInicial { get; set; }
        [ColumnDB(IsMapped = true, IsKey = false)]
        public bool EsFinal { get; set; }

        [ColumnDB(IsMapped = true, IsKey = false)]
        [DisplayFormat(DataFormatString = "{0:#,##0.0#} hrs")]
        [Display(Name = "Hrs.Extras en TxP")]
        public double Extras { get; set; }

        [ColumnDB(IsMapped = true, IsKey = false)]
        [DisplayFormat(DataFormatString = "{0:#,##0.0#} hrs")]
        [Display(Name = "Hrs.Extras en Score general")]
        public double Score { get; set; }
    }
}
