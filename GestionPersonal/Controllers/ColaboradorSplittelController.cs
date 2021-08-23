using GPSInformation;
using GPSInformation.Controllers;
using GPSInformation.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using GestionPersonal.Models;
using GPSInformation.Responses;
using GestionPersonal.Service;
using System.Threading.Tasks;
using System;
using GPSInformation.Exceptions;

namespace GestionPersonal.Controllers
{
    public class ColaboradorSplittelController : Controller
    {
        private DarkManager darkManager;
        private V2EmpleadoCtrl _V2EmpleadoCtrl;
        private readonly IViewRenderService _viewRenderService;


        public ColaboradorSplittelController(IConfiguration configuration, IViewRenderService viewRenderService)
        {
            this._viewRenderService = viewRenderService;
            darkManager = new DarkManager(configuration);
        }
        #region Generales
        [AccessDataSession]
        public IActionResult EmpleadosData( string FilterPatterns)
        {
            _V2EmpleadoCtrl = new V2EmpleadoCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            try
            {
                if (!string.IsNullOrEmpty(FilterPatterns))
                    FilterPatterns = $"where NumeroNomina like '{FilterPatterns}' " +
                        $"or NombreCompleto like '{FilterPatterns}' ";

                return Ok(_V2EmpleadoCtrl._darkM.View_empleado.GetOpenquery(FilterPatterns, "order by NombreCompleto")); ;
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                return BadRequest(ex.Message);
            }
            finally
            {
                _V2EmpleadoCtrl.Terminar();
            }
        }
        [AccessView]
        public IActionResult Index(int Page, int RowsPerPage, string FilterPatterns)
        {
            _V2EmpleadoCtrl = new V2EmpleadoCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            try
            {
                if (!_V2EmpleadoCtrl._Accesos["AlecturaEmpleados"].TieneAcceso)
                {
                    throw new GPException { Description = $"Estimado usuario no tienes permisos para esta sección", ErrorCode = 0, Category = TypeException.Noautorizado, IdAux = "" };
                }

                if (!string.IsNullOrEmpty(FilterPatterns))
                    FilterPatterns = $"where NumeroNomina like '{FilterPatterns}' " +
                        $"or NombreCompleto like '{FilterPatterns}' " +
                        $"or NombreDepartamento like '{FilterPatterns}' " +
                        $"or PuestoNombre like '{FilterPatterns}' " +
                        $"or TipoNomina like '{FilterPatterns}' " +
                        $"or EstatusDescripcion like '{FilterPatterns}'";


                ViewData["Page"] = Page;
                ViewData["RowsPerPage"] = RowsPerPage;
                ViewData["FilterPatterns"] = FilterPatterns;
                ViewData["Accesos"] = _V2EmpleadoCtrl._Accesos;
                return View(_V2EmpleadoCtrl._darkM.View_empleado.DataPage(Page, RowsPerPage, FilterPatterns, "order by NombreCompleto")); ;
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                return ValidateException(ex,null,true,true);
            }
            finally
            {
                _V2EmpleadoCtrl.Terminar();
            }
        }
        [AccessView]
        public IActionResult Edit(int id)
        {
            _V2EmpleadoCtrl = new V2EmpleadoCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            try
            {
                if (!_V2EmpleadoCtrl._Accesos["AlecturaEmpleados"].TieneAcceso)
                {
                    throw new GPException { Description = $"Estimado usuario no tienes permisos para esta sección", ErrorCode = 0, Category = TypeException.Noautorizado, IdAux = "" };
                }
                ViewData["NombreCompleto"] = _V2EmpleadoCtrl._darkM.dBConnection.GetStringValue($"select NombreCompleto from View_empleado where IdPersona = {id}");
                ViewData["IdPersona"] = id;
                ViewData["Accesos"] = _V2EmpleadoCtrl._Accesos;
                return View();
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                return ValidateException(ex,null,true,false);
            }
            finally
            {
                _V2EmpleadoCtrl.Terminar();
            }
        }

        #endregion

