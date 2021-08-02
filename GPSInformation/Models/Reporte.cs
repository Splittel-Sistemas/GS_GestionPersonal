using GPSInformation.Attributes;
using GPSInformation.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GPSInformation.Models
{
    [TableDB(IsMappedByLabels = false, IsStoreProcedure = false)]
    public class Reporte
    {
        [Display(Name = "Folio")]
        [DisplayFormat(DataFormatString = "RE{0:0000}", ApplyFormatInEditMode = false)]
        [ColumnDB(IsMapped = true, IsKey = true, IsKeyNotIdenti = true)]
        public int IdReporte { get; set; }

        /// <summary>
        /// Descripcion del reporte
        /// </summary>
        [Display(Name = "Descripcion del reporte")]
        [ColumnDB(IsMapped = true, IsKey = false)]
        public string Descripcion { get; set; }

        /// <summary>
        /// Sentencia SQl
        /// </summary>
        [Display(Name = "Sentencia SQl")]
        [ColumnDB(IsMapped = true, IsKey = false)]
        public string Sentencia { get; set; }

        /// <summary>
        /// Activo
        /// </summary>
        [Display(Name = "Activo")]
        [ColumnDB(IsMapped = true, IsKey = false)]
        public bool Activo { get; set; }

        /// <summary>
        /// Fecha de creacion del reporte
        /// </summary>
        [Display(Name = "Fecha de creacion del reporte")]
        [ColumnDB(IsMapped = true, IsKey = false)]
        public DateTime Creado { get; set; }

        /// <summary>
        /// Fecha de ultima actualizacion
        /// </summary>
        [Display(Name = "Fecha de ultima actualizacion")]
        [ColumnDB(IsMapped = true, IsKey = false)]
        public DateTime Editado { get; set; }

        /// <summary>
        /// Json de parametros
        /// </summary>
        [Display(Name = "Json de parametros")]
        [ColumnDB(IsMapped = true, IsKey = false)]
        public string Parametros { get; set; }

        /// <summary>
        /// Tipo de sentencia
        /// </summary>
        [Display(Name = "Tipo de sentencia")]
        [ColumnDB(IsMapped = true, IsKey = false)]
        public int Tipo { get; set; }

        /// <summary>
        /// Detalle de parametros
        /// </summary>
        [Display(Name = "Detalle de parametros")]
        [ColumnDB(IsMapped = false, IsKey = false)]
        public List<Rpt_Aux_parame> ParametrosD { get {
                return string.IsNullOrEmpty(Parametros) ? new List<Rpt_Aux_parame>() : JsonConvert.DeserializeObject<List<Rpt_Aux_parame>>(Parametros);
            } 
        }

        /// <summary>
        /// Columnas
        /// </summary>
        [Display(Name = "Columnas")]
        [ColumnDB(IsMapped = true, IsKey = false)]
        public string Columnas { get; set; }
        
        /// <summary>
        /// Detalle de parametros
        /// </summary>
        [Display(Name = "Columnas")]
        [ColumnDB(IsMapped = false, IsKey = false)]
        public List<string> ColumnasD
        {
            get
            {
                return string.IsNullOrEmpty(Columnas) ? new List<string>() : JsonConvert.DeserializeObject<List<string>>(Columnas);
            }
        }

        /// <summary>
        /// Descripcion del tipo de sentencia
        /// </summary>
        [Display(Name = "Descripcion del tipo de sentencia")]
        [ColumnDB(IsMapped = false, IsKey = false)]
        public string TipoDescr
        {
            get
            {
                if (Tipo == 1) return "Query";
                else if (Tipo == 2) return "View";
                else if (Tipo == 3) return "SP";
                else return "";
            }
        }
    }

    public class Rpt_Aux_parame
    {
       
        public string Descripcion { get; set; }
        /// <summary>
        /// Parametro
        /// </summary>
        public string Variable { get; set; }
        /// <summary>
        /// Tipo de dato de la variable
        /// </summary>
        public string Tipo { get; set; }
        /// <summary>
        /// valor
        /// </summary>
        public string Valor { get; set; }
        
        public int Multiple { get; set; }

        public string OptionsSQL { get; set; }
    }
}
