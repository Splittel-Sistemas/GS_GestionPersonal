﻿using GPSInformation;
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
    public class IncidenciasController : Controller
    {
        private DarkManager darkManager;
        private V2IncVacacionesCtrl _V2IncVacacionesCtrl;
        private V2IncPermisoCtrl _V2IncPermisoCtrl;
        private readonly IViewRenderService _viewRenderService;


        public IncidenciasController(IConfiguration configuration, IViewRenderService viewRenderService)
        {
            this._viewRenderService = viewRenderService;
            darkManager = new DarkManager(configuration);
        }
        [AccessView]
        public IActionResult MisSolicitudes(string Tab)
        {
            Tab = string.IsNullOrEmpty(Tab) || Tab.Trim() != "Permisos" && Tab.Trim() != "Vacaciones" ? "Permisos" : Tab;
            _V2IncVacacionesCtrl = new V2IncVacacionesCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            _V2IncPermisoCtrl = new V2IncPermisoCtrl(_V2IncVacacionesCtrl._darkM, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            try
            {
                ViewData["Tab"] = Tab;
                ViewData["Vacaciones"] = _V2IncVacacionesCtrl.GetByUsuario();
                ViewData["Permisos"] = _V2IncPermisoCtrl.GetByUsuario();
                return View();
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                return ValidateException(ex);
            }
            finally
            {
                _V2IncVacacionesCtrl.Terminar();
                _V2IncPermisoCtrl.Terminar();
            }
        }
        [AccessView]
        public IActionResult SolicitudesN1(string Tab)
        {
            Tab = string.IsNullOrEmpty(Tab) || Tab.Trim() != "Permisos" && Tab.Trim() != "Vacaciones" ? "Permisos" : Tab;
            _V2IncVacacionesCtrl = new V2IncVacacionesCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            _V2IncPermisoCtrl = new V2IncPermisoCtrl(_V2IncVacacionesCtrl._darkM, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            try
            {
                ViewData["Tab"] = Tab;
                ViewData["Vacaciones"] = _V2IncVacacionesCtrl.GetByJefeInmediato();
                ViewData["Permisos"] = _V2IncPermisoCtrl.GetByJefeInmediato();
                return View();
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                return ValidateException(ex);
            }
            finally
            {
                _V2IncVacacionesCtrl.Terminar();
                _V2IncPermisoCtrl.Terminar();
            }
        }
        [AccessView]
        public IActionResult SolicitudesN2(string Tab)
        {
            Tab = string.IsNullOrEmpty(Tab) || Tab.Trim() != "Permisos" && Tab.Trim() != "Vacaciones" ? "Permisos" : Tab;
            _V2IncVacacionesCtrl = new V2IncVacacionesCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            _V2IncPermisoCtrl = new V2IncPermisoCtrl(_V2IncVacacionesCtrl._darkM, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            try
            {
                ViewData["Tab"] = Tab;
                ViewData["Vacaciones"] = _V2IncVacacionesCtrl.GetByGPSAdmin();
                ViewData["Permisos"] = _V2IncPermisoCtrl.GetByGPSAdmin();
                return View();
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                return ValidateException(ex);
            }
            finally
            {
                _V2IncVacacionesCtrl.Terminar();
                _V2IncPermisoCtrl.Terminar();
            }
        }
        [AccessView]
        public IActionResult SolicitudesAdmin(string Tab)
        {
            Tab = string.IsNullOrEmpty(Tab) || Tab.Trim() != "Permisos" && Tab.Trim() != "Vacaciones" ? "Permisos" : Tab;
            _V2IncVacacionesCtrl = new V2IncVacacionesCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            _V2IncPermisoCtrl = new V2IncPermisoCtrl(_V2IncVacacionesCtrl._darkM, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            try
            {
                ViewData["Tab"] = Tab;
                ViewData["Vacaciones"] = _V2IncVacacionesCtrl.GetAdmin();
                ViewData["Permisos"] = _V2IncPermisoCtrl.GetAdmin();
                return View();
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                return ValidateException(ex);
            }
            finally
            {
                _V2IncVacacionesCtrl.Terminar();
                _V2IncPermisoCtrl.Terminar();
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
