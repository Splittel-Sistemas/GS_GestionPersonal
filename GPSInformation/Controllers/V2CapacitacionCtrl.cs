using System.Collections.Generic;
using GPSInformation.Exceptions;
using GPSInformation.Models;
using GPSInformation.Tools;
using GPSInformation.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using System.IO;


namespace GPSInformation.Controllers
{
    public class V2CapacitacionCtrl
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
        public string _NombreCompleto { get; internal set; }
        public Dictionary<string, AccesosUs> _Accesos { get; internal set; }
        #endregion

        #region Constructores
        public V2CapacitacionCtrl(DarkManager darkManager, int IdUsuario, int IdPersona)
        {
            this._darkM = darkManager;
            this._IdUsuario = IdUsuario;
            this._IdPersona = IdPersona;
            this._darkM.OpenConnection();
            this._darkM.LoadObject(GpsManagerObjects.CatalogoOpcionesValores);
            this._darkM.LoadObject(GpsManagerObjects.View_empleado);
            this._darkM.LoadObject(GpsManagerObjects.View_EmpleadoJefe);
            this._darkM.LoadObject(GpsManagerObjects.AccesosSistema);
            this._darkM.LoadObject(GpsManagerObjects.Usuario);
            this._darkM.LoadObject(GpsManagerObjects.CapTempl);
            this._darkM.LoadObject(GpsManagerObjects.CapSess);
            this._darkM.LoadObject(GpsManagerObjects.CapTema);
            this._darkM.LoadObject(GpsManagerObjects.CapEva);
            this._darkM.LoadObject(GpsManagerObjects.CapEvaPrg);
            this._darkM.LoadObject(GpsManagerObjects.CapEvaPrgRes);
            //this._darkM.LoadObject(GpsManagerObjects.CapSessEva);
            this._darkM.LoadObject(GpsManagerObjects.CapProg);
            this._darkM.LoadObject(GpsManagerObjects.CapProgPonts);
            this._darkM.LoadObject(GpsManagerObjects.CapProgSess);
            this._darkM.LoadObject(GpsManagerObjects.CapProgEmp);
            this._darkM.LoadObject(GpsManagerObjects.CapProgEmpSes);
            this._darkM.LoadObject(GpsManagerObjects.CapTemplShedule);
            this._darkM.LoadObject(GpsManagerObjects.CapTemplStatusStand);

            _UsrCrt = new UsuarioCtrl(_darkM, true);

            _Accesos = new Dictionary<string, AccesosUs>();

            _NombreCompleto = _darkM.dBConnection.GetStringValue($"select NombreCompleto from View_empleado where IdPersona = {IdPersona}");
            //obtener permisos
            _Accesos["ACrearIncidencias"] = new AccesosUs { IdSubModulo = 25, TieneAcceso = _UsrCrt.ValidAction(IdUsuario, 1054) };
        }
        #endregion
        
