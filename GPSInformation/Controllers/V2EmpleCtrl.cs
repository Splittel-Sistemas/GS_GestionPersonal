using GPSInformation.Exceptions;
using GPSInformation.Models;
using GPSInformation.Tools;
using GPSInformation.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace GPSInformation.Controllers
{
    public class V2EmpleCtrl
    {
        #region Atributos
        /// <summary>
        /// controlador de objetos 
        /// </summary>
        public DarkManager _darkM;
        /// <summary>
        /// controlador para acciones de usuario
        /// </summary>
        public UsuarioCtrl _UsrCrt;
        /// <summary>
        /// Cargar transacciones por metodo
        /// </summary>
        public bool LoadTranssByMethod { get; set; }
        public int _IdUsuario { get; internal set; }
        #endregion

        #region Constructores
        public V2EmpleCtrl(DarkManager darkManager, int IdUsuario = 0)
        {
            this._darkM = darkManager;
            this._IdUsuario = IdUsuario;
            this._darkM.OpenConnection();
            this._darkM.LoadObject(GpsManagerObjects.IncidenciaAuthAux);
            this._darkM.LoadObject(GpsManagerObjects.SystSelect);

            _UsrCrt = new UsuarioCtrl(_darkM, true);
        }
        #endregion
        /// <summary>
        /// terminar controllador
        /// </summary>
        public void Terminar()
        {
            _darkM.CloseConnection();
            _darkM.IncidenciaAuthAux = null;
            _darkM.SystSelect = null;
            _UsrCrt = null;
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }
        public List<SystSelect> EmplSelectlIst()
        {
            return _darkM.SystSelect.GetSpecialStat($"select IdPersona as Value, NombreCompleto as Label from View_Empleado where IdEstatus = 19  order by NombreCompleto");
        }
        #region Incidencias
        public void IncAutRemove(int IdPesona)
        {
            if (LoadTranssByMethod) _darkM.StartTransaction();
            try
            {
                var a = IncAutValidExists(IdPesona);
                Funciones.DarkValidModel(a, "Información incompleta");
                a.Activa = false;
                _darkM.IncidenciaAuthAux.Element = a;
                if (!_darkM.IncidenciaAuthAux.Update())
                {
                    throw new GPException { Description = $"Por favor intenta de nuevo, error al actualizar registros jefe auxiliar", ErrorCode = 0, Category = TypeException.Error, IdAux = "" };
                }

                if (LoadTranssByMethod) _darkM.Commit();
            }
            catch (GPException)
            {
                if (LoadTranssByMethod) _darkM.RolBack();
                throw;
            }
        }
        public IncidenciaAuthAux IncAutValidExists(int IdPersona)
        {
            return _darkM.IncidenciaAuthAux.GetOpenquerys($"where IdPersona = {IdPersona} and Activa = 1");
        }
        public int IncAutAdd(IncidenciaAuthAux incidenciaAuthAux)
        {
            if (LoadTranssByMethod) _darkM.StartTransaction();
            try
            {
                Funciones.DarkValidModel(incidenciaAuthAux, "Información incompleta");

                _darkM.IncidenciaAuthAux.GetOpenquery($"where IdPersona = {incidenciaAuthAux.IdPersona} and Activa = 1", "").ForEach(a =>
                {
                    a.Activa = false;
                    _darkM.IncidenciaAuthAux.Element = a;
                    if (!_darkM.IncidenciaAuthAux.Update())
                    {
                        throw new GPException { Description = $"Por favor intenta de nuevo, error al actualizar registros jefe auxiliar", ErrorCode = 0, Category = TypeException.Error, IdAux = "" };
                    }
                });


                incidenciaAuthAux.Creada = DateTime.Now;
                incidenciaAuthAux.Modificada = DateTime.Now;
                incidenciaAuthAux.NombreAuth = _darkM.SystSelect.GetStringValue($"select NombreCompleto from View_Empleado where IdPersona = {incidenciaAuthAux.IdPersonaAuth}");
                incidenciaAuthAux.Activa = true;
                _darkM.IncidenciaAuthAux.Element = incidenciaAuthAux;
                if (!_darkM.IncidenciaAuthAux.Add())
                {
                    throw new GPException { Description = $"Por favor intenta de nuevo, error al registrar jefe auxiliar", ErrorCode = 0, Category = TypeException.Error, IdAux = "" };
                }
                int LastInserted = _darkM.IncidenciaAuthAux.GetLastId();

                


                if (LoadTranssByMethod) _darkM.Commit();
                return LastInserted;
            }
            catch (GPException)
            {
                if (LoadTranssByMethod) _darkM.RolBack();
                throw;
            }
        }
        #endregion
    }
}
