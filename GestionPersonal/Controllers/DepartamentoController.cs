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
        14 - Lectura
        15 - scritura
     */
    public class DepartamentoController : Controller
    {
        private DarkManager darkManager;
        private V2OrganCtrl _V2OrganCtrl;


        public DepartamentoController(IConfiguration configuration)
        {
            darkManager = new DarkManager(configuration);
        }

        ~DepartamentoController()
        {

        }

        // GET: Departamento
        [AccessMultipleView( IdAction = new int[] { 14,15})]
        public ActionResult Index()
        {
            _V2OrganCtrl = new V2OrganCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"));
            try
            {
                var result = _V2OrganCtrl.DepGet();
                ViewData["Access15"] = _V2OrganCtrl._UsrCrt.ValidAction(_V2OrganCtrl._IdUsuario, 15);
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

        // GET: Departamento/Details/5
        [AccessMultipleView(IdAction = new int[] { 14, 15 })]
        public ActionResult Details(int id)
        {
            _V2OrganCtrl = new V2OrganCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"));
            try
            {
                var result = _V2OrganCtrl.DepDetails(id);
                if (result is null)
                {
                    return NotFound("Departamento no encontrada");
                }
                ViewData["Access15"] = _V2OrganCtrl._UsrCrt.ValidAction(_V2OrganCtrl._IdUsuario, 15);
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

        // GET: Departamento/Create
        [AccessMultipleView(IdAction = new int[] { 15 })]
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

        // POST: Departamento/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AccessMultipleView(IdAction = new int[] { 15 })]
        public ActionResult Create(Departamento Departamento)
        {
            _V2OrganCtrl = new V2OrganCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"));
            _V2OrganCtrl.LoadTranssByMethod = true;
            GenerateSelects(Departamento.IdDireccion);
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(Departamento);
                }
                int Created = _V2OrganCtrl.DepAdd(Departamento);
                return RedirectToAction("Details", new { Id = Created });
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                ModelState.AddModelError(string.IsNullOrEmpty(ex.IdAux) ? "" : ex.IdAux, ex.Message);
                return View(Departamento);
            }
            finally
            {
                _V2OrganCtrl.Terminar();
            }
        }

        // GET: Departamento/Edit/5
        [AccessMultipleView(IdAction = new int[] { 15 })]
        public ActionResult Edit(int id)
        {
            _V2OrganCtrl = new V2OrganCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"));

            try
            {
                var result = _V2OrganCtrl._darkM.Departamento.Get(id);
                if (result is null)
                {
                    return NotFound("Departamento no encontrada");
                }
                GenerateSelects(result.IdDireccion);
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

        // POST: Departamento/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AccessMultipleView(IdAction = new int[] { 15 })]
        public ActionResult Edit(Departamento Departamento)
        {
            _V2OrganCtrl = new V2OrganCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"));
            _V2OrganCtrl._darkM.StartTransaction();
            GenerateSelects(Departamento.IdDireccion);
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(Departamento);
                }
                _V2OrganCtrl.DepEdit(Departamento);
                ViewData["MessageSuccess"] = "Se han guardado los cambios exitosamente, gracias por usar nuestra plataforma GPS";
                _V2OrganCtrl._darkM.Commit();
                return View(Departamento);
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                ModelState.AddModelError(string.IsNullOrEmpty(ex.IdAux) ? "" : ex.IdAux, ex.Message);
                _V2OrganCtrl._darkM.RolBack();
                return View(Departamento);
            }
            finally
            {
                _V2OrganCtrl.Terminar();
            }
        }

        [NonAction]
        private void GenerateSelects(int IdDireccion = 0)
        {
            ViewData["Direcciones"] = new SelectList(darkManager.Direccion.Get().OrderBy(a => a.Nombre).ToList(), "IdDireccion", "Nombre", IdDireccion);
        }
    }
}