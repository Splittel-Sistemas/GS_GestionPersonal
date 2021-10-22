﻿using GPSInformation.Exceptions;
using GPSInformation.Models;
using GPSInformation.Responses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


namespace GPSInformation.Controllers
{
    public class V2IncVacacionesCtrl
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
        public readonly int _ALecturaEscrituraAdmin = 1054;
        /// <summary>
        /// ids de permisos por usuario en session
        /// </summary>
        public List<AccesosUs> _Accesos { get; internal set; }
        public string _NombreCompleto { get; internal set; }
        #endregion

        #region Constructores
        public V2IncVacacionesCtrl(DarkManager darkManager, int IdUsuario, int IdPersona)
        {
            this._darkM = darkManager;
            this._IdUsuario = IdUsuario;
            this._IdPersona = IdPersona;
            this._darkM.OpenConnection();
            this._darkM.LoadObject(GpsManagerObjects.IncidenciaVacacion);
            this._darkM.LoadObject(GpsManagerObjects.IncidenciaProcess);
            this._darkM.LoadObject(GpsManagerObjects.CatalogoOpcionesValores);
            this._darkM.LoadObject(GpsManagerObjects.View_empleado);
            this._darkM.LoadObject(GpsManagerObjects.View_EmpleadoJefe);
            this._darkM.LoadObject(GpsManagerObjects.AccesosSistema);
            this._darkM.LoadObject(GpsManagerObjects.Usuario);
            this._darkM.LoadObject(GpsManagerObjects.IncidenciaAuthAux);
            this._darkM.LoadObject(GpsManagerObjects.DiaFeriado);
            this._darkM.LoadObject(GpsManagerObjects.VacionesPeriodo);
            this._darkM.LoadObject(GpsManagerObjects.VacacionesDiasRegla);

            _UsrCrt = new UsuarioCtrl(_darkM, true);
            _NombreCompleto = _darkM.dBConnection.GetStringValue($"select NombreCompleto from View_empleado where IdPersona = {IdPersona}");
            //obtener permisos
            _Accesos = _UsrCrt.ValidatePermis(IdUsuario, new int[] { _ALecturaEscritura, _AauthJefeInmediato, _AauthAdminGPS, _AadminPeriodos, _AincidenciasAdmin, _ALecturaEscrituraAdmin });
        }
        #endregion