        #region Evaluaciones
        /// <summary>
        /// eliminar 
        /// </summary>
        /// <param name="IdCapEvaPrg"></param>
        /// <param name="CapEvaPrgRes"></param>
        public void CapEvaPrgResDelete(int IdCapEvaPrg, int CapEvaPrgRes)
        {
            var pregunta = CapEvaPrgDeetails(IdCapEvaPrg, true);
            var CapEva = CapEvaDetails(pregunta.IdCapEva, true);

            if (CapEva.Estatus != 1 && CapEva.Estatus != 2)
            {
                throw new GPException { Description = $"No se puede modificar la evalución seleccionada, estatus actual: {CapEva.LabelStatus()}", ErrorCode = 0, Category = TypeException.Info };
            }

            if (pregunta.Tipo == "T")
                throw new GPException { Description = $"No se pueden agregar respuestas a la pregunta: '{pregunta.Pregunta}', es tipo: '{pregunta.LabelStatus()}'", ErrorCode = 0, Category = TypeException.Info };

            var respuesta_obj = CapEvaPrgResDetails(CapEvaPrgRes);
            _darkM.CapEvaPrgRes.Element = respuesta_obj;
            _darkM.CapEvaPrgRes.Delete();
        }
        /// <summary>
        /// Editar respuesta
        /// </summary>
        /// <param name="IdCapEvaPrg"></param>
        /// <param name="CapEvaPrgRes"></param>
        /// <param name="Respuesta"></param>
        /// <param name="EsCorrect"></param>
        public void CapEvaPrgResEdit(int IdCapEvaPrg, int CapEvaPrgRes, string Respuesta, bool EsCorrect)
        {
            var pregunta = CapEvaPrgDeetails(IdCapEvaPrg, true);
            var CapEva = CapEvaDetails(pregunta.IdCapEva, true);

            if (CapEva.Estatus != 1 && CapEva.Estatus != 2)
            {
                throw new GPException { Description = $"No se puede modificar la evalución seleccionada, estatus actual: {CapEva.LabelStatus()}", ErrorCode = 0, Category = TypeException.Info };
            }

            if (pregunta.Tipo == "T")
                throw new GPException { Description = $"No se pueden agregar respuestas a la pregunta: '{pregunta.Pregunta}', es tipo: '{pregunta.LabelStatus()}'", ErrorCode = 0, Category = TypeException.Info };

            var respuesta_obj = CapEvaPrgResDetails(CapEvaPrgRes);
            respuesta_obj.Respuesta = Respuesta;
            respuesta_obj.EsCorrecta = EsCorrect;
            _darkM.CapEvaPrgRes.Element = respuesta_obj;
            _darkM.CapEvaPrgRes.Update();
        }
        /// <summary>
        /// Agregar respuesta 
        /// </summary>
        /// <param name="IdCapEvaPrg"></param>
        /// <param name="Respuesta"></param>
        /// <param name="EsCorrecta"></param>
        /// <returns></returns>
        public int CapEvaPrgResAdd(int IdCapEvaPrg, string Respuesta, bool EsCorrecta)
        {
            var pregunta = CapEvaPrgDeetails(IdCapEvaPrg, true);
            var CapEva = CapEvaDetails(pregunta.IdCapEva, true);

            if (CapEva.Estatus != 1 && CapEva.Estatus != 2)
            {
                throw new GPException { Description = $"No se puede modificar la evalución seleccionada, estatus actual: {CapEva.LabelStatus()}", ErrorCode = 0, Category = TypeException.Info };
            }

            if(pregunta.Tipo == "T")
                throw new GPException { Description = $"No se pueden agregar respuestas a la pregunta: '{pregunta.Pregunta}', es tipo: '{pregunta.LabelStatus()}'", ErrorCode = 0, Category = TypeException.Info };



            var respuesta = new CapEvaPrgRes
            {
                IdCapEvaPrgRes = _darkM.CapEvaPrgRes.GetLastId() + 1,
                IdCapEvaPrg = IdCapEvaPrg,
                Respuesta = Respuesta,
                EsCorrecta = EsCorrecta
            };

            _darkM.CapEvaPrgRes.Element = respuesta;
            _darkM.CapEvaPrgRes.Add();

            return respuesta.IdCapEvaPrgRes;

        }
        /// <summary>
        /// Listado de respuestas por preguntas
        /// </summary>
        /// <param name="IdCapEvaPrg"></param>
        /// <returns></returns>
        public List<CapEvaPrgRes> CapEvaPrgResList(int IdCapEvaPrg)
        {
            return _darkM.CapEvaPrgRes.GetOpenquery($"where IdCapEvaPrg = {IdCapEvaPrg}", "");
        }
        /// <summary>
        /// extraer detalle de respuesta
        /// </summary>
        /// <param name="IdCapEvaPrgRes"></param>
        /// <param name="ShowExceNotFound"></param>
        /// <returns></returns>
        public CapEvaPrgRes CapEvaPrgResDetails(int IdCapEvaPrgRes, bool ShowExceNotFound = false)
        {
            var data = _darkM.CapEvaPrgRes.GetOpenquerys($"where IdCapEvaPrgRes = {IdCapEvaPrgRes}");

            if (data is null && ShowExceNotFound)
            {
                throw new GPException { Description = $"Registro no encontrado", ErrorCode = 0, Category = TypeException.NotFound };
            }
            return data;
        }
        
