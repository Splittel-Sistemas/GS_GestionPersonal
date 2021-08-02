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
        16 - Lectura
        17 - scritura
     */
    public class PuestoController : Controller
    {
        private DarkManager darkManager;
        private V2OrganCtrl _V2OrganCtrl;

        public PuestoController(IConfiguration configuration)
        {
            darkManager = new DarkManager(configuration);
        }

        ~PuestoController()
        {

        }

        // GET: Puesto
        [AccessMultipleView(IdAction = new int[] { 16,17 })]
        public ActionResult Index()
        {
            _V2OrganCtrl = new V2OrganCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"));
            try
            {
                var result = _V2OrganCtrl.PueGet();
                ViewData["Access17"] = _V2OrganCtrl._UsrCrt.ValidAction(_V2OrganCtrl._IdUsuario, 17);
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

        // GET: Puesto/Details/5
        [AccessMultipleView(IdAction = new int[] { 16, 17 })]
        public ActionResult Details(int id)
        {
            _V2OrganCtrl = new V2OrganCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"));
            try
            {
                var result = _V2OrganCtrl.PueDetails(id);
                if (result is null)
                {
                    return NotFound("Puesto no encontrado");
                }
                ViewData["Access17"] = _V2OrganCtrl._UsrCrt.ValidAction(_V2OrganCtrl._IdUsuario, 17);
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

        // GET: Puesto/Create
        [AccessMultipleView(IdAction = new int[] { 17 })]
        public ActionResult Create()
        {
            _V2OrganCtrl = new V2OrganCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"));
            GenerateSelects();
            try
            {
                return View(new Puesto { NumeroDPU = 0 });
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

        // POST: Puesto/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AccessMultipleView(IdAction = new int[] { 17 })]
        public ActionResult Create(Puesto Puesto)
        {
            _V2OrganCtrl = new V2OrganCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"));
            _V2OrganCtrl.LoadTranssByMethod = true;
            GenerateSelects(Puesto.IdDepartamento, Puesto.IdUbicacion);
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(Puesto);
                }
                int Created = _V2OrganCtrl.PueAdd(Puesto);
                return RedirectToAction("Details", new { Id = Created });
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                ModelState.AddModelError(string.IsNullOrEmpty(ex.IdAux) ? "" : ex.IdAux, ex.Message);
                return View(Puesto);
            }
            finally
            {
                _V2OrganCtrl.Terminar();
            }
        }

        // GET: Puesto/Edit/5
        [AccessMultipleView(IdAction = new int[] { 17 })]
        public ActionResult Edit(int id)
        {
            _V2OrganCtrl = new V2OrganCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"));

            try
            {
                var result = _V2OrganCtrl.PueDetails(id);
                if (result is null)
                {
                    return NotFound("Puesto no encontrado");
                }
                GenerateSelects(result.Puesto.IdDepartamento, result.Puesto.IdUbicacion);
                return View(result.Puesto);
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

        // POST: Puesto/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AccessMultipleView(IdAction = new int[] { 17 })]
        public ActionResult Edit(Puesto Puesto)
        {
            _V2OrganCtrl = new V2OrganCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"));
            _V2OrganCtrl._darkM.StartTransaction();
            GenerateSelects(Puesto.IdDepartamento, Puesto.IdUbicacion);
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(Puesto);
                }
                _V2OrganCtrl.PueEdit(Puesto);
                ViewData["MessageSuccess"] = "Se han guardado los cambios exitosamente, gracias por usar nuestra plataforma GPS";
                _V2OrganCtrl._darkM.Commit();
                return View(Puesto);
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                ModelState.AddModelError(string.IsNullOrEmpty(ex.IdAux) ? "" : ex.IdAux, ex.Message);
                _V2OrganCtrl._darkM.RolBack();
                return View(Puesto);
            }
            finally
            {
                _V2OrganCtrl.Terminar();
            }
        }

        [NonAction]
        private void GenerateSelects(int idDepartamentos = 0,  int idUbicaciones = 0)
        {
            _V2OrganCtrl._darkM.LoadObject(GpsManagerObjects.CatalogoOpcionesValores);
            ViewData["Departamentos"] = new SelectList(darkManager.Departamento.Get().OrderBy(a => a.Nombre).ToList(), "IdDepartamento", "Nombre", idDepartamentos);
            ViewData["Ubicaciones"] = new SelectList(darkManager.CatalogoOpcionesValores.Get("" + 1, "IdCatalogoOpciones").OrderBy(a => a.Descripcion).ToList(), "IdCatalogoOpcionesValores", "Descripcion", idUbicaciones);
        }

    }
}