        #region Persona
        [AccessView]
        public IActionResult EmpPersonalDetails(int id)
        {
            _V2EmpleadoCtrl = new V2EmpleadoCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            try
            {
                _V2EmpleadoCtrl.ValidarAcciones(V2EmpleadoValidation.Details, V2EmpleadoSeccion.Personal, id);
                ViewData["IdPersona"] = id;
                ViewData["Accesos"] = _V2EmpleadoCtrl._Accesos;
                return PartialView(_V2EmpleadoCtrl.EmpPersonalDetails(id));
            }
            catch (GPException ex)
            {
                return ValidateException(ex);
            }
            finally
            {
                _V2EmpleadoCtrl.Terminar();
            }
        }
        [AccessView]
        public IActionResult EmpPersonaEdit(int id)
        {
            _V2EmpleadoCtrl = new V2EmpleadoCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            try
            {
                _V2EmpleadoCtrl.ValidarAcciones(V2EmpleadoValidation.Edit, V2EmpleadoSeccion.Personal, id, false);
                ViewData["IdPersona"] = id;
                ViewData["Accesos"] = _V2EmpleadoCtrl._Accesos;
                var persona = _V2EmpleadoCtrl.EmpPersonalDetails(id);
                ViewData["Genero"] = (SelectList)_V2EmpleadoCtrl.GetCatalogo(V2EmpleadoCatalogo.Genero, V2EmpleadoCatalogoDatatype.SelectList, persona.IdGenero);
                ViewData["EstadoCivil"] = (SelectList)_V2EmpleadoCtrl.GetCatalogo(V2EmpleadoCatalogo.EstatusCivil, V2EmpleadoCatalogoDatatype.SelectList, persona.IdEstadoCivil);
                return PartialView(persona);
            }
            catch (GPException ex)
            {
                return ValidateException(ex);
            }
            finally
            {
                _V2EmpleadoCtrl.Terminar();
            }
        }
        [AccessView]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult EmpPersonaEdit(Persona persona)
        {
            _V2EmpleadoCtrl = new V2EmpleadoCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            try
            {
                ViewData["Genero"] = (SelectList) _V2EmpleadoCtrl.GetCatalogo(V2EmpleadoCatalogo.Genero, V2EmpleadoCatalogoDatatype.SelectList, persona.IdGenero);
                ViewData["EstadoCivil"] = (SelectList)_V2EmpleadoCtrl.GetCatalogo(V2EmpleadoCatalogo.EstatusCivil, V2EmpleadoCatalogoDatatype.SelectList, persona.IdEstadoCivil);
                if (!ModelState.IsValid)
                {
                    return PartialView(persona);
                }
                _V2EmpleadoCtrl.ValidarAcciones(V2EmpleadoValidation.Edit, V2EmpleadoSeccion.Personal, persona.IdPersona, false);
                _V2EmpleadoCtrl.EmpPersonaEdit(persona);
                ViewData["Accesos"] = _V2EmpleadoCtrl._Accesos;
                ViewData["SuccessMessage"] = "Información guardada exitosamente";
                return PartialView(_V2EmpleadoCtrl.EmpPersonalDetails(persona.IdPersona));
            }
            catch (GPException ex)
            {
                return ValidateException(ex, persona, false);
            }
            finally
            {
                _V2EmpleadoCtrl.Terminar();
            }
        }
        [AccessView]
        public IActionResult Create()
        {
            _V2EmpleadoCtrl = new V2EmpleadoCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            try
            {
                _V2EmpleadoCtrl.ValidarAcciones(V2EmpleadoValidation.Create, V2EmpleadoSeccion.Personal, 0, false);
                ViewData["Genero"] = (SelectList)_V2EmpleadoCtrl.GetCatalogo(V2EmpleadoCatalogo.Genero, V2EmpleadoCatalogoDatatype.SelectList);
                ViewData["EstadoCivil"] = (SelectList)_V2EmpleadoCtrl.GetCatalogo(V2EmpleadoCatalogo.EstatusCivil, V2EmpleadoCatalogoDatatype.SelectList);
                ViewData["Accesos"] = _V2EmpleadoCtrl._Accesos;
                return View();
            }
            catch (GPException ex)
            {
                return ValidateException(ex,null,true, false);
            }
            finally
            {
                _V2EmpleadoCtrl.Terminar();
            }
        }
        [AccessView]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Create(Persona persona)
        {
            _V2EmpleadoCtrl = new V2EmpleadoCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            try
            {
                ViewData["Genero"] = (SelectList)_V2EmpleadoCtrl.GetCatalogo(V2EmpleadoCatalogo.Genero, V2EmpleadoCatalogoDatatype.SelectList, persona.IdGenero);
                ViewData["EstadoCivil"] = (SelectList)_V2EmpleadoCtrl.GetCatalogo(V2EmpleadoCatalogo.EstatusCivil, V2EmpleadoCatalogoDatatype.SelectList, persona.IdEstadoCivil);
                if (!ModelState.IsValid)
                {
                    return View(persona);
                }
                _V2EmpleadoCtrl.ValidarAcciones(V2EmpleadoValidation.Create, V2EmpleadoSeccion.Personal, persona.IdPersona, false);
                int Creado = _V2EmpleadoCtrl.EmpPersonaCreate(persona);
                
                return RedirectToAction("Edit", new { id = Creado });
            }
            catch (GPException ex)
            {
                return ValidateException(ex, persona, false,false);
            }
            finally
            {
                _V2EmpleadoCtrl.Terminar();
            }
        }
        #endregion