        /// <summary>
        /// Eliminar pregunta
        /// </summary>
        /// <param name="IdCapEva"></param>
        /// <param name="IdCapEvaPrg"></param>
        public void CapEvaPrgDelete(int IdCapEva, int IdCapEvaPrg)
        {
            var CapEva = CapEvaDetails(IdCapEva, true);
            if (CapEva.Estatus != 1 && CapEva.Estatus != 2)
            {
                throw new GPException { Description = $"No se puede modificar la evalución seleccionada, estatus actual: {CapEva.LabelStatus()}", ErrorCode = 0, Category = TypeException.Info };
            }

            var CapEvaPrg_res = CapEvaPrgDeetails(IdCapEvaPrg, true);

            //borrar respuestas
            CapEvaPrg_res.CapEvaPrgList.ForEach(a =>
            {
                CapEvaPrgResDelete(a.IdCapEvaPrg,a.IdCapEvaPrgRes);
            });


            _darkM.CapEvaPrg.Element = CapEvaPrg_res;
            _darkM.CapEvaPrg.Delete();
        }
        /// <summary>
        /// editar pregunta
        /// </summary>
        /// <param name="IdCapEva"></param>
        /// <param name="IdCapEvaPrg"></param>
        /// <param name="Pregunta"></param>
        /// <param name="Comentarios"></param>
        /// <param name="Puntaje"></param>
        /// <param name="Tipo"></param>
        public void CapEvaPrgEdit(int IdCapEva, int IdCapEvaPrg, string Pregunta, string Comentarios, int Puntaje, string Tipo)
        {
            var CapEva = CapEvaDetails(IdCapEva, true);
            if (CapEva.Estatus != 1 && CapEva.Estatus != 2)
            {
                throw new GPException { Description = $"No se puede modificar la evalución seleccionada, estatus actual: {CapEva.LabelStatus()}", ErrorCode = 0, Category = TypeException.Info };
            }

            var CapEvaPrg_res = CapEvaPrgDeetails(IdCapEvaPrg, true);

            if(Pregunta != CapEvaPrg_res.Pregunta || Comentarios != CapEvaPrg_res.Comentarios || Puntaje != CapEvaPrg_res.Puntaje || Tipo != CapEvaPrg_res.Tipo)
            {
                CapEvaPrg_res.Pregunta = Pregunta;
                CapEvaPrg_res.Comentarios = Comentarios;
                CapEvaPrg_res.Tipo = Tipo;
                CapEvaPrg_res.Puntaje = Puntaje;
                _darkM.CapEvaPrg.Element = CapEvaPrg_res;
                _darkM.CapEvaPrg.Update();
            }
        }
        /// <summary>
        /// Agregar pregunta a evaluacion
        /// </summary>
        /// <param name="IdCapEva"></param>
        /// <param name="Pregunta"></param>
        /// <param name="Comentarios"></param>
        /// <param name="Puntaje"></param>
        /// <param name="Tipo"></param>
        /// <returns></returns>
        public int CapEvaPrgAdd(int IdCapEva, string Pregunta, string Comentarios, int Puntaje, string Tipo, List<CapEvaPrgRes> CapEvaPrgList)
        {
            var CapEva = CapEvaDetails(IdCapEva, true);
            if(CapEva.Estatus != 1 && CapEva.Estatus != 2)
            {
                throw new GPException { Description = $"No se puede modificar la evalución seleccionada, estatus actual: {CapEva.LabelStatus()}", ErrorCode = 0, Category = TypeException.Info };
            }
            if (CapEvaPrgList == null || CapEvaPrgList != null && CapEvaPrgList.Count == 0 && Tipo != "T")
            {
                throw new GPException { Description = $"Por favor define las posibles respuestas a tu pregunta", ErrorCode = 0, Category = TypeException.Info };
            }
            var CapEvaPrg_res = new CapEvaPrg
            {
                IdCapEva = IdCapEva,
                Comentarios = Comentarios,
                Pregunta = Pregunta,
                Puntaje = Puntaje,
                Tipo = Tipo,
                IdCapEvaPrg = _darkM.CapEvaPrg.GetLastId() + 1
            };

            _darkM.CapEvaPrg.Element = CapEvaPrg_res;
            _darkM.CapEvaPrg.Add();

            CapEvaPrgList.ForEach(a =>
            {
                CapEvaPrgResAdd(CapEvaPrg_res.IdCapEvaPrg, a.Respuesta, a.EsCorrecta);
            });

            return CapEvaPrg_res.IdCapEvaPrg;
        }
        /// <summary>
        /// Listar preguntas porevaluacion
        /// </summary>
        /// <param name="IdCapEvaPrg"></param>
        /// <returns></returns>
        public List<CapEvaPrg> CapEvaPrgList(int IdCapEva)
        {
            var data = _darkM.CapEvaPrg.GetOpenquery($"where IdCapEva = {IdCapEva}", "order by Creada asc");

            data.ForEach(a =>
            {
                a.CapEvaPrgList = CapEvaPrgResList(a.IdCapEvaPrg);
            });

            return data;
        }
        /// <summary>
        /// Detalles de pregunta
        /// </summary>
        /// <param name="IdCapEvaPrg"></param>
        /// <param name="ShowExceNotFound"></param>
        /// <returns></returns>
        public CapEvaPrg CapEvaPrgDeetails(int IdCapEvaPrg, bool ShowExceNotFound = false)
        {
            var data = _darkM.CapEvaPrg.GetOpenquerys($"where IdCapEvaPrg = {IdCapEvaPrg}");

            if (data is null && ShowExceNotFound)
            {
                throw new GPException { Description = $"Registro no encontrado", ErrorCode = 0, Category = TypeException.NotFound };
            }

            data.CapEvaPrgList = CapEvaPrgResList(data.IdCapEvaPrg);
            return data;
        }
        