        #region solicitar cancelacion
        public void CancelSolAutorizar(InAutorizacion inAutorizacion)
        {
            var details = Details(inAutorizacion.IdIncidencia);
            if (details.Estatus != 10)
                throw new GPException { Description = $"Estimado usuario, para autorizar una cancelacion es necesaria una previa solicitud de cancelación, estatus actual: {details.EstatusDescricion}", ErrorCode = 0, Category = TypeException.Info, IdAux = "" };
            var proceso = details.Proceso.Find(a => a.Nivel == 10);

            if (proceso is null)
                throw new GPException { Description = $"Estimado usuario, no se encontró la solicitud de cancelación", ErrorCode = 0, Category = TypeException.Info, IdAux = "" };


            if (proceso.Revisada)
                throw new GPException { Description = $"Estimado usuario, la solicitud de cancelación ya fue procesada, para poder visualizar mas detalles, recarga la pagina nuevamente", ErrorCode = 0, Category = TypeException.Info, IdAux = "" };

            if (details.CreadoPor == "A" && !_Accesos.Find(a => a.IdSubModulo == _AauthAdminGPS).TieneAcceso)
                throw new GPException { Description = $"Estimado usuario no tienes permisos para cancelar esta solicitud", ErrorCode = 0, Category = TypeException.Noautorizado, IdAux = "" };

            if (details.IdPersona != _IdPersona && !_Accesos.Find(a => a.IdSubModulo == _AauthAdminGPS).TieneAcceso)
                throw new GPException { Description = $"Estimado usuario no tienes permisos para cancelar esta solicitud", ErrorCode = 0, Category = TypeException.Noautorizado, IdAux = "" };

            proceso.Comentarios = inAutorizacion.Comentarios;
            proceso.IdPersona = inAutorizacion.IdAutorizante;
            proceso.NombreEmpleado = _darkM.IncidenciaVacacion.GetStringValue($"select NombreCompleto from View_empleado where IdPersona = {inAutorizacion.IdAutorizante}");
            proceso.Revisada = true;
            proceso.Autorizada = inAutorizacion.Autoriza;
            proceso.Fecha = DateTime.Now;
            proceso.IdIncidenciaVacacion = inAutorizacion.IdIncidencia;
            _darkM.IncidenciaProcess.Element = proceso;
            _darkM.IncidenciaProcess.Update();

            if (inAutorizacion.Autoriza)
            {
                details.Estatus = 6;
                _darkM.IncidenciaVacacion.Element = details;
                _darkM.IncidenciaVacacion.Update();
            }
        }
        public void CancelSolCreate(int IdIncidenciaVacacion, string comentarios)
        {
            var details = Details(IdIncidenciaVacacion);
            /*
             * REGLAS DE VALIDACION
             * 
             * solo se pueden solicitar cancelaciones para incidencias autorizadas
             * incidencias A
             *  solo pueden ser canceladas por el administrador
             * incidencias E
             *  solo pueden ser canceladas por el empleado o el administrador
             *  Solicitud por el empleado
             *      notificar a GPS
             *      crear solicitud de cancelacion en espera de procesar
             *  solicitud por el administrador
             *      crear solicitud de cancelacion con estatus de proceso completo
             */
            if (details.Estatus != 4)
                throw new GPException { Description = $"Estimado usuario, para solicitar una cancelación es necesario que la solicitud se encuentre AUTORIZADA, estatus actual: {details.EstatusDescricion}", ErrorCode = 0, Category = TypeException.Info, IdAux = "" };
            if(details.Proceso != null && details.Proceso.Find(a => a.Nivel == 10) != null)
            {
                throw new GPException { Description = $"Estimado usuario, esta solicitud de vacaciones ya cuenta con una solicitud de vacaciónes", ErrorCode = 0, Category = TypeException.Info, IdAux = "" };
            }
            if (details.CreadoPor == "A")
            {
                if (!_Accesos.Find(a => a.IdSubModulo == _ALecturaEscrituraAdmin).TieneAcceso)
                    throw new GPException { Description = $"Estimado usuario no tienes permisos para cancelar esta solicitud", ErrorCode = 0, Category = TypeException.Noautorizado, IdAux = "" };
                else
                {
                    var procesoStep = new IncidenciaProcess();
                    procesoStep.IdIncidenciaPermiso = 0;
                    procesoStep.IdIncidenciaVacacion = details.IdIncidenciaVacacion;
                    procesoStep.IdPersona = _IdPersona;
                    procesoStep.Fecha = DateTime.Now;
                    procesoStep.Titulo = "Solicitud de cancelación";
                    procesoStep.Comentarios = comentarios;
                    procesoStep.Nivel = 10;
                    procesoStep.Tipo = 2;
                    procesoStep.Revisada = true;
                    procesoStep.Autorizada = true;

                    procesoStep.NombreEmpleado = _darkM.IncidenciaVacacion.GetStringValue($"select NombreCompleto from View_empleado where IdPersona = {_IdPersona}");
                    _darkM.IncidenciaProcess.Element = procesoStep;
                    _darkM.IncidenciaProcess.Add();

                    details.Estatus = 6;
                    _darkM.IncidenciaVacacion.Element = details;
                    _darkM.IncidenciaVacacion.Update();
                }
            }
            else
            {
                if(details.IdPersona != _IdPersona && !_Accesos.Find(a => a.IdSubModulo == _ALecturaEscrituraAdmin).TieneAcceso)
                    throw new GPException { Description = $"Estimado usuario no tienes permisos para cancelar esta solicitud", ErrorCode = 0, Category = TypeException.Noautorizado, IdAux = "" };
                
                if(details.IdPersona != _IdPersona && _Accesos.Find(a => a.IdSubModulo == _ALecturaEscrituraAdmin).TieneAcceso || details.IdPersona == _IdPersona && _Accesos.Find(a => a.IdSubModulo == _ALecturaEscrituraAdmin).TieneAcceso)
                {
                    var procesoStep = new IncidenciaProcess();
                    procesoStep.IdIncidenciaPermiso = 0;
                    procesoStep.IdIncidenciaVacacion = details.IdIncidenciaVacacion;
                    procesoStep.IdPersona = _IdPersona;
                    procesoStep.Fecha = DateTime.Now;
                    procesoStep.Titulo = "Solicitud de cancelación";
                    procesoStep.Comentarios = comentarios;
                    procesoStep.Nivel = 10;
                    procesoStep.Tipo = 2;
                    procesoStep.Revisada = true;
                    procesoStep.Autorizada = true;

                    procesoStep.NombreEmpleado = _darkM.IncidenciaVacacion.GetStringValue($"select NombreCompleto from View_empleado where IdPersona = {_IdPersona}");
                    _darkM.IncidenciaProcess.Element = procesoStep;
                    _darkM.IncidenciaProcess.Add();

                    details.Estatus = 6;
                    _darkM.IncidenciaVacacion.Element = details;
                    _darkM.IncidenciaVacacion.Update();
                }
                else
                {
                    var procesoStep = new IncidenciaProcess();
                    procesoStep.IdIncidenciaPermiso = 0;
                    procesoStep.IdIncidenciaVacacion = details.IdIncidenciaVacacion;
                    procesoStep.Fecha = DateTime.Now;
                    procesoStep.Titulo = "Solicitud de cancelación";
                    procesoStep.Comentarios = "";
                    procesoStep.Comentarios2 = comentarios;
                    procesoStep.Nivel = 10;
                    procesoStep.Tipo = 2;
                    procesoStep.Revisada = false;
                    procesoStep.Autorizada = false;

                    _darkM.IncidenciaProcess.Element = procesoStep;
                    _darkM.IncidenciaProcess.Add();

                    details.Estatus = 10;
                    _darkM.IncidenciaVacacion.Element = details;
                    _darkM.IncidenciaVacacion.Update();
                }
            }
        }
        #endregion

