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
    public class IncPermisoController : Controller
    {
        private DarkManager darkManager;
        private V2IncPermisoCtrl _V2IncidenciaCtrl;
        private readonly IViewRenderService _viewRenderService;


        public IncPermisoController(IConfiguration configuration, IViewRenderService viewRenderService)
        {
            this._viewRenderService = viewRenderService;
            darkManager = new DarkManager(configuration);
        }
        [AccessView]
        public IActionResult Notification(int id)
        {
            _V2IncidenciaCtrl = new V2IncPermisoCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            try
            {
                var incidencia = _V2IncidenciaCtrl.Details(id, true);
                if (incidencia.Estatus == 2 || incidencia.Estatus == 3)
                    incidencia.Link = Url.Action("Autorizar", "IncPermiso", new { id = id, Mode = incidencia.Estatus });
                else
                    incidencia.Link = Url.Action("Details", "IncPermiso", new { id = id });
                return View(incidencia);
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                return ValidateException(ex);
            }
            finally
            {
                _V2IncidenciaCtrl.Terminar();
            }
        }
        [AccessView]
        public IActionResult Autorizar(string id, string Mode)
        {
            _V2IncidenciaCtrl = new V2IncPermisoCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            try
            {
                int _id = Int32.Parse(GPSInformation.Tools.EncryptData.Decrypt(id));
                int _Mode = Int32.Parse(GPSInformation.Tools.EncryptData.Decrypt(Mode));
                _V2IncidenciaCtrl.ValidarAcciones(V2IncValidation.Aprove, _id, _Mode);
                var incidencia = _V2IncidenciaCtrl.Details(_id, true);
                ViewData["Details"] = incidencia;
                return View(new InAutorizacion { IdAutorizante = (int)HttpContext.Session.GetInt32("user_id"), IdIncidencia = _id, Modee = _Mode  });
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                return ValidateException(ex);
            }
            finally
            {
                _V2IncidenciaCtrl.Terminar();
            }
        }
        [AccessView]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Autorizar(InAutorizacion inAutorizacion)
        {
            _V2IncidenciaCtrl = new V2IncPermisoCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            try
            {
                _V2IncidenciaCtrl.ValidarAcciones(V2IncValidation.Aprove, inAutorizacion.IdIncidencia, inAutorizacion.Modee);
                _V2IncidenciaCtrl.Autorizar(inAutorizacion);
                SendNotificationAsync(inAutorizacion.IdIncidencia);
                return RedirectToAction("Autorizar", new { id = GPSInformation.Tools.EncryptData.Encrypt(inAutorizacion.IdIncidencia+""), Mode = GPSInformation.Tools.EncryptData.Encrypt(inAutorizacion.Modee+"") });
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                return ValidateException(ex);
            }
            finally
            {
                _V2IncidenciaCtrl.Terminar();
            }
        }
        [AccessView]
        public IActionResult Delete(int id)
        {
            _V2IncidenciaCtrl = new V2IncPermisoCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            try
            {
                _V2IncidenciaCtrl.ValidarAcciones(V2IncValidation.Delete, id);
                _V2IncidenciaCtrl.Eliminar(id);
                return RedirectToAction("Details", new { id = id });
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                return ValidateException(ex, null, true);
            }
            finally
            {
                _V2IncidenciaCtrl.Terminar();
            }
        }
        [AccessView]
        public IActionResult Cancelar(int id)
        {
            _V2IncidenciaCtrl = new V2IncPermisoCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            try
            {
                _V2IncidenciaCtrl.ValidarAcciones(V2IncValidation.Cancel, id);
                _V2IncidenciaCtrl.Cancelar(id);
                SendNotificationAsync(id);
                return RedirectToAction("Details", new { id = id });
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                return ValidateException(ex,null, true);
            }
            finally
            {
                _V2IncidenciaCtrl.Terminar();
            }
        }
        [AccessView]
        public IActionResult Details(int id, string AnteriorView)
        {
            _V2IncidenciaCtrl = new V2IncPermisoCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            try
            {
                var incidencia = _V2IncidenciaCtrl.Details(id, true);
                var accessoAd = _V2IncidenciaCtrl._Accesos.Find(a => a.IdSubModulo == _V2IncidenciaCtrl._ALecturaEscrituraAdmin);
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
                _V2IncidenciaCtrl.Terminar();
            }
        }
        [AccessView]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(IncidenciaPermiso incidencia)
        {
            _V2IncidenciaCtrl = new V2IncPermisoCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            ViewData["TiposPermisos"] = new SelectList(darkManager.CatalogoOpcionesValores.GetOpenquery("where IdCatalogoOpciones = 1009", "order by Descripcion"), "IdCatalogoOpcionesValores", "Descripcion", incidencia.IdAsunto);
            ViewData["PagoPermisoPersonal"] = new SelectList(darkManager.CatalogoOpcionesValores.GetOpenquery("where IdCatalogoOpciones = 1010", "order by Descripcion"), "IdCatalogoOpcionesValores", "Descripcion", incidencia.IdPagoPermiso);
            try
            {
                _V2IncidenciaCtrl.Edit(incidencia);
                ViewData["MessageSuccess"] = "Incidencia guardada";
                return RedirectToAction("Details", new { id = incidencia.IdIncidenciaPermiso });
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                return ValidateException(ex);
            }
            finally
            {
                _V2IncidenciaCtrl.Terminar();
            }
        }
        [AccessView]
        public IActionResult Edit(int id)
        {
            _V2IncidenciaCtrl = new V2IncPermisoCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            try
            {
               
                var incidencia = _V2IncidenciaCtrl.Details(id, true);
                _V2IncidenciaCtrl.ValidarAcciones(V2IncValidation.Edit, 0, 0, incidencia);

                ViewData["TiposPermisos"] = new SelectList(darkManager.CatalogoOpcionesValores.GetOpenquery("where IdCatalogoOpciones = 1009", "order by Descripcion"), "IdCatalogoOpcionesValores", "Descripcion", incidencia.IdAsunto);
                ViewData["PagoPermisoPersonal"] = new SelectList(darkManager.CatalogoOpcionesValores.GetOpenquery("where IdCatalogoOpciones = 1010", "order by Descripcion"), "IdCatalogoOpcionesValores", "Descripcion", incidencia.IdPagoPermiso);
                return View(incidencia);
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                return ValidateException(ex);
            }
            finally
            {
                _V2IncidenciaCtrl.Terminar();
            }
        }
        [AccessView]
        public IActionResult Create(int id)
        {
            _V2IncidenciaCtrl = new V2IncPermisoCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            ViewData["TiposPermisos"] = new SelectList(darkManager.CatalogoOpcionesValores.GetOpenquery("where IdCatalogoOpciones = 1009", "order by Descripcion"), "IdCatalogoOpcionesValores", "Descripcion");
            ViewData["PagoPermisoPersonal"] = new SelectList(darkManager.CatalogoOpcionesValores.GetOpenquery("where IdCatalogoOpciones = 1010", "order by Descripcion"), "IdCatalogoOpcionesValores", "Descripcion");
            try
            {
                var nuevo = new IncidenciaPermiso { IdPersona = id == 0 ? (int)HttpContext.Session.GetInt32("user_id") : 0, Fecha = System.DateTime.Now };
                _V2IncidenciaCtrl.ValidarAcciones(V2IncValidation.Edit, 0, 0, nuevo);

                return View(nuevo);
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                return ValidateException(ex);
            }
            finally
            {
                _V2IncidenciaCtrl.Terminar();
            }
        }
        [AccessView]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(IncidenciaPermiso incidencia)
        {
            _V2IncidenciaCtrl = new V2IncPermisoCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            ViewData["TiposPermisos"] = new SelectList(darkManager.CatalogoOpcionesValores.GetOpenquery("where IdCatalogoOpciones = 1009", "order by Descripcion"), "IdCatalogoOpcionesValores", "Descripcion", incidencia.IdAsunto);
            ViewData["PagoPermisoPersonal"] = new SelectList(darkManager.CatalogoOpcionesValores.GetOpenquery("where IdCatalogoOpciones = 1010", "order by Descripcion"), "IdCatalogoOpcionesValores", "Descripcion", incidencia.IdPagoPermiso);
            try
            {
                var _id = _V2IncidenciaCtrl.Create(incidencia);
                SendNotificationAsync(_id);
                return RedirectToAction("Details",new { id = _id });
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                return ValidateException(ex);
            }
            finally
            {
                _V2IncidenciaCtrl.Terminar();
            }
        }
        [AccessView]
        public IActionResult MisSolicitudes()
        {
            _V2IncidenciaCtrl = new V2IncPermisoCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            try
            {
                return View(new ResV2Inicidencias { Permisos = _V2IncidenciaCtrl.GetByUsuario() });
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                return ValidateException(ex);
            }
            finally
            {
                _V2IncidenciaCtrl.Terminar();
            }
        }
        [AccessView]
        public IActionResult SolicitudesN1()
        {
            _V2IncidenciaCtrl = new V2IncPermisoCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            try
            {
                return View(new ResV2Inicidencias { Permisos = _V2IncidenciaCtrl.GetByJefeInmediato() });
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                return ValidateException(ex);
            }
            finally
            {
                _V2IncidenciaCtrl.Terminar();
            }
        }
        [AccessView]
        public IActionResult SolicitudesN2()
        {
            _V2IncidenciaCtrl = new V2IncPermisoCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            try
            {
                return View(new ResV2Inicidencias { Permisos = _V2IncidenciaCtrl.GetByGPSAdmin() });
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                return ValidateException(ex);
            }
            finally
            {
                _V2IncidenciaCtrl.Terminar();
            }
        }




        [NonAction]
        private async void SendNotificationAsync(int IdPermiso)
        {
            try
            {
                var incidencia = _V2IncidenciaCtrl.Details(IdPermiso, true);
                if (incidencia.Estatus == 2 || incidencia.Estatus == 3)
                    incidencia.Link =$"{((HttpContext.Request.IsHttps ? "https:" : "http: "))}//{HttpContext.Request.Host}{Url.Action("Autorizar", "IncPermiso", new { id = incidencia.EncriptId, Mode = GPSInformation.Tools.EncryptData.Encrypt(incidencia.Estatus + "") })}";
                else
                    incidencia.Link = $"{((HttpContext.Request.IsHttps ? "https:" : "http: "))}//{HttpContext.Request.Host}{Url.Action("Details", "IncPermiso", new { id = incidencia.EncriptId })}";

                var result = await _viewRenderService.RenderToStringAsync("IncPermiso/Notification", incidencia);

                _V2IncidenciaCtrl.EnviarNotificacion(IdPermiso, result);
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
            else if(ex.Category == GPSInformation.Exceptions.TypeException.NotFound)
            {
                ViewData["MessageError"] = ex.Message;
                return View("../Home/NotFoundPage");
            }
            else if(ex.Category == GPSInformation.Exceptions.TypeException.Info)
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