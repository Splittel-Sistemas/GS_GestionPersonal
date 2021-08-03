using GPSInformation.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GPSInformation.Models
{
    [TableDB(IsMappedByLabels = false, IsStoreProcedure = false, Created_at = "Creado", Updated_at = "Editado")]
    public class IncidenciaPermiso
    {
        [Display(Name = "Folio")]
        [DisplayFormat(DataFormatString = "{0:0000}", ApplyFormatInEditMode = true)]
        [ColumnDB(IsMapped = true, IsKey = true)]
        public int IdIncidenciaPermiso { get; set; }

        [Required]
        [Display(Name = "Solicitante")]
        [ColumnDB(IsMapped = true, IsKey = false)]
        public int IdPersona { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = false)]
        [Required]
        [Display(Name = "Fecha del permiso")]
        [ColumnDB(IsMapped = true, IsKey = false)]
        public DateTime Fecha { get; set; }

        [Display(Name = "Fe.Creación")]
        [ColumnDB(IsMapped = true, IsKey = false)]
        public DateTime Creado { get; set; }

        [Display(Name = "Ult.Actualizacion")]
        [ColumnDB(IsMapped = true, IsKey = false)]
        public DateTime Editado { get; set; }

        //[DisplayFormat(DataFormatString = "{0:hh:mm:ss}", ApplyFormatInEditMode = false)]
        [Required]
        [Display(Name = "Hora.Salida")]
        [ColumnDB(IsMapped = true, IsKey = false)]
        public TimeSpan Inicio { get; set; }

        //[DisplayFormat(DataFormatString = "{0:hh:mm:ss}", ApplyFormatInEditMode = false)]
        [Required]
        [Display(Name = "Hora.Regreso")]
        [ColumnDB(IsMapped = true, IsKey = false)]
        public TimeSpan Fin { get; set; }

        [Required]
        [Display(Name = "Asunto")]
        [ColumnDB(IsMapped = true, IsKey = false)]
        public int IdAsunto { get; set; }

        [Required]
        [Display(Name = "Estatus")]
        [ColumnDB(IsMapped = true, IsKey = false)]
        public int Estatus { get; set; }

        [Required]
        [Display(Name = "Comentarios")]
        [ColumnDB(IsMapped = true, IsKey = false)]
        public string DescripcionAsunto { get; set; }

        [Required]
        [Display(Name = "Tipo de permiso")]
        [ColumnDB(IsMapped = true, IsKey = false)]
        public int IdPagoPermiso { get; set; }

        [Display(Name = "Creado por")]
        [ColumnDB(IsMapped = true, IsKey = false)]
        public string CreadoPor { get; set; }


        [ColumnDB(IsMapped = false, IsKey = false)]
        public string EmpleadoNombre { get; set; }

        [Display(Name = "Asunto")]
        [ColumnDB(IsMapped = false, IsKey = false)]
        public string DEscripcionTipo { get; set; }

        [Display(Name = "Tipo de permiso")]
        [ColumnDB(IsMapped = false, IsKey = false)]
        public string PagoPermisoDesc { get; set; }

        [ColumnDB(IsMapped = false, IsKey = false)]
        public List<IncidenciaProcess> Proceso { get; set; }

        [ColumnDB(IsMapped = false, IsKey = false)]
        public string Folio
        {
            get
            {
                return string.Format("P{0:0000}", IdIncidenciaPermiso);
            }
        }

        [ColumnDB(IsMapped = false, IsKey = false)]
        public bool ActiveEdit
        {
            get
            {
                //return Estatus == 2 ? true : false;
                return false;
            }
        }

        [ColumnDB(IsMapped = false, IsKey = false)]
        public bool ActiveCancelar
        {
            get
            {
                return Estatus == 2 || Estatus == 3 || Estatus == 4? true : false;
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
                else if (Estatus == 9) return "Expirada";
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
                else if (Estatus == 9) return "info";
                else return "--";
            }
        }

        [ColumnDB(IsMapped = false, IsKey = false)]
        public string Link { get; set; }

        [ColumnDB(IsMapped = false, IsKey = false)]
        public string EncriptId { get { return Tools.EncryptData.Encrypt(IdIncidenciaPermiso + ""); } }
    }
}