        #region Informacion medica
        [AccessView]
        public IActionResult EmpInfoMedicaDetails(int id)
        {
            _V2EmpleadoCtrl = new V2EmpleadoCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            try
            {
                _V2EmpleadoCtrl.ValidarAcciones(V2EmpleadoValidation.Details, V2EmpleadoSeccion.InfoMedica, id);
                ViewData["IdPersona"] = id;
                ViewData["Accesos"] = _V2EmpleadoCtrl._Accesos;
                var data = _V2EmpleadoCtrl.EmpInfoMedicaDetails(id);

                return PartialView(data);
            }
            catch (GPException ex)
            {
                return ValidateException(ex, null, true);
            }
            finally
            {
                _V2EmpleadoCtrl.Terminar();
            }
        }
        [AccessView]
        public IActionResult EmpInfoMedicaCreate(int id)
        {
            _V2EmpleadoCtrl = new V2EmpleadoCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            try
            {
                _V2EmpleadoCtrl.ValidarAcciones(V2EmpleadoValidation.Create, V2EmpleadoSeccion.InfoMedica, id, false);
                ViewData["TipoSangre"] = (SelectList)_V2EmpleadoCtrl.GetCatalogo(V2EmpleadoCatalogo.TipoSangre, V2EmpleadoCatalogoDatatype.SelectList);
                ViewData["Alergia"] = (SelectList)_V2EmpleadoCtrl.GetCatalogo(V2EmpleadoCatalogo.Alergias, V2EmpleadoCatalogoDatatype.SelectList);
                ViewData["IdPersona"] = id;
                ViewData["Accesos"] = _V2EmpleadoCtrl._Accesos;
                return PartialView(new InformacionMedica
                {
                    IdPersona = id
                });
            }
            catch (GPException ex)
            {
                return ValidateException(ex);
            }
            finally
            {
                _V2EmpleadoCtrl.Terminar();
            }
        }
        [AccessView]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult EmpInfoMedicaCreate(InformacionMedica informacionMedica)
        {
            _V2EmpleadoCtrl = new V2EmpleadoCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            try
            {
                ViewData["TipoSangre"] = (SelectList)_V2EmpleadoCtrl.GetCatalogo(V2EmpleadoCatalogo.TipoSangre, V2EmpleadoCatalogoDatatype.SelectList, informacionMedica.TipoSangre);
                ViewData["Alergia"] = (SelectList)_V2EmpleadoCtrl.GetCatalogo(V2EmpleadoCatalogo.Alergias, V2EmpleadoCatalogoDatatype.SelectList, informacionMedica.Alergias);
                if (!ModelState.IsValid)
                {
                    return PartialView(informacionMedica);
                }
                _V2EmpleadoCtrl.ValidarAcciones(V2EmpleadoValidation.Edit, V2EmpleadoSeccion.InfoMedica, informacionMedica.IdPersona, true);
                int Creado = _V2EmpleadoCtrl.EmpInfoMedicaCreate(informacionMedica);

                return RedirectToAction("EmpInfoMedicaDetails", new { id = informacionMedica.IdPersona });
            }
            catch (GPException ex)
            {
                return ValidateException(ex, informacionMedica, false);
            }
            finally
            {
                _V2EmpleadoCtrl.Terminar();
            }
        }
        [AccessView]
        public IActionResult EmpInfoMedicaEdit(int id)
        {
            _V2EmpleadoCtrl = new V2EmpleadoCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            try
            {
                _V2EmpleadoCtrl.ValidarAcciones(V2EmpleadoValidation.Edit, V2EmpleadoSeccion.InfoMedica, id, false);
                ViewData["IdPersona"] = id;
                ViewData["Accesos"] = _V2EmpleadoCtrl._Accesos;
                var informacionMedica = _V2EmpleadoCtrl.EmpInfoMedicaDetails(id);
                ViewData["TipoSangre"] = (SelectList)_V2EmpleadoCtrl.GetCatalogo(V2EmpleadoCatalogo.TipoSangre, V2EmpleadoCatalogoDatatype.SelectList, informacionMedica.TipoSangre);
                ViewData["Alergia"] = (SelectList)_V2EmpleadoCtrl.GetCatalogo(V2EmpleadoCatalogo.Alergias, V2EmpleadoCatalogoDatatype.SelectList, informacionMedica.Alergias);
                return PartialView(informacionMedica);
            }
            catch (GPException ex)
            {
                return ValidateException(ex);
            }
            finally
            {
                _V2EmpleadoCtrl.Terminar();
            }
        }
        [AccessView]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult EmpInfoMedicaEdit(InformacionMedica informacionMedica)
        {
            _V2EmpleadoCtrl = new V2EmpleadoCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            try
            {
                ViewData["TipoSangre"] = (SelectList)_V2EmpleadoCtrl.GetCatalogo(V2EmpleadoCatalogo.TipoSangre, V2EmpleadoCatalogoDatatype.SelectList, informacionMedica.TipoSangre);
                ViewData["Alergia"] = (SelectList)_V2EmpleadoCtrl.GetCatalogo(V2EmpleadoCatalogo.Alergias, V2EmpleadoCatalogoDatatype.SelectList, informacionMedica.Alergias);
                if (!ModelState.IsValid)
                {
                    return PartialView(informacionMedica);
                }
                _V2EmpleadoCtrl.ValidarAcciones(V2EmpleadoValidation.Edit, V2EmpleadoSeccion.InfoMedica, informacionMedica.IdPersona, true);
                int Creado = _V2EmpleadoCtrl.EmpInfoMedicaEdit(informacionMedica);
                ViewData["SuccessMessage"] = "Información guardada exitosamente";
                return PartialView(_V2EmpleadoCtrl.EmpInfoMedicaDetails(informacionMedica.IdPersona));
            }
            catch (GPException ex)
            {
                return ValidateException(ex, informacionMedica, false);
            }
            finally
            {
                _V2EmpleadoCtrl.Terminar();
            }
        }
        #endregion

