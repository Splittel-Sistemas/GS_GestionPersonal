using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionPersonal.Models;
using GPSInformation;
using GPSInformation.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace GestionPersonal.Controllers
{
    public class AccesoSistemaController : Controller
    {
        private DarkManager darkManager;
        public AccesoSistemaController(IConfiguration configuration)
        {
            darkManager = new DarkManager(configuration);
            darkManager.OpenConnection();
            darkManager.LoadObject(GpsManagerObjects.Modulo);
            darkManager.LoadObject(GpsManagerObjects.SubModulo);
            darkManager.LoadObject(GpsManagerObjects.AccesosSistema);
            darkManager.LoadObject(GpsManagerObjects.Usuario);
            darkManager.LoadObject(GpsManagerObjects.Reporte);
            darkManager.LoadObject(GpsManagerObjects.ReporteAccss);
        }

        // GET: AccesoSistema
        public ActionResult Index()
        {
            return View();
        }

        // GET: AccesoSistema/Details/5
        public ActionResult Details(int id)
        {
            var persona = darkManager.Usuario.GetByColumn("" + id, nameof(darkManager.Usuario.Element.IdPersona));
            var menu = darkManager.Modulo.Get().OrderBy(a => a.Posicion).ToList();
            var accesos = darkManager.AccesosSistema.Get("" + persona.IdUsuario, nameof(darkManager.AccesosSistema.Element.IdUsuario));
            menu.ForEach(a => {
                a.SubModulos = new List<GPSInformation.Models.SubModulo>();
                var Submodulos = darkManager.SubModulo.Get("" + a.IdModulo, nameof(darkManager.SubModulo.Element.IdModulo)).OrderBy(b => b.Posicion).ToList();

                Submodulos.ForEach(b => {
                    var acces = accesos.Find(n => n.IdSubModulo == b.IdSubModulo);
                    if (acces == null)
                    {
                        b.AccesosSistema = new GPSInformation.Models.AccesosSistema() { IdUsuario = persona.IdUsuario, IdSubModulo = b.IdSubModulo };
                    }
                    else
                    {
                        b.AccesosSistema = acces;
                    }
                    a.SubModulos.Add(b);
                });
            });

            var reportes = new  List<ReporteAccessos>();
            darkManager.Reporte.GetOpenquery($"Where Activo = 1", "order by Descripcion").ForEach(re =>
            {
                var rex = new ReporteAccessos { 
                    Descripcion = re.Descripcion,
                    IdReporte = re.IdReporte
                };
                var acceso = darkManager.ReporteAccss.GetOpenquerys($"where IdReporte = {re.IdReporte} and IdUsuario = {persona.IdUsuario}");

                rex.Acceso = acceso is null ? false : acceso.Access;

                reportes.Add(rex);

            });


            return Ok(new UsuarioPermisos { IdPersona = persona.IdPersona, IdPersonaUser = persona.IdUsuario, Modulos = menu.Where(a => a.SubModulos.Count > 0).ToList(), Reportes = reportes });
        }

        // GET: AccesoSistema/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AccesoSistema/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AccesoSistema/Edit/5
        public ActionResult Edit(int id)
        {
            var persona = darkManager.Usuario.GetByColumn("" + id, nameof(darkManager.Usuario.Element.IdPersona));
            ViewData["AccesoEdit"] = darkManager.AccesosSistema.GetOpenquerys($"where IdUsuario = {(int)HttpContext.Session.GetInt32("user_id_permiss")} and IdSubModulo = 19").TieneAcceso;
            return View(new UsuarioPermisos { IdPersona = persona.IdPersona, Modulos = new List<GPSInformation.Models.Modulo>() }); ;
        }

        // POST: AccesoSistema/Edit/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult EditPermissions([FromBody] UsuarioPermisos modulos)
        {
            try
            {
                var accesos = darkManager.AccesosSistema.Get("" + modulos.IdPersonaUser, nameof(darkManager.AccesosSistema.Element.IdUsuario));
                // TODO: Add update logic here
                modulos.Modulos.ForEach(a =>
                {
                    a.SubModulos.ForEach(b =>
                    {
                        b.AccesosSistema.Forzado = true;
                        b.AccesosSistema.Modificado = DateTime.Now;
                        darkManager.AccesosSistema.Element = b.AccesosSistema;

                        if (accesos.Find(c => c.IdSubModulo == b.IdSubModulo) == null)
                        {
                            if (!darkManager.AccesosSistema.Add())
                            {
                                throw new GPSInformation.Exceptions.GpExceptions(darkManager.GetLastMessage());
                            }
                        }
                        else
                        {
                            if (!darkManager.AccesosSistema.Update())
                            {
                                throw new GPSInformation.Exceptions.GpExceptions(darkManager.GetLastMessage());
                            }
                        }
                    });
                });

                modulos.Reportes.ForEach(re =>
                {
                    var acceso = darkManager.ReporteAccss.GetOpenquerys($"where IdReporte = {re.IdReporte} and IdUsuario = {modulos.IdPersonaUser}");
                    if(acceso is null)
                    {
                        acceso = new ReporteAccss
                        {
                            Access = re.Acceso,
                            IdReporte = re.IdReporte,
                            IdUsuario = modulos.IdPersonaUser,
                            Editado = DateTime.Now,
                            IdReporteAccss = darkManager.ReporteAccss.GetLastId() + 1
                        };
                        darkManager.ReporteAccss.Element = acceso;
                        darkManager.ReporteAccss.Add();
                    }
                    else
                    {
                        acceso.Access = re.Acceso;
                        acceso.Editado = DateTime.Now;
                        darkManager.ReporteAccss.Element = acceso;
                        darkManager.ReporteAccss.Update();
                    }
                });


                return Ok("Permisos guardados");
            }
            catch (GPSInformation.Exceptions.GpExceptions ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}