        /// <summary>
        /// Editar evaluacion
        /// </summary>
        /// <param name="IdCapEva"></param>
        /// <param name="Nombre"></param>
        /// <param name="Instrucciones"></param>
        public void CapEvaEit(int IdCapEva, string Nombre, string Instrucciones)
        {
            var capEva_res = CapEvaDetails(IdCapEva, true);

            if(capEva_res.Nombre != Nombre || capEva_res.Decripcion != Instrucciones)
            {
                _darkM.CapEva.Element = capEva_res;
                _darkM.CapEva.Update();
            }
        }
        /// <summary>
        /// Crearnueva evaluacion
        /// </summary>
        /// <param name="Nombre"></param>
        /// <param name="Instrucciones"></param>
        /// <returns></returns>
        public int CapEvaAdd(string Nombre, string Instrucciones)
        {
            CapEva capEva_res = null;

            if(string.IsNullOrEmpty(Nombre))
                throw new GPException { Description = $"El nombre de la evaluación no es valido", ErrorCode = 0, Category = TypeException.Info };

            capEva_res = new CapEva
            {
                Nombre = Nombre,
                Decripcion = Instrucciones,
                AplTime = false,
                HrsDurac = 1,
                Estatus = 1,
                IdCapEva = _darkM.CapEva.GetLastId() + 1
            };

            _darkM.CapEva.Element = capEva_res;

            _darkM.CapEva.Add();

            return capEva_res.IdCapEva;
        }
        /// <summary>
        /// Listar evaluaciones
        /// </summary>
        /// <returns></returns>
        public List<CapEva> CapEvaList()
        {
            return _darkM.CapEva.GetOpenquery($"","order by Nombre desc");
        }
        /// <summary>
        /// Detalle de evaluacion
        /// </summary>
        /// <param name="IdCapEva"></param>
        /// <param name="ShowExceNotFound"></param>
        /// <returns></returns>
        public CapEva CapEvaDetails(int IdCapEva, bool ShowExceNotFound = false)
        {
            var data = _darkM.CapEva.GetOpenquerys($"where IdCapEva = {IdCapEva}");

            if (data is null && ShowExceNotFound)
            {
                throw new GPException { Description = $"Registro no encontrado", ErrorCode = 0, Category = TypeException.NotFound };
            }
            return data;
        }
        #endregion

