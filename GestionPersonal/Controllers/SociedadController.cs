using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionPersonal.Models;
using GPSInformation;
using GPSInformation.Controllers;
using GPSInformation.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace GestionPersonal.Controllers
{
    public class SociedadController : Controller
    {
        private DarkManager darkManager;
        private V2OrganCtrl _V2OrganCtrl;

        public SociedadController(IConfiguration configuration)
        {
            darkManager = new DarkManager(configuration);
        }

        ~SociedadController()
        {

        }

        // GET: Sociedad
        [AccessMultipleView(IdAction = new int[] { 10,11 })]
        public ActionResult Index()
        {
            _V2OrganCtrl = new V2OrganCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"));
            try
            {
                var result = _V2OrganCtrl._darkM.Sociedad.GetOpenquery("","order by Descripcion");
                ViewData["Access11"] = _V2OrganCtrl._UsrCrt.ValidAction(_V2OrganCtrl._IdUsuario, 11);
                return View(result);
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                return NotFound(ex.Message);
            }
            finally
            {
                _V2OrganCtrl.Terminar();
            }
        }

        // GET: Sociedad/Details/5
        [AccessMultipleView(IdAction = new int[] { 10, 11 })]
        public ActionResult Details(int id)
        {
            _V2OrganCtrl = new V2OrganCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"));
            try
            {
                var result = _V2OrganCtrl._darkM.Sociedad.Get(id);
                if (result is null)
                {
                    return NotFound("Sociedad no encontrada");
                }
                ViewData["Access11"] = _V2OrganCtrl._UsrCrt.ValidAction(_V2OrganCtrl._IdUsuario, 11);
                return View(result);
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                return NotFound(ex.Message);
            }
            finally
            {
                _V2OrganCtrl.Terminar();
            }
        }

        // GET: Sociedad/Create
        [AccessMultipleView(IdAction = new int[] { 11 })]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sociedad/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AccessMultipleView(IdAction = new int[] { 11 })]
        public ActionResult Create(Sociedad Sociedad)
        {
            _V2OrganCtrl = new V2OrganCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"));
            _V2OrganCtrl.LoadTranssByMethod = true;
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(Sociedad);
                }
                int Created = _V2OrganCtrl.SocAdd(Sociedad);
                return RedirectToAction("Details", new { Id = Created });
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                ModelState.AddModelError(string.IsNullOrEmpty(ex.IdAux) ? "" : ex.IdAux, ex.Message);
                return View(Sociedad);
            }
            finally
            {
                _V2OrganCtrl.Terminar();
            }
        }

        // GET: Sociedad/Edit/5
        [AccessMultipleView(IdAction = new int[] { 11 })]
        public ActionResult Edit(int id)
        {
            _V2OrganCtrl = new V2OrganCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"));
            try
            {
                var result = _V2OrganCtrl._darkM.Sociedad.Get(id);
                if(result is null)
                {
                    return NotFound("Sociedad no encontrada");
                }
                return View(result);
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                return NotFound(ex.Message);
            }
            finally
            {
                _V2OrganCtrl.Terminar();
            }
        }

        // POST: Sociedad/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AccessMultipleView(IdAction = new int[] { 11 })]
        public ActionResult Edit(Sociedad Sociedad)
        {
            _V2OrganCtrl = new V2OrganCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"));
            _V2OrganCtrl.LoadTranssByMethod = true;
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(Sociedad);
                }
                _V2OrganCtrl.SocEdit(Sociedad);
                ViewData["MessageSuccess"] = "Se han guardado los cambios exitosamente, gracias por usar nuestra plataforma GPS";
                return View(Sociedad);
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                ModelState.AddModelError(string.IsNullOrEmpty(ex.IdAux) ? "" : ex.IdAux, ex.Message);
                return View(Sociedad);
            }
            finally
            {
                _V2OrganCtrl.Terminar();
            }
        }
    }
}