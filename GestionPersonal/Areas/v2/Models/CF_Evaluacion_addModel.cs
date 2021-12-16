using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestionPersonal.Areas.v2.Models
{
    public class CF_Evaluacion_addModel
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Descripcion { get; set; }
        public bool Activa { get; set; }
    }
    public class CF_Evaluacion_updModel
    {
        public int IdCF_Evaluacion { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Descripcion { get; set; }
        public bool Activa { get; set; }
    }

    public class CF_EvaluacionVersion_addModel
    {
        public int IdCF_Evaluacion { get; set; }
        [Required]
        public string Comentarios { get; set; }
        public string Instrucciones { get; set; }
        public decimal MinCalificacion { get; set; }
        public bool Aleatory { get; set; }
        public bool BySecciones { get; set; }
    }

    public class CF_EvaluacionVersion_updModel
    {
        public int IdCF_EvaluacionVersion { get; set; }
        public int IdCF_Evaluacion { get; set; }
        [Required]
        public string Comentarios { get; set; }
        public string Instrucciones { get; set; }
        public decimal MinCalificacion { get; set; }
        public bool Aleatory { get; set; }
        public bool BySecciones { get; set; }
    }

    public class CF_EvaluacionSeccion_addModel
    {
        [Required]
        public string Nombre { get; set; }
        public int IdCF_EvaluacionVersion { get; set; }
    }

    public class CF_EvaluacionSeccion_updModel
    {
        public int IdCF_EvaluacionSeccion { get; set; }
        [Required]
        public string Nombre { get; set; }
        public int IdCF_EvaluacionVersion { get; set; }
    }


    public class CF_EvaluacionPreg_addModel
    {
        public int IdCF_EvaluacionVersion { get; set; }
        public int IdCF_EvaluacionSeccion { get; set; }
        [Required]
        public string Pregunta { get; set; }
        public IFormFile Contenido { get; set; }
        public string Tipo { get; set; }
        public int Orden { get; set; }
    }

    public class CF_EvaluacionPreg_updModel
    {
        public int IdCF_EvaluacionPreg { get; set; }
        public int IdCF_EvaluacionVersion { get; set; }
        public int IdCF_EvaluacionSeccion { get; set; }
        [Required]
        public string Pregunta { get; set; }
        public IFormFile Contenido { get; set; }
        [Required]
        public string Tipo { get; set; }
        public int Orden { get; set; }
    }

    public class CF_EvaluacionPregRes_addModel
    {
        public int IdCF_EvaluacionPreg { get; set; }
        public string Respuesta { get; set; }
        public IFormFile ImgOpcion { get; set; }
    }

    public class CF_EvaluacionPregRes_updModel
    {
        public int IdCF_EvaluacionPregRes { get; set; }
        public int IdCF_EvaluacionPreg { get; set; }
        public string Respuesta { get; set; }
        public IFormFile ImgOpcion { get; set; }
    }

}