        #region Empleado splittel
        [AccessView]
        public IActionResult EmpInfoSplittelDetails(int id)
        {
            _V2EmpleadoCtrl = new V2EmpleadoCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            try
            {
                _V2EmpleadoCtrl.ValidarAcciones(V2EmpleadoValidation.Details, V2EmpleadoSeccion.InfoSplittel, id);
                ViewData["IdPersona"] = id;
                ViewData["Accesos"] = _V2EmpleadoCtrl._Accesos;
                var data = _V2EmpleadoCtrl.EmpInfoSplittelDetails(id);
                return PartialView(data);
            }
            catch (GPException ex)
            {
                return ValidateException(ex, null, true);
            }
            finally
            {
                _V2EmpleadoCtrl.Terminar();
            }
        }
        [AccessView]
        public IActionResult EmpInfoSplittelCreate(int id)
        {
            _V2EmpleadoCtrl = new V2EmpleadoCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            try
            {
                _V2EmpleadoCtrl.ValidarAcciones(V2EmpleadoValidation.Create, V2EmpleadoSeccion.InfoSplittel, id, false);
                ViewData["TipoNomina"] = (SelectList)_V2EmpleadoCtrl.GetCatalogo(V2EmpleadoCatalogo.TipoNomina, V2EmpleadoCatalogoDatatype.SelectList);
                ViewData["Sociedad"] = (SelectList)_V2EmpleadoCtrl.GetCatalogo(V2EmpleadoCatalogo.Sociedad, V2EmpleadoCatalogoDatatype.SelectList);
                ViewData["Puesto"] = (SelectList)_V2EmpleadoCtrl.GetCatalogo(V2EmpleadoCatalogo.Puesto, V2EmpleadoCatalogoDatatype.SelectList);
                ViewData["EstatusEmpleado"] = (SelectList)_V2EmpleadoCtrl.GetCatalogo(V2EmpleadoCatalogo.EstatusEmpleado, V2EmpleadoCatalogoDatatype.SelectList);
                ViewData["IdPersona"] = id;
                ViewData["Accesos"] = _V2EmpleadoCtrl._Accesos;
                return PartialView(new Empleado { IdPersona = id });
            }
            catch (GPException ex)
            {
                return ValidateException(ex);
            }
            finally
            {
                _V2EmpleadoCtrl.Terminar();
            }
        }
        [AccessView]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult EmpInfoSplittelCreate(Empleado Empleado)
        {
            _V2EmpleadoCtrl = new V2EmpleadoCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            try
            {
                ViewData["TipoNomina"] = (SelectList)_V2EmpleadoCtrl.GetCatalogo(V2EmpleadoCatalogo.TipoNomina, V2EmpleadoCatalogoDatatype.SelectList, Empleado.TipoNomina);
                ViewData["Sociedad"] = (SelectList)_V2EmpleadoCtrl.GetCatalogo(V2EmpleadoCatalogo.Sociedad, V2EmpleadoCatalogoDatatype.SelectList, Empleado.IdSociedad);
                ViewData["Puesto"] = (SelectList)_V2EmpleadoCtrl.GetCatalogo(V2EmpleadoCatalogo.Puesto, V2EmpleadoCatalogoDatatype.SelectList, Empleado.IdPuesto);
                ViewData["EstatusEmpleado"] = (SelectList)_V2EmpleadoCtrl.GetCatalogo(V2EmpleadoCatalogo.EstatusEmpleado, V2EmpleadoCatalogoDatatype.SelectList, Empleado.IdEstatus);
                if (!ModelState.IsValid)
                {
                    return PartialView(Empleado);
                }
                _V2EmpleadoCtrl.ValidarAcciones(V2EmpleadoValidation.Create, V2EmpleadoSeccion.InfoSplittel, Empleado.IdPersona, true);
                int Creado = _V2EmpleadoCtrl.EmpInfoSplittelCreate(Empleado);

                return RedirectToAction("EmpInfoSplittelDetails", new { id = Empleado.IdPersona });
            }
            catch (GPException ex)
            {
                return ValidateException(ex, Empleado, false);
            }
            finally
            {
                _V2EmpleadoCtrl.Terminar();
            }
        }
        [AccessView]
        public IActionResult EmpInfoSplittelEdit(int id)
        {
            _V2EmpleadoCtrl = new V2EmpleadoCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            try
            {
                _V2EmpleadoCtrl.ValidarAcciones(V2EmpleadoValidation.Edit, V2EmpleadoSeccion.InfoSplittel, id, false);
                
                ViewData["IdPersona"] = id;
                ViewData["Accesos"] = _V2EmpleadoCtrl._Accesos;
                var Empleado = _V2EmpleadoCtrl.EmpInfoSplittelDetails(id);
                ViewData["TipoNomina"] = (SelectList)_V2EmpleadoCtrl.GetCatalogo(V2EmpleadoCatalogo.TipoNomina, V2EmpleadoCatalogoDatatype.SelectList, Empleado.TipoNomina);
                ViewData["Sociedad"] = (SelectList)_V2EmpleadoCtrl.GetCatalogo(V2EmpleadoCatalogo.Sociedad, V2EmpleadoCatalogoDatatype.SelectList, Empleado.IdSociedad);
                ViewData["Puesto"] = (SelectList)_V2EmpleadoCtrl.GetCatalogo(V2EmpleadoCatalogo.Puesto, V2EmpleadoCatalogoDatatype.SelectList, Empleado.IdPuesto);
                ViewData["EstatusEmpleado"] = (SelectList)_V2EmpleadoCtrl.GetCatalogo(V2EmpleadoCatalogo.EstatusEmpleado, V2EmpleadoCatalogoDatatype.SelectList, Empleado.IdEstatus);
                return PartialView(Empleado);
            }
            catch (GPException ex)
            {
                return ValidateException(ex);
            }
            finally
            {
                _V2EmpleadoCtrl.Terminar();
            }
        }
        [AccessView]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult EmpInfoSplittelEdit(Empleado Empleado)
        {
            _V2EmpleadoCtrl = new V2EmpleadoCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            try
            {
                ViewData["TipoNomina"] = (SelectList)_V2EmpleadoCtrl.GetCatalogo(V2EmpleadoCatalogo.TipoNomina, V2EmpleadoCatalogoDatatype.SelectList, Empleado.TipoNomina);
                ViewData["Sociedad"] = (SelectList)_V2EmpleadoCtrl.GetCatalogo(V2EmpleadoCatalogo.Sociedad, V2EmpleadoCatalogoDatatype.SelectList, Empleado.IdSociedad);
                ViewData["Puesto"] = (SelectList)_V2EmpleadoCtrl.GetCatalogo(V2EmpleadoCatalogo.Puesto, V2EmpleadoCatalogoDatatype.SelectList, Empleado.IdPuesto);
                ViewData["EstatusEmpleado"] = (SelectList)_V2EmpleadoCtrl.GetCatalogo(V2EmpleadoCatalogo.EstatusEmpleado, V2EmpleadoCatalogoDatatype.SelectList, Empleado.IdEstatus);
                if (!ModelState.IsValid)
                {
                    return PartialView(Empleado);
                }
                _V2EmpleadoCtrl.ValidarAcciones(V2EmpleadoValidation.Edit, V2EmpleadoSeccion.InfoSplittel, Empleado.IdPersona, true);
                int Creado = _V2EmpleadoCtrl.EmpInfoSplittelEdit(Empleado);
                ViewData["SuccessMessage"] = "Información guardada exitosamente";
                return PartialView(_V2EmpleadoCtrl.EmpInfoSplittelDetails(Empleado.IdPersona));
            }
            catch (GPException ex)
            {
                return ValidateException(ex, Empleado, false);
            }
            finally
            {
                _V2EmpleadoCtrl.Terminar();
            }
        }
        #endregion

