﻿using GPSInformation.Attributes;
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
    public class CapTempl
    {

        /// <summary>
        /// #
        /// </summary>
        [ColumnDB(IsMapped = true, IsKey = true, IsKeyNotIdenti = true)]
        public int IdCapTempl { get; set; }

        /// <summary>
        /// clave de la capacitacion
        /// </summary>
        [ColumnDB(IsMapped = true, IsKey = false)]
        [Required]
        public string Clave { get; set; }

        /// <summary>
        /// Nombre
        /// </summary>
        [ColumnDB(IsMapped = true, IsKey = false)]
        [Required]
        public string Nombre { get; set; }

        /// <summary>
        /// Descripción
        /// </summary>
        [ColumnDB(IsMapped = true, IsKey = false)]
        public string Descripcion { get; set; }

        /// <summary>
        /// Objetivo
        /// </summary>
        [ColumnDB(IsMapped = true, IsKey = false)]
        public string Objetivo { get; set; }

        ///// <summary>
        ///// Aplicar evaluacion por cada session
        ///// </summary>
        //[ColumnDB(IsMapped = true, IsKey = false)]
        //[Display(Name = "Aplicar evaluacion por cada session")]
        //public bool AplEvaBySess { get; set; }

        ///// <summary>
        ///// Aplicar evaluacion al termino de las sessiones
        ///// </summary>
        //[ColumnDB(IsMapped = true, IsKey = false)]
        //[Display(Name = "Aplicar evaluación al termino del curso")]
        //public bool AplEvaEnd { get; set; }

        /// <summary>
        /// Calificacion en caso de repetir curso
        /// </summary>
        [ColumnDB(IsMapped = true, IsKey = false)]
        [Display(Name = "Calificación aceptada")]
        public float CalRepet { get; set; }
        
        /// <summary>
        /// Duracion
        /// </summary>
        [ColumnDB(IsMapped = true, IsKey = false)]
        [Display(Name = "Duracion")]
        public float Duracion { get; set; }

        ///// <summary>
        ///// # referencia a template -  control versiones
        ///// </summary>
        //[ColumnDB(IsMapped = true, IsKey = false)]
        //[Display(Name = "referencia a version anterior")]
        //public int RefCapVersion { get; set; }

        ///// <summary>
        ///// Clave de version
        ///// </summary>
        //[ColumnDB(IsMapped = true, IsKey = false)]
        //[Display(Name = "Clave de version")]
        //public string ClvVersion { get; set; }

        ///// <summary>
        ///// Comentarios de version
        ///// </summary>
        //[ColumnDB(IsMapped = true, IsKey = false)]
        //[Display(Name = "Comentarios de version")]
        //public string ComtsNewVers { get; set; }

        /// <summary>
        /// Estatus
        /// </summary>
        [ColumnDB(IsMapped = true, IsKey = false)]
        public int Estatus { get; set; }
        /// <summary>
        /// No.sesiones
        /// </summary>
        [Display(Name = "No.Sesiones")]
        [ColumnDB(IsMapped = true, IsKey = false)]
        public int NoSesions { get; set; }

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
        /// <summary>
        /// 1.- en proceso
        /// 2.- en mantenimiento
        /// 3.- eliminada
        /// 4.- Disponible
        /// </summary>
        /// <param name="ShowSalbel"></param>
        /// <returns></returns>
        [ColumnDB(IsMapped = false, IsKey = false)]
        public string LabelStatus(bool ShowSalbel = false)
        {
            if (Estatus == 1) return ShowSalbel ? "<span class='badge badge-warning'><i class='icon ion-md-construct mg-r-5 tx-16 lh--9'></i>En proceso</span>" : "En proceso";
            if (Estatus == 2) return ShowSalbel ? "<span class='badge badge-warning'><i class='icon ion-md-construct mg-r-5 tx-16 lh--9'></i>En mantenimiento</span>" : "En mantenimiento";
            if (Estatus == 3) return ShowSalbel ? "<span class='badge badge-danger'><i class='icon ion-md-trash mg-r-5 tx-16 lh--9'></i>Eliminada</span>" : "Eliminada";
            if (Estatus == 4) return ShowSalbel ? "<span class='badge badge-success'><i class='icon ion-md-checkmarck-done mg-r-5 tx-16 lh--9'></i>Disponible</span>" : "Disponible";
            else return ShowSalbel ? "<span class='badge badge-light'>--</span>" : "--";
        }
    }

    /// <summary>
    /// enums para estatus del template
    /// </summary>
    public enum CapTemplEstatus
    {
        Enproceso = 1,
        Mantenimiento = 2,
        Eliminada = 3,
        Disponible = 4,
        Todas = 5
    }
    /// <summary>
    /// registro de cambios estatus
    /// </summary>
    [TableDB(IsMappedByLabels = false, IsStoreProcedure = false)]
    public class CapTemplStatusStand
    {
        [ColumnDB(IsMapped = true, IsKey = true)]
        public int IdRegistry { get; set; }

        [ColumnDB(IsMapped = true, IsKey = false)]
        public int IdCapTempl { get; set; }

        [ColumnDB(IsMapped = true, IsKey = false)]
        public DateTime Inicio { get; set; }

        [ColumnDB(IsMapped = true, IsKey = false)]
        public DateTime Fin { get; set; }

        [ColumnDB(IsMapped = true, IsKey = false)]
        public bool Actual { get; set; }
        
        [ColumnDB(IsMapped = true, IsKey = false)]
        public int Estatus { get; set; }
    }

    /// <summary>
    /// tabla de estrucutra de seguimiento
    /// </summary>
    [TableDB(IsMappedByLabels = false, IsStoreProcedure = false, Created_at = "Creada", Updated_at = "Editada")]
    public class CapTemplShedule
    {
        [ColumnDB(IsMapped = true, IsKey = true, IsKeyNotIdenti = true)]
        public int IdCapTemplShedule  { get; set; }

        [ColumnDB(IsMapped = true, IsKey = false)]
        public int IdCapTempl { get; set; }

        [ColumnDB(IsMapped = true, IsKey = false)]
        public int IdRefer { get; set; }

        [ColumnDB(IsMapped = true, IsKey = false)]
        public int Tipo { get; set; }

        [ColumnDB(IsMapped = true, IsKey = false)]
        public int Ordern { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ColumnDB(IsMapped = true, IsKey = false)]
        public bool Eliminada { get; set; }

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

        [ColumnDB(IsMapped = false, IsKey = false)]
        public string Title { get; set; }

        [ColumnDB(IsMapped = false, IsKey = false)]
        public string Rute { get; set; }

        [ColumnDB(IsMapped = false, IsKey = false)]
        public string LabelTipo(bool ShowSalbel = false)
        {
            if (Tipo == 1) return ShowSalbel ? "<span class='badge badge-warning'><i class='icon ion-md-construct mg-r-5 tx-16 lh--9'></i>Evaluacion</span>" : "Evaluacion";
            if (Tipo == 2) return ShowSalbel ? "<span class='badge badge-warning'><i class='icon ion-md-construct mg-r-5 tx-16 lh--9'></i>Session</span>" : "Session";
            else return ShowSalbel ? "<span class='badge badge-light'>--</span>" : "--";
        }
    }

    /// <summary>
    /// sessiones del curso
    /// </summary>
    [TableDB(IsMappedByLabels = false, IsStoreProcedure = false, Created_at = "Creada", Updated_at = "Editada")]
    public class CapSess
    {

        /// <summary>
        /// 
        /// </summary>
        [ColumnDB(IsMapped = true, IsKey = true, IsKeyNotIdenti = true)]
        public int IdCapSess { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ColumnDB(IsMapped = true, IsKey = false)]
        public int IdCapTempl { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ColumnDB(IsMapped = true, IsKey = false)]
        public int NoSession { get; set; }

        /// <summary>
        /// Duracion
        /// </summary>
        [ColumnDB(IsMapped = true, IsKey = false)]
        [Display(Name = "Duracion")]
        public decimal Duracion { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ColumnDB(IsMapped = true, IsKey = false)]
        public bool Eliminada { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ColumnDB(IsMapped = true, IsKey = false)]
        public string Nombre { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ColumnDB(IsMapped = true, IsKey = false)]
        public string Objetivo { get; set; }

        ///// <summary>
        ///// Aplicar evaluacion al termino de las sessiones
        ///// </summary>
        //[ColumnDB(IsMapped = true, IsKey = false)]
        //[Display(Name = "Aplicar evaluación")]
        //public bool AplEva { get; set; }

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

    /// <summary>
    /// temas de la session
    /// </summary>
    [TableDB(IsMappedByLabels = false, IsStoreProcedure = false, Created_at = "Creada", Updated_at = "Editada")]
    public class CapTema
    {

        /// <summary>
        /// 
        /// </summary>
        [ColumnDB(IsMapped = true, IsKey = true, IsKeyNotIdenti = true)]
        public int IdCapTema { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ColumnDB(IsMapped = true, IsKey = false)]
        public int IdCapSess { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ColumnDB(IsMapped = true, IsKey = false)]
        public string Nombre { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ColumnDB(IsMapped = true, IsKey = false)]
        public string Descripcion { get; set; }


        ///// <summary>
        ///// Aplicar evaluacion al termino de las sessiones
        ///// </summary>
        //[ColumnDB(IsMapped = true, IsKey = false)]
        //[Display(Name = "Aplicar evaluación")]
        //public bool AplEva { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ColumnDB(IsMapped = true, IsKey = false)]
        public bool Eliminada { get; set; }

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

    /// <summary>
    /// template de evaluacion
    /// </summary>
    [TableDB(IsMappedByLabels = false, IsStoreProcedure = false, Created_at = "Creada", Updated_at = "Editada")]
    public class CapEva
    {

        /// <summary>
        /// 
        /// </summary>
        [ColumnDB(IsMapped = true, IsKey = true, IsKeyNotIdenti = true)]
        public int IdCapEva { get; set; }

        /// <summary>
        /// Nombre de la evaluacion
        /// </summary>
        [ColumnDB(IsMapped = true, IsKey = false)]
        public string Nombre { get; set; }

        /// <summary>
        /// Descripcion de la evalaucion
        /// </summary>
        [ColumnDB(IsMapped = true, IsKey = false)]
        public string Decripcion { get; set; }

        ///// <summary>
        ///// 
        ///// </summary>
        //[ColumnDB(IsMapped = true, IsKey = false)]
        //public string ClvVersion { get; set; }

        ///// <summary>
        ///// 
        ///// </summary>
        //[ColumnDB(IsMapped = true, IsKey = false)]
        //public int CapEvaVer { get; set; }

        /// <summary>
        /// Duración de la evaluacion
        /// </summary>
        [ColumnDB(IsMapped = true, IsKey = false)]
        public float HrsDurac { get; set; }


        /// <summary>
        /// Estatus de la evaluacion
        /// </summary>
        [ColumnDB(IsMapped = true, IsKey = false)]
        public int Estatus { get; set; }

        /// <summary>
        /// Aplicar tiempo
        /// </summary>
        [ColumnDB(IsMapped = true, IsKey = false)]
        public bool AplTime { get; set; }

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

        [ColumnDB(IsMapped = false, IsKey = false)]
        public string LabelStatus(bool ShowSalbel = false)
        {
            if (Estatus == 1) return ShowSalbel ? "<span class='badge badge-warning'><i class='icon ion-md-construct mg-r-5 tx-16 lh--9'></i>En proceso</span>" : "En proceso";
            if (Estatus == 2) return ShowSalbel ? "<span class='badge badge-warning'><i class='icon ion-md-construct mg-r-5 tx-16 lh--9'></i>En mantenimiento</span>" : "En mantenimiento";
            if (Estatus == 3) return ShowSalbel ? "<span class='badge badge-danger'><i class='icon ion-md-trash mg-r-5 tx-16 lh--9'></i>Eliminada</span>" : "Eliminada";
            if (Estatus == 4) return ShowSalbel ? "<span class='badge badge-success'><i class='icon ion-md-checkmarck-done mg-r-5 tx-16 lh--9'></i>Disponible</span>" : "Disponible";
            else return ShowSalbel ? "<span class='badge badge-light'>--</span>" : "--";
        }
    }

    /// <summary>
    /// preguntas de la evaluacion
    /// </summary>
    [TableDB(IsMappedByLabels = false, IsStoreProcedure = false, Created_at = "Creada", Updated_at = "Editada")]
    public class CapEvaPrg
    {

        /// <summary>
        /// 
        /// </summary>
        [ColumnDB(IsMapped = true, IsKey = true, IsKeyNotIdenti = true)]
        public int IdCapEvaPrg { get; set; }

        /// <summary>
        /// Descripcion de la pregunta
        /// </summary>
        [ColumnDB(IsMapped = true, IsKey = false)]
        public string Pregunta { get; set; }


        /// <summary>
        /// Comentarios
        /// </summary>
        [ColumnDB(IsMapped = true, IsKey = false)]
        public string Comentarios { get; set; }

        /// <summary>
        /// Evaluacion
        /// </summary>
        [ColumnDB(IsMapped = true, IsKey = false)]
        public int IdCapEva { get; set; }

        /// <summary>
        /// Tipo de pregunta
        /// </summary>
        [ColumnDB(IsMapped = true, IsKey = false)]
        public string Tipo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ColumnDB(IsMapped = true, IsKey = false)]
        public int Puntaje { get; set; }

        [ColumnDB(IsMapped = false, IsKey = false)]
        public string LabelStatus(bool ShowSalbel = false)
        {
            if (Tipo == "T") return ShowSalbel ? "<span class='badge badge-warning'><i class='icon ion-md-construct mg-r-5 tx-16 lh--9'></i>Abierta</span>" : "Abierta";
            else if (Tipo == "O") return ShowSalbel ? "<span class='badge badge-warning'><i class='icon ion-md-construct mg-r-5 tx-16 lh--9'></i>Opcional</span>" : "Opcional";
            else if (Tipo == "M") return ShowSalbel ? "<span class='badge badge-danger'><i class='icon ion-md-trash mg-r-5 tx-16 lh--9'></i>Multiple opción</span>" : "Multiple opción";
            else return ShowSalbel ? "<span class='badge badge-light'>--</span>" : "--";
        }

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

        [ColumnDB(IsMapped = false, IsKey = false)]
        public List<CapEvaPrgRes> CapEvaPrgList { get; set; }
    }

    /// <summary>
    /// respuestas para preguntas
    /// </summary>
    [TableDB(IsMappedByLabels = false, IsStoreProcedure = false, Created_at = "Creada", Updated_at = "Editada")]
    public class CapEvaPrgRes
    {

        /// <summary>
        /// 
        /// </summary>
        [ColumnDB(IsMapped = true, IsKey = true, IsKeyNotIdenti = true)]
        public int IdCapEvaPrgRes { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ColumnDB(IsMapped = true, IsKey = false)]
        public int IdCapEvaPrg { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ColumnDB(IsMapped = true, IsKey = false)]
        public string Respuesta { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ColumnDB(IsMapped = true, IsKey = false)]
        public bool EsCorrecta { get; set; }

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

    //[TableDB(IsMappedByLabels = false, IsStoreProcedure = false, Created_at = "Creada", Updated_at = "Editada")]
    //public class CapSessEva
    //{

    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    [ColumnDB(IsMapped = true, IsKey = true, IsKeyNotIdenti = true)]
    //    public int IdCapSessEva { get; set; }

    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    [ColumnDB(IsMapped = true, IsKey = false)]
    //    public int IdCapEva { get; set; }

    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    [ColumnDB(IsMapped = true, IsKey = false)]
    //    public int IdCapSess { get; set; }
    //}

    /// <summary>
    /// 
    /// </summary>
    [TableDB(IsMappedByLabels = false, IsStoreProcedure = false, Created_at = "Creada", Updated_at = "Editada")]
    public class CapProg
    {

        /// <summary>
        /// 
        /// </summary>
        [ColumnDB(IsMapped = true, IsKey = true, IsKeyNotIdenti = true)]
        public int IdCapProg { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ColumnDB(IsMapped = true, IsKey = false)]
        public int IdCapTempl { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ColumnDB(IsMapped = true, IsKey = false)]
        public int Estatus { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ColumnDB(IsMapped = true, IsKey = false)]
        public DateTime FePubli { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ColumnDB(IsMapped = true, IsKey = false)]
        public DateTime FeCierre { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ColumnDB(IsMapped = true, IsKey = false)]
        public DateTime Creada { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ColumnDB(IsMapped = true, IsKey = false)]
        public DateTime Editada { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    [TableDB(IsMappedByLabels = false, IsStoreProcedure = false, Created_at = "Creada", Updated_at = "Editada")]
    public class CapProgPonts
    {

        /// <summary>
        /// 
        /// </summary>
        [ColumnDB(IsMapped = true, IsKey = true, IsKeyNotIdenti = true)]
        public int IdCapProgPonts { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ColumnDB(IsMapped = true, IsKey = false)]
        public int IdCapProg { get; set; }

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

        /// <summary>
        /// 
        /// </summary>
        [ColumnDB(IsMapped = true, IsKey = false)]
        public string Puesto { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ColumnDB(IsMapped = true, IsKey = false)]
        public char Tipo { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    [TableDB(IsMappedByLabels = false, IsStoreProcedure = false, Created_at = "Creada", Updated_at = "Editada")]
    public class CapProgSess
    {

        /// <summary>
        /// 
        /// </summary>
        [ColumnDB(IsMapped = true, IsKey = true, IsKeyNotIdenti = true)]
        public int IdCapProgSess { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ColumnDB(IsMapped = true, IsKey = false)]
        public int IdCapProg { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ColumnDB(IsMapped = true, IsKey = false)]
        public int IdCapSess { get; set; }
        public DateTime Fecha { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ColumnDB(IsMapped = true, IsKey = false)]
        public TimeSpan HrInicio { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ColumnDB(IsMapped = true, IsKey = false)]
        public TimeSpan HrFin { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ColumnDB(IsMapped = true, IsKey = false)]
        public float Duracion { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ColumnDB(IsMapped = true, IsKey = false)]
        public bool EsReprog { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ColumnDB(IsMapped = true, IsKey = false)]
        public string ComtsReprog { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ColumnDB(IsMapped = true, IsKey = false)]
        public bool Ultima { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ColumnDB(IsMapped = true, IsKey = false)]
        public DateTime Creada { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ColumnDB(IsMapped = true, IsKey = false)]
        public DateTime Editada { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    [TableDB(IsMappedByLabels = false, IsStoreProcedure = false, Created_at = "Creada", Updated_at = "Editada")]
    public class CapProgEmp
    {

        /// <summary>
        /// 
        /// </summary>
        [ColumnDB(IsMapped = true, IsKey = true, IsKeyNotIdenti = true)]
        public int IdCapProgEmp { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ColumnDB(IsMapped = true, IsKey = false)]
        public int IdCapProg { get; set; }

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

        /// <summary>
        /// 
        /// </summary>
        [ColumnDB(IsMapped = true, IsKey = false)]
        public string Puesto { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ColumnDB(IsMapped = true, IsKey = false)]
        public DateTime Creada { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ColumnDB(IsMapped = true, IsKey = false)]
        public DateTime Editada { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    [TableDB(IsMappedByLabels = false, IsStoreProcedure = false, Created_at = "Creada", Updated_at = "Editada")]
    public class CapProgEmpSes
    {

        /// <summary>
        /// 
        /// </summary>
        [ColumnDB(IsMapped = true, IsKey = true, IsKeyNotIdenti = true)]
        public int IdCapProgEmpSes { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ColumnDB(IsMapped = true, IsKey = false)]
        public int IdCapProg { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ColumnDB(IsMapped = true, IsKey = false)]
        public int IdCapSess { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ColumnDB(IsMapped = true, IsKey = false)]
        public int IdCapEva { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ColumnDB(IsMapped = true, IsKey = false)]
        public float Calificacion { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ColumnDB(IsMapped = true, IsKey = false)]
        public string Comentarios { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ColumnDB(IsMapped = true, IsKey = false)]
        public DateTime Creada { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ColumnDB(IsMapped = true, IsKey = false)]
        public DateTime Editada { get; set; }
    }

}
