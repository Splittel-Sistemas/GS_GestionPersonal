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
    public class V2EmpleadoCtrl
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
        /*
         
        19	Lectura de empleados
        20	Escritura de empleados
        21	Lectura de prospectos
        22	Escritura de prospectos
        23	Lectura de prenomina
        25	Escritura de prenomina
        26	Lectura y escritura de requisiciones
        28	Autorizar requisiciones
        1054	Crear incidencias
         */
        public Dictionary<string, AccesosUs> _Accesos { get; internal set; }
        #endregion

        #region Constructores
        public V2EmpleadoCtrl(DarkManager darkManager, int IdUsuario, int IdPersona)
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
            this._darkM.LoadObject(GpsManagerObjects.InformacionMedica);
            this._darkM.LoadObject(GpsManagerObjects.Persona);
            this._darkM.LoadObject(GpsManagerObjects.PersonaContacto);
            this._darkM.LoadObject(GpsManagerObjects.Empleado);
            this._darkM.LoadObject(GpsManagerObjects.SystSelect);
            this._darkM.LoadObject(GpsManagerObjects.ExpedienteArchivo);
            this._darkM.LoadObject(GpsManagerObjects.ExpedienteEmpleado);

            _UsrCrt = new UsuarioCtrl(_darkM, true);

            _Accesos = new Dictionary<string, AccesosUs>();

            _NombreCompleto = _darkM.Persona.GetStringValue($"select NombreCompleto from View_empleado where IdPersona = {IdPersona}");
            //obtener permisos
            _Accesos["ALecturaNominas"] = new AccesosUs { IdSubModulo = 18, TieneAcceso = _UsrCrt.ValidAction(IdUsuario, 18) };
            _Accesos["AlecturaEmpleados"] = new AccesosUs { IdSubModulo = 19, TieneAcceso = _UsrCrt.ValidAction(IdUsuario, 19) };
            _Accesos["AEscrituraEmpleados"] = new AccesosUs { IdSubModulo = 20, TieneAcceso = _UsrCrt.ValidAction(IdUsuario, 20) };
            _Accesos["ALecturaProspectos"] = new AccesosUs { IdSubModulo = 21, TieneAcceso = _UsrCrt.ValidAction(IdUsuario, 21) };
            _Accesos["AEscrituraProspectos"] = new AccesosUs { IdSubModulo = 22, TieneAcceso = _UsrCrt.ValidAction(IdUsuario, 22) };
            _Accesos["ALecturaPrenomina"] = new AccesosUs { IdSubModulo = 23, TieneAcceso = _UsrCrt.ValidAction(IdUsuario, 23) };
            _Accesos["AEscrituraPrenomina"] = new AccesosUs { IdSubModulo = 25, TieneAcceso = _UsrCrt.ValidAction(IdUsuario, 25) };
            _Accesos["AEscrituraPRequisisiones"] = new AccesosUs { IdSubModulo = 25, TieneAcceso = _UsrCrt.ValidAction(IdUsuario, 26) };
            _Accesos["AAutorizarRequisisiones"] = new AccesosUs { IdSubModulo = 25, TieneAcceso = _UsrCrt.ValidAction(IdUsuario, 28) };
            _Accesos["ACrearIncidencias"] = new AccesosUs { IdSubModulo = 25, TieneAcceso = _UsrCrt.ValidAction(IdUsuario, 1054) };
        }
        #endregion

        #region Empleado informacion personal
        /// <summary>
        /// 
        /// </summary>
        /// <param name="IdPersona"></param>
        /// <returns></returns>
        public Persona EmpPersonalDetails(int IdPersona)
        {
            if(IdPersona == 0) IdPersona = _IdPersona;
            ValidarAcciones(V2EmpleadoValidation.Details, V2EmpleadoSeccion.Personal, IdPersona);

            var data = _darkM.Persona.GetOpenquerys($"where IdPersona = {IdPersona}");

            if(data != null)
            {
                data.Cat_Generos = (SystSelect)GetCatalogo(V2EmpleadoCatalogo.Genero, V2EmpleadoCatalogoDatatype.Details, data.IdGenero);
                data.Cat_EstadosCiviles = (SystSelect)GetCatalogo(V2EmpleadoCatalogo.EstatusCivil, V2EmpleadoCatalogoDatatype.Details, data.IdEstadoCivil);
            }

            return data;
        }
        /// <summary>
        /// /
        /// </summary>
        /// <param name="persona"></param>
        public int EmpPersonaCreate(Persona persona)
        {
            ValidarAcciones(V2EmpleadoValidation.Create, V2EmpleadoSeccion.Personal, persona.IdPersona, persona);
            ValidCorreo(persona.Email, "Email");
            persona.Empleado = 1;
            _darkM.Persona.Element = persona;
            _darkM.Persona.Add();
            int lastId = _darkM.Persona.GetLastId();

            SPValidator(lastId, "EmpPersonaCreate");
            return lastId;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="persona"></param>
        public int EmpPersonaEdit(Persona persona)
        {
            ValidarAcciones(V2EmpleadoValidation.Edit, V2EmpleadoSeccion.Personal, persona.IdPersona, persona);
            ValidCorreo(persona.Email, "Email");
            _darkM.Persona.Element = persona;
            _darkM.Persona.Update();

            SPValidator(persona.IdPersona, "EmpPersonaEdit");

            return persona.IdPersona;
        }
        #endregion

        #region Empleado informacion Medidca
        /// <summary>
        /// 
        /// </summary>
        /// <param name="IdPersona"></param>
        /// <returns></returns>
        public InformacionMedica EmpInfoMedicaDetails(int IdPersona)
        {
            if (IdPersona == 0) IdPersona = _IdPersona;
            ValidarAcciones(V2EmpleadoValidation.Details, V2EmpleadoSeccion.InfoMedica, IdPersona);

            var data = _darkM.InformacionMedica.GetOpenquerys($"where IdPersona = {IdPersona}");

            if (data != null)
            {
                data.Cat_Alergias = (SystSelect)GetCatalogo(V2EmpleadoCatalogo.Genero, V2EmpleadoCatalogoDatatype.Details, data.Alergias);
                data.Cat_TiposSangre = (SystSelect)GetCatalogo(V2EmpleadoCatalogo.EstatusCivil, V2EmpleadoCatalogoDatatype.Details, data.TipoSangre);
            }

            return data;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="persona"></param>
        public int EmpInfoMedicaCreate(InformacionMedica persona)
        {
            ValidarAcciones(V2EmpleadoValidation.Create, V2EmpleadoSeccion.InfoMedica, persona.IdPersona, persona);
            var lastId = _darkM.InformacionMedica.GetIntValue($"select IdInformacionMedica from InformacionMedica where IdPersona = {persona.IdPersona}");
            
            if (lastId != 0)
                throw new GPException { Description = $"Estimado usuario el empleado ya cuenta con su respectiva información medica", ErrorCode = 0, Category = TypeException.Info, IdAux = "" };


            _darkM.InformacionMedica.Element = persona;
            _darkM.InformacionMedica.Add();
            lastId = _darkM.InformacionMedica.GetIntValue($"select IdInformacionMedica from InformacionMedica where IdPersona = {persona.IdPersona}");
            SPValidator(persona.IdPersona, "EmpInfoMedicaCreate");

            return lastId;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="persona"></param>
        public int EmpInfoMedicaEdit(InformacionMedica persona)
        {
            ValidarAcciones(V2EmpleadoValidation.Edit, V2EmpleadoSeccion.InfoMedica, persona.IdPersona, persona);
            var lastId = _darkM.InformacionMedica.GetIntValue($"select IdInformacionMedica from InformacionMedica where IdPersona = {persona.IdPersona}");

            if (lastId == 0)
                throw new GPException { Description = $"Estimado usuario el empleado aun cuenta con su respectiva información medica", ErrorCode = 0, Category = TypeException.Info, IdAux = "" };


            _darkM.InformacionMedica.Element = persona;
            _darkM.InformacionMedica.Update();
            SPValidator(persona.IdPersona, "EmpInfoMedicaEdit");

            return lastId;
        }
        #endregion

        #region Empleado informacion Empleado
        /// <summary>
        /// 
        /// </summary>
        /// <param name="IdPersona"></param>
        /// <returns></returns>
        public Empleado EmpInfoSplittelDetails(int IdPersona)
        {
            if (IdPersona == 0) IdPersona = _IdPersona;
            ValidarAcciones(V2EmpleadoValidation.Details, V2EmpleadoSeccion.InfoSplittel, IdPersona);

            var data = _darkM.Empleado.GetOpenquerys($"where IdPersona = {IdPersona}");

            if (data != null)
            {
                data.Cat_EstatusEmpleado = (SystSelect)GetCatalogo(V2EmpleadoCatalogo.EstatusEmpleado, V2EmpleadoCatalogoDatatype.Details, data.IdEstatus);
                data.Cat_Puestos = (SystSelect)GetCatalogo(V2EmpleadoCatalogo.Puesto, V2EmpleadoCatalogoDatatype.Details, data.IdPuesto);
                data.Cat_Sociedades = (SystSelect)GetCatalogo(V2EmpleadoCatalogo.Sociedad, V2EmpleadoCatalogoDatatype.Details, data.IdSociedad);
                data.Cat_TipoNomina = (SystSelect)GetCatalogo(V2EmpleadoCatalogo.TipoNomina, V2EmpleadoCatalogoDatatype.Details, data.TipoNomina);
            }

            return data;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="persona"></param>
        public int EmpInfoSplittelCreate(Empleado persona)
        {
            ValidarAcciones(V2EmpleadoValidation.Create, V2EmpleadoSeccion.InfoSplittel, persona.IdPersona, persona);
            var lastId = _darkM.Empleado.GetIntValue($"select IdEmpleado from Empleado where IdPersona = {persona.IdPersona}");

            if (lastId != 0)
                throw new GPException { Description = $"Estimado usuario el empleado ya cuenta con su respectiva información de Empleado", ErrorCode = 0, Category = TypeException.Info, IdAux = "" };

            ValidCorreo(persona.Email, "Email");

            #region validar numero de nomina
            if (persona.NumeroNomina == 0)
            {
                var maxOb = _darkM.Empleado.GetMax("NumeroNomina", "TipoNomina", persona.TipoNomina + "");
                int max = maxOb is System.DBNull ? 0 : (int)maxOb;
                persona.NumeroNomina = max + 1;
            }
            else
            {
                var emple = _darkM.Empleado.Get("NumeroNomina", persona.NumeroNomina + "", "TipoNomina", persona.TipoNomina + "");
                if (emple != null)
                {
                    int max = (int)_darkM.Empleado.GetMax("NumeroNomina", "NumeroNomina", persona.TipoNomina + "");
                    throw new GPException
                    {
                        Description = string.Format("El número de nomina '{0}' ya esta siendo utilizado por otro empleado, número disponible: '{0}'",
                        persona.TipoNomina, max + 1),
                        ErrorCode = 0,
                        Category = TypeException.Info,
                        IdAux = "NumeroNomina"
                    };
                }
            }
            #endregion
            persona.Egreso = DateTime.Now;
            _darkM.Empleado.Element = persona;
            _darkM.Empleado.Add();
            lastId = _darkM.Empleado.GetIntValue($"select IdEmpleado from Empleado where IdPersona = {persona.IdPersona}");
            SPValidator(persona.IdPersona, "EmpInfoSplittelCreate");

            return lastId;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="persona"></param>
        public int EmpInfoSplittelEdit(Empleado persona)
        {
            ValidarAcciones(V2EmpleadoValidation.Edit, V2EmpleadoSeccion.InfoSplittel, persona.IdPersona, persona);
            var lastId = _darkM.Empleado.GetIntValue($"select IdEmpleado from Empleado where IdPersona = {persona.IdPersona}");

            if (lastId == 0)
                throw new GPException { Description = $"Estimado usuario el empleado aun no cuenta con su respectiva información de Empleado", ErrorCode = 0, Category = TypeException.Info, IdAux = "" };

            ValidCorreo(persona.Email, "Email");

            #region validar numero de nomina
            if (persona.NumeroNomina == 0)
            {
                var maxOb = _darkM.Empleado.GetMax("NumeroNomina", "TipoNomina", persona.TipoNomina + "");
                int max = maxOb is System.DBNull ? 0 : (int)maxOb;
                persona.NumeroNomina = max + 1;
            }
            else
            {
                var emple = _darkM.Empleado.Get("NumeroNomina", persona.NumeroNomina + "", "TipoNomina", persona.TipoNomina + "");
                if (emple != null && emple.IdEmpleado != persona.IdEmpleado)
                {
                    var maxOb = _darkM.Empleado.GetMax("NumeroNomina", "TipoNomina", persona.TipoNomina + "");
                    int max = maxOb is System.DBNull ? 0 : (int)maxOb;
                    throw new GPException
                    {
                        Description = string.Format("El número de nomina '{0}' ya esta siendo utilizado por otro empleado, número disponible: '{1}'",
                        persona.NumeroNomina, max + 1),
                        ErrorCode = 0,
                        Category = TypeException.Info,
                        IdAux = "NumeroNomina"
                    };
                }
            }
            #endregion
            persona.Egreso = DateTime.Now;
            persona.IdEmpleado = lastId;
            _darkM.Empleado.Element = persona;
            _darkM.Empleado.Update();
            SPValidator(persona.IdPersona, "EmpInfoSplittelEdit");

            return lastId;
        }
        #endregion
        
        #region Empleado informacion Contacto emergencia
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public PersonaContacto EmpContEmergenciaDetails(int id, bool ShowExceNotFound = false)
        {
            //ValidarAcciones(V2EmpleadoValidation.Details, V2EmpleadoSeccion.InfoContactoEmer, IdPersona);

            var data = _darkM.PersonaContacto.GetOpenquerys($"where IdPersonaContacto = {id}");
            if (data.IdPersona != _IdPersona && !_Accesos["AEscrituraEmpleados"].TieneAcceso)
            {
                throw new GPException { Description = $"Estimado usuario no tienes permisos para esta sección", ErrorCode = 0, Category = TypeException.Noautorizado, IdAux = "" };
            }
            if(ShowExceNotFound && data is null)
            {
                throw new GPException { Description = $"Estimado usuario no se encontró el contacto de emergencia seleccionado", ErrorCode = 0, Category = TypeException.NotFound, IdAux = "" };
            }

            if (data != null)
            {
                data.Cat_Parentezcos = (SystSelect)GetCatalogo(V2EmpleadoCatalogo.Genero, V2EmpleadoCatalogoDatatype.Details, data.IdParentezco);
            }

            return data;
        }
        public List<PersonaContacto> EmpContEmergenciaList(int IdPersona)
        {
            ValidarAcciones(V2EmpleadoValidation.Details, V2EmpleadoSeccion.InfoContactoEmer, IdPersona);

            var data = _darkM.PersonaContacto.GetOpenquery($"where IdPersona = {IdPersona}", "Order by NombreCompleto");
            data.ForEach(a => a.Cat_Parentezcos = (SystSelect)GetCatalogo(V2EmpleadoCatalogo.Genero, V2EmpleadoCatalogoDatatype.Details, a.IdParentezco));

            return data;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="persona"></param>
        public int EmpContEmergencialCreate(PersonaContacto persona)
        {
            ValidarAcciones(V2EmpleadoValidation.Create, V2EmpleadoSeccion.InfoContactoEmer, persona.IdPersona, persona);

            _darkM.PersonaContacto.Element = persona;
            _darkM.PersonaContacto.Add();
            int lastId = _darkM.PersonaContacto.GetIntValue($"select max(IdPersonaContacto) from PersonaContacto where IdPersona = {persona.IdPersona}");
            SPValidator(persona.IdPersona, "EmpContEmergencialCreate");

            return lastId;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="persona"></param>
        public int EmpContEmergenciaEdit(PersonaContacto persona)
        {
            ValidarAcciones(V2EmpleadoValidation.Create, V2EmpleadoSeccion.InfoContactoEmer, persona.IdPersona, persona);

            _darkM.PersonaContacto.Element = persona;
            _darkM.PersonaContacto.Update();
            SPValidator(persona.IdPersona, "EmpContEmergenciaEdit");

            return persona.IdPersonaContacto; 
        }
        public int EmpContEmergenciaDelete(int IdPersonaConacto)
        {
            var details = EmpContEmergenciaDetails(IdPersonaConacto, true);

            _darkM.PersonaContacto.Element = details;
            _darkM.PersonaContacto.Delete();
            SPValidator(details.IdPersona, "EmpContEmergenciaDelete");
            return details.IdPersona;
        }
        #endregion

        #region expediente
        /// <summary>
        /// 
        /// </summary>
        /// <param name="IdPersona"></param>
        /// <returns></returns>
        public List<ExpedienteEmpleado> EmpExpedienteList(int IdPersona)
        {
            if (!_Accesos["AlecturaEmpleados"].TieneAcceso)
            {
                throw new GPException { Description = $"Estimado usuario no tienes permisos para esta sección", ErrorCode = 0, Category = TypeException.Noautorizado, IdAux = "" };
            }
            var data = _darkM.ExpedienteEmpleado.GetOpenquery($"where IdPersona = {IdPersona} and Actual = 1", "");
            data.ForEach(file =>
            {
                file.TipDocument = _darkM.ExpedienteArchivo.Get(file.IdExpedienteArchivo).Nombre;
            });
            return data;
        }

        public void EmpExpedienteAdd(ExpedienteEmpleado expedienteEmpleado)
        {
            if (!_Accesos["AEscrituraEmpleados"].TieneAcceso)
                throw new GPException { Description = $"Estimado usuario no tienes permisos para esta sección", ErrorCode = 0, Category = TypeException.Noautorizado, IdAux = "" };
            

            if(expedienteEmpleado.Archivo is null)
                throw new GPException { Description = $"Estimado usuario no tienes permisos para esta sección", ErrorCode = 0, Category = TypeException.Info, IdAux = "Archivo" };
            if (expedienteEmpleado.Archivo != null && expedienteEmpleado.Archivo.Length == 0)
                throw new GPException { Description = $"Estimado usuario el archivo seleccionado esta dañado", ErrorCode = 0, Category = TypeException.Info, IdAux = "Archivo" };

            string FileTipe = _darkM.ExpedienteArchivo.GetStringValue($"select Nombre from ExpedienteArchivo where IdExpedienteArchivo = {expedienteEmpleado.IdExpedienteArchivo}");
            if(FileTipe == "")
                throw new GPException { Description = $"Por favor selecciona un Tipo de documento", ErrorCode = 0, Category = TypeException.Info, IdAux = "IdExpedienteArchivo" };

            _darkM.ExpedienteEmpleado.GetOpenquery($"where IdPersona = {expedienteEmpleado.IdPersona} and IdExpedienteArchivo = {expedienteEmpleado.IdExpedienteArchivo}", "").ForEach(file =>
            {
                file.Actual = false;
                _darkM.ExpedienteEmpleado.Element = file;
                _darkM.ExpedienteEmpleado.Update();
            });

            int lastID = _darkM.ExpedienteArchivo.GetLastId();
            expedienteEmpleado.Ruta = $"{(lastID+1)}_{FileTipe.Replace(" ","_")}_arct_.{expedienteEmpleado.Archivo.FileName.Split('.')[1]}";
            
            string Directorio = $"C:\\Splittel\\GestionPersonal\\{expedienteEmpleado.IdPersona}\\Expediente";
            if (!System.IO.Directory.Exists(Directorio))
            {
                System.IO.Directory.CreateDirectory(Directorio);
            }

            Directorio = $"{Directorio}\\{expedienteEmpleado.Ruta}";
            using (FileStream fs = System.IO.File.Create(Directorio))
            {
                expedienteEmpleado.Archivo.CopyTo(fs);
                fs.Flush();
            }
            expedienteEmpleado.TipoFile = expedienteEmpleado.Archivo.ContentType;
            expedienteEmpleado.Actual = true;

            _darkM.ExpedienteEmpleado.Element = expedienteEmpleado;
            _darkM.ExpedienteEmpleado.Add();
        }


        #endregion

        #region MetodosGenerales
        /// <summary>
        /// 
        /// </summary>
        /// <param name="v2EmpleadoCatalogo"></param>
        /// <param name="DataType"></param>
        /// <param name="selected"></param>
        /// <returns></returns>
        public object GetCatalogo(V2EmpleadoCatalogo v2EmpleadoCatalogo, V2EmpleadoCatalogoDatatype DataType, int selected = 0)
        {
            object data = null;
            //if (selected == 0) throw new GPException { Description = $"Estimado usuario no tienes permisos para esta sección", ErrorCode = 0, Category = TypeException.Error, IdAux = "" };
            if (v2EmpleadoCatalogo == V2EmpleadoCatalogo.Genero)
            {
                if(DataType == V2EmpleadoCatalogoDatatype.Details)
                {
                    data = _darkM.SystSelect.GetUnicSatatment($"select IdCatalogoOpcionesValores as Value, Descripcion as Label from CatalogoOpcionesValores where IdCatalogoOpcionesValores = {selected}");
                }
                if(DataType == V2EmpleadoCatalogoDatatype.List || DataType == V2EmpleadoCatalogoDatatype.SelectList)
                {
                     data = _darkM.SystSelect.GetSpecialStat("select IdCatalogoOpcionesValores as Value, Descripcion as Label from CatalogoOpcionesValores where IdCatalogoOpciones = 2 order by Descripcion");
                }
            }
            if (v2EmpleadoCatalogo == V2EmpleadoCatalogo.EstatusCivil)
            {
                if (DataType == V2EmpleadoCatalogoDatatype.Details)
                {
                    data = _darkM.SystSelect.GetUnicSatatment($"select IdCatalogoOpcionesValores as Value, Descripcion as Label from CatalogoOpcionesValores where IdCatalogoOpcionesValores = {selected}");
                }
                if (DataType == V2EmpleadoCatalogoDatatype.List || DataType == V2EmpleadoCatalogoDatatype.SelectList)
                {
                    data = _darkM.SystSelect.GetSpecialStat("select IdCatalogoOpcionesValores as Value, Descripcion as Label from CatalogoOpcionesValores where IdCatalogoOpciones = 3 order by Descripcion");
                }
            }
            if (v2EmpleadoCatalogo == V2EmpleadoCatalogo.Alergias)
            {
                if (DataType == V2EmpleadoCatalogoDatatype.Details)
                {
                    data = _darkM.SystSelect.GetUnicSatatment($"select IdCatalogoOpcionesValores as Value, Descripcion as Label from CatalogoOpcionesValores where IdCatalogoOpcionesValores = {selected}");
                }
                if (DataType == V2EmpleadoCatalogoDatatype.List || DataType == V2EmpleadoCatalogoDatatype.SelectList)
                {
                    data = _darkM.SystSelect.GetSpecialStat("select IdCatalogoOpcionesValores as Value, Descripcion as Label from CatalogoOpcionesValores where IdCatalogoOpciones = 5 order by Descripcion");
                }
            }
            if (v2EmpleadoCatalogo == V2EmpleadoCatalogo.TipoSangre)
            {
                if (DataType == V2EmpleadoCatalogoDatatype.Details)
                {
                    data = _darkM.SystSelect.GetUnicSatatment($"select IdCatalogoOpcionesValores as Value, Descripcion as Label from CatalogoOpcionesValores where IdCatalogoOpcionesValores = {selected}");
                }
                if (DataType == V2EmpleadoCatalogoDatatype.List || DataType == V2EmpleadoCatalogoDatatype.SelectList)
                {
                    data = _darkM.SystSelect.GetSpecialStat("select IdCatalogoOpcionesValores as Value, Descripcion as Label from CatalogoOpcionesValores where IdCatalogoOpciones = 4 order by Descripcion");
                }
            }
            if (v2EmpleadoCatalogo == V2EmpleadoCatalogo.TipoNomina)
            {
                if (DataType == V2EmpleadoCatalogoDatatype.Details)
                {
                    data = _darkM.SystSelect.GetUnicSatatment($"select IdCatalogoOpcionesValores as Value, Descripcion as Label from CatalogoOpcionesValores where IdCatalogoOpcionesValores = {selected}");
                }
                if (DataType == V2EmpleadoCatalogoDatatype.List || DataType == V2EmpleadoCatalogoDatatype.SelectList)
                {
                    data = _darkM.SystSelect.GetSpecialStat("select IdCatalogoOpcionesValores as Value, Descripcion as Label from CatalogoOpcionesValores where IdCatalogoOpciones = 6 order by Descripcion");
                    
                }
            }
            if (v2EmpleadoCatalogo == V2EmpleadoCatalogo.Sociedad)
            {
                if (DataType == V2EmpleadoCatalogoDatatype.Details)
                {
                    data = _darkM.SystSelect.GetUnicSatatment($"select IdSociedad as Value, Descripcion as Label  from Sociedad where IdSociedad = {selected}");
                }
                if (DataType == V2EmpleadoCatalogoDatatype.List || DataType == V2EmpleadoCatalogoDatatype.SelectList)
                {
                    data = _darkM.SystSelect.GetSpecialStat("select IdSociedad as Value, Descripcion as Label  from Sociedad order by Descripcion");
                }
            }
            if (v2EmpleadoCatalogo == V2EmpleadoCatalogo.Puesto)
            {
                if (DataType == V2EmpleadoCatalogoDatatype.Details)
                {
                    data = _darkM.SystSelect.GetUnicSatatment($"select IdPuesto as Value, Nombre as Label  from View_puestos where IdPuesto = {selected}");
                }
                if (DataType == V2EmpleadoCatalogoDatatype.List || DataType == V2EmpleadoCatalogoDatatype.SelectList)
                {
                    data = _darkM.SystSelect.GetSpecialStat("select IdPuesto as Value, Nombre as Label from View_puestos order by Nombre");
                }
            }
            if (v2EmpleadoCatalogo == V2EmpleadoCatalogo.EstatusEmpleado)
            {
                if (DataType == V2EmpleadoCatalogoDatatype.Details)
                {
                    data = _darkM.SystSelect.GetUnicSatatment($"select IdCatalogoOpcionesValores as Value, Descripcion as Label from CatalogoOpcionesValores where IdCatalogoOpcionesValores = {selected}");
                }
                if (DataType == V2EmpleadoCatalogoDatatype.List || DataType == V2EmpleadoCatalogoDatatype.SelectList)
                {
                    data = _darkM.SystSelect.GetSpecialStat("select IdCatalogoOpcionesValores as Value, Descripcion as Label from CatalogoOpcionesValores where IdCatalogoOpciones = 7 order by Descripcion");

                }
            }
            if (v2EmpleadoCatalogo == V2EmpleadoCatalogo.ContactoParentezco)
            {
                if (DataType == V2EmpleadoCatalogoDatatype.Details)
                {
                    data = _darkM.SystSelect.GetUnicSatatment($"select IdCatalogoOpcionesValores as Value, Descripcion as Label from CatalogoOpcionesValores where IdCatalogoOpcionesValores = {selected}");
                }
                if (DataType == V2EmpleadoCatalogoDatatype.List || DataType == V2EmpleadoCatalogoDatatype.SelectList)
                {
                    data = _darkM.SystSelect.GetSpecialStat("select IdCatalogoOpcionesValores as Value, Descripcion as Label from CatalogoOpcionesValores where IdCatalogoOpciones = 9 order by Descripcion");

                }
            }
            if (v2EmpleadoCatalogo == V2EmpleadoCatalogo.JefeAuxiliarEmpleado)
            {
                if (DataType == V2EmpleadoCatalogoDatatype.Details)
                {
                    data = _darkM.SystSelect.GetUnicSatatment($"select IdPersona as Value, NombreCompleto as Label from View_empleado where IdPersona = {selected}");
                }
                if (DataType == V2EmpleadoCatalogoDatatype.List || DataType == V2EmpleadoCatalogoDatatype.SelectList)
                {
                    data = _darkM.SystSelect.GetSpecialStat("select IdPersona as Value, NombreCompleto as Label from View_empleado where IdEstatus != 20 order by NombreCompleto");

                }
            }
            if (v2EmpleadoCatalogo == V2EmpleadoCatalogo.ExpedienteTipoFile)
            {
                if (DataType == V2EmpleadoCatalogoDatatype.List || DataType == V2EmpleadoCatalogoDatatype.SelectList)
                {
                    data = _darkM.SystSelect.GetSpecialStat("select IdExpedienteArchivo as Value, Nombre as Label from ExpedienteArchivo order by Nombre");
                }
            }
            if (DataType == V2EmpleadoCatalogoDatatype.SelectList) return selected == 0 ? new SelectList((System.Collections.IEnumerable)data, "Value", "Label") : new SelectList((System.Collections.IEnumerable)data, "Value", "Label", selected);
            else return data;
        }
        private void SPValidator(int IdPersona, string Mode)
        {
            _darkM.dBConnection.StartProcedure($"SP_Empleado", new List<ProcedureModel>
                {
                    new ProcedureModel { Namefield = "IdPersonaValidate", value = IdPersona },
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
        /// <param name="Email">data de emails</param>
        /// <param name="IdAuxForm">id del elemento en el formulario</param>
        private void ValidCorreo(string Email, string IdAuxForm = "")
        {
            if (!string.IsNullOrEmpty(Email))
            {
                string emailValid = Funciones.ValidateEmail(Email);
                if (emailValid != "")
                {
                    throw new GPException { Description = $"El correo: '{emailValid}', no es valido", ErrorCode = 0, Category = TypeException.Info, IdAux = IdAuxForm };
                    
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="IdPersona"></param>
        /// <param name="Data"></param>
        public void ValidarAcciones(V2EmpleadoValidation mode, V2EmpleadoSeccion seccion, int IdPersona, object Data = null, bool validModel = true)
        {
            if(mode == V2EmpleadoValidation.Create)
            {
                if(seccion == V2EmpleadoSeccion.Personal)
                {
                    if (!_Accesos["AEscrituraEmpleados"].TieneAcceso)
                    {
                        throw new GPException { Description = $"Estimado usuario no tienes permisos para esta sección", ErrorCode = 0, Category = TypeException.Noautorizado, IdAux = "" };
                    }
                }
                else
                {
                    if (IdPersona != _IdPersona)
                    {
                        if (!_Accesos["AEscrituraEmpleados"].TieneAcceso)
                        {
                            throw new GPException { Description = $"Estimado usuario no tienes permisos para esta sección", ErrorCode = 0, Category = TypeException.Noautorizado, IdAux = "" };
                        
                        }
                    }
                    if (IdPersona == _IdPersona && seccion == V2EmpleadoSeccion.InfoSplittel)
                    {
                        if (!_Accesos["AEscrituraEmpleados"].TieneAcceso)
                        {
                            throw new GPException { Description = $"Estimado usuario no tienes permisos para esta sección", ErrorCode = 0, Category = TypeException.Noautorizado, IdAux = "" };
                        }
                    }

                }
            }
            if ( mode == V2EmpleadoValidation.Edit)
            {
                if (Data is null && validModel)
                {
                    throw new GPException { Description = $"Estimado usuario por favor verifica tu información", ErrorCode = 0, Category = TypeException.Error, IdAux = "" };
                }

                if (IdPersona != _IdPersona)
                {
                    if (!_Accesos["AEscrituraEmpleados"].TieneAcceso)
                    {
                        throw new GPException { Description = $"Estimado usuario no tienes permisos para esta sección", ErrorCode = 0, Category = TypeException.Noautorizado, IdAux = "" };
                    }
                }

                if(IdPersona == _IdPersona && seccion == V2EmpleadoSeccion.InfoSplittel)
                {
                    if (!_Accesos["AEscrituraEmpleados"].TieneAcceso)
                    {
                        throw new GPException { Description = $"Estimado usuario no tienes permisos para esta sección", ErrorCode = 0, Category = TypeException.Noautorizado, IdAux = "" };
                    }
                }
            }
            if (mode == V2EmpleadoValidation.Details)
            {

                if (IdPersona != _IdPersona)
                {
                    if (!_Accesos["AlecturaEmpleados"].TieneAcceso)
                    {
                        throw new GPException { Description = $"Estimado usuario no tienes permisos para esta sección", ErrorCode = 0, Category = TypeException.Noautorizado, IdAux = "" };
                    }
                }

                if (IdPersona == _IdPersona && seccion == V2EmpleadoSeccion.InfoSplittel)
                {
                    if (!_Accesos["AEscrituraEmpleados"].TieneAcceso)
                    {
                        throw new GPException { Description = $"Estimado usuario no tienes permisos para esta sección", ErrorCode = 0, Category = TypeException.Noautorizado, IdAux = "" };
                    }
                }
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
        #endregion
    }

    public enum V2EmpleadoCatalogo
    {
        /// <summary>
        /// ok
        /// </summary>
        Genero = 1,
        /// <summary>
        /// ok
        /// </summary>
        EstatusCivil = 2,
        /// <summary>
        /// ok
        /// </summary>
        Alergias = 3,
        /// <summary>
        /// ok
        /// </summary>
        TipoSangre = 4,
        /// <summary>
        /// ok
        /// </summary>
        TipoNomina = 5,
        /// <summary>
        /// ok
        /// </summary>
        Sociedad = 6,
        /// <summary>
        /// ok
        /// </summary>
        Puesto = 7,
        /// <summary>
        /// ok
        /// </summary>
        EstatusEmpleado = 8,
        /// <summary>
        /// ok
        /// </summary>
        ContactoParentezco = 9,
        /// <summary>
        /// ok
        /// </summary>
        JefeAuxiliarEmpleado = 10,
        ExpedienteTipoFile = 11
    }
    public enum V2EmpleadoCatalogoDatatype
    {
        SelectList = 1,
        Details = 2,
        List = 3
    }
    public enum V2EmpleadoValidation
    {
        Create = 1,
        Edit = 2,
        Details = 3,
        Baja = 4,
        List = 5
    }

    public enum V2EmpleadoSeccion
    {
        Personal,
        InfoMedica,
        InfoSplittel,
        InfoContactoEmer
    }
}
