using GPSInformation;
using GPSInformation.Controllers;
using GPSInformation.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using GestionPersonal.Models;

namespace GestionPersonal.Controllers
{
    public class ReporteController : Controller
    {
        private DarkManager darkManager;
        private V2ReporteCtrl _V2ReporteCtrl;

        public ReporteController(IConfiguration configuration)
        {
            darkManager = new DarkManager(configuration);
        }
        [HttpPost]
        [AccessJson]
        public IActionResult EjecutarSentence(string sentence)
        {
            _V2ReporteCtrl = new V2ReporteCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            try
            {
                return Ok(_V2ReporteCtrl.GetSystSelects(sentence));
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                return BadRequest(ex.Message);
            }
            finally
            {
                _V2ReporteCtrl.Terminar();
            }
        }
        [HttpPost]
        [AccessJson]
        public IActionResult GetDetailsJson(int id)
        {
            _V2ReporteCtrl = new V2ReporteCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            try
            {
                return Ok(_V2ReporteCtrl.Details(id));
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                return BadRequest(ex.Message);
            }
            finally
            {
                _V2ReporteCtrl.Terminar();
            }
        }
        [AccessView]
        public IActionResult Edit(int id)
        {
            _V2ReporteCtrl = new V2ReporteCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            try
            {
                _V2ReporteCtrl._Accesos.ForEach(a => ViewData[a.Clave] = a.TieneAcceso);
                if(!_V2ReporteCtrl._Accesos.Find(a => a.IdSubModulo == _V2ReporteCtrl._AdminReportes).TieneAcceso)
                {
                    return View("../ErrorPages/NoAccess");
                }


                return View(_V2ReporteCtrl.Details(id));
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                if (ex.Category == GPSInformation.Exceptions.TypeException.Noautorizado)
                {
                    ViewData["MessageError"] = ex.Message;
                    return View("../ErrorPages/NoAccess");
                }
                else
                {
                    ViewData["MessageError"] = ex.Message;
                    return View("../ErrorPages/Error");
                }
            }
            finally
            {
                _V2ReporteCtrl.Terminar();
            }
        }
        [AccessView]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Reporte reporte)
        {
            _V2ReporteCtrl = new V2ReporteCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            _V2ReporteCtrl._darkM.StartTransaction();
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(reporte);
                }

                int _id = _V2ReporteCtrl.Edit(reporte);

                _V2ReporteCtrl._darkM.Commit();
                return RedirectToAction("Details", new { Id = _id });
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                ModelState.AddModelError("", ex.Message);
                _V2ReporteCtrl._darkM.RolBack();
                return View(reporte);
            }
            finally
            {
                _V2ReporteCtrl.Terminar();
            }
        }
        [AccessView]
        public IActionResult Create()
        {
            _V2ReporteCtrl = new V2ReporteCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            if (!_V2ReporteCtrl._Accesos.Find(a => a.IdSubModulo == _V2ReporteCtrl._AdminReportes).TieneAcceso)
            {
                ViewData["MessageError"] = "No tienes permisos para visualizar esta sección, por favor contacta al administrador del sitio";
                return View("../ErrorPages/Error");
            }
            _V2ReporteCtrl.Terminar();
            return View(new Reporte { IdReporte = 1, Creado = System.DateTime.Now, Editado =System.DateTime.Now, Tipo = 1 });
        }
        [AccessView]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Reporte reporte)
        {
            _V2ReporteCtrl = new V2ReporteCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            _V2ReporteCtrl._darkM.StartTransaction();
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(reporte);
                }
                int _id = _V2ReporteCtrl.Create(reporte);
                _V2ReporteCtrl._darkM.Commit();
                return RedirectToAction("Details", new { Id = _id });
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                ModelState.AddModelError("", ex.Message);
                _V2ReporteCtrl._darkM.RolBack();
                return View(reporte);
            }
            finally
            {
                _V2ReporteCtrl.Terminar();
            }
        }
        [HttpPost]
        [AccessViewPartial]
        public IActionResult EjecutarExistente([FromBody] GPSInformation.Request.ReqReporteRun reqReporteRun)
        {
            _V2ReporteCtrl = new V2ReporteCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            try
            {
                _V2ReporteCtrl._Accesos.ForEach(a => ViewData[a.Clave] = a.TieneAcceso);
                return PartialView(_V2ReporteCtrl.EjecutarExistente(reqReporteRun.IdReporte, reqReporteRun.OmitCols, reqReporteRun.Parametros));
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                if(ex.Category == GPSInformation.Exceptions.TypeException.Noautorizado || ex.Category == GPSInformation.Exceptions.TypeException.System)
                {
                    ViewData["MessageError"] = ex.Message;
                    return PartialView("../ErrorPages/Error");
                }
                else
                {
                    return BadRequest(ex.Message);
                }
            }
            finally
            {
                _V2ReporteCtrl.Terminar();
            }
        }
        [AccessView]
        public IActionResult Details(int Id)
        {
            _V2ReporteCtrl = new V2ReporteCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            try
            {

                _V2ReporteCtrl._Accesos.ForEach(a => ViewData[a.Clave] = a.TieneAcceso);

                var dealle = _V2ReporteCtrl.Details(Id);
                dealle.ParametrosD.ForEach(a =>
                {
                    if(a.Multiple == 1 && !string.IsNullOrEmpty(a.OptionsSQL))
                    {
                        ViewData[a.Variable] = new SelectList(_V2ReporteCtrl.GetSystSelects(a.OptionsSQL), "Value", "Label");
                    }
                });

                return View(dealle);
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                ViewData["MessageError"] = ex.Message;
                return View("../ErrorPages/Error");
            }
            finally
            {
                _V2ReporteCtrl.Terminar();
            }
        }
        [AccessView]
        public IActionResult Admin()
        {
            _V2ReporteCtrl = new V2ReporteCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            try
            {
                if(!_V2ReporteCtrl._Accesos.Find(a => a.IdSubModulo == _V2ReporteCtrl._AdminReportes).TieneAcceso)
                {
                    ViewData["MessageError"] = "No tienes permisos para visualizar esta sección, por favor contacta al administrador del sitio";
                    return View("../ErrorPages/Error");
                }
                return View(_V2ReporteCtrl.GetAdmin());
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                //if(ex.Category != GPSInformation.Exceptions.TypeException.Error)
                //{
                //    return View(_V2ReporteCtrl.GetAdmin());
                //}
                ViewData["MessageError"] = ex.Message;
                return View("../ErrorPages/Error");
            }
            finally
            {
                _V2ReporteCtrl.Terminar();
            }
        }
        [AccessView]
        public IActionResult Lectura()
        {
            _V2ReporteCtrl = new V2ReporteCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            try
            {
                if (!_V2ReporteCtrl._Accesos.Find(a => a.IdSubModulo == _V2ReporteCtrl._VerReportes).TieneAcceso)
                {
                    ViewData["MessageError"] = "No tienes permisos para visualizar esta sección, por favor contacta al administrador del sitio";
                    return View("../ErrorPages/Error");
                }
                return View(_V2ReporteCtrl.GetByUsuario());
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                //if(ex.Category != GPSInformation.Exceptions.TypeException.Error)
                //{
                //    return View(_V2ReporteCtrl.GetAdmin());
                //}
                ViewData["MessageError"] = ex.Message;
                return View("../ErrorPages/Error");
            }
            finally
            {
                _V2ReporteCtrl.Terminar();
            }
        }
    }
}
