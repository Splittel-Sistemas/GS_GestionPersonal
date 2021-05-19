using GPSInformation.Exceptions;
using GPSInformation.Models;
using GPSInformation.Request;
using GPSInformation.Tools;
using GPSInformation.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace GPSInformation.Controllers
{
    /// <summary>
    /// controlar y procesar puestos, departamentos, direcciones y estructuras de organigrama
    /// </summary>
    public class V2OrganCtrl
    {
        #region Atributos
        /// <summary>
        /// controlador de objetos 
        /// </summary>
        public DarkManager _darkM;
        /// <summary>
        /// Cargar transacciones por metodo
        /// </summary>
        public bool LoadTranssByMethod { get; set; }
        #endregion

        #region Constructores
        public V2OrganCtrl(DarkManager darkManager)
        {
            this._darkM = darkManager;
            this._darkM.OpenConnection();
            this._darkM.LoadObject(GpsManagerObjects.OrganigramaStructura);
            this._darkM.LoadObject(GpsManagerObjects.OrganigramaVersion);
            this._darkM.LoadObject(GpsManagerObjects.Sociedad);
            this._darkM.LoadObject(GpsManagerObjects.Puesto);
            this._darkM.LoadObject(GpsManagerObjects.Departamento);
            this._darkM.LoadObject(GpsManagerObjects.Direccion);
            this._darkM.LoadObject(GpsManagerObjects.SystSelect);
            this._darkM.LoadObject(GpsManagerObjects.AccesosSistema);
        }
        #endregion
        /// <summary>
        /// terminar controllador
        /// </summary>
        public void Terminar()
        {
            _darkM.CloseConnection();
            _darkM.OrganigramaStructura = null;
            _darkM.OrganigramaVersion = null;
            _darkM.Puesto = null;
            _darkM.Departamento = null;
            _darkM.Sociedad = null;
            _darkM.Direccion = null;
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

        #region Sociedades
        /// <summary>
        /// Editar sociedad
        /// </summary>
        /// <param name="sociedad"></param>
        public void SocEdit(Sociedad sociedad)
        {
            if (LoadTranssByMethod) _darkM.StartTransaction();
            try
            {
                Funciones.DarkValidModel(sociedad,"Información incompleta");
                Funciones.DarkValidString(sociedad.Descripcion, $"Por favor introduce un nombre para la nueva sociedad", "Descripcion");
                SocValidExists(sociedad.IdSociedad, true);
                _darkM.Sociedad.Element = sociedad;
                if (!_darkM.Sociedad.Update())
                {
                    throw new GPException { Description = $"Por favor intenta de nuevo, error al registrar la sociedad: '{sociedad.Descripcion}'", ErrorCode = 0, Category = TypeException.Error, IdAux = "" };
                }
                int LastInserted = _darkM.Sociedad.GetLastId();
                if (LoadTranssByMethod) _darkM.Commit();
            }
            catch (GPException)
            {
                if (LoadTranssByMethod) _darkM.RolBack();
                throw;
            }
        }
        /// <summary>
        /// crear sociedad
        /// </summary>
        /// <param name="sociedad">datos para regsitrar</param>
        /// <returns></returns>
        public int SocAdd(Sociedad sociedad)
        {
            if (LoadTranssByMethod) _darkM.StartTransaction();
            try
            {
                Funciones.DarkValidModel(sociedad, "Información incompleta");
                Funciones.DarkValidString(sociedad.Descripcion, $"Por favor introduce un nombre para la nueva sociedad", "Descripcion");
                _darkM.Sociedad.Element = sociedad;
                if (!_darkM.Sociedad.Add())
                {
                    throw new GPException { Description = $"Por favor intenta de nuevo, error al registrar la sociedad: '{sociedad.Descripcion}'", ErrorCode = 0, Category = TypeException.Error, IdAux = "" };
                }
                int LastInserted = _darkM.Sociedad.GetLastId();
                if (LoadTranssByMethod) _darkM.Commit();
                return LastInserted;
            }
            catch (GPException)
            {
                if (LoadTranssByMethod) _darkM.RolBack();
                throw;
            }
        }
        /// <summary>
        /// validar si existe sociedad seleccionada
        /// </summary>
        /// <param name="IdSociedad"> id de la sociedad</param>
        /// <param name="ShowWhenIsnull">forzar exception</param>
        /// <returns></returns>
        public Sociedad SocValidExists(int IdSociedad, bool ShowWhenIsnull = false)
        {
            if(IdSociedad == 0)
                throw new GPException { Description = $"Por favor selecciona una sociedad", ErrorCode = 0, Category = TypeException.Info, IdAux = "" };
            var Sociedad = _darkM.Sociedad.Get(IdSociedad);

            if(Sociedad is null && ShowWhenIsnull)
            {
                throw new GPException { Description = $"No se encontró la sociedad seleccionada", ErrorCode = 0, Category = TypeException.Info, IdAux = "" };
            }

            return Sociedad;
        }
        #endregion

        #region Direcciones
        /// <summary>
        /// Editar direccion
        /// </summary>
        /// <param name="direccion">dataset para dirección</param>
        public void DireEdit(Direccion direccion)
        {
            if (LoadTranssByMethod) _darkM.StartTransaction();
            try
            {
                Funciones.DarkValidModel(direccion, "Información incompleta");
                Funciones.DarkValidString(direccion.Nombre, $"Por favor introduce un nombre para la nueva dirección", "Nombre");
                DireValidExists(direccion.IdDireccion, true);
                _darkM.Direccion.Element = direccion;
                if (!_darkM.Direccion.Update())
                {
                    throw new GPException { Description = $"Por favor intenta de nuevo, error al registrar la sociedad: '{direccion.Nombre}'", ErrorCode = 0, Category = TypeException.Error, IdAux = "" };
                }
                if (LoadTranssByMethod) _darkM.Commit();
            }
            catch (GPException)
            {
                if (LoadTranssByMethod) _darkM.RolBack();
                throw;
            }
        }
        /// <summary>
        /// Registrar nueva direccion
        /// </summary>
        /// <param name="direccion">Dataset para direccion</param>
        /// <returns></returns>
        public int DireAdd(Direccion direccion)
        {
            if (LoadTranssByMethod) _darkM.StartTransaction();
            try
            {
                Funciones.DarkValidModel(direccion, "Información incompleta");
                Funciones.DarkValidString(direccion.Nombre, $"Por favor introduce un nombre para la nueva dirección", "Nombre");

                _darkM.Direccion.Element = direccion;
                if (!_darkM.Direccion.Add())
                {
                    throw new GPException { Description = $"Por favor intenta de nuevo, error al registrar la sociedad: '{direccion.Nombre}'", ErrorCode = 0, Category = TypeException.Error, IdAux = "" };
                }
                int LastInserted = _darkM.Direccion.GetLastId();
                if (LoadTranssByMethod) _darkM.Commit();
                return LastInserted;
            }
            catch (GPException)
            {
                if (LoadTranssByMethod) _darkM.RolBack();
                throw;
            }
        }
        /// <summary>
        /// Validar si existe una direccion
        /// </summary>
        /// <param name="IdDireccion">Id de la direccion</param>
        /// <param name="ShowWhenIsnull">forzar exception</param>
        /// <returns></returns>
        public Direccion DireValidExists(int IdDireccion, bool ShowWhenIsnull = false)
        {
            if (IdDireccion == 0)
                throw new GPException { Description = $"Por favor selecciona una dirección", ErrorCode = 0, Category = TypeException.Info, IdAux = "" };
            var Direccion = _darkM.Direccion.Get(IdDireccion);

            if (Direccion is null && ShowWhenIsnull)
            {
                throw new GPException { Description = $"No se encontró la dirección seleccionada", ErrorCode = 0, Category = TypeException.Info, IdAux = "" };
            }

            return Direccion;

        }
        #endregion

        #region departamentos
        /// <summary>
        /// editar departamento
        /// </summary>
        /// <param name="departamento">dataset</param>
        public void DepEdit(Departamento departamento)
        {
            if (LoadTranssByMethod) _darkM.StartTransaction();
            try
            {
                Funciones.DarkValidModel(departamento, "Información incompleta");
                Funciones.DarkValidString(departamento.Nombre, $"Por favor introduce un nombre para el nuevo departamento", "Nombre");
                DepValidExists(departamento.IdDepartamento);
                DireValidExists(departamento.IdDireccion, true);
                _darkM.Departamento.Element = departamento;
                if (!_darkM.Departamento.Update())
                {
                    throw new GPException { Description = $"Por favor intenta de nuevo, error al acualizar el departamento: '{departamento.Nombre}'", ErrorCode = 0, Category = TypeException.Error, IdAux = "" };
                }
                if (LoadTranssByMethod) _darkM.Commit();
            }
            catch (GPException)
            {
                if (LoadTranssByMethod) _darkM.RolBack();
                throw;
            }
        }
        /// <summary>
        /// crear departamento
        /// </summary>
        /// <param name="departamento">dataset</param>
        /// <returns></returns>
        public int DepAdd(Departamento departamento)
        {
            if (LoadTranssByMethod) _darkM.StartTransaction();
            try
            {
                Funciones.DarkValidModel(departamento, "Información incompleta");
                Funciones.DarkValidString(departamento.Nombre, $"Por favor introduce un nombre para el nuevo departamento", "Nombre");
                DireValidExists(departamento.IdDireccion, true);
                _darkM.Departamento.Element = departamento;
                if (!_darkM.Departamento.Add())
                {
                    throw new GPException { Description = $"Por favor intenta de nuevo, error al registrar el departamento: '{departamento.Nombre}'", ErrorCode = 0, Category = TypeException.Error, IdAux = "" };
                }
                int LastInserted = _darkM.Departamento.GetLastId();
                if (LoadTranssByMethod) _darkM.Commit();
                return LastInserted;
            }
            catch (GPException)
            {
                if (LoadTranssByMethod) _darkM.RolBack();
                throw;
            }
        }
        /// <summary>
        /// validar si existe un departamento
        /// </summary>
        /// <param name="IdDepartamento">Id del departamento</param>
        /// <param name="ShowWhenIsnull">Forzar null exception</param>
        /// <returns>dataset</returns>
        public Departamento DepValidExists(int IdDepartamento, bool ShowWhenIsnull = false)
        {
            if (IdDepartamento == 0)
                throw new GPException
                {
                    Description = $"Por favor selecciona un departamento",
                    ErrorCode = 0,
                    Category = TypeException.Info,
                    IdAux = ""
                };
            var Direccion = _darkM.Departamento.Get(IdDepartamento);

            if (Direccion is null && ShowWhenIsnull)
            {
                throw new GPException { Description = $"No se encontró el Departamento seleccionado", ErrorCode = 0, Category = TypeException.Info, IdAux = "" };
            }

            return Direccion;

        }
        #endregion

        #region Puestos
        /// <summary>
        /// crear puesto
        /// </summary>
        /// <param name="puesto">datset</param>
        /// <param name="IsRequisicion">es IsRequisicion</param>
        public void PueEdit(Puesto puesto, bool IsRequisicion = false)
        {
            if (LoadTranssByMethod) _darkM.StartTransaction();
            try
            {
                Funciones.DarkValidModel(puesto, "Información incompleta");
                Funciones.DarkValidString(puesto.Nombre, $"Por favor introduce un nombre para el nuevo puesto", "Nombre");
                Funciones.DarkValidString(puesto.DescripcionPuesto, $"Por favor introduce una descripcipon", "DescripcionPuesto");

                PueValidExists(puesto.IdPuesto, true);

                #region validar horas y salarios
                if (puesto.HoraEntrada >= puesto.HoraSalida)
                    throw new GPException { Description = $"Horario de entrada es mayor o igual que el horario de salida", ErrorCode = 0, Category = TypeException.Error, IdAux = "HoraEntrada" };

                if (puesto.SalarioMin >= puesto.SalarioMin)
                    throw new GPException { Description = $"Salario minimo es mayor o igual que el salario maximo", ErrorCode = 0, Category = TypeException.Error, IdAux = "SalarioMin" };
                #endregion

                var dep = DepValidExists(puesto.IdDepartamento, true);

                #region valdiar DPU
                if (puesto.NumeroDPU == 0)
                {
                    var NumerpDPU = _darkM.Puesto.GetIntValue($"select max(NumeroDPU) from Puesto where IdDepartamento = {puesto.IdDepartamento} and RequisicionPersonal != 2");
                    puesto.NumeroDPU = NumerpDPU + 1;
                }
                else
                {
                    if (_darkM.Puesto.Count($"select count(*) from Puesto where IdPuesto = {puesto.IdPuesto} and IdDepartamento = {puesto.IdDepartamento} and NumeroDPU = {puesto.NumeroDPU} RequisicionPersonal != 2") > 0)
                    {
                        throw new GPException { Description = $"Ya se encuentra en uso la clave '{puesto.NumeroDPU}' por otro puesto", ErrorCode = 0, Category = TypeException.Error, IdAux = "NumeroDPU" };
                    }
                }
                #endregion

                if (IsRequisicion)
                {
                    puesto.RequisicionPersonal = 2;
                }
                else
                {
                    puesto.RequisicionPersonal = 1;
                }

                puesto.DPU = $"{dep.ClaveDPU}-DPU-{string.Format("0:000", puesto.NumeroDPU)}";
                _darkM.Puesto.Element = puesto;
                if (!_darkM.Puesto.Update())
                {
                    throw new GPException { Description = $"Por favor intenta de nuevo, error al actualizar el Puesto: '{puesto.Nombre}'", ErrorCode = 0, Category = TypeException.Error, IdAux = "" };
                }
                if (LoadTranssByMethod) _darkM.Commit();
            }
            catch (GPException)
            {
                if (LoadTranssByMethod) _darkM.RolBack();
                throw;
            }
        }
        /// <summary>
        /// crear puesto
        /// </summary>
        /// <param name="puesto">data set</param>
        /// <param name="IsRequisicion">Requisicion</param>
        /// <returns>id puesto</returns>
        public int PueAdd(Puesto puesto, bool IsRequisicion = false)
        {
            if (LoadTranssByMethod) _darkM.StartTransaction();
            try
            {
                Funciones.DarkValidModel(puesto, "Información incompleta");
                Funciones.DarkValidString(puesto.Nombre, $"Por favor introduce un nombre para el nuevo puesto", "Nombre");
                Funciones.DarkValidString(puesto.DescripcionPuesto, $"Por favor introduce una descripcipon", "DescripcionPuesto");
               
                #region validar horas y salarios
                if (puesto.HoraEntrada >= puesto.HoraSalida)
                    throw new GPException { Description = $"Horario de entrada es mayor o igual que el horario de salida", ErrorCode = 0, Category = TypeException.Error, IdAux = "HoraEntrada" };

                if (puesto.SalarioMin >= puesto.SalarioMin)
                    throw new GPException { Description = $"Salario minimo es mayor o igual que el salario maximo", ErrorCode = 0, Category = TypeException.Error, IdAux = "SalarioMin" };
                #endregion

                var dep = DepValidExists(puesto.IdDepartamento, true);
               
                #region valdiar DPU
                if (puesto.NumeroDPU == 0)
                {
                    var NumerpDPU = _darkM.Puesto.GetIntValue($"select max(NumeroDPU) from Puesto where IdDepartamento = {puesto.IdDepartamento} and RequisicionPersonal != 2");
                    puesto.NumeroDPU = NumerpDPU + 1;
                }
                else
                {
                    if (_darkM.Puesto.Count($"select count(*) from Puesto where IdDepartamento = {puesto.IdDepartamento} and NumeroDPU = {puesto.NumeroDPU} RequisicionPersonal != 2") > 0)
                    {
                        throw new GPException { Description = $"Ya se encuentra en uso la clave '{puesto.NumeroDPU}'", ErrorCode = 0, Category = TypeException.Error, IdAux = "NumeroDPU" };
                    }
                }
                #endregion

                if (IsRequisicion)
                {
                    puesto.RequisicionPersonal = 2;
                }
                else
                {
                    puesto.RequisicionPersonal = 1;
                }
                
                puesto.DPU = $"{dep.ClaveDPU}-DPU-{string.Format("0:000", puesto.NumeroDPU)}";
                _darkM.Puesto.Element = puesto;
                if (!_darkM.Puesto.Add())
                {
                    throw new GPException { Description = $"Por favor intenta de nuevo, error al registrar el Puesto: '{puesto.Nombre}'", ErrorCode = 0, Category = TypeException.Error, IdAux = "" };
                }
                int LastInserted = _darkM.Puesto.GetLastId();
                if (LoadTranssByMethod) _darkM.Commit();
                return LastInserted;
            }
            catch (GPException)
            {
                if (LoadTranssByMethod) _darkM.RolBack();
                throw;
            }
        }
        /// <summary>
        /// Validar si existe puesto
        /// </summary>
        /// <param name="IdPuesto">id puesto</param>
        /// <param name="ShowWhenIsnull">forze show null excepction</param>
        /// <returns>dataset</returns>
        public Puesto PueValidExists(int IdPuesto, bool ShowWhenIsnull = false)
        {
            if (IdPuesto == 0)
                throw new GPException
                {
                    Description = $"Por favor selecciona un Puesto",
                    ErrorCode = 0,
                    Category = TypeException.Info,
                    IdAux = ""
                };
            var Direccion = _darkM.Puesto.Get(IdPuesto);

            if (Direccion is null && ShowWhenIsnull)
            {
                throw new GPException { Description = $"No se encontró el Puesto seleccionado", ErrorCode = 0, Category = TypeException.Info, IdAux = "" };
            }

            return Direccion;
        }
        #endregion

        #region Organigrama
        /// <summary>
        /// obtener puestos sin agregar a un organigrama
        /// </summary>
        /// <param name="IdOrganigramaVersion"></param>
        /// <returns></returns>
        public List<SystSelect> OrgNodePuestosFree(int IdOrganigramaVersion, bool FilterByVersion = true)
        {
            if (FilterByVersion)
            {
                return _darkM.SystSelect.GetSpecialStat($"select " +
                   $"  t01.IdPuesto as Value, " +
                   $"  t01.Nombre as Label " +
                   $"from Puesto as t01 where IdPuesto not in (select t02.IdPuesto from OrganigramaStructura as t02 where t02.IdOrganigramaVersion = {IdOrganigramaVersion} ) order by t01.Nombre");
            }
            else
            {
                return _darkM.SystSelect.GetSpecialStat($"select " +
                   $"  t01.IdPuesto as Value, " +
                   $"  t01.Nombre as Label " +
                   $"from Puesto as t01 where IdPuesto in (select t02.IdPuesto from OrganigramaStructura as t02 where t02.IdOrganigramaVersion = {IdOrganigramaVersion} ) order by t01.Nombre");
            }
           
        }
        /// <summary>
        /// listar empleados que opcupan el puesto seleccionado
        /// </summary>
        /// <param name="IdPuesto"></param>
        /// <returns></returns>
        public List<SystSelect> OrgNodeOcupantes(int IdPuesto)
        {
            return _darkM.SystSelect.GetSpecialStat($"select IdPersona as Value, NombreCompleto as Label from View_Empleado where IdEstatus = 19 and IdPuesto = {IdPuesto}  order by NombreCompleto");
        }
        /// <summary>
        /// cambiar jefe 
        /// </summary>
        /// <param name="IdOrganigramaVersion">Id del organigrama</param>
        /// <param name="IdPuesto">Id de puesto a procesar</param>
        /// <param name="IdPuestoParentNew">Nuevo puesto parent</param>
        public void OrgNodeMoveTo(int IdOrganigramaVersion, int IdPuesto, int IdPuestoParentNew)
        {
            if (LoadTranssByMethod) _darkM.StartTransaction();
            try
            {
                var data = OrgNodeParentExits(IdOrganigramaVersion, IdPuesto);
                data.IdPuestoParent = IdPuestoParentNew;
                _darkM.OrganigramaStructura.Element = data;
                if (!_darkM.OrganigramaStructura.Update())
                {
                    throw new GPException { Description = "No se movio el puesto solicitado, por favor intenta nuevamente", ErrorCode = 0, Category = TypeException.Info, IdAux = "" };
                }
                if (LoadTranssByMethod) _darkM.Commit();
            }
            catch (GPException)
            {
                if (LoadTranssByMethod) _darkM.RolBack();
                throw;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="IdOrganigramaVersion">Id del organigrama</param>
        /// <param name="IdPuesto">Id de puesto a procesar</param>
        /// <param name="IdPuestoParent">Puesto parent</param>
        public void OrgNodeDelete(int IdOrganigramaVersion, int IdPuesto)
        {
            if (LoadTranssByMethod) _darkM.StartTransaction();
            try
            {
                var data = OrgNodeParentExits(IdOrganigramaVersion, IdPuesto);
                var NodesChidls = _darkM.OrganigramaStructura.Count($" IdOrganigramaVersion = {IdOrganigramaVersion} and IdPuestoParent = {IdPuesto}");
                if(NodesChidls != 0)
                {
                    throw new GPException { Description = $"Puesto no eliminado, El puesto {data.Descripcion} tiene asignado a mas de un puesto dentro del organigrama {string.Format("OR-{0:0000}", IdOrganigramaVersion)}", ErrorCode = 0, Category = TypeException.Error, IdAux = "" };
                }
                _darkM.OrganigramaStructura.Element = data;
                if (!_darkM.OrganigramaStructura.Delete())
                {
                    throw new GPException { Description = "No se elimino el puesto solicitado, por favor intenta nuevamente", ErrorCode = 0, Category = TypeException.Info, IdAux = "" };
                }
                if (LoadTranssByMethod) _darkM.Commit();
            }
            catch (GPException)
            {
                if (LoadTranssByMethod) _darkM.RolBack();
                throw;
            }
        }
        
        /// <summary>
        /// Agregar nuevo puesto a organigrama
        /// </summary>
        /// <param name="IdOrganigramaVersion">Id del organigrama</param>
        /// <param name="IdPuesto">Id de puesto a procesar</param>
        /// <param name="IdPuestoParent">Puesto parent</param>
        public void OrgNodeAdd(OrgNodeReq orgNodeReq)
        {
            if (LoadTranssByMethod) _darkM.StartTransaction();
            try
            {
                //extraer datos de la version
                OrgValidExistVer(orgNodeReq.IdOrganigramaVersion);

                // validar si existe ya el puesto
                OrgNodeChildExits(orgNodeReq.IdOrganigramaVersion, orgNodeReq.IdPuesto);

                // validar si ya esta registrado el puesto parent
                OrgNodeParentExits(orgNodeReq.IdOrganigramaVersion, orgNodeReq.IdPuestoParent);
                
                // agregar informacion del nuevo puesto
                var data = new OrganigramaStructura
                {
                    IdOrganigramaVersion = orgNodeReq.IdOrganigramaVersion,
                    IdPuesto = orgNodeReq.IdPuesto,
                    IdPuestoParent = orgNodeReq.IdPuestoParent,
                    FechaCreacion = DateTime.Now,
                    Nivel = orgNodeReq.Nivel,
                    DPU = _darkM.OrganigramaStructura.GetStringValue($" select DPU from View_puestos where IdPuesto = {orgNodeReq.IdPuesto}"),
                    Descripcion = _darkM.OrganigramaStructura.GetStringValue($" select Nombre from View_puestos where IdPuesto = {orgNodeReq.IdPuesto}")
                };
                _darkM.OrganigramaStructura.Element = data;
                if (!_darkM.OrganigramaStructura.Add())
                {
                    throw new GPException { Description = "No se agregó el puesto solicitado, por favor intenta nuevamente", ErrorCode = 0, Category = TypeException.Info, IdAux = "" };
                }

                if (LoadTranssByMethod) _darkM.Commit();
            }
            catch (GPException ex)
            {
                if (LoadTranssByMethod) _darkM.RolBack();
                throw ex;
            }
        }
        /// <summary>
        /// Obtener lista de puestos por puesto jefe
        /// </summary>
        /// <param name="IdOrganigramaVersion">Version del organigrama</param>
        /// <param name="IdPuestoParent">Puesto parent</param>
        /// <returns></returns>
        public List<OrganigramaStructura> OrgNodeChilds(int IdOrganigramaVersion, int IdPuestoParent)
        {
            return _darkM.OrganigramaStructura.GetOpenquery($"where  IdOrganigramaVersion = {IdOrganigramaVersion} and IdPuestoParent = {IdPuestoParent}", "order by DPU");
        }
        /// <summary>
        /// validar si existe un puesto en el organigrama
        /// </summary>
        /// <param name="IdOrganigramaVersion">Version del organigrama</param>
        /// <param name="IdPuesto">Puesto hijo</param>
        public void OrgNodeChildExits(int IdOrganigramaVersion, int IdPuesto)
        {
            var data = _darkM.OrganigramaStructura.GetOpenquerys($"where IdOrganigramaVersion = {IdOrganigramaVersion} and IdPuesto = {IdPuesto}");
            if (data != null)
            {
                if(data.IdPuestoParent != 0)
                {
                    string puestoP = _darkM.OrganigramaStructura.GetStringValue($" select Nombre from Puesto where IdPuesto = {data.IdPuestoParent}");
                    throw new GPException { Description = $"El puesto {data.Descripcion} ya se encuentra a cargo de {puestoP} dentro del organigrama {string.Format("OR-{0:0000}", IdOrganigramaVersion)}", ErrorCode = 0, Category = TypeException.Error, IdAux = "" };
                }
                else
                {
                    throw new GPException { Description = $"El puesto {data.Descripcion} ya se encuentra  dentro del organigrama {string.Format("OR-{0:0000}", IdOrganigramaVersion)}", ErrorCode = 0, Category = TypeException.Error, IdAux = "" };
                }
                
            }
        }
        /// <summary>
        /// validar si existe un puesto padre
        /// </summary>
        /// <param name="IdOrganigramaVersion">Version del organigrama</param>
        /// <param name="IdPuestoParent">Puesto padre</param>
        public OrganigramaStructura OrgNodeParentExits(int IdOrganigramaVersion, int IdPuestoParent)
        {
            var data = _darkM.OrganigramaStructura.GetOpenquerys($"where IdOrganigramaVersion = {IdOrganigramaVersion} and IdPuesto = {IdPuestoParent}");
            if (data is  null)
            {
                if(IdPuestoParent != 0)
                {
                    string puestoP = _darkM.OrganigramaStructura.GetStringValue($" select Nombre from Puesto where IdPuesto = {IdPuestoParent}");
                    throw new GPException { Description = $"El puesto {puestoP} no se encuentra dentro del organigrama {string.Format("OR-{0:0000}", IdOrganigramaVersion)}", ErrorCode = 0, Category = TypeException.Error, IdAux = "" };
                }
            }

            return data;
        }
        /// <summary>
        /// Validar si existe version del organigrama
        /// </summary>
        /// <param name="IdOrganigramaVersion">vversion del organigrama</param>
        public OrganigramaVersion OrgValidExistVer(int IdOrganigramaVersion)
        {
            var dataORG = _darkM.OrganigramaVersion.GetOpenquerys($"where  IdOrganigramaVersion = {IdOrganigramaVersion} and (Eliminado is null or Eliminado != 1)");
            if (dataORG is null)
                throw new GPException { Description = $"No se econtró el organigrama {string.Format("OR-{0:0000}", IdOrganigramaVersion)}", ErrorCode = 0, Category = TypeException.Error, IdAux = "" };


            return dataORG;
        }
        #endregion

        #region Organigrama versiones
        /// <summary>
        /// Autorizar una version
        /// </summary>
        /// <param name="IdOrganigramaVersion">>Id del organigrama</param>
        public void OrgAutorizar(int IdOrganigramaVersion)
        {
            if (LoadTranssByMethod) _darkM.StartTransaction();
            try
            {
                //extraer datos de la version
                var data = OrgValidExistVer(IdOrganigramaVersion);
                if (data.Autirizada == 1)
                {
                    _darkM.OrganigramaVersion.GetOpenquery($"where Autirizada = 2", "").ForEach(version =>
                    {
                        //remover autorizacion
                        version.FechaActualizacion = DateTime.Now;
                        version.Autirizada = 1;
                        _darkM.OrganigramaVersion.Element = version;
                        if (!_darkM.OrganigramaVersion.Update())
                        {
                            throw new GPException { Description = "Error al actualizar", ErrorCode = 0, Category = TypeException.Info, IdAux = "" };
                        }
                    });

                    //autorizar
                    data.FechaActualizacion = DateTime.Now;
                    data.Autirizada = 2;
                    _darkM.OrganigramaVersion.Element = data;
                    if (!_darkM.OrganigramaVersion.Update())
                    {
                        throw new GPException { Description = "Error al actualizar", ErrorCode = 0, Category = TypeException.Info, IdAux = "" };
                    }
                }
                if (LoadTranssByMethod) _darkM.Commit();
            }
            catch (GPException)
            {
                if (LoadTranssByMethod) _darkM.RolBack();
                throw;
            }
        }
        /// <summary>
        /// editar comentarios de una version de organigrama
        /// </summary>
        /// <param name="IdOrganigramaVersion">id de la version</param>
        /// <param name="Comentarios">Comentarios</param>
        public void OrgEditComentas(int IdOrganigramaVersion, string Comentarios)
        {
            if (LoadTranssByMethod) _darkM.StartTransaction();
            try
            {
                if (string.IsNullOrEmpty(Comentarios))
                    throw new GPException { Description = "Por favor introduce algún comentario", ErrorCode = 0, Category = TypeException.Info, IdAux = "" };

                //extraer datos de la version
                var data = OrgValidExistVer(IdOrganigramaVersion);

                //modificar datos para estatus eliminado
                data.Comentarios = Comentarios;
                data.FechaActualizacion = DateTime.Now;
                _darkM.OrganigramaVersion.Element = data;
                if (!_darkM.OrganigramaVersion.Update())
                {
                    throw new GPException { Description = "Error al actualizar", ErrorCode = 0, Category = TypeException.Info, IdAux = "" };
                }

                if (LoadTranssByMethod) _darkM.Commit();
            }
            catch (GPException)
            {
                if (LoadTranssByMethod) _darkM.RolBack();
                throw;
            }
        }
        /// <summary>
        /// eliminar organigrama(solo se actualiza el campo Eliminado = 1)
        /// </summary>
        /// <param name="IdOrganigramaVersion">Id de la versión</param>
        public void OrgDelete(int IdOrganigramaVersion)
        {
            if (LoadTranssByMethod) _darkM.StartTransaction();
            try
            {
                //extraer datos de la version
                var data = OrgValidExistVer(IdOrganigramaVersion);

                if (data.Autirizada == 2)
                {
                    throw new GPException { Description = "Info, no es posible eliminar esta versión ya que se encuentra como organigrama VIGENTE, si deseas eliminar por favor elige otro como VIGENTE", ErrorCode = 0, Category = TypeException.Error, IdAux = "" };
                }
                //modificar datos para estatus eliminado
                data.Eliminado = true;
                data.FechaActualizacion = DateTime.Now;
                _darkM.OrganigramaVersion.Element = data;
                if (!_darkM.OrganigramaVersion.Update())
                {
                    throw new GPException { Description = "Error al eliminar la version del organigrama", ErrorCode = 0, Category = TypeException.Info, IdAux = "" };
                }

                if (LoadTranssByMethod) _darkM.Commit();
            }
            catch (GPException)
            {
                if (LoadTranssByMethod) _darkM.RolBack();
                throw;
            }
        }
        /// <summary>
        /// Crear nuevo organigrama
        /// </summary>
        /// <param name="Comentarios">Comentarios de la nueva version</param>
        /// <returns>id del la version creada</returns>
        public int OrgCreate(string Comentarios)
        {
            if (LoadTranssByMethod) _darkM.StartTransaction();
            try
            {
                if (string.IsNullOrEmpty(Comentarios))
                    throw new GPException { Description = "Por favor introduce algún comentario para crear la nueva versión", ErrorCode = 0, Category = TypeException.Info, IdAux = "" };
                //validar datos
                var organigramaVersion = new OrganigramaVersion
                {
                    Eliminado = false,
                    Autirizada = 1,
                    FechaCreacion = DateTime.Now,
                    FechaActualizacion = DateTime.Now,
                    Comentarios = Comentarios
                };
                _darkM.OrganigramaVersion.Element = organigramaVersion;
                if (!_darkM.OrganigramaVersion.Add())
                {
                    throw new GPException { Description = "Error al guardar crear el nuevo organigrama", ErrorCode = 0, Category = TypeException.Info, IdAux = "" };
                }

                int LastCreated = _darkM.OrganigramaVersion.GetLastId();
                if (LoadTranssByMethod) _darkM.Commit();

                return LastCreated;

            }
            catch (GPException)
            {
                if (LoadTranssByMethod) _darkM.RolBack();
                throw;
            }
        }
        /// <summary>
        /// Copiar organigrama
        /// </summary>
        /// <param name="Comentarios"></param>
        /// <param name="IdVersionCopy"></param>
        /// <returns></returns>
        public int OrgCopyTo(string Comentarios, int IdVersionCopy)
        {
            if (LoadTranssByMethod) _darkM.StartTransaction();
            try
            {
                if (string.IsNullOrEmpty(Comentarios))
                    throw new GPException { Description = "Por favor introduce algún comentario para crear la nueva versión", ErrorCode = 0, Category = TypeException.Info, IdAux = "" };

                OrgValidExistVer(IdVersionCopy);
                int LastCreated = OrgCreate(Comentarios);

                _darkM.OrganigramaStructura.GetOpenquery($"where  IdOrganigramaVersion = {IdVersionCopy}", "").ForEach(node =>
                {
                    node.IdOrganigramaStructura = 0;
                    node.IdOrganigramaVersion = LastCreated;
                    node.FechaCreacion = DateTime.Now;
                    _darkM.OrganigramaStructura.Element = node;
                    if (!_darkM.OrganigramaStructura.Add())
                    {
                        throw new GPException { Description = $"Error al copiar el nodo: {node.Descripcion}", ErrorCode = 0, Category = TypeException.Info, IdAux = "" };
                    }
                });

                if (LoadTranssByMethod) _darkM.Commit();

                return LastCreated;

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