        #region Carga de archivos
        /// <summary>
        /// 
        /// </summary>
        public void ProcessPeriodos()
        {
            var empleados = _darkM.View_empleado.Get();
            var periodos = _darkM.VacacionesDiasRegla.Get();
            empleados.ForEach(emp =>
            {
                ProcessPeriodos(emp.IdPersona);
            });
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="IdPersona"></param>
        public void ProcessPeriodos(int IdPersona)
        {
            var emp = _darkM.View_empleado.Get(IdPersona);
            var periodos = _darkM.VacacionesDiasRegla.Get();
            DateTime date_aux = DateTime.Parse(emp.Ingreso.ToString("yyyy-MM-dd 00:00:00"));
            double years = Tools.Funciones.GetAntiguedadInt(emp.Ingreso);
            int Antiguedad = Int32.Parse(years + "");
            //Empleado con peridodo(s) completos
            for (int year = 1; year <= Antiguedad; year++)
            {
                var periodo = _darkM.VacionesPeriodo.GetOpenquerys($"where IdPersona = {emp.IdPersona} and NumeroPeriodo = {year}");
                var diaRegla = periodos.Find(a => a.NoAnio == year);
                if (diaRegla is null)
                    diaRegla = periodos.Find(a => a.NoAnio == periodos.Max(b => b.NoAnio));
                if (periodo is null)
                {
                    periodo = new VacionesPeriodo
                    {
                        IdPersona = emp.IdPersona,
                        NumeroPeriodo = year,
                        Completo = true,
                        DiasDisp = diaRegla.NoDias,
                        DiasAprobadors = diaRegla.NoDias,
                        DiasUsados = 0,
                    };
                    _darkM.VacionesPeriodo.Element = periodo;
                    _darkM.VacionesPeriodo.Add();
                }
                else
                {
                    if (!periodo.Completo)
                    {
                        periodo.Completo = true;
                        periodo.DiasDisp = periodo.DiasDisp + (diaRegla.NoDias - periodo.DiasAprobadors);
                        periodo.DiasAprobadors = diaRegla.NoDias;
                        _darkM.VacionesPeriodo.Element = periodo;
                        _darkM.VacionesPeriodo.Update();
                    }
                }
                date_aux = date_aux.AddYears(1);
            }
            var meses = Tools.Funciones.MonthDifference2(date_aux, DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd 00:00:00")));

            if (Antiguedad > 0)
            {
                if (meses >= 6)
                {
                    var diaRegla = periodos.Find(a => a.NoAnio == Antiguedad + 1);
                    if (diaRegla is null)
                        diaRegla = periodos.Find(a => a.NoAnio == periodos.Max(b => b.NoAnio));
                    var periodo = new VacionesPeriodo
                    {
                        IdPersona = emp.IdPersona,
                        NumeroPeriodo = Antiguedad + 1,
                        Completo = false,
                        DiasAprobadors = diaRegla.NoDias / 2,
                        DiasDisp = diaRegla.NoDias / 2,
                        DiasUsados = 0,
                    };
                    _darkM.VacionesPeriodo.Element = periodo;
                    _darkM.VacionesPeriodo.Add();
                }
            }
            else
            {
                if (meses >= 10)
                {
                    var diaRegla = periodos.Find(a => a.NoAnio == 1);

                    var periodo = new VacionesPeriodo
                    {
                        IdPersona = emp.IdPersona,
                        NumeroPeriodo = 1,
                        Completo = false,
                        DiasAprobadors = diaRegla.NoDias / 2,
                        DiasDisp = diaRegla.NoDias / 2,
                        DiasUsados = 0,
                    };
                    _darkM.VacionesPeriodo.Element = periodo;
                    _darkM.VacionesPeriodo.Add();
                }
            }


        }
        #endregion

        #region Metodos

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<IncidenciaVacacion> GetByUsuario(int IdPersonaa)
        {
            
            if (IdPersonaa == 0) IdPersonaa = _IdPersona;

            if (!_Accesos.Find(a => a.IdSubModulo == _ALecturaEscrituraAdmin).TieneAcceso && IdPersonaa != _IdPersona)
            {
                throw new GPException { Description = $"Estimado usuario no tienes permisos para esta sección", ErrorCode = 0, Category = TypeException.Noautorizado, IdAux = "" };
            }
            var data = _darkM.IncidenciaVacacion.GetOpenquery($" where IdPersona = {IdPersonaa } and Estatus != 8", "Order by Creado desc");

            data.ForEach(result => LLenarTodo(result));
            return data;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<IncidenciaVacacion> GetByJefeInmediato()
        {
            if (!_Accesos.Find(a => a.IdSubModulo == _AauthJefeInmediato).TieneAcceso)
            {
                throw new GPException { Description = $"Estimado usuario no tienes permisos para esta sección", ErrorCode = 0, Category = TypeException.Noautorizado, IdAux = "" };
            }
            var data = _darkM.IncidenciaVacacion.GetOpenquery($" as t01 where  t01.Estatus != 8 and (" +
                $"t01.IdPersona in (select t02.EIdPersona from View_EmpleadoJefe as t02 where t02.JIdpersona = {_IdPersona }) or " +
                $"t01.IdPersona in (select t02.IdPersona from IncidenciaAuthAux as t02 where t02.IdPersonaAuth = {_IdPersona } and t02.Activa = 1 ) )", "Order by Creado desc");
            data.ForEach(result => LLenarTodo(result));
            return data;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<IncidenciaVacacion> GetByGPSAdmin()
        {
            if (!_Accesos.Find(a => a.IdSubModulo == _AauthAdminGPS).TieneAcceso)
            {
                throw new GPException { Description = $"Estimado usuario no tienes permisos para esta sección", ErrorCode = 0, Category = TypeException.Noautorizado, IdAux = "" };
            }
            var data = _darkM.IncidenciaVacacion.GetOpenquery($" as t01 where t01.Estatus in(3,10) ", "Order by Creado desc");
            data.ForEach(result => LLenarTodo(result));
            return data;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<IncidenciaVacacion> GetAdmin()
        {
            //if(!_Accesos.Find(a => a.IdSubModulo == _ALecturaEscrituraAdmin).TieneAcceso )
            //{
            //    throw new GPException { Description = $"Estimado usuario no tienes permisos para crear solicitudes a otros colaboradores", ErrorCode = 0, Category = TypeException.Noautorizado, IdAux = "" };
            //}
            if (!_Accesos.Find(a => a.IdSubModulo == _AincidenciasAdmin).TieneAcceso)
            {
                throw new GPException { Description = $"Estimado usuario no tienes acceso a esta seccion", ErrorCode = 0, Category = TypeException.Noautorizado, IdAux = "" };
            }

            var data = _darkM.IncidenciaVacacion.GetOpenquery($"where Estatus != 8", "Order by Creado desc");

            data.ForEach(result => LLenarTodo(result));
            return data;
        }
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
            _darkM.IncidenciaVacacion.Element = details;

            _darkM.IncidenciaVacacion.Update();

            SPValidator(IdIncidencia, "Eliminar");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="IdIncidencia"></param>
        public void Cancelar(int IdIncidencia)
        {
            var details = Details(IdIncidencia);

            /*
             * incidencias admin solo pueden ser canceladas por el administrador 
             * incidencias empleado solo pueden ser canceladas por e mismo empleado o el administrador
             *  si estatus = 4 solicitar cancelacion notificar a GPS
             *      registrar solicitud
             *      estatus = 10
             *  si estatus < 4 cancelar solicitud sin notificar a GPS
             *      estatus = 6
             *  
             */
            if (details.Estatus == 4)
                throw new GPException { Description = $"Estimado usuario no es posible cancelar la incidencia solicitada, estatus actual: {details.EstatusDescricion}, se requiere una solicitud de cancelación", ErrorCode = 0, Category = TypeException.Info, IdAux = "" };

            if (details.CreadoPor == "A" && !_Accesos.Find(a => a.IdSubModulo == _ALecturaEscrituraAdmin).TieneAcceso)
                throw new GPException { Description = $"Estimado usuario no tienes permisos para cancelar esta solicitud", ErrorCode = 0, Category = TypeException.Noautorizado, IdAux = "" };

            if (details.IdPersona != _IdPersona && !_Accesos.Find(a => a.IdSubModulo == _ALecturaEscrituraAdmin).TieneAcceso)
                throw new GPException { Description = $"Estimado usuario no tienes permisos para cancelar esta solicitud", ErrorCode = 0, Category = TypeException.Noautorizado, IdAux = "" };

           
            details.Estatus = 6;
            _darkM.IncidenciaVacacion.Element = details;

            _darkM.IncidenciaVacacion.Update();


            SPValidator(IdIncidencia, "Cancelar");
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

            if (inAutorizacion.Modee != 2 && inAutorizacion.Modee != 3)
            {
                throw new GPException { Description = $"Estimado usuario no es valido tu autorización, datos incorrectos", ErrorCode = 0, Category = TypeException.Info, IdAux = "" };
            }

            if (inAutorizacion.Modee == details.Estatus)
            {
                var proceso = details.Proceso.Find(a => a.Nivel == inAutorizacion.Modee);
                proceso.Comentarios = inAutorizacion.Comentarios;
                proceso.IdPersona = inAutorizacion.IdAutorizante;
                proceso.NombreEmpleado = _darkM.IncidenciaVacacion.GetStringValue($"select NombreCompleto from View_empleado where IdPersona = {inAutorizacion.IdAutorizante}");
                proceso.Revisada = true;
                proceso.Autorizada = inAutorizacion.Autoriza;
                proceso.Fecha = DateTime.Now;
                proceso.IdIncidenciaVacacion = inAutorizacion.IdIncidencia;
                _darkM.IncidenciaProcess.Element = proceso;
                _darkM.IncidenciaProcess.Update();


                if (inAutorizacion.Autoriza)
                {
                    if(details.Estatus == 2)
                    {
                        if(details.Proceso.Find(a => a.Nivel == 3).Revisada && details.Proceso.Find(a => a.Nivel == 3).Autorizada)
                        {
                            details.Estatus = 4;
                        }
                        else
                        {
                            details.Estatus = 3;
                        }
                    }
                    else if (details.Estatus == 3)
                    {
                        details.Estatus = 4;
                    }
                }
                else
                    details.Estatus = 7;

                _darkM.IncidenciaVacacion.Element = details;

                _darkM.IncidenciaVacacion.Update();
                SPValidator(inAutorizacion.IdIncidencia, "Autorizar");
            }
            else
            {
                var proceso = details.Proceso.Find(a => a.Nivel == inAutorizacion.Modee);
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
        /// <param name="IdIncidenciaVacacion"></param>
        /// <param name="Body"></param>
        public void EnviarNotificacion(int IdIncidenciaVacacion, string Body)
        {
            if (!string.IsNullOrEmpty(Body))
            {
                string asunto = "";
                bool send = false;
                var details = Details(IdIncidenciaVacacion);
                //Solicitud creada
                if (details.Estatus == 1)
                {
                    asunto = $"Solicitud {details.Folio} creada";
                }
                //Jefe inmediado
                else if (details.Estatus == 2)
                {
                    asunto = $"Nueva solicitud {details.Folio} - Aprobación N1";
                    send = true;

                    _darkM.View_EmpleadoJefe.GetOpenquery($"where EIdPersona = {details.IdPersona} ", "").ForEach(a => _darkM.EmailServ_.AddListTO(a.JCorreo));
                    _darkM.EmailServ_.AddListTO(_darkM.View_EmpleadoJefe.GetStringValue($"select Correo from View_empleado where IdPersona = " +
                        $"(select top 1 t01.IdPersonaAuth from IncidenciaAuthAux as t01 where t01.IdPersona = {details.IdPersona} and Activa = 1)"));
                }
                //Gestión personal
                else if (details.Estatus == 3)
                {
                    asunto = $"Nueva solicitud {details.Folio} - Aprobación N2";
                    send = true;

                    _darkM.AccesosSistema.GetOpenquery($"where IdSubModulo = {_AauthAdminGPS} and TieneAcceso = 1", "").ForEach(a =>
                    {
                        var usuario = _darkM.Usuario.Get(a.IdUsuario);
                        if (usuario != null)
                        {
                            var empleado = _darkM.View_empleado.GetOpenquerys($"where IdPersona = {usuario.IdPersona}");
                            if (empleado != null)
                            {
                                _darkM.EmailServ_.AddListTO(empleado.Correo);
                            }
                        }
                    });
                }
                //Autorizada
                else if (details.Estatus == 4)
                {
                    if(details.Proceso.Find(a => a.Nivel == 10) != null)
                    {
                        asunto = $"Solicitud  de cancelacion para{details.Folio} rechazada";
                    }
                    else
                    {
                        asunto = $"Solicitud {details.Folio} autorizada";
                    }
                    
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
                    asunto = $"Solicitud {details.Folio} concluida";

                }
                //Cancelada
                else if (details.Estatus == 6)
                {
                    if (details.Proceso.Find(a => a.Nivel == 10) != null)
                    {
                        asunto = $"Solicitud  de cancelacion para{details.Folio} aceptada";
                    }
                    else
                    {
                        asunto = $"Solicitud {details.Folio} cancelada";
                    }
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
                    asunto = $"Solicitud {details.Folio} rechazada";
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
                    asunto = $"Solicitud {details.Folio} eliminada";
                }
                else if (details.Estatus == 10)
                {
                    asunto = $"Solicitud {details.Folio} - Aprobación de cancelacion";
                    send = true;

                    _darkM.AccesosSistema.GetOpenquery($"where IdSubModulo = {_AauthAdminGPS} and TieneAcceso = 1", "").ForEach(a =>
                    {
                        var usuario = _darkM.Usuario.Get(a.IdUsuario);
                        if (usuario != null)
                        {
                            var empleado = _darkM.View_empleado.GetOpenquerys($"where IdPersona = {usuario.IdPersona}");
                            if (empleado != null)
                            {
                                _darkM.EmailServ_.AddListTO(empleado.Correo);
                            }
                        }
                    });
                }
                else
                {
                }




                if (send == true)
                {
                    _darkM.EmailServ_.Send(Body, asunto);
                    _darkM.RestartEmail();
                }
                // solicitud de cancelación
                

            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="IdIncidenciaVacacion"></param>
        /// <returns></returns>
        public int GetIdPersona(int IdIncidenciaVacacion)
        {
            return _darkM.IncidenciaVacacion.GetIntValue($"select IdPersona from IncidenciaVacacion where IdIncidenciaVacacion = { IdIncidenciaVacacion}");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="IncidenciaVacacion"></param>
        /// <returns></returns>
        public int Create(IncidenciaVacacion IncidenciaVacacion)
        {
            if (IncidenciaVacacion.IdPersona != _IdPersona)
            {
                if (!_Accesos.Find(a => a.IdSubModulo == _ALecturaEscrituraAdmin).TieneAcceso)
                {
                    throw new GPException { Description = $"Estimado usuario no tienes permisos para crear solicitudes a otros colaboradores", ErrorCode = 0, Category = TypeException.Noautorizado, IdAux = "" };
                }
                IncidenciaVacacion.CreadoPor = "A";
            }
            else
            {
                if (_Accesos.Find(a => a.IdSubModulo == _ALecturaEscrituraAdmin).TieneAcceso)
                    IncidenciaVacacion.CreadoPor = "A";
                else
                    IncidenciaVacacion.CreadoPor = "E";

            }

            #region Mover archivo
            if (IncidenciaVacacion.Archivo == null)
                throw new GPException { Description = $"Estimado usuario porfavor selecciona un archivo para poder crear tu solicitud", ErrorCode = 0, Category = TypeException.Info, IdAux = "" };
            if (IncidenciaVacacion.Archivo.Length == 0)
                throw new GPException { Description = $"Estimado usuario el archivo {IncidenciaVacacion.Archivo.FileName} esta dañado", ErrorCode = 0, Category = TypeException.Info, IdAux = "" };

            int last = _darkM.IncidenciaVacacion.GetLastId(nameof(_darkM.IncidenciaVacacion.Element.IdPersona), IncidenciaVacacion.IdPersona + "");
            IncidenciaVacacion.ArchivoScan = $"{(last + 1)}_FormatoDeVacacionesFirmado.{IncidenciaVacacion.Archivo.FileName.Split('.')[1]}";

            
            string Directorio = $"C:\\Splittel\\GestionPersonal\\{IncidenciaVacacion.IdPersona}\\IncVacaciones\\";
            if (!System.IO.Directory.Exists(Directorio))
            {
                System.IO.Directory.CreateDirectory(Directorio);
            }
            Directorio = $"{Directorio}\\{IncidenciaVacacion.ArchivoScan}";

            //var filePath = Path.Combine(Directorio, IncidenciaVacacion.ArchivoScan);


            using (FileStream fs = System.IO.File.Create(Directorio))
            {
                IncidenciaVacacion.Archivo.CopyTo(fs);
                fs.Flush();
            }
            #endregion


            IncidenciaVacacion.NumAutorizaciones = 4;
            IncidenciaVacacion.Estatus = IncidenciaVacacion.CreadoPor == "E" ? 2 : 4;
            IncidenciaVacacion.Tipo = "A";
            IncidenciaVacacion.NoDias = GetDays(IncidenciaVacacion.Inicio, IncidenciaVacacion.Fin);

            _darkM.IncidenciaVacacion.Element = IncidenciaVacacion;

            _darkM.IncidenciaVacacion.Add();

            IncidenciaVacacion.IdIncidenciaVacacion = _darkM.IncidenciaVacacion.LastInserted($"select max(IdIncidenciaVacacion) from IncidenciaVacacion where IdPersona = {IncidenciaVacacion.IdPersona} ");

            AgregarPasos(IncidenciaVacacion, _IdPersona, IncidenciaVacacion.CreadoPor);

            SPValidator(IncidenciaVacacion.IdIncidenciaVacacion, "Create");

            return IncidenciaVacacion.IdIncidenciaVacacion;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="IdIncidenciaVacacion"></param>
        /// <param name="Mode"></param>
        private void SPValidator(int IdIncidenciaVacacion, string Mode)
        {
            _darkM.dBConnection.StartProcedure($"SP_IncidenciaVacacion", new List<ProcedureModel>
                {
                    new ProcedureModel { Namefield = "IdIncidenciaVacacion", value = IdIncidenciaVacacion },
                    new ProcedureModel { Namefield = "IdPersona", value = _IdPersona },
                    new ProcedureModel { Namefield = "IdUsuario", value = _IdUsuario },
                    new ProcedureModel { Namefield = "Mode", value = Mode }
                });

            if (_darkM.dBConnection.ErrorCode != 0)
                throw new GPException { Description = _darkM.GetLastMessage(), ErrorCode = 0, Category = TypeException.Info, IdAux = "" };
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="IncidenciaVacacion"></param>
        public void Edit(IncidenciaVacacion IncidenciaVacacion)
        {
            var details = Details(IncidenciaVacacion.IdIncidenciaVacacion);
            if (details is null)
            {
                throw new GPException { Description = $"Estimado usuario no fue encontrado la solicitud a editar", ErrorCode = 0, Category = TypeException.NotFound, IdAux = "" };
            }
            if (IncidenciaVacacion.IdPersona != _IdPersona)
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


            details.Inicio = IncidenciaVacacion.Inicio;
            details.Fin = IncidenciaVacacion.Fin;
            //details.Tipo = IncidenciaVacacion.Tipo;
            //details.CreadoPor = IncidenciaVacacion.IdAsunto;
            details.NoDias = GetDays(IncidenciaVacacion.Inicio, IncidenciaVacacion.Fin);
            _darkM.IncidenciaVacacion.Element = details;

            _darkM.IncidenciaVacacion.Update();

            SPValidator(IncidenciaVacacion.IdIncidenciaVacacion, "Update");
        }
        /// <summary>
        /// Obtener dias de vacaciones atomar entre dos fechas de acuerdo a dias feriados
        /// </summary>
        /// <param name="desde"></param>
        /// <param name="hasta"></param>
        /// <returns></returns>
        private int GetDays(DateTime desde, DateTime hasta)
        {
            DateTime inicio = desde;
            int dias = 0;
            if(desde == hasta)
            {
                return 1;
            }
            else
            {
                while (inicio <= hasta)
                {
                    if (inicio.DayOfWeek != DayOfWeek.Saturday && inicio.DayOfWeek != DayOfWeek.Sunday)
                    {
                        var result = _darkM.DiaFeriado.GetByColumn(inicio.ToString("yyyy-MM-dd"), nameof(_darkM.DiaFeriado.Element.Fecha));
                        if (result == null)
                        {
                            dias++;
                        }
                    }
                    inicio = inicio.AddDays(1);
                }
                return dias == 0 ? -1 : dias;
            }
           
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="IdIncidenciaVacacion"></param>
        /// <returns></returns>
        public IncidenciaVacacion Details(int IdIncidenciaVacacion, bool LanzarExcep = false)
        {
            var result = _darkM.IncidenciaVacacion.GetOpenquerys($"where IdIncidenciaVacacion = {IdIncidenciaVacacion} and Estatus != 8");

            LLenarTodo(result, true);

            if (LanzarExcep && result is null)
            {
                throw new GPException { Description = $"Estimado usuario no se encontró la incidencia seleccionada", ErrorCode = 0, Category = TypeException.NotFound, IdAux = "" };
            }


            return result;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="result"></param>
        /// <param name="Getprocess"></param>
        private void LLenarTodo(IncidenciaVacacion result, bool Getprocess = false)
        {
            if (result != null)
            {
                if (Getprocess)
                    result.Proceso = _darkM.IncidenciaProcess.GetOpenquery($"where IdIncidenciaVacacion = {result.IdIncidenciaVacacion}", "");
                result.EmpleadoNombre = _darkM.IncidenciaVacacion.GetStringValue($"select NombreCompleto from View_empleado where IdPersona = {result.IdPersona}");
            }
        }
        /// <summary>
        /// agregar flujo de autorizaciones
        /// </summary>
        /// <param name="IncidenciaVacacion"></param>
        /// <param name="IdPersonaCreador"></param>
        private void AgregarPasos(IncidenciaVacacion IncidenciaVacacion, int IdPersonaCreador, string CreadoPor)
        {
            var procesoStep = new IncidenciaProcess();
            procesoStep.IdIncidenciaPermiso = 0;
            procesoStep.IdIncidenciaVacacion = IncidenciaVacacion.IdIncidenciaVacacion;
            procesoStep.IdPersona = IdPersonaCreador;
            procesoStep.Fecha = DateTime.Now;
            procesoStep.Titulo = IdPersonaCreador == IncidenciaVacacion.IdPersona ? "Incidencia creada por solicitante" : "Incidencia creada";
            procesoStep.Comentarios = "";
            procesoStep.Nivel = 1;
            procesoStep.Tipo = 1;
            procesoStep.Revisada = true;
            procesoStep.Autorizada = true;

            procesoStep.NombreEmpleado = _darkM.IncidenciaVacacion.GetStringValue($"select NombreCompleto from View_empleado where IdPersona = {IdPersonaCreador}");
            _darkM.IncidenciaProcess.Element = procesoStep;
            _darkM.IncidenciaProcess.Add();

            procesoStep.IdIncidenciaPermiso = 0;
            procesoStep.IdPersona = 0;
            procesoStep.Fecha = null;
            procesoStep.Titulo = "Aprobación por jefe inmediato";
            procesoStep.Comentarios = CreadoPor == "A" ? "Autorización por default" : "";
            procesoStep.Nivel = 2;
            procesoStep.Tipo = 1;
            procesoStep.Revisada = CreadoPor == "A" ? true : false;
            procesoStep.Autorizada = CreadoPor == "A" ? true : false;
            procesoStep.NombreEmpleado = CreadoPor == "A" ? "Sistema gestión de Personal" : "";
            _darkM.IncidenciaProcess.Element = procesoStep;
            _darkM.IncidenciaProcess.Add();

            procesoStep.IdIncidenciaPermiso = 0;
            procesoStep.IdPersona = 0;
            procesoStep.Fecha = null;
            procesoStep.Titulo = "Aprobación por gestión de personal";
            procesoStep.Comentarios = CreadoPor == "A" ? "Autorización por default" : "";
            procesoStep.Nivel = 3;
            procesoStep.Tipo = 1;
            procesoStep.Revisada = CreadoPor == "A" ? true : false; 
            procesoStep.Autorizada = CreadoPor == "A" ? true : false;
            procesoStep.NombreEmpleado = CreadoPor == "A" ? "Sistema gestión de Personal" : "";
            _darkM.IncidenciaProcess.Element = procesoStep;
            _darkM.IncidenciaProcess.Add();

            procesoStep.IdIncidenciaPermiso = 0;
            procesoStep.IdPersona = 0;
            procesoStep.Fecha = null;
            procesoStep.Titulo = "Incidencia concluido/tomado";
            procesoStep.Comentarios = "";
            procesoStep.Nivel = 5;
            procesoStep.Tipo = 1;
            procesoStep.Revisada = false;
            procesoStep.Autorizada = false;
            procesoStep.NombreEmpleado = "";
            _darkM.IncidenciaProcess.Element = procesoStep;
            _darkM.IncidenciaProcess.Add();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="IdIncidenciaVacacion"></param>
        /// <param name="Nivel"></param>
        /// <param name="IncidenciaVacacion"></param>
        public void ValidarAcciones(V2IncValidation mode, int IdIncidenciaVacacion = 0, int Nivel = 0, IncidenciaVacacion IncidenciaVacacion = null)
        {
            if (mode == V2IncValidation.Create || mode == V2IncValidation.Edit)
            {
                if (IncidenciaVacacion is null)
                {
                    throw new GPException { Description = $"Estimado usuario por favor verifica tu información", ErrorCode = 0, Category = TypeException.Error, IdAux = "" };
                }

                if (IncidenciaVacacion.IdPersona != _IdPersona)
                {
                    if (!_Accesos.Find(a => a.IdSubModulo == _ALecturaEscrituraAdmin).TieneAcceso)
                    {
                        throw new GPException { Description = $"Estimado usuario no tienes permisos para esta sección", ErrorCode = 0, Category = TypeException.Noautorizado, IdAux = "" };
                    }
                }
            }

            if (mode == V2IncValidation.Cancel)
            {
                if (IdIncidenciaVacacion == 0)
                {
                    throw new GPException { Description = $"Estimado usuario por favor selecciona una solicitud", ErrorCode = 0, Category = TypeException.Error, IdAux = "" };
                }

                if (_darkM.IncidenciaVacacion.GetIntValue($"select IdPersona from IncidenciaVacacion where IdIncidenciaVacacion = {IdIncidenciaVacacion}") != _IdPersona)
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
                if (Nivel == 2)
                {
                    if (!_Accesos.Find(a => a.IdSubModulo == _AauthJefeInmediato).TieneAcceso)
                    {
                        throw new GPException { Description = $"Estimado usuario no tienes permisos para esta sección", ErrorCode = 0, Category = TypeException.Noautorizado, IdAux = "" };
                    }
                    var data = _darkM.IncidenciaVacacion.GetOpenquerys($" as t01 where t01.IdIncidenciaVacacion = {IdIncidenciaVacacion} and (" +
                        $"t01.IdPersona in (select t02.EIdPersona from View_EmpleadoJefe as t02 where t02.JIdpersona = {_IdPersona}) or " +
                        $"t01.IdPersona in (select t02.IdPersona from IncidenciaAuthAux as t02 where t02.IdPersonaAuth = {_IdPersona} and t02.Activa = 1 )) ");
                    if (data is null)
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
            if(mode == V2IncValidation.AproveCancelation)
            {
                //if (Nivel != 10)
                //    throw new GPException { Description = $"Estimado usuario la incidencia no se encuentra en estatus SOLICITUD DE CANCELACIÓN", ErrorCode = 0, Category = TypeException.Error, IdAux = "" };

                if(!_Accesos.Find(a => a.IdSubModulo == _AauthAdminGPS).TieneAcceso)
                    throw new GPException { Description = $"Estimado usuario no tienes permisos para esta sección", ErrorCode = 0, Category = TypeException.Noautorizado, IdAux = "" };
            }

        }
        /// <summary>
        /// terminar controllador
        /// </summary>
        public void Terminar()
        {
            _darkM.CloseConnection();
            _darkM.IncidenciaVacacion = null;
            _darkM.IncidenciaVacacion = null;
            _darkM.CatalogoOpcionesValores = null;
            _UsrCrt = null;
            _darkM = null;
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }
        #endregion
    }
}
