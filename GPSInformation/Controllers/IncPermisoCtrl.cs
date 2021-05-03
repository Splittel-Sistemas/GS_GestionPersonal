using GPSInformation.Exceptions;
using GPSInformation.Models;
using GPSInformation.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace GPSInformation.Controllers
{
    public class IncPermisoCtrl
    {
        #region Atributos
        public DarkManager _Dkma { get; internal set; }
        #endregion

        #region Constructores
        public IncPermisoCtrl(DarkManager _Dkma)
        {
            this._Dkma = _Dkma;
            this._Dkma.OpenConnection();
            this._Dkma.LoadObject(GpsManagerObjects.IncidenciaProcess);
            this._Dkma.LoadObject(GpsManagerObjects.IncidenciaPermiso);
            this._Dkma.LoadObject(GpsManagerObjects.IncidenciaVacacion);
        }
        #endregion

        #region Metodos
        /// <summary>
        /// autorizar una incidencia
        /// </summary>
        /// <param name="inAutorizacion"></param>
        public void Autorizar(InAutorizacion inAutorizacion)
        {
            _Dkma.StartTransaction();
            try
            {
                if (inAutorizacion is null)
                {
                    throw new GPException { ErrorCode = 200, Category = TypeException.Info, Description = "Error, informacion incorrecta", IdAux = "" };
                }
                var estatus = _Dkma.IncidenciaProcess.GetOpenquerys($" where IncidenciaPermiso = {inAutorizacion.IdIncidencia} and Nivel = {inAutorizacion.Mode}");
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
        /// Eliminar incidencia
        /// </summary>
        /// <param name="IdIncidenciaPermiso"></param>
        public void Eliminar(int IdIncidenciaPermiso, int IdPersonaCreador)
        {
            _Dkma.StartTransaction();
            try
            {
                var IncidenciaPermiso = _Dkma.IncidenciaPermiso.Get(IdIncidenciaPermiso);
                if (IncidenciaPermiso is null)
                {
                    throw new GPException { ErrorCode = 200, Category = TypeException.Info, Description = "Error, no se encontró el permiso que deseas eliminar", IdAux = "" };
                }

                IncidenciaPermiso.Estatus = 5;
                _Dkma.IncidenciaPermiso.Element = IncidenciaPermiso;

                if (!_Dkma.IncidenciaPermiso.Update())
                {
                    throw new GPException { ErrorCode = 200, Category = TypeException.Info, Description = "Error, El permiso no pudo ser eliminar, intenta de nuevo", IdAux = "" };
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
        /// cancelar solictud
        /// </summary>
        /// <param name="IdIncidenciaPermiso">id de la incidencia</param>
        /// <param name="IdPersonaCreador">En session</param>
        public void Cancel(int IdIncidenciaPermiso, int IdPersonaCreador)
        {
            _Dkma.StartTransaction();
            try
            {
                var IncidenciaPermiso = _Dkma.IncidenciaPermiso.Get(IdIncidenciaPermiso);
                if(IncidenciaPermiso is null)
                {
                    throw new GPException { ErrorCode = 200, Category = TypeException.Info, Description = "Error, no se encontró el permiso que deseas cancelar", IdAux = "" };
                }
                if (IncidenciaPermiso.Estatus == 4)
                {
                    throw new GPException { ErrorCode = 200, Category = TypeException.Info, Description = "Info, esta incidencia no puede ser cancelada ya que fue concluida", IdAux = "" };
                }
                IncidenciaPermiso.Estatus = 2;
                _Dkma.IncidenciaPermiso.Element = IncidenciaPermiso;

                if (!_Dkma.IncidenciaPermiso.Update())
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
        /// editar permiso
        /// </summary>
        /// <param name="IncidenciaPermiso">id de la incidencia</param>
        /// <param name="IdPersonaCreador">En session</param>
        public void Edit(IncidenciaPermiso IncidenciaPermiso, int IdPersonaCreador)
        {
            _Dkma.StartTransaction();
            try
            {
                ValidDataActions(IncidenciaPermiso);
                if(IncidenciaPermiso.IdPersona == 0  || IncidenciaPermiso.IdIncidenciaPermiso == 0)
                {
                    throw new GPException { ErrorCode = -200, Category = TypeException.Info, Description = "Por favor verifica información, algunos datos no estan siendo enviados correctamente", IdAux = "" };
                }
                var estatus = HayRevisiones(IncidenciaPermiso.IdIncidenciaPermiso);
                if (estatus != "")
                {
                    throw new GPException { ErrorCode = 300, Category = TypeException.Info, Description = estatus, IdAux = "" };
                }
                estatus = "";

                _Dkma.IncidenciaPermiso.Element = IncidenciaPermiso;

                if (!_Dkma.IncidenciaPermiso.Update())
                {
                    throw new GPException { ErrorCode = 200, Category = TypeException.Info, Description = "Error, El permiso no pudo ser actualizado, intenta de nuevo", IdAux = "" };
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
        /// crear permiso
        /// </summary>
        /// <param name="IncidenciaPermiso">id de la incidencia</param>
        /// <param name="IdPersonaCreador">En session</param>
        /// <returns></returns>
        public int Create(IncidenciaPermiso IncidenciaPermiso, int IdPersonaCreador)
        {
            var IdCreated = 0;
            _Dkma.StartTransaction();
            try
            {
                #region incidencia
                ValidDataActions(IncidenciaPermiso);

                IncidenciaPermiso.CreadoPor = "Empleado";
                IncidenciaPermiso.Estatus = 1;
                IncidenciaPermiso.Creado = DateTime.Now;

                _Dkma.IncidenciaPermiso.Element = IncidenciaPermiso;

                if (!_Dkma.IncidenciaPermiso.Add())
                {
                    throw new GPException { ErrorCode = 200, Category = TypeException.Info, Description = "Error, El permiso no pudo ser guardado, intenta de nuevo", IdAux = "" };
                }
                #endregion

                IdCreated = _Dkma.IncidenciaPermiso.LastInserted($"select IdIncidenciaPermiso from IncidenciaPermiso where IdPersona = {IncidenciaPermiso.IdPersona} ");
                IncidenciaPermiso.IdIncidenciaPermiso = IdCreated;
                AddSteps(IncidenciaPermiso, IdPersonaCreador);

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
        /// listar permisos
        /// </summary>
        /// <param name="IdStatus">Filtro [0, 1] En proceso, [2] canceladas, [3] Aprobadas [4] concluidas</param>
        /// <param name="IdPersona">id de la persona, enviar 0 para extraer todo</param>
        /// <returns></returns>
        public List<IncPermResp> Get(int IdStatus = 0, int IdPersona = 0)
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

            var lista = new List<IncPermResp>();
            _Dkma.IncidenciaPermiso.GetOpenquery(Query, "order by Creado desc").ForEach(per =>
            {
                var permiso = new IncPermResp
                {
                    IncidenciaPermiso = per,
                    Asunto = _Dkma.IncidenciaPermiso.GetStringValue($"select Descripcion from CatalogoOpcionesValores where IdCatalogoOpcionesValores = {per.IdAsunto}"),
                    pago = _Dkma.IncidenciaPermiso.GetStringValue($"select Descripcion from CatalogoOpcionesValores where IdCatalogoOpcionesValores = {per.IdPagoPermiso}"),
                    Empleado = _Dkma.IncidenciaPermiso.GetStringValue($"select NombreCompleto from View_empleado where IdPersona = {per.IdPersona}"),
                };
                permiso.IncidenciaPermiso.Proceso = _Dkma.IncidenciaProcess.GetOpenquery($"where IdIncidenciaPermiso = {per.IdIncidenciaPermiso}", "");
                lista.Add(permiso); ;
            });
            return lista;
        }
        /// <summary>
        /// detalle de incidencia
        /// </summary>
        /// <param name="IdIncidenciaPermiso"></param>
        /// <returns></returns>
        public IncPermResp Details(int IdIncidenciaPermiso)
        {
            var per = _Dkma.IncidenciaPermiso.Get(IdIncidenciaPermiso);
            if(per is null)
            {
                return null;
            }
            else
            {
                var permiso = new IncPermResp
                {
                    IncidenciaPermiso = per,
                    Asunto = _Dkma.IncidenciaPermiso.GetStringValue($"select Descripcion from CatalogoOpcionesValores where IdCatalogoOpcionesValores = {per.IdAsunto}"),
                    pago = _Dkma.IncidenciaPermiso.GetStringValue($"select Descripcion from CatalogoOpcionesValores where IdCatalogoOpcionesValores = {per.IdPagoPermiso}"),
                    Empleado = _Dkma.IncidenciaPermiso.GetStringValue($"select NombreCompleto from View_empleado where IdPersona = {per.IdPersona}"),
                };
                permiso.IncidenciaPermiso.Proceso = _Dkma.IncidenciaProcess.GetOpenquery($"where IdIncidenciaPermiso = {per.IdIncidenciaPermiso}", "");


                return permiso;
            }
        }
        /// <summary>
        /// Verificar si la incidencia ya ha sido procesada
        /// </summary>
        /// <param name="IdIncidenciaPermiso">id de la incidencia</param>
        /// <param name="nivel">[0] valida todos los procesos [2] Jefe inmediato [3] GPS</param>
        /// <returns></returns>
        private string HayRevisiones(int IdIncidenciaPermiso, int nivel = 0)
        {
            if(nivel == 0)
            {
                bool jefe = _Dkma.IncidenciaPermiso.Count($"where IdIncidenciaPermiso = {IdIncidenciaPermiso} and Revisada = 1 and Nivel in(2)") == 1 ? true : false;
                bool gps = _Dkma.IncidenciaPermiso.Count($"where IdIncidenciaPermiso = {IdIncidenciaPermiso} and Revisada = 1 and Nivel in(3)") == 1 ? true : false;

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
                if(_Dkma.IncidenciaPermiso.Count($"where IdIncidenciaPermiso = {IdIncidenciaPermiso} and Revisada = 1 and Nivel in({nivel})") == 1)
                {
                    return (nivel == 2 ? "El Jefe inmediato " : "Gestión de personal " ) + "ya ha revisado esta incidencia";
                }
                else
                {
                    return "";
                }
            }
        }
        /// <summary>
        /// aregar proceso a incidencia
        /// </summary>
        /// <param name="IncidenciaPermiso"></param>
        /// <param name="IdPersonaCreador">En session</param>
        private void AddSteps(IncidenciaPermiso IncidenciaPermiso, int IdPersonaCreador)
        {
            try
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
                procesoStep.NombreEmpleado = _Dkma.IncidenciaPermiso.GetStringValue($"select NombreCompleto from View_empleado where IdPersona = {IdPersonaCreador}");
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
        /// validar informacion de edit y create
        /// </summary>
        /// <param name="IncidenciaPermiso"></param>
        private void ValidDataActions(IncidenciaPermiso IncidenciaPermiso)
        {
            if (IncidenciaPermiso is null)
            {
                throw new GPException { ErrorCode = -100, Category = TypeException.Error, Description = "Información incorrecta" };
            }

            //salida por cuestiones personales
            if (IncidenciaPermiso.IdAsunto == 36 && IncidenciaPermiso.IdPagoPermiso == 0)
            {
                throw new GPException { ErrorCode = 100, Category = TypeException.Info, Description = "Por favor selecciona un tipo de permiso", IdAux = "IdPagoPermiso" };
            }
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
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
        #endregion
    }
}
