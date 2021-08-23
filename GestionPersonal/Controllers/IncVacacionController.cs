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

namespace GestionPersonal.Controllers
{
    public class IncVacacionController : Controller
    {
        private DarkManager darkManager;
        private V2IncVacacionesCtrl _V2IncVacacionesCtrl;
        private readonly IViewRenderService _viewRenderService;


        public IncVacacionController(IConfiguration configuration, IViewRenderService viewRenderService)
        {
            this._viewRenderService = viewRenderService;
            darkManager = new DarkManager(configuration);
        }
        [AccessView]
        public IActionResult Notification(int id)
        {
            _V2IncVacacionesCtrl = new V2IncVacacionesCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            try
            {
                var incidencia = _V2IncVacacionesCtrl.Details(id, true);
                if (incidencia.Estatus == 2 || incidencia.Estatus == 3)
                    incidencia.Link = Url.Action("Autorizar", "IncVacacion", new { id = id, Mode = incidencia.Estatus });
                else
                    incidencia.Link = Url.Action("Details", "IncVacacion", new { id = id });
                return View(incidencia);
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                return ValidateException(ex);
            }
            finally
            {
                _V2IncVacacionesCtrl.Terminar();
            }
        }

        public ActionResult DowloadFile(int IdPersona, string fileName)
        {
            try
            {
                byte[] fileBytes = System.IO.File.ReadAllBytes($"C:\\Splittel\\GestionPersonal\\{IdPersona}\\IncVacaciones\\{fileName}");
                return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
            }
            catch (GPSInformation.Exceptions.GpExceptions ex)
            {
                return NotFound(ex.Message);
            }

        }
        [AccessView]
        public IActionResult Autorizar(string id, string Mode)
        {
            _V2IncVacacionesCtrl = new V2IncVacacionesCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            
            try
            {
                
                int _id = Int32.Parse(GPSInformation.Tools.EncryptData.Decrypt(id));
                int _Mode = Int32.Parse(GPSInformation.Tools.EncryptData.Decrypt(Mode));

                _V2IncVacacionesCtrl.ValidarAcciones(V2IncValidation.Aprove, _id, _Mode);
                var incidencia = _V2IncVacacionesCtrl.Details(_id, true);
                ViewData["Details"] = incidencia;
                return View(new InAutorizacion { IdAutorizante = (int)HttpContext.Session.GetInt32("user_id"), IdIncidencia = _id, Modee = _Mode });
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                return ValidateException(ex);
            }
            finally
            {
                _V2IncVacacionesCtrl.Terminar();
            }
        }
        [AccessView]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Autorizar(InAutorizacion inAutorizacion)
        {
            _V2IncVacacionesCtrl = new V2IncVacacionesCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            _V2IncVacacionesCtrl._darkM.StartTransaction();
            try
            {
                _V2IncVacacionesCtrl.ValidarAcciones(V2IncValidation.Aprove, inAutorizacion.IdIncidencia, inAutorizacion.Modee);
                _V2IncVacacionesCtrl.Autorizar(inAutorizacion);
                SendNotificationAsync(inAutorizacion.IdIncidencia);
                _V2IncVacacionesCtrl._darkM.Commit();
                return RedirectToAction("Autorizar", new { id = GPSInformation.Tools.EncryptData.Encrypt(inAutorizacion.IdIncidencia + ""), Mode = GPSInformation.Tools.EncryptData.Encrypt(inAutorizacion.Modee + "") });
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                _V2IncVacacionesCtrl._darkM.RolBack();
                return ValidateException(ex, inAutorizacion);
            }
            finally
            {
                _V2IncVacacionesCtrl.Terminar();
            }
        }
        [AccessView]
        public IActionResult Delete(int id, bool isPartial)
        {
            _V2IncVacacionesCtrl = new V2IncVacacionesCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            _V2IncVacacionesCtrl._darkM.StartTransaction();
            try
            {
                int idPersonaa =  _V2IncVacacionesCtrl.GetIdPersona(id);
                _V2IncVacacionesCtrl.ValidarAcciones(V2IncValidation.Delete, id);
                _V2IncVacacionesCtrl.Eliminar(id);
                _V2IncVacacionesCtrl._darkM.Commit();
                return RedirectToAction("MisSolicitudes","Incidencias", new { id = idPersonaa, isPartial = isPartial, Tab="Vacaciones" });
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                _V2IncVacacionesCtrl._darkM.RolBack();
                return ValidateException(ex, null, true);
            }
            finally
            {
                _V2IncVacacionesCtrl.Terminar();
            }
        }
        [AccessView]
        public IActionResult Cancelar(int id, bool isPartial)
        {
            _V2IncVacacionesCtrl = new V2IncVacacionesCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            _V2IncVacacionesCtrl._darkM.StartTransaction();
            try
            {
                _V2IncVacacionesCtrl.ValidarAcciones(V2IncValidation.Cancel, id);
                _V2IncVacacionesCtrl.Cancelar(id);
                SendNotificationAsync(id);
                _V2IncVacacionesCtrl._darkM.Commit();
                return RedirectToAction("Details", new { id = id, isPartial = isPartial });
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                _V2IncVacacionesCtrl._darkM.RolBack();
                return ValidateException(ex, null, true, isPartial);
            }
            finally
            {
                _V2IncVacacionesCtrl.Terminar();
            }
        }
        [AccessView]
        public IActionResult Details(int id, bool isPartial)
        {
            _V2IncVacacionesCtrl = new V2IncVacacionesCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            try
            {
                var incidencia = _V2IncVacacionesCtrl.Details(id, true);
                var accessoAd = _V2IncVacacionesCtrl._Accesos.Find(a => a.IdSubModulo == _V2IncVacacionesCtrl._ALecturaEscrituraAdmin);
                ViewData["ShowEdit"] = incidencia.IdPersona == (int)HttpContext.Session.GetInt32("user_id") && incidencia.CreadoPor == "E" ? true : incidencia.CreadoPor != "E" && accessoAd.TieneAcceso ? true : false;
                ViewData["ShowCancel"] = incidencia.IdPersona == (int)HttpContext.Session.GetInt32("user_id") && incidencia.CreadoPor == "E" ? true : incidencia.CreadoPor != "E" && accessoAd.TieneAcceso ? true : false;
                ViewData["ShowDelete"] = accessoAd.TieneAcceso ? true : false;
                ViewData["isPartial"] = isPartial;
                if (isPartial) return PartialView(incidencia);
                else return View(incidencia);
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                return ValidateException(ex, null,false, isPartial);
            }
            finally
            {
                _V2IncVacacionesCtrl.Terminar();
            }
        }
        [AccessView]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(IncidenciaVacacion incidencia, bool isPartial)
        {
            _V2IncVacacionesCtrl = new V2IncVacacionesCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            _V2IncVacacionesCtrl._darkM.StartTransaction();
            try
            {
                ViewData["isPartial"] = isPartial;
                _V2IncVacacionesCtrl.Edit(incidencia);
                ViewData["MessageSuccess"] = "Incidencia guardada";
                _V2IncVacacionesCtrl._darkM.Commit();
                return RedirectToAction("Details", new { id = incidencia.IdIncidenciaVacacion });
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                _V2IncVacacionesCtrl._darkM.RolBack();
                return ValidateException(ex, incidencia, false, isPartial);
            }
            finally
            {
                _V2IncVacacionesCtrl.Terminar();
            }
        }
        [AccessView]
        public IActionResult Edit(int id, bool isPartial)
        {
            _V2IncVacacionesCtrl = new V2IncVacacionesCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            try
            {

                var incidencia = _V2IncVacacionesCtrl.Details(id, true);
                _V2IncVacacionesCtrl.ValidarAcciones(V2IncValidation.Edit, 0, 0, incidencia);

                ViewData["isPartial"] = isPartial;
                if (isPartial) return PartialView(incidencia);
                else return View(incidencia);
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                return ValidateException(ex,null,true, isPartial);
            }
            finally
            {
                _V2IncVacacionesCtrl.Terminar();
            }
        }
        [AccessView]
        public IActionResult Create(int idPersona_,bool isPartial)
        {
            _V2IncVacacionesCtrl = new V2IncVacacionesCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            ViewData["TiposPermisos"] = new SelectList(darkManager.CatalogoOpcionesValores.GetOpenquery("where IdCatalogoOpciones = 1009", "order by Descripcion"), "IdCatalogoOpcionesValores", "Descripcion");
            ViewData["PagoPermisoPersonal"] = new SelectList(darkManager.CatalogoOpcionesValores.GetOpenquery("where IdCatalogoOpciones = 1010", "order by Descripcion"), "IdCatalogoOpcionesValores", "Descripcion");
            try
            {
                ViewData["isPartial"] = isPartial;
                var nuevo = new IncidenciaVacacion { IdPersona = idPersona_ == 0 ? (int)HttpContext.Session.GetInt32("user_id") : idPersona_, Inicio = System.DateTime.Now, Fin = System.DateTime.Now.AddDays(1) };
                _V2IncVacacionesCtrl.ValidarAcciones(V2IncValidation.Edit, 0, 0, nuevo);
                
                if (isPartial) return PartialView(nuevo);
                else return View(nuevo);
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                return ValidateException(ex,null, false, isPartial);
            }
            finally
            {
                _V2IncVacacionesCtrl.Terminar();
            }
        }
        [AccessView]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(IncidenciaVacacion incidencia,bool isPartial)
        {
            _V2IncVacacionesCtrl = new V2IncVacacionesCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            _V2IncVacacionesCtrl._darkM.StartTransaction();
            try
            {
                ViewData["isPartial"] = isPartial;
                var _id = _V2IncVacacionesCtrl.Create(incidencia);
                SendNotificationAsync(_id);
                _V2IncVacacionesCtrl._darkM.Commit();
                return RedirectToAction("Details", new { id = _id, isPartial = isPartial });
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                _V2IncVacacionesCtrl._darkM.RolBack();
                return ValidateException(ex, incidencia,false, isPartial);
            }
            finally
            {
                _V2IncVacacionesCtrl.Terminar();
            }
        }
        [AccessView]
        public IActionResult MisSolicitudes(int id)
        {
            _V2IncVacacionesCtrl = new V2IncVacacionesCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            try
            {
                return PartialView(new ResV2Inicidencias { Vacaciones = _V2IncVacacionesCtrl.GetByUsuario(id) });
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                return ValidateException(ex);
            }
            finally
            {
                _V2IncVacacionesCtrl.Terminar();
            }
        }
        [AccessView]
        public IActionResult SolicitudesN1()
        {
            _V2IncVacacionesCtrl = new V2IncVacacionesCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            try
            {
                return View(new ResV2Inicidencias { Vacaciones = _V2IncVacacionesCtrl.GetByJefeInmediato() });
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                return ValidateException(ex);
            }
            finally
            {
                _V2IncVacacionesCtrl.Terminar();
            }
        }
        [AccessView]
        public IActionResult SolicitudesN2()
        {
            _V2IncVacacionesCtrl = new V2IncVacacionesCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            try
            {
                return View(new ResV2Inicidencias { Vacaciones = _V2IncVacacionesCtrl.GetByGPSAdmin() });
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                return ValidateException(ex);
            }
            finally
            {
                _V2IncVacacionesCtrl.Terminar();
            }
        }

