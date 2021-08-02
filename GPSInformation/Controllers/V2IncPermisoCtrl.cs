﻿using GPSInformation.Exceptions;
using GPSInformation.Models;
using GPSInformation.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace GPSInformation.Controllers
{
    public class V2IncPermisoCtrl
    {
        #region Atributos
        /// <summary>
        /// controlador de objetos 
        /// </summary>
        public DarkManager _darkM { get; internal set; }
        /// <summary>
        /// controlador para acciones de usuario
        /// </summary>
        public UsuarioCtrl _UsrCrt;
        /// <summary>
        /// Cargar transacciones por metodo
        /// </summary>
        public bool LoadTranssByMethod { get; set; }
        /// <summary>
        /// Id del usuario
        /// </summary>
        public int _IdUsuario { get; internal set; }
        /// <summary>
        /// Id de la persona
        /// </summary>
        public int _IdPersona { get; internal set; }
        /*
         *30.-lectura y escritura de incidencias
         *32.-Autorización jefe directo de incidencias
         *36.-Autorización gestion personal en incidencias
         *46.-Administrar periodos de vacaciones
         *1055.-Incidencias(administrador) 
         */
        public readonly int _ALecturaEscritura = 30;
        /// <summary>
        /// administrar incidencias por jefe inmediato
        /// </summary>
        public readonly int _AauthJefeInmediato = 32;
        /// <summary>
        /// autorizar incidencias GPS
        /// </summary>
        public readonly int _AauthAdminGPS = 36;
        /// <summary>
        /// Administrar periodos de empleados ajustes
        /// </summary>
        public readonly int _AadminPeriodos = 46;
        /// <summary>
        /// administrar incidencias (lectura de todo)
        /// </summary>
        public readonly int _AincidenciasAdmin = 1055;
        /// <summary>
        /// crear, editar incidencias a otros empleados
        /// </summary>
        public readonly int _ALecturaEscrituraAdmin = 1058;
        /// <summary>
        /// ids de permisos por usuario en session
        /// </summary>
        public List<AccesosUs> _Accesos { get; internal set; }
        #endregion

        #region Constructores
        public V2IncPermisoCtrl(DarkManager darkManager, int IdUsuario, int IdPersona)
        {
            this._darkM = darkManager;
            this._IdUsuario = IdUsuario;
            this._IdPersona = IdPersona;
            this._darkM.OpenConnection();
            this._darkM.LoadObject(GpsManagerObjects.IncidenciaPermiso);
            this._darkM.LoadObject(GpsManagerObjects.IncidenciaProcess);
            this._darkM.LoadObject(GpsManagerObjects.CatalogoOpcionesValores);
            this._darkM.LoadObject(GpsManagerObjects.View_empleado);
            this._darkM.LoadObject(GpsManagerObjects.View_EmpleadoJefe);
            this._darkM.LoadObject(GpsManagerObjects.AccesosSistema);
            this._darkM.LoadObject(GpsManagerObjects.Usuario);

            _UsrCrt = new UsuarioCtrl(_darkM, true);

            //obtener permisos
            _Accesos = _UsrCrt.ValidatePermis(IdUsuario, new int[] { _ALecturaEscritura, _AauthJefeInmediato, _AauthAdminGPS, _AadminPeriodos, _AincidenciasAdmin, _ALecturaEscrituraAdmin });
        }
        #endregion

        #region Metodos
        /// <summary>
        /// 
        /// </summary>
        /// <param name="IdIncidencia"></param>
        public void Eliminar(int IdIncidencia)
        {
            var details = Details(IdIncidencia);
            if (!_Accesos.Find(a => a.IdSubModulo == _ALecturaEscrituraAdmin).TieneAcceso)
            {
                throw new GPException { Description = $"Estimado usuario no tienes permisos para crear solicitudes a otros colaboradores", ErrorCode = 0, Category = TypeException.Noautorizado, IdAux = "" };
            }

            details.Estatus = 8;
            _darkM.IncidenciaPermiso.Element = details;

            _darkM.IncidenciaPermiso.Update();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="IdIncidencia"></param>
        public void Cancelar(int IdIncidencia)
        {
            var details = Details(IdIncidencia);
            if (details.IdPersona != _IdPersona)
            {
                if (!_Accesos.Find(a => a.IdSubModulo == _ALecturaEscrituraAdmin).TieneAcceso)
                {
                    throw new GPException { Description = $"Estimado usuario no tienes permisos para crear solicitudes a otros colaboradores", ErrorCode = 0, Category = TypeException.Noautorizado, IdAux = "" };
                }
            }
            if (!details.ActiveCancelar)
                throw new GPException { Description = $"Estimado usuario no es posible procesar la incidencia solicitada, estatus actual: {details.EstatusDescricion}", ErrorCode = 0, Category = TypeException.Info, IdAux = "" };
            if (details.Fecha >= DateTime.Now)
                throw new GPException { Description = $"Estimado usuario ya no puedes cancelar esta solicitud, las cancelaciones deberam de hacerce un dia antes", ErrorCode = 0, Category = TypeException.Info, IdAux = "" };
            details.Estatus = 6;
            _darkM.IncidenciaPermiso.Element = details;

            _darkM.IncidenciaPermiso.Update();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="inAutorizacion"></param>
        public void Autorizar(InAutorizacion inAutorizacion)
        {
            var details = Details(inAutorizacion.IdIncidencia);
            if (details.Estatus != 2 && details.Estatus != 3)
            {
                throw new GPException { Description = $"Estimado usuario no es posible procesar la incidencia solicitada, estatus actual: {details.EstatusDescricion}", ErrorCode = 0, Category = TypeException.Info, IdAux = "" };
            }

            if(inAutorizacion.Mode != 2 && inAutorizacion.Mode != 3)
            {
                throw new GPException { Description = $"Estimado usuario no es valido tu autorización, datos incorrectos", ErrorCode = 0, Category = TypeException.Info, IdAux = "" };
            }

            if(inAutorizacion.Mode == details.Estatus)
            {
                var proceso = details.Proceso.Find(a => a.Nivel == inAutorizacion.Mode);
                proceso.Comentarios = inAutorizacion.Comentarios;
                proceso.IdPersona = inAutorizacion.IdAutorizante;
                proceso.NombreEmpleado = _darkM.IncidenciaPermiso.GetStringValue($"select NombreCompleto from View_empleado where IdPersona = {inAutorizacion.IdAutorizante}");
                proceso.Revisada = true;
                proceso.Autorizada = inAutorizacion.Autoriza;
                proceso.Fecha = DateTime.Now;
                proceso.IdIncidenciaPermiso = inAutorizacion.IdIncidencia;
                _darkM.IncidenciaProcess.Element = proceso;
                _darkM.IncidenciaProcess.Update();


                if (inAutorizacion.Autoriza)
                    details.Estatus = details.Estatus + 1;
                else
                    details.Estatus = 7;

                _darkM.IncidenciaPermiso.Element = details;

                _darkM.IncidenciaPermiso.Update();
            }
            else
            {
                var proceso = details.Proceso.Find(a => a.Nivel == inAutorizacion.Mode);
                if (proceso.Revisada)
                {
                    throw new GPException { Description = $"Estimado usuario ya fue procesada esta autorización", ErrorCode = 0, Category = TypeException.Info, IdAux = "" };
                }
                else
                {
                    throw new GPException { Description = $"Estimado usuario aun no es requerida esta autorización", ErrorCode = 0, Category = TypeException.Info, IdAux = "" };
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<IncidenciaPermiso> GetAdmin()
        {
            if(!_Accesos.Find(a => a.IdSubModulo == _ALecturaEscrituraAdmin).TieneAcceso)
            {
                throw new GPException { Description = $"Estimado usuario no tienes permisos para crear solicitudes a otros colaboradores", ErrorCode = 0, Category = TypeException.Noautorizado, IdAux = "" };
            }

            var data = _darkM.IncidenciaPermiso.GetOpenquery($"","Order by Creado");

            data.ForEach(result => LLenarTodo(result));
            return data;
        }
        public void EnviarNotificacion(int IdIncidenciaPermiso, string Body)
        {
            if (!string.IsNullOrEmpty(Body))
            {
                string asunto = "";
                bool send = false;
                var details = Details(IdIncidenciaPermiso);
                //Solicitud creada
                if (details.Estatus == 1)
                {
                    asunto = $"Solicitud de permiso {details.Folio} creada";
                }
                //Jefe inmediado
                else if (details.Estatus == 2)
                {
                    asunto = $"Nuevo permiso {details.Folio} - Aprobación N1";
                    send = true;

                    _darkM.View_EmpleadoJefe.GetOpenquery($"where EIdPersona = {details.IdPersona}", "").ForEach(a => _darkM.EmailServ_.AddListTO(a.JCorreo));
                    _darkM.EmailServ_.AddListTO(_darkM.View_EmpleadoJefe.GetStringValue($"select Correo from View_empleado where IdPersona = " +
                        $"(select top 1 t01.IdIncidenciaAuthAux from IncidenciaAuthAux as t01 where t01.IdPersona = {details.IdPersona} and Activa = 1)"));
                }
                //Gestión personal
                else if (details.Estatus == 3)
                {
                    asunto = $"Nuevo permiso {details.Folio} - Aprobación N2";
                    send = true;

                    _darkM.AccesosSistema.GetOpenquery($"where IdSubModulo = {_AauthAdminGPS} and TieneAcceso = 1", "").ForEach(a =>
                    {
                        var usuario = _darkM.Usuario.Get(a.IdUsuario);
                        if(usuario != null)
                        {
                            var empleado = _darkM.View_empleado.GetOpenquerys($"where IdPersona = {usuario.IdPersona}");
                            if(empleado != null)
                            {
                                _darkM.EmailServ_.AddListTO(empleado.Correo);
                            }
                        }
                    });
                }
                //Autorizada
                else if (details.Estatus == 4)
                {
                    asunto = $"Solicitud de permiso {details.Folio} autorizada";
                    send = true;
                    var empleado = _darkM.View_empleado.GetOpenquerys($"where IdPersona = {details.IdPersona}");
                    if (empleado != null)
                    {
                        _darkM.EmailServ_.AddListTO(empleado.Correo);
                    }
                }
                //Councluida
                else if (details.Estatus == 5)
                {
                    asunto = $"Solicitud de permiso {details.Folio} concluida";

                }
                //Cancelada
                else if (details.Estatus == 6)
                {
                    asunto = $"Solicitud de permiso {details.Folio} cancelada";
                    send = true;
                    var empleado = _darkM.View_empleado.GetOpenquerys($"where IdPersona = {details.IdPersona}");
                    if (empleado != null)
                    {
                        _darkM.EmailServ_.AddListTO(empleado.Correo);
                    }
                }
                //Rechazada
                else if (details.Estatus == 7)
                {
                    asunto = $"Solicitud de permiso {details.Folio} rechazada";
                    send = true;
                    var empleado = _darkM.View_empleado.GetOpenquerys($"where IdPersona = {details.IdPersona}");
                    if (empleado != null)
                    {
                        _darkM.EmailServ_.AddListTO(empleado.Correo);
                    }
                }
                //Eliminada
                else if (details.Estatus == 8)
                {
                    asunto = $"Solicitud de permiso {details.Folio} eliminada";
                }
                else 
                { 
                }
                if(send == true)
                {
                    _darkM.EmailServ_.Send(Body, asunto);
                    _darkM.RestartEmail();
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<IncidenciaPermiso> GetByUsuario()
        {
            var data = _darkM.IncidenciaPermiso.GetOpenquery($" where IdPersona = {_IdPersona }", "Order by Creado");

            data.ForEach(result => LLenarTodo(result));
            return data;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<IncidenciaPermiso> GetByJefeInmediato()
        {
            if (!_Accesos.Find(a => a.IdSubModulo == _AauthJefeInmediato).TieneAcceso)
            {
                throw new GPException { Description = $"Estimado usuario no tienes permisos para esta sección", ErrorCode = 0, Category = TypeException.Noautorizado, IdAux = "" };
            }
            var data = _darkM.IncidenciaPermiso.GetOpenquery($" as t01 where t01.Estatus = 2 and (t01.IdPersona in (select t02.EIdPersona from View_EmpleadoJefe as t02 where t02.JIdpersona = {_IdPersona}) or " +
                $" or t01.IdPersona in (select t01.IdPersona from IncidenciaAuthAux as t02 where t02.IdPersonaAuth = {_IdPersona} and t02.Activa = 1 ) )", "Order by Creado");
            data.ForEach(result => LLenarTodo(result));
            return data;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<IncidenciaPermiso> GetByGPSAdmin()
        {
            if (!_Accesos.Find(a => a.IdSubModulo == _AauthAdminGPS).TieneAcceso)
            {
                throw new GPException { Description = $"Estimado usuario no tienes permisos para esta sección", ErrorCode = 0, Category = TypeException.Noautorizado, IdAux = "" };
            }
            var data = _darkM.IncidenciaPermiso.GetOpenquery($" as t01 where t01.Estatus = 3 ", "Order by Creado");
            data.ForEach(result => LLenarTodo(result));
            return data;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="IdIncidenciaPermiso"></param>
        /// <returns></returns>
        public IncidenciaPermiso Details(int IdIncidenciaPermiso, bool LanzarExcep = false)
        {
            var result = _darkM.IncidenciaPermiso.Get(IdIncidenciaPermiso);

            LLenarTodo(result, true);

            if (LanzarExcep && result is null)
            {
                throw new GPException { Description = $"Estimado usuario noo se encontró la incidencia seleccionada", ErrorCode = 0, Category = TypeException.NotFound, IdAux = "" };
            }


            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="IdIncidenciaPermiso"></param>
        /// <param name="Nivel"></param>
        /// <param name="IncidenciaPermiso"></param>
        public void ValidarAcciones(V2IncValidation mode, int IdIncidenciaPermiso = 0, int Nivel = 0, IncidenciaPermiso IncidenciaPermiso = null)
        {
            if(mode == V2IncValidation.Create || mode == V2IncValidation.Edit)
            {
                if(IncidenciaPermiso is null )
                {
                    throw new GPException { Description = $"Estimado usuario por favor verifica tu información", ErrorCode = 0, Category = TypeException.Error, IdAux = "" };
                }

                if(IncidenciaPermiso.IdPersona != _IdPersona)
                {
                    if (!_Accesos.Find(a => a.IdSubModulo == _ALecturaEscrituraAdmin).TieneAcceso)
                    {
                        throw new GPException { Description = $"Estimado usuario no tienes permisos para esta sección", ErrorCode = 0, Category = TypeException.Noautorizado, IdAux = "" };
                    }
                }
            }

            if(mode == V2IncValidation.Cancel)
            {
                if (IdIncidenciaPermiso == 0)
                {
                    throw new GPException { Description = $"Estimado usuario por favor selecciona una solicitud", ErrorCode = 0, Category = TypeException.Error, IdAux = "" };
                }

                if (_darkM.IncidenciaPermiso.GetIntValue($"select IdPersona from IncidenciaPermiso where IdIncidenciaPermiso = {IdIncidenciaPermiso}") != _IdPersona)
                {
                    if (!_Accesos.Find(a => a.IdSubModulo == _ALecturaEscrituraAdmin).TieneAcceso)
                    {
                        throw new GPException { Description = $"Estimado usuario no tienes permisos para esta sección", ErrorCode = 0, Category = TypeException.Noautorizado, IdAux = "" };
                    }
                }
            }

            if (mode == V2IncValidation.Delete)
            {
                if (!_Accesos.Find(a => a.IdSubModulo == _ALecturaEscrituraAdmin).TieneAcceso)
                {
                    throw new GPException { Description = $"Estimado usuario no tienes permisos para esta sección", ErrorCode = 0, Category = TypeException.Noautorizado, IdAux = "" };
                }
            }

            if (mode == V2IncValidation.Aprove)
            {
                if(Nivel == 2)
                {
                    if (!_Accesos.Find(a => a.IdSubModulo == _AauthJefeInmediato).TieneAcceso)
                    {
                        throw new GPException { Description = $"Estimado usuario no tienes permisos para esta sección", ErrorCode = 0, Category = TypeException.Noautorizado, IdAux = "" };
                    }
                    var data = _darkM.IncidenciaPermiso.GetOpenquerys($" as t01 where t01.IdIncidenciaPermiso = {IdIncidenciaPermiso} and (t01.IdPersona in (select t02.EIdPersona from View_EmpleadoJefe as t02 where t02.JIdpersona = {_IdPersona}) " +
                        $"or t01.IdPersona in (select t01.IdPersona from IncidenciaAuthAux as t02 where t02.IdPersonaAuth = {_IdPersona} and t02.Activa = 1 ) )");
                    if(data is null)
                    {
                        throw new GPException { Description = $"Estimado usuario no tienes permisos para esta sección", ErrorCode = 0, Category = TypeException.Noautorizado, IdAux = "" };
                    }
                }
                else if (Nivel == 3)
                {
                    if (!_Accesos.Find(a => a.IdSubModulo == _AauthAdminGPS).TieneAcceso)
                    {
                        throw new GPException { Description = $"Estimado usuario no tienes permisos para esta sección", ErrorCode = 0, Category = TypeException.Noautorizado, IdAux = "" };
                    }
                }
                else
                {
                    throw new GPException { Description = $"Estimado usuario el nivel de probación es incorrecto", ErrorCode = 0, Category = TypeException.Error, IdAux = "" };
                }
            }


        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="result"></param>
        /// <param name="Getprocess"></param>
        private void LLenarTodo(IncidenciaPermiso result, bool Getprocess = false)
        {
            if (result != null)
            {
                if(Getprocess)
                    result.Proceso = _darkM.IncidenciaProcess.GetOpenquery($"where IdIncidenciaPermiso = {result.IdIncidenciaPermiso}", "");
                result.DEscripcionTipo = _darkM.IncidenciaPermiso.GetStringValue($"select Descripcion from CatalogoOpcionesValores where IdCatalogoOpcionesValores = {result.IdAsunto}");
                result.PagoPermisoDesc = _darkM.IncidenciaPermiso.GetStringValue($"select Descripcion from CatalogoOpcionesValores where IdCatalogoOpcionesValores = {result.IdPagoPermiso}");
                result.EmpleadoNombre = _darkM.IncidenciaPermiso.GetStringValue($"select NombreCompleto from View_empleado where IdPersona = {result.IdPersona}");
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="IncidenciaPermiso"></param>
        /// <returns></returns>
        public int Create(IncidenciaPermiso IncidenciaPermiso)
        {
            if(IncidenciaPermiso.IdPersona != _IdPersona)
            {
                if(!_Accesos.Find(a => a.IdSubModulo == _ALecturaEscrituraAdmin).TieneAcceso)
                {
                    throw new GPException { Description = $"Estimado usuario no tienes permisos para crear solicitudes a otros colaboradores", ErrorCode = 0, Category = TypeException.Noautorizado, IdAux = "" };
                }
                IncidenciaPermiso.CreadoPor = "Admin";
            }
            else
            {
                IncidenciaPermiso.CreadoPor = "Empleado";
            }
            if (IncidenciaPermiso.IdAsunto == 36 && IncidenciaPermiso.IdPagoPermiso == 0)
            {
                throw new GPException { Description = $"Por favor selecciona un tipo de permiso", ErrorCode = 0, Category = TypeException.Info, IdAux = "IdPagoPermiso" };
            }
            IncidenciaPermiso.Estatus = 2;
            //IncidenciaPermiso.Creado = DateTime.Now;
            //IncidenciaPermiso.Editado = DateTime.Now;

            _darkM.IncidenciaPermiso.Element = IncidenciaPermiso;

            _darkM.IncidenciaPermiso.Add();

            IncidenciaPermiso.IdIncidenciaPermiso = _darkM.IncidenciaPermiso.LastInserted($"select max(IdIncidenciaPermiso) from IncidenciaPermiso where IdPersona = {IncidenciaPermiso.IdPersona} ");

            _darkM.dBConnection.StartProcedure($"SP_IncidenciaPermiso", new List<ProcedureModel>
                {
                    new ProcedureModel { Namefield = "IdIncidenciaPermiso", value = IncidenciaPermiso.IdIncidenciaPermiso },
                    new ProcedureModel { Namefield = "Mode", value = "Create" }
                });

            if (_darkM.dBConnection.ErrorCode != 0)
                throw new GPException { Description = _darkM.GetLastMessage(), ErrorCode = 0, Category = TypeException.Info, IdAux = "" };

            AgregarPasos(IncidenciaPermiso, _IdPersona);

            return IncidenciaPermiso.IdIncidenciaPermiso;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="IncidenciaPermiso"></param>
        public void Edit(IncidenciaPermiso IncidenciaPermiso)
        {
            var details = Details(IncidenciaPermiso.IdIncidenciaPermiso);
            if(details is null)
            {
                throw new GPException { Description = $"Estimado usuario no fue encontrado la solicitud a editar", ErrorCode = 0, Category = TypeException.NotFound, IdAux = "" };
            }
            if (IncidenciaPermiso.IdPersona != _IdPersona)
            {
                if (!_Accesos.Find(a => a.IdSubModulo == _ALecturaEscrituraAdmin).TieneAcceso)
                {
                    throw new GPException { Description = $"Estimado usuario no tienes permisos para crear solicitudes a otros colaboradores", ErrorCode = 0, Category = TypeException.Noautorizado, IdAux = "" };
                }
            }
            if (!details.ActiveEdit)
            {
                throw new GPException { Description = $"Estimado usuario esta incidencia no puede ser cancelada ya que se encuentra en estatus = '{details.EstatusDescricion}'", ErrorCode = 0, Category = TypeException.Info, IdAux = "" };
            }

            if(IncidenciaPermiso.IdAsunto == 36 && IncidenciaPermiso.IdPagoPermiso == 0)
            {
                throw new GPException { Description = $"Por favor selecciona un tipo de permiso", ErrorCode = 0, Category = TypeException.Info, IdAux = "IdPagoPermiso" };
            }

            details.Fecha = IncidenciaPermiso.Fecha;
            details.Inicio = IncidenciaPermiso.Inicio;
            details.Fin = IncidenciaPermiso.Fin;
            details.IdAsunto = IncidenciaPermiso.IdAsunto;
            details.DescripcionAsunto = IncidenciaPermiso.DescripcionAsunto;
            details.IdPagoPermiso = IncidenciaPermiso.IdPagoPermiso;
            //details.Editado = DateTime.Now;
            _darkM.IncidenciaPermiso.Element = details;

            _darkM.IncidenciaPermiso.Update();

            _darkM.dBConnection.StartProcedure($"SP_IncidenciaPermiso", new List<ProcedureModel>
                {
                    new ProcedureModel { Namefield = "IdIncidenciaPermiso", value = IncidenciaPermiso.IdIncidenciaPermiso },
                    new ProcedureModel { Namefield = "Mode", value = "Update" }
                });

            if (_darkM.dBConnection.ErrorCode != 0)
                throw new GPException { Description = _darkM.GetLastMessage(), ErrorCode = 0, Category = TypeException.Info, IdAux = "" };
        }
        /// <summary>
        /// agregar flujo de autorizaciones
        /// </summary>
        /// <param name="IncidenciaPermiso"></param>
        /// <param name="IdPersonaCreador"></param>
        private void AgregarPasos(IncidenciaPermiso IncidenciaPermiso, int IdPersonaCreador)
        {
            var procesoStep = new IncidenciaProcess();
            procesoStep.IdIncidenciaPermiso = IncidenciaPermiso.IdIncidenciaPermiso;
            procesoStep.IdIncidenciaVacacion = 0;
            procesoStep.IdPersona = IdPersonaCreador;
            procesoStep.Fecha = DateTime.Now;
            procesoStep.Titulo = IdPersonaCreador == IncidenciaPermiso.IdPersona ? "Incidencia creada por solicitante" : "Incidencia creada";
            procesoStep.Comentarios = "";
            procesoStep.Nivel = 1;
            procesoStep.Revisada = true;
            procesoStep.Autorizada = true;
            procesoStep.NombreEmpleado = _darkM.IncidenciaPermiso.GetStringValue($"select NombreCompleto from View_empleado where IdPersona = {IdPersonaCreador}");
            _darkM.IncidenciaProcess.Element = procesoStep;
            _darkM.IncidenciaProcess.Add();

            procesoStep.IdIncidenciaVacacion = 0;
            procesoStep.IdPersona = 0;
            procesoStep.Fecha = null;
            procesoStep.Titulo = "Aprobación por jefe inmediato";
            procesoStep.Comentarios = "";
            procesoStep.Nivel = 2;
            procesoStep.Revisada = false;
            procesoStep.Autorizada = false;
            procesoStep.NombreEmpleado = "";
            _darkM.IncidenciaProcess.Element = procesoStep;
            _darkM.IncidenciaProcess.Add();

            procesoStep.IdIncidenciaVacacion = 0;
            procesoStep.IdPersona = 0;
            procesoStep.Fecha = null;
            procesoStep.Titulo = "Aprobación por gestión de personal";
            procesoStep.Comentarios = "";
            procesoStep.Nivel = 3;
            procesoStep.Revisada = false;
            procesoStep.Autorizada = false;
            procesoStep.NombreEmpleado = "";
            _darkM.IncidenciaProcess.Element = procesoStep;
            _darkM.IncidenciaProcess.Add();

            procesoStep.IdIncidenciaVacacion = 0;
            procesoStep.IdPersona = 0;
            procesoStep.Fecha = null;
            procesoStep.Titulo = "permiso concluido/tomado";
            procesoStep.Comentarios = "";
            procesoStep.Nivel = 5;
            procesoStep.Revisada = false;
            procesoStep.Autorizada = false;
            procesoStep.NombreEmpleado = "";
            _darkM.IncidenciaProcess.Element = procesoStep;
            _darkM.IncidenciaProcess.Add();
        }
        /// <summary>
        /// terminar controllador
        /// </summary>
        public void Terminar()
        {
            _darkM.CloseConnection();
            _darkM.IncidenciaPermiso = null;
            _darkM.IncidenciaProcess = null;
            _darkM.CatalogoOpcionesValores = null;
            _UsrCrt = null;
            _darkM = null;
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }
        #endregion
    }

    public enum V2IncValidation
    {
        Create = 1,
        Edit = 2,
        Details = 3,
        Delete = 4,
        Aprove = 5,
        Cancel = 6
    }
}