        #region Conactos de emergencia
        [AccessView]
        public IActionResult EmpContEmergenciaList(int id)
        {
            _V2EmpleadoCtrl = new V2EmpleadoCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            try
            {
                _V2EmpleadoCtrl.ValidarAcciones(V2EmpleadoValidation.List, V2EmpleadoSeccion.InfoContactoEmer, id);
                ViewData["IdPersona"] = id;
                ViewData["Accesos"] = _V2EmpleadoCtrl._Accesos;
                return PartialView(_V2EmpleadoCtrl.EmpContEmergenciaList(id));
            }
            catch (GPException ex)
            {
                return ValidateException(ex, null, true);
            }
            finally
            {
                _V2EmpleadoCtrl.Terminar();
            }
        }
        [AccessView]
        public IActionResult EmpContEmergenciaDetails(int id)
        {
            _V2EmpleadoCtrl = new V2EmpleadoCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            try
            {
                //_V2EmpleadoCtrl.ValidarAcciones(V2EmpleadoValidation.Details, V2EmpleadoSeccion.InfoContactoEmer,);
                //ViewData["IdPersona"] = id;
                ViewData["Accesos"] = _V2EmpleadoCtrl._Accesos;
                return PartialView(_V2EmpleadoCtrl.EmpContEmergenciaDetails(id));
            }
            catch (GPException ex)
            {
                return ValidateException(ex, null, true);
            }
            finally
            {
                _V2EmpleadoCtrl.Terminar();
            }
        }
        [AccessView]
        public IActionResult EmpContEmergenciaDelete(int id)
        {
            _V2EmpleadoCtrl = new V2EmpleadoCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            try
            {
                _V2EmpleadoCtrl.ValidarAcciones(V2EmpleadoValidation.Edit, V2EmpleadoSeccion.InfoContactoEmer, id, false);
                int IdPersona = _V2EmpleadoCtrl.EmpContEmergenciaDelete(id);
                return RedirectToAction("EmpContEmergenciaList", new { id = IdPersona });
            }
            catch (GPException ex)
            {
                return ValidateException(ex);
            }
            finally
            {
                _V2EmpleadoCtrl.Terminar();
            }
        }
        [AccessView]
        public IActionResult EmpContEmergencialCreate(int id)
        {
            _V2EmpleadoCtrl = new V2EmpleadoCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            try
            {
                _V2EmpleadoCtrl.ValidarAcciones(V2EmpleadoValidation.Create, V2EmpleadoSeccion.InfoContactoEmer, id, false);
                ViewData["ContactoParentezco"] = (SelectList)_V2EmpleadoCtrl.GetCatalogo(V2EmpleadoCatalogo.ContactoParentezco, V2EmpleadoCatalogoDatatype.SelectList);

                ViewData["IdPersona"] = id;
                ViewData["Accesos"] = _V2EmpleadoCtrl._Accesos;
                return PartialView(new PersonaContacto { IdPersona = id });
            }
            catch (GPException ex)
            {
                return ValidateException(ex);
            }
            finally
            {
                _V2EmpleadoCtrl.Terminar();
            }
        }
        [AccessView]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult EmpContEmergencialCreate(PersonaContacto PersonaContacto)
        {
            _V2EmpleadoCtrl = new V2EmpleadoCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            try
            {
                ViewData["ContactoParentezco"] = (SelectList)_V2EmpleadoCtrl.GetCatalogo(V2EmpleadoCatalogo.ContactoParentezco, V2EmpleadoCatalogoDatatype.SelectList, PersonaContacto.IdParentezco);

                if (!ModelState.IsValid)
                {
                    return PartialView(PersonaContacto);
                }
                _V2EmpleadoCtrl.ValidarAcciones(V2EmpleadoValidation.Create, V2EmpleadoSeccion.InfoContactoEmer, PersonaContacto.IdPersona, true);
                int Creado = _V2EmpleadoCtrl.EmpContEmergencialCreate(PersonaContacto);

                return RedirectToAction("EmpContEmergenciaDetails", new { id = Creado });
            }
            catch (GPException ex)
            {
                return ValidateException(ex, PersonaContacto, false);
            }
            finally
            {
                _V2EmpleadoCtrl.Terminar();
            }
        }
        [AccessView]
        public IActionResult EmpContEmergenciaEdit(int id)
        {
            _V2EmpleadoCtrl = new V2EmpleadoCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            try
            {
                var PersonaContacto = _V2EmpleadoCtrl.EmpContEmergenciaDetails(id);
                _V2EmpleadoCtrl.ValidarAcciones(V2EmpleadoValidation.Edit, V2EmpleadoSeccion.InfoContactoEmer, id, false);
                ViewData["ContactoParentezco"] = (SelectList)_V2EmpleadoCtrl.GetCatalogo(V2EmpleadoCatalogo.ContactoParentezco, V2EmpleadoCatalogoDatatype.SelectList, PersonaContacto.IdParentezco);

                ViewData["IdPersona"] = id;
                ViewData["Accesos"] = _V2EmpleadoCtrl._Accesos;
                return PartialView(PersonaContacto);
            }
            catch (GPException ex)
            {
                return ValidateException(ex);
            }
            finally
            {
                _V2EmpleadoCtrl.Terminar();
            }
        }
        [AccessView]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult EmpContEmergenciaEdit(PersonaContacto PersonaContacto)
        {
            _V2EmpleadoCtrl = new V2EmpleadoCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            try
            {
                ViewData["ContactoParentezco"] = (SelectList)_V2EmpleadoCtrl.GetCatalogo(V2EmpleadoCatalogo.ContactoParentezco, V2EmpleadoCatalogoDatatype.SelectList, PersonaContacto.IdParentezco);

                if (!ModelState.IsValid)
                {
                    return PartialView(PersonaContacto);
                }
                _V2EmpleadoCtrl.ValidarAcciones(V2EmpleadoValidation.Edit, V2EmpleadoSeccion.InfoContactoEmer, PersonaContacto.IdPersona, true);
                int Creado = _V2EmpleadoCtrl.EmpContEmergenciaEdit(PersonaContacto);
                ViewData["SuccessMessage"] = "Información guardada exitosamente";
                return PartialView(_V2EmpleadoCtrl.EmpContEmergenciaDetails(PersonaContacto.IdPersonaContacto));
            }
            catch (GPException ex)
            {
                return ValidateException(ex, PersonaContacto, false);
            }
            finally
            {
                _V2EmpleadoCtrl.Terminar();
            }
        }
        #endregion