        [NonAction]
        private async void SendNotificationAsync(int IdPermiso)
        {
            try
            {
                var incidencia = _V2IncVacacionesCtrl.Details(IdPermiso, true);

                #region Notifiacion
                //-------------------------------------------------------
                //--estatus de acuerdo a la incidencias nueva version
                //------------------------------------------------------ -
                //--1 - Solicitud creada
                //--2 - Jefe inmediado
                //--3 - Gestión personal
                //--4 - Autorizada
                //--5 - Councluida
                //--6 - Cancelada
                //--7 - Rechazada
                //--8 - Eliminada
                //--9 - Expirada

                var Notificaciones = new V2NotificacionCtrl(_V2IncVacacionesCtrl._darkM, _V2IncVacacionesCtrl._IdUsuario, _V2IncVacacionesCtrl._IdPersona);
                if (incidencia.Estatus == 6)
                {
                    Notificaciones.AddToPermiso(
                        $"Solicitud <strong>{incidencia.Folio}</strong> cancelada",
                        $"El colaborador@ <strong>{_V2IncVacacionesCtrl._NombreCompleto}</strong> ha cancelado la solicitud: <strong>{incidencia.Folio}</strong>",
                        Url.Action("Details", "IncVacacion", new { id = incidencia.IdIncidenciaVacacion }),
                        "Link",
                        36);
                }
                if (incidencia.Estatus == 3 && incidencia.CreadoPor == "E")
                {
                    Notificaciones.AddToPermiso(
                        $"Nueva solicitud <strong>{incidencia.Folio}</strong>",
                        $"El colaborador@ <strong>{_V2IncVacacionesCtrl._NombreCompleto}</strong> ha creado una solicitud con folio: <strong>{incidencia.Folio}</strong>",
                        Url.Action("Autorizar", "IncVacacion", new { id = incidencia.EncriptId, Mode = GPSInformation.Tools.EncryptData.Encrypt(incidencia.Estatus + "") }),
                        "Link",
                        36); ;
                }
                #endregion

                //solo se envian notificaciones email a solicitudes creadas por empleados
                if (incidencia.CreadoPor == "E")
                {
                    if (incidencia.Estatus == 2 || incidencia.Estatus == 3)
                        incidencia.Link = $"{((HttpContext.Request.IsHttps ? "https:" : "http: "))}//{HttpContext.Request.Host}{Url.Action("Autorizar", "IncVacacion", new { id = incidencia.EncriptId, Mode = GPSInformation.Tools.EncryptData.Encrypt(incidencia.Estatus + "") })}";
                    else
                        incidencia.Link = $"{((HttpContext.Request.IsHttps ? "https:" : "http: "))}//{HttpContext.Request.Host}{Url.Action("Details", "IncVacacion", new { id = incidencia.EncriptId })}";

                    var result = await _viewRenderService.RenderToStringAsync("IncVacacion/Notification", incidencia);

                    _V2IncVacacionesCtrl.EnviarNotificacion(IdPermiso, result);
                }

                Notificaciones = null;
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {

            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="DataModel"></param>
        /// <param name="SinVista"> set false for return view with model</param>
        /// <returns></returns>
        [NonAction]
        private IActionResult ValidateException(GPSInformation.Exceptions.GPException ex, object DataModel = null, bool SinVista = false, bool isPartial = false)
        {
            if (ex.Category == GPSInformation.Exceptions.TypeException.Noautorizado)
            {
                ViewData["MessageError"] = ex.Message;
                if (isPartial)
                    return PartialView("../ErrorPages/NoAccess");
                else 
                    return View("../ErrorPages/NoAccess");
            }
            else if (ex.Category == GPSInformation.Exceptions.TypeException.NotFound)
            {
                ViewData["MessageError"] = ex.Message;
                if (isPartial)
                    return PartialView("../Home/NotFoundPage");
                else
                    return View("../Home/NotFoundPage");
            }
            else if (ex.Category == GPSInformation.Exceptions.TypeException.Info)
            {
                if (SinVista)
                {
                    ViewData["MessageError"] = ex.Message;
                    if (isPartial)
                        return PartialView("../ErrorPages/Error");
                    else
                        return View("../ErrorPages/Error");
                }
                else
                {
                    ViewData["MessageError"] = ex.Message;
                    ModelState.AddModelError(string.IsNullOrEmpty(ex.IdAux) ? "" : ex.IdAux, ex.Message);
                    if (isPartial)
                        return PartialView(DataModel);
                    else
                        return View(DataModel);
                }

            }
            else
            {
                ViewData["MessageError"] = ex.Message;
                if (isPartial)
                    return PartialView("../ErrorPages/Error");
                else
                    return View("../ErrorPages/Error");
            }
        }
    }
}
