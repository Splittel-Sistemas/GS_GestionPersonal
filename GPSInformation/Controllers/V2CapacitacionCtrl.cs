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
            this._darkM.LoadObject(GpsManagerObjects.CapSessEva);
            this._darkM.LoadObject(GpsManagerObjects.CapProg);
            this._darkM.LoadObject(GpsManagerObjects.CapProgPonts);
            this._darkM.LoadObject(GpsManagerObjects.CapProgSess);
            this._darkM.LoadObject(GpsManagerObjects.CapProgEmp);
            this._darkM.LoadObject(GpsManagerObjects.CapProgEmpSes);

            _UsrCrt = new UsuarioCtrl(_darkM, true);

            _Accesos = new Dictionary<string, AccesosUs>();

            _NombreCompleto = _darkM.dBConnection.GetStringValue($"select NombreCompleto from View_empleado where IdPersona = {IdPersona}");
            //obtener permisos
            _Accesos["ACrearIncidencias"] = new AccesosUs { IdSubModulo = 25, TieneAcceso = _UsrCrt.ValidAction(IdUsuario, 1054) };
        }
        #endregion

        #region CapTema
        /// <summary>
        /// Registrar tema para sessión
        /// </summary>
        /// <param name="capTema"></param>
        /// <returns></returns>
        //public int CapTemaCreate(CapTema capTema)
        //{
        //    ValidObj(capTema, $"Error, no se puede guardar el tema, la información esta incompleta");

        //}
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
                throw new GPException { Description = $"No se encontró la sesión seleccionada", ErrorCode = 0, Category = TypeException.NotFound };

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
        /// <param name="IdCapSess"></param>
        public void CapSessDelete(int IdCapTempl, int IdCapSess)
        {
            // validar que exista la capacitacion
            var CapTempl = CapTemplDetails(IdCapTempl, true);
            // validar que solo capacitaciones en estatus En proceso y En mantenimiento puedan ser editadas
            if (CapTempl.Estatus != 1 || CapTempl.Estatus != 2)
                throw new GPException { Description = $"No puedes anterar esta capacitación, estatus actual: {CapTempl.LabelStatus()}", ErrorCode = 0, Category = TypeException.Info };

            var capSess = CapSessDetails(IdCapSess, true);
            capSess.Eliminada = true;
            _darkM.CapSess.Element = capSess;
            _darkM.CapSess.Update();

            // editar numero de sesiones en el header de la capacitacion
            CapTempl.NoSesions = _darkM.CapSess.Count($" IdCapTempl = {IdCapTempl} and Eliminada = 0");
            _darkM.CapTempl.Element = CapTempl;
            _darkM.CapTempl.Update();
        }
        /// <summary>
        /// Editar session de la capacitacion seleccionada
        /// </summary>
        /// <param name="capSess"></param>
        public void CapSessEdit(CapSess capSess)
        {
            //validar objecto
            ValidObj(capSess, $"Error, no se puede editar la solicitud a la capacitación seleccionada");
            // validar que exista la capacitacion
            var CapTempl = CapTemplDetails(capSess.IdCapTempl, true);
            // validar que solo capacitaciones en estatus En proceso y En mantenimiento puedan ser editadas
            if (CapTempl.Estatus != 1 || CapTempl.Estatus != 2)
                throw new GPException { Description = $"No puedes anterar esta capacitación, estatus actual: {CapTempl.LabelStatus()}", ErrorCode = 0, Category = TypeException.Info };


            //Editat capacitacion
            _darkM.CapSess.Element = capSess;
            _darkM.CapSess.Update();
        }
        /// <summary>
        /// agregar session a capacitacion
        /// </summary>
        /// <param name="capSess"></param>
        /// <returns></returns>
        public int CapSessCreate(CapSess capSess)
        {
            //validar objecto
            ValidObj(capSess,$"Error, no se puede agregar la solicitud a la capacitación seleccionada");
            // validar que exista la capacitacion
            var CapTempl = CapTemplDetails(capSess.IdCapTempl, true);
            // validar que solo capacitaciones en estatus En proceso y En mantenimiento puedan ser editadas
            if(CapTempl.Estatus != 1 || CapTempl.Estatus != 2)
                throw new GPException { Description = $"No puedes anterar esta capacitación, estatus actual: {CapTempl.LabelStatus()}", ErrorCode = 0, Category = TypeException.Info };
            // registrar nueva sesion
            capSess.IdCapSess = _darkM.CapSess.GetLastId() + 1;
            capSess.NoSession = _darkM.CapSess.Count($" IdCapTempl = {capSess.IdCapTempl}  and Eliminada = 0") + 1;
            _darkM.CapSess.Element = capSess;
            _darkM.CapSess.Add();

            // editar numero de sesiones en el header de la capacitacion
            CapTempl.NoSesions = _darkM.CapSess.Count($" IdCapTempl = {capSess.IdCapTempl}  and Eliminada = 0");
            _darkM.CapTempl.Element = CapTempl;
            _darkM.CapTempl.Update();

            return _darkM.CapSess.GetLastId();
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
        public CapSess CapSessDetails(int IdCapSess, bool ShowExceNotFound = false)
        {
            var data = _darkM.CapSess.Get(IdCapSess);
            if (data is null && ShowExceNotFound)
                throw new GPException { Description = $"No se encontró la sesión seleccionada", ErrorCode = 0, Category = TypeException.NotFound };

            return data;
        }
        #endregion

        #region CapTempl CRUD
        /// <summary>
        /// Crear template header
        /// </summary>
        /// <param name="capTempl">dataset para crear nuevo template de capacitacion</param>
        /// <returns></returns>
        public int CapTemplCreate(CapTempl capTempl)
        {
            ValidObj(capTempl, $"Información incorrecta o no enviada");

            if(_darkM.dBConnection.GetIntegerValue($"select count(*) from CapTempl where ClvVersion = '{capTempl.ClvVersion}'") > 0)
                throw new GPException { Description = $"Por favor selecciona otra clave, la clave '{capTempl.ClvVersion}' ya se encuentra en uso", ErrorCode = 0, Category = TypeException.Info, IdAux = "ClvVersion" };

            capTempl.IdCapTempl = _darkM.CapTempl.GetLastId() + 1;
            capTempl.Estatus = 1;

            _darkM.CapTempl.Element = capTempl;

            _darkM.CapTempl.Add();

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
            if(data is null && ShowExceNotFound)
                throw new GPException { Description = $"No se encontró la capacitacion seleccionada", ErrorCode = 0, Category = TypeException.NotFound };

            return data;
        }
        /// <summary>
        /// List de templates de capacitaciones
        /// </summary>
        /// <param name="capTemplEstatus">Tipo de capacitaciones a Mostrar</param>
        /// <returns></returns>
        public List<CapTempl> CapTemplList(CapTemplEstatus capTemplEstatus)
        {
            if (capTemplEstatus == CapTemplEstatus.Todas)
                return _darkM.CapTempl.GetOpenquery($"", "Order by Nombre");
            else
                return _darkM.CapTempl.GetOpenquery($"where Estatus = {((int)capTemplEstatus)}", "Order by Nombre");
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
