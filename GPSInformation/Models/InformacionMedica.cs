using GPSInformation.Attributes;
using GPSInformation.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GPSInformation.Models
{
    [TableDB(Name = "InformacionMedica", IsMappedByLabels = false, IsStoreProcedure = false, Created_at = "Creado", Updated_at = "Editado")]
    public class InformacionMedica
    {
        [ColumnDB(Name = "IdPersona", IsMapped = true, IsKey = true)]
        public int IdInformacionMedica { get; set; }
        [Required]
        [ColumnDB(Name = "Nombre", IsMapped = true, IsKey = false)]
        public int IdPersona { get; set; }

        [Display(Name = "Tipo sangre")]
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Por favor selecciona una opción")]
        [ColumnDB(Name = "Nombre", IsMapped = true, IsKey = false)]
        public int TipoSangre { get; set; }

        [Display(Name = "Alergias")]
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Por favor selecciona una opción")]
        [ColumnDB(Name = "Nombre", IsMapped = true, IsKey = false)]
        public int Alergias { get; set; }

        [Display(Name = "Altura(Mts)")]
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Por favor selecciona una opción > 0")]
        [ColumnDB(Name = "Nombre", IsMapped = true, IsKey = false)]
        public double Altura { set; get; }

        [Display(Name = "Peso(Kg)")]
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Por favor selecciona una opción > 0")]
        [ColumnDB(Name = "Nombre", IsMapped = true, IsKey = false)]
        public double Peso { set; get; }

        [Display(Name = "Talla")]
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Por favor selecciona una opción > 0")]
        [ColumnDB(Name = "Nombre", IsMapped = true, IsKey = false)]
        public double Talla { set; get; }

        [Display(Name = "IMC")]
        [Required]
        [ColumnDB(Name = "Nombre", IsMapped = true, IsKey = false)]
        public double IMC { set; get; }

        [Display(Name = "Comentarios medicos")]
        [Required]
        [ColumnDB(Name = "Nombre", IsMapped = true, IsKey = false)]
        public string Comentarios { get; set; }

        [Display(Name = "Creado")]
        [ColumnDB(Name = "Creado", IsMapped = true, IsKey = false)]
        public DateTime Creado { get; set; }

        [Display(Name = "Ult.Atualización")]
        [ColumnDB(Name = "Editado", IsMapped = true, IsKey = false)]
        public DateTime Editado { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ColumnDB(IsMapped = false, IsKey = false)]
        public SystSelect Cat_Alergias { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [ColumnDB(IsMapped = false, IsKey = false)]
        public SystSelect Cat_TiposSangre { get; set; }
    }
}
