using GPSInformation.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GPSInformation.Models
{
    /// <summary>
    /// template de curso
    /// </summary>
    [TableDB(IsMappedByLabels = false, IsStoreProcedure = false, Created_at = "Creada", Updated_at = "Editada")]
    public class CapRegistryVersion
    {
        /// <summary>
        /// #
        /// </summary>
        [ColumnDB(IsMapped = true, IsKey = true)]
        public int IdCapRegistryVersion { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ColumnDB(IsMapped = true, IsKey = false)]
        public string TipoRef { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ColumnDB(IsMapped = true, IsKey = false)]
        public int IdRefer { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ColumnDB(IsMapped = true, IsKey = false)]
        public string Comentarios { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ColumnDB(IsMapped = true, IsKey = false)]
        public bool Actual { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ColumnDB(IsMapped = true, IsKey = false)]
        public int IdPersona { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ColumnDB(IsMapped = true, IsKey = false)]
        public string Nombre { get; set; }
        
        // <summary>
        /// 
        /// </summary>
        [ColumnDB(IsMapped = true, IsKey = false)]
        public string EstructuraJSON { get; set; }

        /// <summary>
        /// Fe.Registro
        /// </summary>
        [ColumnDB(IsMapped = true, IsKey = false)]
        [Display(Name = "Fe.Registro")]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:F}")]
        public DateTime Creada { get; set; }

        /// <summary>
        /// Fe.Ult.Actualizacion
        /// </summary>
        [ColumnDB(IsMapped = true, IsKey = false)]
        [Display(Name = "Fe.Ult.Actualizacion")]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:F}")]
        public DateTime Editada { get; set; }
    }
}
