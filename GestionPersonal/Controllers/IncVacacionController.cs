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
        [AccessView]
        public IActionResult Autorizar(int id, int Mode)
        {
            _V2IncVacacionesCtrl = new V2IncVacacionesCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            
            try
            {
                _V2IncVacacionesCtrl.ValidarAcciones(V2IncValidation.Aprove, id, Mode);
                var incidencia = _V2IncVacacionesCtrl.Details(id, true);
                ViewData["Details"] = incidencia;
                return View(new InAutorizacion { IdAutorizante = (int)HttpContext.Session.GetInt32("user_id"), IdIncidencia = id, Mode = Mode });
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
                _V2IncVacacionesCtrl.ValidarAcciones(V2IncValidation.Aprove, inAutorizacion.IdIncidencia, inAutorizacion.Mode);
                _V2IncVacacionesCtrl.Autorizar(inAutorizacion);
                SendNotificationAsync(inAutorizacion.IdIncidencia);
                _V2IncVacacionesCtrl._darkM.Commit();
                return RedirectToAction("Autorizar", new { id = inAutorizacion.IdIncidencia, Mode = inAutorizacion.Mode });
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                _V2IncVacacionesCtrl._darkM.RolBack();
                return ValidateException(ex);
            }
            finally
            {
                _V2IncVacacionesCtrl.Terminar();
            }
        }
        [AccessView]
        public IActionResult Delete(int id)
        {
            _V2IncVacacionesCtrl = new V2IncVacacionesCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            _V2IncVacacionesCtrl._darkM.StartTransaction();
            try
            {
                _V2IncVacacionesCtrl.ValidarAcciones(V2IncValidation.Delete, id);
                _V2IncVacacionesCtrl.Eliminar(id);
                _V2IncVacacionesCtrl._darkM.Commit();
                return RedirectToAction("Details", new { id = id });
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
        public IActionResult Cancelar(int id)
        {
            _V2IncVacacionesCtrl = new V2IncVacacionesCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            _V2IncVacacionesCtrl._darkM.StartTransaction();
            try
            {
                _V2IncVacacionesCtrl.ValidarAcciones(V2IncValidation.Cancel, id);
                _V2IncVacacionesCtrl.Cancelar(id);
                SendNotificationAsync(id);
                _V2IncVacacionesCtrl._darkM.Commit();
                return RedirectToAction("Details", new { id = id });
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
        public IActionResult Details(int id, string AnteriorView)
        {
            _V2IncVacacionesCtrl = new V2IncVacacionesCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            try
            {
                var incidencia = _V2IncVacacionesCtrl.Details(id, true);
                var accessoAd = _V2IncVacacionesCtrl._Accesos.Find(a => a.IdSubModulo == _V2IncVacacionesCtrl._ALecturaEscrituraAdmin);
                ViewData["ShowEdit"] = incidencia.IdPersona == (int)HttpContext.Session.GetInt32("user_id") && incidencia.CreadoPor == "Empleado" ? true : incidencia.CreadoPor != "Empleado" && accessoAd.TieneAcceso ? true : false;
                ViewData["ShowCancel"] = incidencia.IdPersona == (int)HttpContext.Session.GetInt32("user_id") && incidencia.CreadoPor == "Empleado" ? true : incidencia.CreadoPor != "Empleado" && accessoAd.TieneAcceso ? true : false;
                ViewData["ShowDelete"] = accessoAd.TieneAcceso ? true : false;
                ViewData["AnteriorView"] = AnteriorView;
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
        [AccessView]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(IncidenciaVacacion incidencia)
        {
            _V2IncVacacionesCtrl = new V2IncVacacionesCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            _V2IncVacacionesCtrl._darkM.StartTransaction();
            try
            {
                _V2IncVacacionesCtrl.Edit(incidencia);
                ViewData["MessageSuccess"] = "Incidencia guardada";
                _V2IncVacacionesCtrl._darkM.Commit();
                return RedirectToAction("Details", new { id = incidencia.IdIncidenciaVacacion });
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                _V2IncVacacionesCtrl._darkM.RolBack();
                return ValidateException(ex, incidencia);
            }
            finally
            {
                _V2IncVacacionesCtrl.Terminar();
            }
        }
        [AccessView]
        public IActionResult Edit(int id)
        {
            _V2IncVacacionesCtrl = new V2IncVacacionesCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            try
            {

                var incidencia = _V2IncVacacionesCtrl.Details(id, true);
                _V2IncVacacionesCtrl.ValidarAcciones(V2IncValidation.Edit, 0, 0, incidencia);

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
        [AccessView]
        public IActionResult Create(int id)
        {
            _V2IncVacacionesCtrl = new V2IncVacacionesCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            ViewData["TiposPermisos"] = new SelectList(darkManager.CatalogoOpcionesValores.GetOpenquery("where IdCatalogoOpciones = 1009", "order by Descripcion"), "IdCatalogoOpcionesValores", "Descripcion");
            ViewData["PagoPermisoPersonal"] = new SelectList(darkManager.CatalogoOpcionesValores.GetOpenquery("where IdCatalogoOpciones = 1010", "order by Descripcion"), "IdCatalogoOpcionesValores", "Descripcion");
            try
            {
                var nuevo = new IncidenciaVacacion { IdPersona = id == 0 ? (int)HttpContext.Session.GetInt32("user_id") : 0, Inicio = System.DateTime.Now, Fin = System.DateTime.Now.AddDays(1) };
                _V2IncVacacionesCtrl.ValidarAcciones(V2IncValidation.Edit, 0, 0, nuevo);

                return View(nuevo);
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
        public IActionResult Create(IncidenciaVacacion incidencia)
        {
            _V2IncVacacionesCtrl = new V2IncVacacionesCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            _V2IncVacacionesCtrl._darkM.StartTransaction();
            try
            {
                var _id = _V2IncVacacionesCtrl.Create(incidencia);
                SendNotificationAsync(_id);
                _V2IncVacacionesCtrl._darkM.Commit();
                return RedirectToAction("Details", new { id = _id });
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                _V2IncVacacionesCtrl._darkM.RolBack();
                return ValidateException(ex, incidencia);
            }
            finally
            {
                _V2IncVacacionesCtrl.Terminar();
            }
        }
        [AccessView]
        public IActionResult MisSolicitudes()
        {
            _V2IncVacacionesCtrl = new V2IncVacacionesCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            try
            {
                return View(new ResV2Inicidencias { Vacaciones = _V2IncVacacionesCtrl.GetByUsuario() });
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
                if (incidencia.Estatus == 2 || incidencia.Estatus == 3)
                    incidencia.Link = $"{((HttpContext.Request.IsHttps ? "https:" : "http: "))}//{HttpContext.Request.Host}{Url.Action("Autorizar", "IncVacacion", new { id = IdPermiso, Mode = incidencia.Estatus })}";
                else
                    incidencia.Link = $"{((HttpContext.Request.IsHttps ? "https:" : "http: "))}//{HttpContext.Request.Host}{Url.Action("Details", "IncVacacion", new { id = IdPermiso })}";

                var result = await _viewRenderService.RenderToStringAsync("IncVacacion/Notification", incidencia);

                _V2IncVacacionesCtrl.EnviarNotificacion(IdPermiso, result);
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {

            }
        }
        [NonAction]
        private IActionResult ValidateException(GPSInformation.Exceptions.GPException ex, object DataModel = null, bool SinVista = false)
        {
            if (ex.Category == GPSInformation.Exceptions.TypeException.Noautorizado)
            {
                ViewData["MessageError"] = ex.Message;
                return View("../ErrorPages/NoAccess");
            }
            else if (ex.Category == GPSInformation.Exceptions.TypeException.NotFound)
            {
                ViewData["MessageError"] = ex.Message;
                return View("../Home/NotFoundPage");
            }
            else if (ex.Category == GPSInformation.Exceptions.TypeException.Info)
            {
                if (SinVista)
                {
                    ViewData["MessageError"] = ex.Message;
                    return View("../ErrorPages/Error");
                }
                else
                {
                    ViewData["MessageError"] = ex.Message;
                    ModelState.AddModelError(string.IsNullOrEmpty(ex.IdAux) ? "" : ex.IdAux, ex.Message);
                    return View(DataModel);
                }

            }
            else
            {
                ViewData["MessageError"] = ex.Message;
                return View("../ErrorPages/Error");
            }
        }
    }
}
