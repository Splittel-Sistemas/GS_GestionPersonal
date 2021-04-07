using GPSInformation.Controllers;
using GPSInformation.Models.Produccion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GPSInformation.Reportes.ProduccionV3
{
    public class EmpleadoProd
    {
        public int IdPersona { get; set; }
        public string NombreCompleto { get; set; }
        public string NumeroNomina { get; set; }
        public string PuestoNombre { get; set; }
        public double Antiguedad { get; set; }
        [DisplayFormat(DataFormatString = "{0:#,##0.0#} (hrs)")]
        [Display(Name="Hrs.Meta(Nomina)")]
        public double HorasMeta { get; set; }
        [DisplayFormat(DataFormatString = "{0:#,##0.0#} (hrs)")]
        [Display(Name = "Hrs.Justificadas")]
        public double HorasAprobadas { get; set; }
        [DisplayFormat(DataFormatString = "{0:#,##0.0#} (hrs)")]
        [Display(Name = "Hrs.Trabajadas")]
        public double HorasReal { get; set; }
        [DisplayFormat(DataFormatString = "{0:#,##0.0#} (hrs)")]
        [Display(Name = "Dif.Nomina")]
        public double HorasScore { get { return HorasMeta - HorasAprobadas - HorasReal; } }
        public DateTime Incio { get; set; }
        public DateTime Fin { get; set; }

        public List<AccessLog> Accessos { get; set; }
        public List<JornadaGrupo> JornadaGrupos { get; set; }
        public List<GrupoProdIncidencia> GrupoProdIncidencias { get; set; }
        public List<GrupoCambios> GrupoCambios { get; set; }
        public GrupoProdCorte GrupoProdCorteAct { get; set; }
        public GrupoProdCorte GrupoProdCorteLast { get; set; }
        public GrupoCorte GrupoCorte { get; set; }
        public GrupoCorte GrupoCorteLast { get; set; }
        public List<NewIncidence> NewIncidence { get; set; }
        [DisplayFormat(DataFormatString = "{0:#,##0.0#} (hrs)")]
        [Display(Name = "Hrs.TxT")]
        public double HrsTxt { get; internal set; }
        [DisplayFormat(DataFormatString = "{0:#,##0.0#} (hrs)")]
        [Display(Name = "Hrs.Score general")]
        public double HrsScoreGen { get; internal set; }
    }

    public class NewIncidence
    {
        public GrupoIncidencia Incidencia { get; set; }
        public List<GrupoIncidenciaDetalle> Detalle { get; set; }
    }
}