        #region Expediente
        [AccessView]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EmpExpedienteAdd(ExpedienteEmpleado expedienteEmpleado)
        {
            _V2EmpleadoCtrl = new V2EmpleadoCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            try
            {
                if (!_V2EmpleadoCtrl._Accesos["AEscrituraEmpleados"].TieneAcceso)
                    throw new GPException { Description = $"Estimado usuario no tienes permisos para esta sección", ErrorCode = 0, Category = TypeException.Noautorizado, IdAux = "" };
                ViewData["ExpedienteTipoFile"] = (SelectList)_V2EmpleadoCtrl.GetCatalogo(V2EmpleadoCatalogo.ExpedienteTipoFile, V2EmpleadoCatalogoDatatype.SelectList, expedienteEmpleado.IdExpedienteArchivo);
                _V2EmpleadoCtrl.EmpExpedienteAdd(expedienteEmpleado);
                return RedirectToAction("EmpExpedienteList", new { IdPersona = expedienteEmpleado.IdPersona });
            }
            catch (GPException ex)
            {
                return ValidateException(ex, null, true);
            }
            finally
            {
                _V2EmpleadoCtrl.Terminar();
            }
        }

        [AccessView]
        public IActionResult EmpExpedienteAdd(int IdPersona)
        {
            _V2EmpleadoCtrl = new V2EmpleadoCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            try
            {
                ViewData["ExpedienteTipoFile"] = (SelectList)_V2EmpleadoCtrl.GetCatalogo(V2EmpleadoCatalogo.ExpedienteTipoFile, V2EmpleadoCatalogoDatatype.SelectList);
                ViewData["IdPersona"] = IdPersona;
                ViewData["Accesos"] = _V2EmpleadoCtrl._Accesos;
                if (!_V2EmpleadoCtrl._Accesos["AEscrituraEmpleados"].TieneAcceso)
                    throw new GPException { Description = $"Estimado usuario no tienes permisos para esta sección", ErrorCode = 0, Category = TypeException.Noautorizado, IdAux = "" };
                
                return PartialView(new ExpedienteEmpleado { IdPersona = IdPersona });
            }
            catch (GPException ex)
            {
                return ValidateException(ex, null, true);
            }
            finally
            {
                _V2EmpleadoCtrl.Terminar();
            }
        }
        [AccessView]
        public IActionResult EmpExpedienteList(int IdPersona)
        {
            _V2EmpleadoCtrl = new V2EmpleadoCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            try
            {
                ViewData["IdPersona"] = IdPersona;
                ViewData["Accesos"] = _V2EmpleadoCtrl._Accesos;
                if (!_V2EmpleadoCtrl._Accesos["AlecturaEmpleados"].TieneAcceso)
                    throw new GPException { Description = $"Estimado usuario no tienes permisos para esta sección", ErrorCode = 0, Category = TypeException.Noautorizado, IdAux = "" };

               
                return PartialView(_V2EmpleadoCtrl.EmpExpedienteList(IdPersona));
            }
            catch (GPException ex)
            {
                return ValidateException(ex, null, true);
            }
            finally
            {
                _V2EmpleadoCtrl.Terminar();
            }
        }
        public ActionResult EmpExpedienteFileDownload(int IdPersona, string fileName)
        {
            try
            {
                byte[] fileBytes = System.IO.File.ReadAllBytes($"C:\\Splittel\\GestionPersonal\\{IdPersona}\\Expediente\\{fileName}");
                return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
            }
            catch (GPSInformation.Exceptions.GpExceptions ex)
            {
                return NotFound(ex.Message);
            }

        }
        #endregion

