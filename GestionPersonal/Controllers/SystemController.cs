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
    public class SystemController : Controller
    {
        private DarkManager darkManager;
        private V2NotificacionCtrl v2NotificacionCtrl;
        private readonly IViewRenderService _viewRenderService;


        public SystemController(IConfiguration configuration, IViewRenderService viewRenderService)
        {
            this._viewRenderService = viewRenderService;
            darkManager = new DarkManager(configuration);
        }
        [AccessView]
        public IActionResult Notification(string Mode, string ViewMode)
        {
            v2NotificacionCtrl = new V2NotificacionCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            try
            {
                var incidencia = v2NotificacionCtrl.Notificaciones(Mode);
                ViewData["ViewMode"] = ViewMode;
                return PartialView(incidencia);
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                return ValidateException(ex);
            }
            finally
            {
                v2NotificacionCtrl.Terminar();
            }
        }
        public IActionResult CheckAsReaded(int IdPersona, int IdNotificacion, string URL_next)
        {
            v2NotificacionCtrl = new V2NotificacionCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            try
            {
                v2NotificacionCtrl.CheckAsReaded(IdPersona, IdNotificacion);

                return Redirect(URL_next);
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                return ValidateException(ex);
            }
            finally
            {
                v2NotificacionCtrl.Terminar();
            }
        }
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