        #region CapTema
        /// <summary>
        /// 
        /// </summary>
        /// <param name="IdCapTempl"></param>
        /// <param name="IdCapSess"></param>
        /// <param name="IdCapTema"></param>
        public void CapTemaDelete(int IdCapTempl, int IdCapSess, int IdCapTema)
        {
            var data_templ = CapTemplDetails(IdCapTempl, true);
            CapTemplValidActions(data_templ);

            var data_sess_ = CapSessDetails(IdCapTempl, IdCapSess, true);
            CapSessValidate(data_sess_);

            var data = CapTemaDetails(IdCapTema, true);


            _darkM.CapTema.Element = data;
            _darkM.CapTema.Delete();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="IdCapTempl"></param>
        /// <param name="IdCapSess"></param>
        /// <param name="IdCapTema"></param>
        /// <param name="Nombre"></param>
        /// <param name="Descripcion"></param>
        public void CapTemaUpdate(int IdCapTempl, int IdCapSess, int IdCapTema, string Nombre, string Descripcion)
        {
            var data_templ = CapTemplDetails(IdCapTempl, true);
            CapTemplValidActions(data_templ);

            var data_sess_ = CapSessDetails(IdCapTempl, IdCapSess, true);
            CapSessValidate(data_sess_);

            var data = CapTemaDetails(IdCapTema, true);
            data.Nombre = Nombre;
            data.Descripcion = Descripcion;

            _darkM.CapTema.Element = data;
            _darkM.CapTema.Update();
        }
        /// <summary>
        /// Registrar tema para sessión
        /// </summary>
        /// <param name="capTema"></param>
        /// <returns></returns>
        public int CapTemaCreate(int IdCapTempl, int IdCapSess, string Nombre, string Descripcion)
        {
            var data_sess_ = CapSessDetails(IdCapTempl, IdCapSess, true);
            CapSessValidate(data_sess_);

            // validar estatus del template
            var data_templ = CapTemplDetails(data_sess_.IdCapTempl, true);
            CapTemplValidActions(data_templ);
            var data = new CapTema
            {
                IdCapTema = _darkM.CapTema.GetLastId() + 1,
                IdCapSess = IdCapSess,
                Nombre = Nombre,
                Descripcion = Descripcion,
                Eliminada = false
            };

            _darkM.CapTema.Element = data;
            _darkM.CapTema.Add();

            return data.IdCapTema;
        }
        /// <summary>
        /// Detalle de tema de una session
        /// </summary>
        /// <param name="IdCapTema"></param>
        /// <param name="ShowExceNotFound"></param>
        /// <returns></returns>
        public CapTema CapTemaDetails(int IdCapTema, bool ShowExceNotFound = false)
        {
            var data = _darkM.CapTema.Get(IdCapTema);
            if (data is null && ShowExceNotFound)
                throw new GPException { Description = $"No se encontró el tema seleccionada", ErrorCode = 0, Category = TypeException.NotFound };

            return data;
        }
        /// <summary>
        /// Lista de temas por session seleccionada
        /// </summary>
        /// <param name="IdCapSess"></param>
        /// <returns></returns>
        public List<CapTema> CapTemaBySession(int IdCapSess)
        {
            
            var data = _darkM.CapTema.GetOpenquery($" where IdCapSess = {IdCapSess} and Eliminada  = 0", "");

            return data;
        }
        #endregion

        #region CapSess CRUD
        /// <summary>
        /// eliminar session de capacitacion
        /// </summary>
        /// <param name="IdCapTempl"></param>
        /// <param name="IdRefer"></param>
        public void CapSessDelete(int IdCapTempl, int IdRefer )
        {
            // validar que exista la capacitacion
            var CapTempl = CapTemplDetails(IdCapTempl, true);
            
            // validar que solo capacitaciones en estatus En proceso y En mantenimiento puedan ser editadas
            CapTemplValidActions(CapTempl);

            var capSess = GetSheduleid(IdCapTempl, IdRefer, true);
            ///eliminar los registros solo cuando el diseño esta siendo creado (Estatus = 1 - En proceso)
            if(CapTempl.Estatus == 1)
            {
                _darkM.CapTemplShedule.Element = capSess;
                _darkM.CapTemplShedule.Delete();


                _darkM.CapSess.Element = CapSessDetails(IdCapTempl, IdRefer, true);
                _darkM.CapSess.Element.Eliminada = true;
                _darkM.CapSess.Update();

            }

            if (capSess != null && !capSess.Eliminada)
            {
                capSess.Eliminada = true;
                _darkM.CapTemplShedule.Element = capSess;
                _darkM.CapTemplShedule.Update();
            }
        }
        /// <summary>
        /// /
        /// </summary>
        /// <param name="IdCapTempl"></param>
        /// <param name="IdCapSess"></param>
        /// <param name="Nombre"></param>
        /// <param name="Duracion"></param>
        public void CapSessEdit(int IdCapTempl, int IdCapSess, string Nombre, decimal Duracion, string Objetivo)
        {
            //validar objecto
            var capSess = CapSessDetails(IdCapTempl, IdCapSess, true);
            CapSessValidate(capSess);
            

            // validar que exista la capacitacion
            var CapTempl = CapTemplDetails(capSess.IdCapTempl, true);

            // validar que solo capacitaciones en estatus En proceso y En mantenimiento puedan ser editadas
            CapTemplValidActions(CapTempl);

            //crear copia para session cuando se tenga un estatus mayor

            //Editat capacitacion
            if(capSess.Nombre != Nombre || capSess.Duracion != Duracion || capSess.Objetivo != Objetivo)
            {
                capSess.Nombre = Nombre;
                capSess.Objetivo = Objetivo;
                capSess.Duracion = Duracion;
                _darkM.CapSess.Element = capSess;
                _darkM.CapSess.Update();
            }
            
        }
        /// <summary>
        /// agregar session a capacitacion
        /// </summary>
        /// <param name="capSess"></param>
        /// <returns></returns>
        public int CapSessCreate(CapSess capSess)
        {
            //validar objecto
            ValidObj(capSess, $"Error, no se puede agregar la solicitud a la capacitación seleccionada");
            // validar que exista la capacitacion
            var CapTempl = CapTemplDetails(capSess.IdCapTempl, true);
            // validar que solo capacitaciones en estatus En proceso y En mantenimiento puedan ser editadas
            CapTemplValidActions(CapTempl);
            // registrar nueva sesion
            capSess.IdCapSess = _darkM.CapSess.GetLastId() + 1;
            capSess.NoSession = _darkM.CapSess.Count($" IdCapTempl = {capSess.IdCapTempl}  and Eliminada = 0") + 1;
            _darkM.CapSess.Element = capSess;
            _darkM.CapSess.Add();

            _darkM.CapTemplShedule.Element = new CapTemplShedule
            {
                IdCapTemplShedule = _darkM.CapTemplShedule.GetLastId() + 1,
                IdCapTempl = capSess.IdCapTempl,
                IdRefer = capSess.IdCapSess,
                Tipo = 1,
                Eliminada = false,
                Ordern = _darkM.CapTemplShedule.Count($" IdCapTempl = {capSess.IdCapTempl}") + 1
            };
            _darkM.CapTemplShedule.Add();
            // editar numero de sesiones en el header de la capacitacion
            CapSessUpdateTotalTempl(CapTempl);

            return capSess.IdCapSess;
        }
        public void CapSessUpdateTotalTempl(CapTempl CapTempl)
        {
            CapTempl.NoSesions = _darkM.CapSess.Count($" IdCapTempl = {CapTempl.IdCapTempl}  and Eliminada = 0");
            _darkM.CapTempl.Element = CapTempl;
            _darkM.CapTempl.Update();
        }
        /// <summary>
        /// Obtener lista de sessiones por capactacion
        /// </summary>
        /// <param name="IdCapTempl"></param>
        /// <returns></returns>
        public List<CapSess> CapSessByCapTempl(int IdCapTempl)
        {
            var data = _darkM.CapSess.GetOpenquery($"where IdCapTempl = {IdCapTempl}", "rder by NoSession");

            return data;
        }
        /// <summary>
        /// Obtener detalle de session
        /// </summary>
        /// <param name="IdCapSess">id de la session</param>
        /// <param name="ShowExceNotFound">Forzar excepcion</param>
        /// <returns></returns>
        public CapSess CapSessDetails(int IdCapTempl, int IdCapSess, bool ShowExceNotFound = false)
        {
            var data = _darkM.CapSess.GetOpenquerys($"where IdCapSess = {IdCapSess} and IdCapTempl = {IdCapTempl}");
            if (data is null && ShowExceNotFound)
                throw new GPException { Description = $"No se encontró la sesión seleccionada", ErrorCode = 0, Category = TypeException.NotFound };

            return data;
        }
        private void CapSessValidate(CapSess capSess)
        {
            if (capSess.Eliminada)
            {
                throw new GPException { Description = $"No se encontró la sesión seleccionada", ErrorCode = 0, Category = TypeException.NotFound };
            }
        }

        #endregion

        #region CapTempl CRUD
        /// <summary>
        /// 
        /// </summary>
        /// <param name="IdCapTempl"></param>
        /// <param name="Clave"></param>
        /// <param name="Nombre"></param>
        /// <param name="Objetivo"></param>
        /// <param name="CalRepet"></param>
        public void CapTemplEdit(int IdCapTempl, string Clave, string Nombre, string Descripcion, string Objetivo, float CalRepet)
        {
            var data = CapTemplDetails(IdCapTempl, true);

            CapTemplValidActions(data);

            data.Clave = Clave;
            data.Nombre = Nombre;
            data.Descripcion = Descripcion;
            data.Objetivo = Objetivo;
            data.CalRepet = CalRepet;

            _darkM.CapTempl.Element = data;

            _darkM.CapTempl.Update();

        }
        /// <summary>
        /// Crear template header
        /// </summary>
        /// <param name="capTempl">dataset para crear nuevo template de capacitacion</param>
        /// <returns></returns>
        public int CapTemplCreate(CapTempl capTempl)
        {
            ValidObj(capTempl, $"Información incorrecta o no enviada");

            //if (_darkM.dBConnection.GetIntegerValue($"select count(*) from CapTempl where ClvVersion = '{capTempl.ClvVersion}'") > 0)
            //    throw new GPException { Description = $"Por favor selecciona otra clave, la clave '{capTempl.ClvVersion}' ya se encuentra en uso", ErrorCode = 0, Category = TypeException.Info, IdAux = "ClvVersion" };

            capTempl.IdCapTempl = _darkM.CapTempl.GetLastId() + 1;
            capTempl.Estatus = 1;

            _darkM.CapTempl.Element = capTempl;

            _darkM.CapTempl.Add();

            CapTemplStatusStand stand = new CapTemplStatusStand
            {
                IdCapTempl = capTempl.IdCapTempl,
                Actual = true,
                Inicio =  DateTime.Now,
                Fin =  DateTime.Now,
                Estatus = 1
            };
            _darkM.CapTemplStatusStand.Element = stand;
            _darkM.CapTemplStatusStand.Add();

            return _darkM.CapTempl.GetLastId();
        }
        /// <summary>
        /// detalle de template header
        /// </summary>
        /// <param name="IdCapTempl">Id del template de capacitacion</param>
        /// <param name="ShowExceNotFound">Mostrar excepcion si no se encuentra el template</param>
        /// <returns></returns>
        public CapTempl CapTemplDetails(int IdCapTempl, bool ShowExceNotFound = false)
        {
            var data = _darkM.CapTempl.Get(IdCapTempl);
            if (data is null && ShowExceNotFound)
                throw new GPException { Description = $"No se encontró la capacitacion seleccionada", ErrorCode = 0, Category = TypeException.NotFound };

            return data;
        }
        /// <summary>
        /// listado del esquema de capacitacion
        /// </summary>
        /// <param name="IdCapTempl"></param>
        /// <returns></returns>
        public List<CapTemplShedule> GetShedule(int IdCapTempl)
        {
            var data = _darkM.CapTemplShedule.GetOpenquery($"where IdCapTempl = {IdCapTempl}", "");
            data.ForEach(a =>
            {
                if(a.Tipo == 1)
                    a.Title = _darkM.CapTemplShedule.GetStringValue($"select top 1 Nombre from CapSess where IdCapSess = {a.IdRefer}");
            });
            return data;
        }

        public CapTemplShedule GetSheduleid(int IdCapTempl, int IdRefer, bool ShowExceNotFound = false)
        {
            var data = _darkM.CapTemplShedule.GetOpenquerys($"where IdCapTempl = {IdCapTempl} and IdRefer = {IdRefer}");

            if (data is null && ShowExceNotFound)
                throw new GPException { Description = $"No se encontró GetSheduleid", ErrorCode = 0, Category = TypeException.NotFound };

            if (data != null && data.Tipo == 1)
                data.Title = _darkM.CapTemplShedule.GetStringValue($"select top 1 Nombre from CapSess where IdCapSess = {data.IdRefer}");
            return data;
        }


        /// <summary>
        /// List de templates de capacitaciones
        /// </summary>
        /// <param name="capTemplEstatus">Tipo de capacitaciones a Mostrar</param>
        /// <returns></returns>
        public List<CapTempl> CapTemplList(CapTemplEstatus capTemplEstatus = CapTemplEstatus.Todas)
        {
            if (capTemplEstatus == CapTemplEstatus.Todas)
                return _darkM.CapTempl.GetOpenquery($"", "Order by Nombre");
            else
                return _darkM.CapTempl.GetOpenquery($"where Estatus = {((int)capTemplEstatus)}", "Order by Nombre");
        }

        private void CapTemplValidActions(CapTempl data)
        {
            if (data.Estatus != 1 && data.Estatus != 2)
                throw new GPException { Description = $"No se puede modificar la capacitacion: '{data.Nombre}', estatus actual: '{data.LabelStatus()}'", ErrorCode = 0, Category = TypeException.Info, IdAux = "ClvVersion" };

        }
        #endregion

        #region Generales
        private void ValidObj(object data, string mensaje)
        {
            if (data is null) throw new GPException { Description = mensaje, ErrorCode = 0, Category = TypeException.Info };
        }
        public void Terminar()
        {
            _darkM.CloseConnection();
            _darkM = null;
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }
        #endregion

    }

}
