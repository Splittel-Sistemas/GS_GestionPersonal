using GPSInformation.Exceptions;
using GPSInformation.Models;
using GPSInformation.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace GPSInformation.Controllers
{
    public class IncVacacionesCtrl
    {
        #region Atributos
        public DarkManager _Dkma { get; internal set; }
        #endregion

        #region Constructores
        public IncVacacionesCtrl(DarkManager _Dkma)
        {
            this._Dkma = _Dkma;
            this._Dkma.OpenConnection();
            this._Dkma.LoadObject(GpsManagerObjects.IncidenciaProcess);
            this._Dkma.LoadObject(GpsManagerObjects.IncidenciaPermiso);
            this._Dkma.LoadObject(GpsManagerObjects.IncidenciaVacacion);
            this._Dkma.LoadObject(GpsManagerObjects.DiaFeriado);
        }
        #endregion

        #region Metodos
        /// <summary>
        /// autorizar una incidencia
        /// </summary>
        /// <param name="inAutorizacion">informacion de autrizacion</param>
        public void Autorizar(InAutorizacion inAutorizacion)
        {
            _Dkma.StartTransaction();
            try
            {
                if (inAutorizacion is null)
                {
                    throw new GPException { ErrorCode = 200, Category = TypeException.Info, Description = "Error, informacion incorrecta", IdAux = "" };
                }
                var estatus = _Dkma.IncidenciaProcess.GetOpenquerys($" where IdIncidenciaVacacion = {inAutorizacion.IdIncidencia} and Nivel = {inAutorizacion.Mode}");
                //var estatus = HayRevisiones(inAutorizacion.IdIncidencia, inAutorizacion.Mode);
                if (estatus is null)
                {
                    throw new GPException { ErrorCode = 300, Category = TypeException.Info, Description = "No fue encontrada la incidencia", IdAux = "" };
                }

                if (estatus.Revisada)
                {
                    throw new GPException { ErrorCode = 300, Category = TypeException.Info, Description = "Ya ha sido revisada esta incidencia por: " + estatus.NombreEmpleado, IdAux = "" };
                }

                estatus.Comentarios = inAutorizacion.Comentarios;
                estatus.IdPersona = inAutorizacion.IdAutorizante;
                estatus.NombreEmpleado = inAutorizacion.NombreApro;
                estatus.Revisada = true;
                estatus.Autorizada = inAutorizacion.Autoriza;
                estatus.Fecha = DateTime.Now;

                _Dkma.IncidenciaProcess.Element = estatus;

                if (!_Dkma.IncidenciaProcess.Update())
                {
                    throw new GPException { ErrorCode = 200, Category = TypeException.Info, Description = $"Error, No fueron guardados los cambios de {(inAutorizacion.Autoriza ? "Autorización" : "Rechazo")} de la incidencia", IdAux = "" };
                }
                _Dkma.Commit();
            }
            catch (GpExceptions ex)
            {
                _Dkma.RolBack();
                throw new GPException { ErrorCode = -200, Category = TypeException.Info, Description = ex.Message, IdAux = "" };
            }
            catch (GPException ex)
            {
                _Dkma.RolBack();
                throw ex;
            }
        }
        /// <summary>
        /// eliminar incidencia
        /// </summary>
        /// <param name="IdIncidenciaVacacion"></param>
        /// <param name="IdPersonaCreador"></param>
        public void Eliminar(int IdIncidenciaVacacion, int IdPersonaCreador)
        {
            _Dkma.StartTransaction();
            try
            {
                var IncidenciaVacacion = _Dkma.IncidenciaVacacion.Get(IdIncidenciaVacacion);
                if (IncidenciaVacacion is null)
                {
                    throw new GPException { ErrorCode = 200, Category = TypeException.Info, Description = "Error, no se encontró la incidencia que deseas eliminar", IdAux = "" };
                }

                IncidenciaVacacion.Estatus = 5;
                _Dkma.IncidenciaVacacion.Element = IncidenciaVacacion;

                if (!_Dkma.IncidenciaVacacion.Update())
                {
                    throw new GPException { ErrorCode = 200, Category = TypeException.Info, Description = "Error, La incidencia no pudo ser eliminar, intenta de nuevo", IdAux = "" };
                }

                _Dkma.Commit();
            }
            catch (GpExceptions ex)
            {
                _Dkma.RolBack();
                throw new GPException { ErrorCode = -200, Category = TypeException.Info, Description = ex.Message, IdAux = "" };
            }
            catch (GPException ex)
            {
                _Dkma.RolBack();
                throw ex;
            }
        }
        /// <summary>
        /// Cancelar incidencia
        /// </summary>
        /// <param name="IdIncidenciaVacacion">Id de la incidencia</param>
        /// <param name="IdPersonaCreador">Persona editor</param>
        public void Cancel(int IdIncidenciaVacacion, int IdPersonaCreador)
        {
            _Dkma.StartTransaction();
            try
            {
                var IncidenciaVacacion = _Dkma.IncidenciaVacacion.Get(IdIncidenciaVacacion);
                if (IncidenciaVacacion is null)
                {
                    throw new GPException { ErrorCode = 200, Category = TypeException.Info, Description = "Error, no se encontró el permiso que deseas cancelar", IdAux = "" };
                }
                if (IncidenciaVacacion.Estatus == 4)
                {
                    throw new GPException { ErrorCode = 200, Category = TypeException.Info, Description = "Info, esta incidencia no puede ser cancelada ya que fue concluida", IdAux = "" };
                }
                IncidenciaVacacion.Estatus = 2;
                _Dkma.IncidenciaVacacion.Element = IncidenciaVacacion;

                if (!_Dkma.IncidenciaVacacion.Update())
                {
                    throw new GPException { ErrorCode = 200, Category = TypeException.Info, Description = "Error, El permiso no pudo ser cancelado, intenta de nuevo", IdAux = "" };
                }
                _Dkma.Commit();
            }
            catch (GpExceptions ex)
            {
                _Dkma.RolBack();
                throw new GPException { ErrorCode = -200, Category = TypeException.Info, Description = ex.Message, IdAux = "" };
            }
            catch (GPException ex)
            {
                _Dkma.RolBack();
                throw ex;
            }
        }
        /// <summary>
        /// Editar solicitud de vacaciones
        /// </summary>
        /// <param name="IncidenciaVacacion">informcacion de solicitud</param>
        /// <param name="IdPersonaCreador"></param>
        public void Edit(IncidenciaVacacion IncidenciaVacacion, int IdPersonaCreador)
        {
            _Dkma.StartTransaction();
            try
            {
                if (IncidenciaVacacion is null)
                {
                    throw new GPException { ErrorCode = -100, Category = TypeException.Error, Description = "Información incorrecta" };
                }
                var estatus = HayRevisiones(IncidenciaVacacion.IdIncidenciaVacacion);
                if (estatus != "")
                {
                    throw new GPException { ErrorCode = 300, Category = TypeException.Info, Description = estatus, IdAux = "" };
                }
                
                estatus = "";

                _Dkma.IncidenciaVacacion.Element = IncidenciaVacacion;

                if (!_Dkma.IncidenciaVacacion.Update())
                {
                    throw new GPException { ErrorCode = 200, Category = TypeException.Info, Description = "Error, La incidencia no pudo ser actualizada, intenta de nuevo", IdAux = "" };
                }

                ValidDataActions(IncidenciaVacacion, "Edit");

                _Dkma.Commit();
            }
            catch (GpExceptions ex)
            {
                _Dkma.RolBack();
                throw new GPException { ErrorCode = -200, Category = TypeException.Info, Description = ex.Message, IdAux = "" };
            }
            catch (GPException ex)
            {
                _Dkma.RolBack();
                throw ex;
            }
        }
        /// <summary>
        /// crear nueva incidecias tipo vacacion,
        /// </summary>
        /// <param name="IncidenciaVacacion">informacion de la incidencias</param>
        /// <param name="IdPersonaCreador">creador</param>
        /// <returns></returns>
        public int Create(IncidenciaVacacion IncidenciaVacacion, int IdPersonaCreador)
        {
            var IdCreated = 0;
            _Dkma.StartTransaction();
            try
            {
                if (IncidenciaVacacion is null)
                {
                    throw new GPException { ErrorCode = -100, Category = TypeException.Error, Description = "Información incorrecta" };
                }
                IncidenciaVacacion.CreadoPor = "E";
                IncidenciaVacacion.Estatus = 1; // activas 2 canceladas 
                IncidenciaVacacion.NoDias = GetDays(IncidenciaVacacion.Inicio, IncidenciaVacacion.Fin);
                IncidenciaVacacion.Tipo = "A";
                IncidenciaVacacion.NumAutorizaciones = 4;
                IncidenciaVacacion.Creado = DateTime.Now;

                _Dkma.IncidenciaVacacion.Element = IncidenciaVacacion;

                if (!_Dkma.IncidenciaPermiso.Add())
                {
                    throw new GPException { ErrorCode = 200, Category = TypeException.Info, Description = "Error, La incidencia no pudo ser guardada, intenta de nuevo", IdAux = "" };
                }

                IdCreated = _Dkma.IncidenciaVacacion.LastInserted($"select IdIncidenciaVacacion from IncidenciaVacacion where IdPersona = {IncidenciaVacacion.IdPersona} ");

                IncidenciaVacacion.IdIncidenciaVacacion = IdCreated;
                ValidDataActions(IncidenciaVacacion,"Create");
                AddSteps(IncidenciaVacacion, IdPersonaCreador);

                _Dkma.Commit();
                return IdCreated;
            }
            catch (GpExceptions ex)
            {
                _Dkma.RolBack();
                throw new GPException { ErrorCode = -200, Category = TypeException.Info, Description = ex.Message, IdAux = "" };
            }
            catch (GPException ex)
            {
                _Dkma.RolBack();
                throw ex;
            }
        }
        /// <summary>
        /// listar vacaciones
        /// </summary>
        /// <param name="IdStatus">Filtro [0, 1] En proceso, [2] Aprobadas, [3] canceladas [4] concluidas</param>
        /// <param name="IdPersona">id de la persona, enviar 0 para extraer todo</param>
        /// <returns></returns>
        public List<IncidenciaVacacion> GetVacacions(int IdStatus = 0, int IdPersona = 0)
        {
            /*
                Filtro 
                    [0, 1] En proceso, 
                    [2] canceladas, 
                    [3] Aprobadas 
                    [4] concluidas
                    [5] eliminadas
             */

            string Query = "";
            #region filtro 1
            //if (IdStatus == 0 || IdStatus == 1)
            //{
            //    Query = $"as t01 where {(IdPersona != 0 ? $" t01.IdPersona {IdPersona} and" : "")} (select count(*) from IncidenciaProcess as t02 where t02.IdIncidenciaPermiso = t01.IdIncidenciaPermiso and t02.Revisada = 0) > 0";
            //}
            //else if (IdStatus == 2)
            //{
            //    Query = $"as t01 where {(IdPersona != 0 ? $" t01.IdPersona {IdPersona} and" : "")} (select count(*) from IncidenciaProcess as t02 where t02.IdIncidenciaPermiso = t01.IdIncidenciaPermiso and t02.Revisada = 0) <= 0";
            //}
            //else if (IdStatus == 3)
            //{
            //    Query = $"where estatus = 2 {(IdPersona != 0 ? $" and IdPersona {IdPersona}" : "")}";
            //}
            //else if (IdStatus == 4)
            //{
            //    Query = $"where estatus = 3 {(IdPersona != 0 ? $" and IdPersona {IdPersona}" : "")}";
            //}
            //else
            //{

            //}
            #endregion

            if (IdStatus == 0 || IdStatus == 1)
            {
                Query = $"where estatus = 1 {(IdPersona != 0 ? $" and IdPersona {IdPersona}" : "")}";
            }
            else if (IdStatus == 2)
            {
                Query = $"where estatus = 2 {(IdPersona != 0 ? $" and IdPersona {IdPersona}" : "")}";
            }
            else if (IdStatus == 3)
            {
                Query = $"where estatus = 3 {(IdPersona != 0 ? $" and IdPersona {IdPersona}" : "")}";
            }
            else if (IdStatus == 4)
            {
                Query = $"where estatus = 4 {(IdPersona != 0 ? $" and IdPersona {IdPersona}" : "")}";
            }
            else
            {

            }

            var inc_data = _Dkma.IncidenciaVacacion.GetOpenquery(Query, "order by Creado desc");
            inc_data.ForEach(inc =>
            {
                inc.Proceso = _Dkma.IncidenciaProcess.GetOpenquery($"where IdIncidenciaPermiso = {inc.IdIncidenciaVacacion}", "");
            });
            return inc_data;
            
        }
        /// <summary>
        /// obtener detalles de la solicitud
        /// </summary>
        /// <param name="IdIncidenciaVacacion"></param>
        /// <returns></returns>
        public IncidenciaVacacion Details(int IdIncidenciaVacacion)
        {
            var data = _Dkma.IncidenciaVacacion.Get(IdIncidenciaVacacion);

            if(data is null)
            {
                return null;
            }
            else
            {
                data.Proceso = _Dkma.IncidenciaProcess.GetOpenquery($"where IdIncidenciaPermiso = {data.IdIncidenciaVacacion}", "");
                return data;
            }
        }
        /// <summary>
        /// Verificar si la incidencia ya ha sido procesada
        /// </summary>
        /// <param name="IdIncidenciaVacacion">id de la incidencia</param>
        /// <param name="nivel">[0] valida todos los procesos [2] Jefe inmediato [3] GPS</param>
        /// <returns></returns>
        private string HayRevisiones(int IdIncidenciaVacacion, int nivel = 0)
        {
            if (nivel == 0)
            {
                bool jefe = _Dkma.IncidenciaVacacion.Count($"where IdIncidenciaVacacion = {IdIncidenciaVacacion} and Revisada = 1 and Nivel in(2)") == 1 ? true : false;
                bool gps = _Dkma.IncidenciaVacacion.Count($"where IdIncidenciaVacacion = {IdIncidenciaVacacion} and Revisada = 1 and Nivel in(3)") == 1 ? true : false;

                if (jefe && gps)
                {
                    return $"Esta incidencia ya ha sido revisada por el Jefe imediato y Gestion de personal";
                }
                else if (jefe && !gps)
                {
                    return $"Esta incidencia ya ha sido revisada por el Jefe imediato y esta pendiente de revision por Gestion de personal";
                }
                else if (!jefe && gps)
                {
                    return $"Esta incidencia ya ha sido revisada por Gestion de personal y esta pendiente de revision por el Jefe imediato";
                }
                else
                {
                    return "";
                }
            }
            else
            {
                if (_Dkma.IncidenciaVacacion.Count($"where IdIncidenciaVacacion = {IdIncidenciaVacacion} and Revisada = 1 and Nivel in({nivel})") == 1)
                {
                    return (nivel == 2 ? "El Jefe inmediato " : "Gestión de personal ") + "ya ha revisado esta incidencia";
                }
                else
                {
                    return "";
                }
            }
        }
        /// <summary>
        /// validar datos de incidencia
        /// </summary>
        /// <param name="IncidenciaVacacion">Id de la incidecia</param>
        /// <param name="Mode">Edit, Create</param>
        private void ValidDataActions(IncidenciaVacacion IncidenciaVacacion, string Mode)
        {
            _Dkma.dBConnection.StartProcedure($"SP_IncVacaciones", new List<ProcedureModel>
                {
                    new ProcedureModel { Namefield = "IdIncidenciaVacacion", value = IncidenciaVacacion },
                    new ProcedureModel { Namefield = "Mode", value = Mode }
                });

            if (_Dkma.dBConnection.ErrorCode != 0)
            {
                string[] respuesta = _Dkma.GetLastMessage().Split('@');
                throw new GPException { ErrorCode = 100, Category = TypeException.Info, Description = (respuesta.Length > 1 ? respuesta[1] : ""), IdAux = (respuesta.Length > 1 ? respuesta[0] : "") };
            }
        }
        /// <summary>
        /// aregar proceso a incidencia
        /// </summary>
        /// <param name="IncidenciaPermiso"></param>
        /// <param name="IdPersonaCreador">En session</param>
        private void AddSteps(IncidenciaVacacion IncidenciaVacacion, int IdPersonaCreador)
        {
            try
            {
                var procesoStep = new IncidenciaProcess();
                procesoStep.IdIncidenciaPermiso = 0;
                procesoStep.IdIncidenciaVacacion = IncidenciaVacacion.IdIncidenciaVacacion;
                procesoStep.IdPersona = IdPersonaCreador;
                procesoStep.Fecha = DateTime.Now;
                procesoStep.Titulo = IdPersonaCreador == IncidenciaVacacion.IdPersona ? "Incidencia creada por solicitante" : "Incidencia creada";
                procesoStep.Comentarios = "";
                procesoStep.Nivel = 1;
                procesoStep.Revisada = true;
                procesoStep.Autorizada = true;
                procesoStep.NombreEmpleado = _Dkma.IncidenciaVacacion.GetStringValue($"select NombreCompleto from View_empleado where IdPersona = {IdPersonaCreador}");
                _Dkma.IncidenciaProcess.Element = procesoStep;
                _Dkma.IncidenciaProcess.Add();

                procesoStep.IdIncidenciaVacacion = 0;
                procesoStep.IdPersona = 0;
                procesoStep.Fecha = null;
                procesoStep.Titulo = "Aprobación por jefe inmediato";
                procesoStep.Comentarios = "";
                procesoStep.Nivel = 2;
                procesoStep.Revisada = false;
                procesoStep.Autorizada = false;
                procesoStep.NombreEmpleado = "";
                _Dkma.IncidenciaProcess.Element = procesoStep;
                _Dkma.IncidenciaProcess.Add();

                procesoStep.IdIncidenciaVacacion = 0;
                procesoStep.IdPersona = 0;
                procesoStep.Fecha = null;
                procesoStep.Titulo = "Aprobación por gestión de personal";
                procesoStep.Comentarios = "";
                procesoStep.Nivel = 3;
                procesoStep.Revisada = false;
                procesoStep.Autorizada = false;
                procesoStep.NombreEmpleado = "";
                _Dkma.IncidenciaProcess.Element = procesoStep;
                _Dkma.IncidenciaProcess.Add();

                procesoStep.IdIncidenciaVacacion = 0;
                procesoStep.IdPersona = 0;
                procesoStep.Fecha = null;
                procesoStep.Titulo = "permiso concluido/tomado";
                procesoStep.Comentarios = "";
                procesoStep.Nivel = 4;
                procesoStep.Revisada = false;
                procesoStep.Autorizada = false;
                procesoStep.NombreEmpleado = "";
                _Dkma.IncidenciaProcess.Element = procesoStep;
                _Dkma.IncidenciaProcess.Add();
            }
            catch (Exception ex)
            {

                throw new GPSInformation.Exceptions.GpExceptions(ex.Message);
            }


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
            while (inicio <= hasta)
            {
                if (inicio.DayOfWeek != DayOfWeek.Saturday && inicio.DayOfWeek != DayOfWeek.Sunday)
                {
                    var result = _Dkma.DiaFeriado.GetByColumn(inicio.ToString("yyyy-MM-dd"), nameof(_Dkma.DiaFeriado.Element.Fecha));
                    if (result == null)
                    {
                        dias++;
                    }
                }
                inicio = inicio.AddDays(1);
            }
            return dias;
        }
        #endregion

        #region Metodos Generales
        /// <summary>
        /// terminar procesos
        /// </summary>
        public void Terminar()
        {
            _Dkma.CloseConnection();
            _Dkma.IncidenciaVacacion = null;
            _Dkma.IncidenciaPermiso = null;
            _Dkma.IncidenciaProcess = null;
            _Dkma.DiaFeriado = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
        #endregion
    }
}
