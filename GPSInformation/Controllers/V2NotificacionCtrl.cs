using GPSInformation.Exceptions;
using GPSInformation.Models;
using GPSInformation.Responses;
using GPSInformation.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GPSInformation.Controllers
{
    public class V2NotificacionCtrl
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
        #endregion

        #region Constructores
        public V2NotificacionCtrl(DarkManager darkManager, int IdUsuario, int IdPersona)
        {
            this._darkM = darkManager;
            this._IdUsuario = IdUsuario;
            this._IdPersona = IdPersona;
            this._darkM.OpenConnection();
            this._darkM.LoadObject(GpsManagerObjects.Notificacion);
            this._darkM.LoadObject(GpsManagerObjects.NotificacionAsig);
            this._darkM.LoadObject(GpsManagerObjects.View_notificacionEmp);
        }
        #endregion
        /// <summary>
        /// obtener notificaciones de personas
        /// </summary>
        /// <returns></returns>
        public List<View_notificacionEmp> Notificaciones(string Mode)
        {
            if (string.IsNullOrEmpty(Mode) || Mode == "Todas")
                Mode = "";
            else if (Mode == "Leidas")
                Mode = "and Revisado = 1";
            else if (Mode == "SinLeer")
                Mode = "and Revisado = 0";

            return _darkM.View_notificacionEmp.GetOpenquery($"Where IdPersona = {_IdPersona} {Mode}", "order by Creado desc");
        }


        public void AddToDepartamento(string Descripcion, string Url, string Categoria, int IdPersona)
        {

        }

        public void AddToPerson(string Descripcion, string Url, string Categoria, int IdPersona)
        {

        }

        public void CheckAsReaded(int IdPersona, int IdNotificacion)
        {
            var data = _darkM.NotificacionAsig.GetOpenquerys($"where IdPersona = {IdPersona}  and IdNotificacion = {IdNotificacion} and Revisado = 0");

            if(data != null)
            {
                data.Revisado = true;
                data.FechaRevision = DateTime.Now;
                _darkM.NotificacionAsig.Element = data;

                _darkM.NotificacionAsig.Update();
            }
        }

        public void AddToPermiso(string Titulo,string Descripcion, string Url, string Categoria, int IdPermiso)
        {
            _darkM.LoadObject(GpsManagerObjects.View_empleado);

            int IdNotificacion = AddNotification(Titulo,Descripcion, Url, Categoria);

            _darkM.View_empleado.GetOpenquery($"where IdPersona in (" +
                $"    select t01.IdPersona from View_AccesoUsuario as t01 where t01.TieneAcceso = 1 and IdSubModulo = {IdPermiso} " +
                $")", "").ForEach(emp =>
                {
                    AddNotificationEmp(emp.IdPersona,IdNotificacion);
                });
        }

        private int AddNotification(string Titulo,string Descripcion, string Url, string Categoria)
        {
            var Notificacion = new Notificacion
            {
                IdNotificacion = _darkM.Notificacion.GetLastId() + 1,
                Categoria = Categoria,
                URL = Url,
                Descripcion = Descripcion,
                Creado = DateTime.Now,
                Titulo = Titulo,
            };
            _darkM.Notificacion.Element = Notificacion;

            _darkM.Notificacion.Add();


            return Notificacion.IdNotificacion;
        }

        private void AddNotificationEmp(int IdPersona , int IdNotificacion)
        {
            if(_darkM.NotificacionAsig.Count($" IdPersona = {IdPersona}  and IdNotificacion = {IdNotificacion}") == 0)
            {
                var Notificacio = new NotificacionAsig
                {
                    FechaRevision = DateTime.Now,
                    IdNotificacion = IdNotificacion,
                    IdPersona = IdPersona,
                    Revisado = false,
                    IdNotificacionAsig = _darkM.NotificacionAsig.GetLastId() + 1
                };
                _darkM.NotificacionAsig.Element = Notificacio;

                _darkM.NotificacionAsig.Add();
            }
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
    }
}
