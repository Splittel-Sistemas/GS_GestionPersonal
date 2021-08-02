using GPSInformation.Attributes;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GPSInformation.Models
{
    [TableDB(IsMappedByLabels = false, IsStoreProcedure = false, Created_at = "Creado", Updated_at = "Editado")]
    public class IncidenciaVacacion
    {
        [Display(Name = "Folio")]
        [DisplayFormat(DataFormatString = "{0:0000}", ApplyFormatInEditMode = true)]
        [ColumnDB(IsMapped = true, IsKey = true)]
        public int IdIncidenciaVacacion { get; set; }

        [Display(Name = "Solicitante")]
        [ColumnDB(IsMapped = true, IsKey = false)]
        public int IdPersona { get; set; }

        [Required]
        [Display(Name = "Inicio")]
        [ColumnDB(IsMapped = true, IsKey = false)]
        public DateTime Inicio { get; set; }

        [Required]
        [Display(Name = "Fin")]
        [ColumnDB(IsMapped = true, IsKey = false)]
        public DateTime Fin { get; set; }

        [Display(Name = "No.Días")]
        [ColumnDB(IsMapped = true, IsKey = false)]
        public int NoDias { get; set; }

        [Display(Name = "Creado por")]
        [ColumnDB(IsMapped = true, IsKey = false)]
        public string CreadoPor { get; set; }

        [Display(Name = "Estatus")]
        [ColumnDB(IsMapped = true, IsKey = false)]
        public int Estatus { get; set; }

        [Display(Name = "No.Autorizaciones")]
        [ColumnDB(IsMapped = true, IsKey = false)]
        public int NumAutorizaciones { get; set; }

        [Display(Name = "Tipo solicitud")]
        [ColumnDB(IsMapped = true, IsKey = false)]
        public string Tipo { get; set; }

        [Display(Name = "Fe.Creación")]
        [ColumnDB(IsMapped = true, IsKey = false)]
        public DateTime Creado { get; set; }

        [Display(Name = "Ult.Actualizacion")]
        [ColumnDB(IsMapped = true, IsKey = false)]
        public DateTime Editado { get; set; }

        [Display(Name = "Archivo")]
        [ColumnDB(IsMapped = true, IsKey = false)]
        public string ArchivoScan { get; set; }
        
        [Display(Name = "Archivo")]
        [ColumnDB(IsMapped = false, IsKey = false)]
        public IFormFile Archivo { get; set; }

        [ColumnDB(IsMapped = false, IsKey = false)]
        public List<IncidenciaProcess> Proceso { get; set; }

        [ColumnDB(IsMapped = false, IsKey = false)]
        public string Folio 
        { 
            get 
            { 
                return string.Format("V-{0:0000}", IdIncidenciaVacacion); 
            } 
        }

        [ColumnDB(IsMapped = false, IsKey = false)]
        public string EmpleadoNombre { get; set; }


        [ColumnDB(IsMapped = false, IsKey = false)]
        public bool ActiveEdit
        {
            get
            {
                return Estatus == 2 ? true : false;
            }
        }

        [ColumnDB(IsMapped = false, IsKey = false)]
        public bool ActiveCancelar
        {
            get
            {
                return Estatus == 2 || Estatus == 3 || Estatus == 4 ? true : false;
            }
        }

        [ColumnDB(IsMapped = false, IsKey = false)]
        public string EstatusDescricion
        {
            get
            {
                if (Estatus == 1) return "Solicitud creada";
                else if (Estatus == 2) return "Jefe inmediado";
                else if (Estatus == 3) return "Gestión personal";
                else if (Estatus == 4) return "Autorizada";
                else if (Estatus == 5) return "Councluida";
                else if (Estatus == 6) return "Cancelada";
                else if (Estatus == 7) return "Rechazada";
                else if (Estatus == 8) return "Eliminada";
                else return "--";
            }
        }

        [ColumnDB(IsMapped = false, IsKey = false)]
        public string EstatusColor
        {
            get
            {
                if (Estatus == 1) return "info";
                else if (Estatus == 2) return "info";
                else if (Estatus == 3) return "info";
                else if (Estatus == 4) return "success";
                else if (Estatus == 5) return "success";
                else if (Estatus == 6) return "warning";
                else if (Estatus == 7) return "danger";
                else if (Estatus == 8) return "info";
                else return "--";
            }
        }

        [ColumnDB(IsMapped = false, IsKey = false)]
        public string Link { get; set; }
    }

    [TableDB(IsMappedByLabels = false, IsStoreProcedure = false)]
    public class IncidenciaProcess
    {
        [ColumnDB(IsMapped = true, IsKey = true)]
        public int IdIncidenciaProcess { get; set; }

        [Display(Name = "IdIncidenciaVacacion")]
        [DisplayFormat(DataFormatString = "{0:0000}", ApplyFormatInEditMode = true)]
        [ColumnDB(IsMapped = true, IsKey = false)]
        public int? IdIncidenciaVacacion { get; set; }

        [Display(Name = "IdIncidenciaPermiso")]
        [DisplayFormat(DataFormatString = "{0:0000}", ApplyFormatInEditMode = true)]
        [ColumnDB(IsMapped = true, IsKey = false)]
        public int? IdIncidenciaPermiso { get; set; }

        [Display(Name = "Aprobador")]
        [ColumnDB(IsMapped = true, IsKey = false)]
        public int IdPersona { get; set; }

        [Display(Name = "Fecha")]
        [ColumnDB(IsMapped = true, IsKey = false)]
        public DateTime? Fecha { get; set; }

        [Display(Name = "Comentarios")]
        [ColumnDB(IsMapped = true, IsKey = false)]
        public string Comentarios { get; set; }

        [Display(Name = "Fue revisada")]
        [ColumnDB(IsMapped = true, IsKey = false)]
        public bool Revisada { get; set; }

        [Display(Name = "Autorizada")]
        [ColumnDB(IsMapped = true, IsKey = false)]
        public bool Autorizada { get; set; }

        [Display(Name = "Nivel")]
        [ColumnDB(IsMapped = true, IsKey = false)]
        public int Nivel { get; set; }

        [Display(Name = "Titulo")]
        [ColumnDB(IsMapped = true, IsKey = false)]
        public string Titulo { get; set; }

        [Display(Name = "Nombre del Empleado")]
        [ColumnDB(IsMapped = true, IsKey = false)]
        public string NombreEmpleado { get; set; }
    }
}
