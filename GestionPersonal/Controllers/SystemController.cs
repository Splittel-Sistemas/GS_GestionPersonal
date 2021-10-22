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
using System.Collections.Generic;
using System.Reflection;
using System.Collections;

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
        //public  IActionResult GetActiveUsers()
        //{
        //    List<string> activeSessions = new List<string>();
        //    object obj = typeof(HttpRuntime).GetProperty("CacheInternal", BindingFlags.NonPublic | BindingFlags.Static).GetValue(null, null);
        //    object[] obj2 = (object[])obj.GetType().GetField("_caches", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(obj);
        //    for (int i = 0; i < obj2.Length; i++)
        //    {
        //        Hashtable c2 = (Hashtable)obj2[i].GetType().GetField("_entries", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(obj2[i]);
        //        foreach (DictionaryEntry entry in c2)
        //        {
        //            object o1 = entry.Value.GetType().GetProperty("Value", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(entry.Value, null);
        //            if (o1.GetType().ToString() == "System.Web.SessionState.InProcSessionState")
        //            {

        //                SessionStateItemCollection sess = (SessionStateItemCollection)o1.GetType().GetField("_sessionItems", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(o1);
        //                if (sess != null)
        //                {
        //                    if (sess["loggedInUserId"] != null)
        //                    {
        //                        activeSessions.Add(sess["loggedInUserId"].ToString());
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    return Ok(activeSessions);
        //}
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