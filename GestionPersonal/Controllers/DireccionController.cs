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
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;

namespace GestionPersonal.Controllers
{
    /*
        estructura de permisos
        12 - Lectura
        13 - scritura
     */

    public class DireccionController : Controller
    {
        private DarkManager darkManager;
        private V2OrganCtrl _V2OrganCtrl;

        public DireccionController(IConfiguration configuration)
        {
            darkManager = new DarkManager(configuration);
        }

        ~DireccionController()
        {

        }

        // GET: Direccion
        [AccessMultipleView(IdAction = new int[] {12,13 })]
        public ActionResult Index()
        {
            _V2OrganCtrl = new V2OrganCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"));
            try
            {
                var result = _V2OrganCtrl.DireGet();
                ViewData["Access13"] = _V2OrganCtrl._UsrCrt.ValidAction(_V2OrganCtrl._IdUsuario, 13);
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

        // GET: Direccion/Details/5
        [AccessMultipleView(IdAction = new int[] { 12, 13 })]
        public ActionResult Details(int id)
        {
            _V2OrganCtrl = new V2OrganCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"));
            try
            {
                var result = _V2OrganCtrl.DireDetails(id);
                if (result is null)
                {
                    return NotFound("direccion no encontrada");
                }
                ViewData["Access13"] = _V2OrganCtrl._UsrCrt.ValidAction(_V2OrganCtrl._IdUsuario, 13);
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

        // GET: Direccion/Create
        [AccessMultipleView(IdAction = new int[] { 13 })]
        public ActionResult Create()
        {
            _V2OrganCtrl = new V2OrganCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"));
            GenerateSelects();
            try
            {
                return View();
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

        // POST: Direccion/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AccessMultipleView(IdAction = new int[] { 13 })]
        public ActionResult Create(Direccion Direccion)
        {
            _V2OrganCtrl = new V2OrganCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"));
            _V2OrganCtrl.LoadTranssByMethod = true;
            GenerateSelects(Direccion.IdSociedad);
            try
            {
                if (!ModelState.IsValid)
                {
                    
                    return View(Direccion);
                }
                int Created = _V2OrganCtrl.DireAdd(Direccion);
                return RedirectToAction("Details", new { Id = Created });
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                ModelState.AddModelError(string.IsNullOrEmpty(ex.IdAux) ? "" : ex.IdAux, ex.Message);
                return View(Direccion);
            }
            finally
            {
                _V2OrganCtrl.Terminar();
            }
        }

        // GET: Direccion/Edit/5
        [AccessMultipleView(IdAction = new int[] { 13 })]
        public ActionResult Edit(int id)
        {
            _V2OrganCtrl = new V2OrganCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"));
            
            try
            {
                var result = _V2OrganCtrl._darkM.Direccion.Get(id);
                if (result is null)
                {
                    return NotFound("Sociedad no encontrada");
                }
                GenerateSelects(result.IdSociedad);
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

        // POST: Direccion/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AccessMultipleView(IdAction = new int[] { 13 })]
        public ActionResult Edit(Direccion Direccion)
        {
            _V2OrganCtrl = new V2OrganCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"));
            _V2OrganCtrl._darkM.StartTransaction();
            GenerateSelects(Direccion.IdSociedad);
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(Direccion);
                }
                _V2OrganCtrl.DireEdit(Direccion);
                ViewData["MessageSuccess"] = "Se han guardado los cambios exitosamente, gracias por usar nuestra plataforma GPS";
                _V2OrganCtrl._darkM.Commit();
                return View(Direccion);
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                ModelState.AddModelError(string.IsNullOrEmpty(ex.IdAux) ? "" : ex.IdAux, ex.Message);
                _V2OrganCtrl._darkM.RolBack();
                return View(Direccion);
            }
            finally
            {
                _V2OrganCtrl.Terminar();
            }
        }
        
        [NonAction]
        private void GenerateSelects(int IdSociedad = 0)
        {
            ViewData["Sociedades"] = new SelectList(darkManager.Sociedad.Get().OrderBy(a => a.Descripcion).ToList(), "IdSociedad", "Descripcion", IdSociedad);
        }
    }
}