        #region Generales
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="DataModel"></param>
        /// <param name="SinVista"> set false for return view with model</param>
        /// <returns></returns>
        [NonAction]
        private IActionResult ValidateException(GPSInformation.Exceptions.GPException ex, object DataModel = null, bool SinVista = true, bool IsPartial = true)
        {
            if (ex.Category == GPSInformation.Exceptions.TypeException.Noautorizado)
            {
                ViewData["MessageError"] = ex.Message;
                if (!IsPartial)
                    return View("../ErrorPages/NoAccess");
                else
                    return PartialView("../ErrorPages/NoAccess");
            }
            else if (ex.Category == GPSInformation.Exceptions.TypeException.NotFound)
            {
                ViewData["MessageError"] = ex.Message;
                if (!IsPartial)
                    return View("../ErrorPages/NotFoundPage");
                else
                    return PartialView("../Home/NotFoundPage");
            }
            else if (ex.Category == GPSInformation.Exceptions.TypeException.Info)
            {
                if (SinVista)
                {
                    ViewData["MessageError"] = ex.Message;
                    if (!IsPartial)
                        return View("../ErrorPages/Error");
                    else
                        return PartialView("../ErrorPages/Error");
                }
                else
                {
                    ViewData["MessageError"] = ex.Message;
                    ModelState.AddModelError(string.IsNullOrEmpty(ex.IdAux) ? "" : ex.IdAux, ex.Message);
                    if (!IsPartial)
                        return View(DataModel);
                    else
                        return PartialView(DataModel);
                }

            }
            else
            {
                ViewData["MessageError"] = ex.Message;
                if (!IsPartial)
                    return View("../ErrorPages/Error");
                else
                    return PartialView("../ErrorPages/Error");
            }
        }
        #endregion


    }
}
