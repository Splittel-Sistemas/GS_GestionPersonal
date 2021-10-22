﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionPersonal.Models;
using GPSInformation;
using GPSInformation.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;

namespace GestionPersonal.Controllers
{
    public class SalaController : Controller
    {
        private DarkManager darkManager;

        public SalaController(IConfiguration configuration)
        {
            darkManager = new DarkManager(configuration);
            darkManager.OpenConnection();
            darkManager.LoadObject(GpsManagerObjects.Sala);
            darkManager.LoadObject(GpsManagerObjects.SalaReservacion);
            darkManager.LoadObject(GpsManagerObjects.Persona);
            darkManager.LoadObject(GpsManagerObjects.Empleado);
            darkManager.LoadObject(GpsManagerObjects.AccesosSistema);
            darkManager.LoadObject(GpsManagerObjects.View_empleado);
        }

        ~SalaController()
        {

        }

        #region Sala
        [AccessMultipleView(IdAction = new int[] { 33 })]
        public ActionResult Reservar()
        {
            var AccesoAdmin = darkManager.AccesosSistema.Get(
                "IdUsuario","" + (int)HttpContext.Session.GetInt32("user_id_permiss"),
                "IdSubModulo", "35");
            bool access = AccesoAdmin != null ? AccesoAdmin.TieneAcceso : false;
            ViewData["access"] = access;
            ViewData["IdPersona"] = (int)HttpContext.Session.GetInt32("user_id"); ;
            return View();
        }

        [AccessMultipleView(IdAction = new int[] { 35 })]
        public ActionResult Index()
        {
            try
            {
                return View(darkManager.Sala.Get());
            }
            catch (GPSInformation.Exceptions.GpExceptions ex)
            {
                return NotFound(ex.Message);
            }
            finally
            {
                darkManager.CloseConnection();
                darkManager = null;
            }

            
        }

        [AccessMultipleView(IdAction = new int[] { 33, 35 })]
        public ActionResult Details(int id)
        {
            try
            {
                var result = darkManager.Sala.Get(id);
                if (result == null)
                {
                    return BadRequest("No se encontró ninguna sala");
                }
                return Ok(result);
            }
            catch (GPSInformation.Exceptions.GpExceptions ex)
            {
                return BadRequest(ex.Message);
            }
            finally
            {
                darkManager.CloseConnection();
                darkManager = null;
            }
        }

        [HttpPost]
        [AccessDataSession(IdAction = new int[] { 33 })]
        public ActionResult GetList()
        {
            try
            {
                var result = darkManager.Sala.Get().Where(a => a.Activa).OrderBy(a => a.Nombre);
                return Ok(result);
            }
            catch (GPSInformation.Exceptions.GpExceptions ex)
            {
                return BadRequest(ex.Message);
            }
            finally
            {
                darkManager.CloseConnection();
                darkManager = null;
            }
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AccessMultipleView(IdAction = new int[] { 35 })]
        public ActionResult Create(Sala Sala)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(Sala);
                }
                darkManager.Sala.Element = Sala;
                if (darkManager.Sala.Add())
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError("", darkManager.GetLastMessage());
                    return View(Sala);
                }
            }
            catch (GPSInformation.Exceptions.GpExceptions ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(Sala);
            }
            finally
            {
                darkManager.CloseConnection();
                darkManager = null;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AccessMultipleView(IdAction = new int[] { 35 })]
        public ActionResult Edit(Sala Sala)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(Sala);
                }
                darkManager.Sala.Element = Sala;
                if (darkManager.Sala.Update())
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ModelState.AddModelError("", darkManager.GetLastMessage());
                    return View(Sala);
                }
            }
            catch (GPSInformation.Exceptions.GpExceptions ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(Sala);
            }
            finally
            {
                darkManager.CloseConnection();
                darkManager = null;
            }
        }
        [AccessMultipleView(IdAction = new int[] { 35 })]
        public ActionResult Edit(int id)
        {
            try
            {
                return View(darkManager.Sala.Get(id));
            }
            catch (GPSInformation.Exceptions.GpExceptions ex)
            {
                return NotFound(ex.Message);
            }
            finally
            {
                darkManager.CloseConnection();
                darkManager = null;
            }
           
        }

        [AccessMultipleView(IdAction = new int[] { 35 })]
        public ActionResult Create()
        {
            try
            {
                return View();
            }
            catch (GPSInformation.Exceptions.GpExceptions ex)
            {
                return NotFound(ex.Message);
            }
            finally
            {
                darkManager.CloseConnection();
                darkManager = null;
            }
            
        }

        #endregion

        #region Reservaciones
        [AccessDataSession(IdAction = new int[] { 33 })]
        public ActionResult DetailsReservacion(int id)
        {
            try
            {
                var result = darkManager.SalaReservacion.Get(id);
                if (result == null)
                {
                    return BadRequest("No se encontró ninguna reservación");
                }
                return Ok(result);
            }
            catch (GPSInformation.Exceptions.GpExceptions ex)
            {
                return BadRequest(ex.Message);
            }
            finally
            {
                darkManager.CloseConnection();
                darkManager = null;
            }
            
        }

        [HttpPost]
        [AccessDataSession(IdAction = new int[] { 33 })]
        public ActionResult GetListReservacion()
        {
            try
            {
                var Res_Salas = new List<GPSInformation.Responses.Res_Salas>();

                darkManager.Sala.Get().ForEach(sala =>
                {
                    var salaAux = new GPSInformation.Responses.Res_Salas
                    {
                        Id = sala.IdSala,
                        BackgroundColor = sala.ColorFondo,
                        BorderColor = sala.ColorBorder,
                        Events = new List<GPSInformation.Responses.Res_Salarerservacion>()
                    };
                    darkManager.SalaReservacion.GetOpenquery($"where IdSala = {sala.IdSala} and Activa = 1", "order by FechaInicio desc").ForEach(a => {
                        //a.CreadaPor = darkManager.View_empleado.Get(a.IdPersona).NombreCompleto
                        var reserva = new GPSInformation.Responses.Res_Salarerservacion
                        {
                            Id = a.IdSalaReservacion,
                            Start = a.FechaInicio.ToString("yyyy-MM-dd") + "T" + a.HoraIncio.ToString(@"hh\:mm\:ss"),
                            End = a.FechaInicio.ToString("yyyy-MM-dd") + "T" + a.HolaFin.ToString(@"hh\:mm\:ss"),
                            Title = a.Motivo,
                            Description = a.Comentarios,
                            IdSala = a.IdSala,
                            IdPersona = a.IdPersona
                        };
                        salaAux.Events.Add(reserva);
                    });
                    Res_Salas.Add(salaAux);
                });



                //var result = ;
                //result
                return Ok(Res_Salas);
            }
            catch (GPSInformation.Exceptions.GpExceptions ex)
            {
                return BadRequest(ex.Message);
            }
            finally
            {
                darkManager.CloseConnection();
                darkManager = null;
            }
            
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        [AccessDataSession(IdAction = new int[] { 33 })]
        public ActionResult CreateReservacion(SalaReservacion SalaReservacion)
        {
            darkManager.StartTransaction();
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Algunos campos son invalidos");
                }
                SalaReservacion.Comentarios = string.IsNullOrEmpty(SalaReservacion.Comentarios) ? "N/A" : SalaReservacion.Comentarios;
                darkManager.SalaReservacion.Element = SalaReservacion;
                darkManager.SalaReservacion.Element.IdPersona = (int)HttpContext.Session.GetInt32("user_id");
                darkManager.SalaReservacion.Element.Activa = true;
                if (!darkManager.SalaReservacion.Add())
                {
                    //return BadRequest(darkManager.GetLastMessage());
                    throw new GPSInformation.Exceptions.GpExceptions(darkManager.GetLastMessage());
                }

                int Lastid = darkManager.SalaReservacion.GetLastId();

                darkManager.dBConnection.StartProcedure($"SP_Salas", new List<ProcedureModel>
                {
                    new ProcedureModel { Namefield = "IdSala", value = Lastid },
                    new ProcedureModel { Namefield = "Mode", value = "Create" }
                });

                if(darkManager.dBConnection.ErrorCode != 0)
                {
                    throw new GPSInformation.Exceptions.GpExceptions(darkManager.GetLastMessage());
                }
                darkManager.Commit();
                return Ok(Lastid);
            }
            catch (GPSInformation.Exceptions.GpExceptions ex)
            {
                darkManager.RolBack();
                return BadRequest("Error de sistema!");
            }
            finally
            {
                darkManager.CloseConnection();
                darkManager = null;
            }
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        [AccessDataSession(IdAction = new int[] { 33 })]
        public ActionResult EditReservacion( SalaReservacion SalaReservacion)
        {
            darkManager.StartTransaction();
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Algunos campos son invalidos");
                }
                SalaReservacion.Comentarios = string.IsNullOrEmpty(SalaReservacion.Comentarios) ? "N/A" : SalaReservacion.Comentarios;
                darkManager.SalaReservacion.Element = SalaReservacion;
                darkManager.SalaReservacion.Element.IdPersona = (int)HttpContext.Session.GetInt32("user_id");
                darkManager.SalaReservacion.Element.Activa = true;
                if (!darkManager.SalaReservacion.Update())
                {
                    //return BadRequest(darkManager.GetLastMessage());
                    throw new GPSInformation.Exceptions.GpExceptions(darkManager.GetLastMessage());
                }

                int Lastid = darkManager.SalaReservacion.GetLastId();

                darkManager.dBConnection.StartProcedure($"SP_Salas", new List<ProcedureModel>
                {
                    new ProcedureModel { Namefield = "IdSala", value = Lastid },
                    new ProcedureModel { Namefield = "Mode", value = "Edit" }
                });

                if (darkManager.dBConnection.ErrorCode != 0)
                {
                    throw new GPSInformation.Exceptions.GpExceptions(darkManager.GetLastMessage());
                }
                darkManager.Commit();
                return Ok(Lastid);
            }
            catch (GPSInformation.Exceptions.GpExceptions ex)
            {
                darkManager.RolBack();
                return BadRequest("Error de sistema!");
            }
            finally
            {
                darkManager.CloseConnection();
                darkManager = null;
            }
        }
        [HttpGet]
        //[ValidateAntiForgeryToken]
        [AccessDataSession(IdAction = new int[] { 33 })]
        public ActionResult EditSalaReservacion(int id)
        {
            try
            {
                var result = darkManager.SalaReservacion.Get(id);
                if (result == null)
                {
                    return BadRequest("No se encontró ninguna sala");
                }
                if (result.IdPersona != (int)HttpContext.Session.GetInt32("user_id"))
                {
                    return BadRequest("No es tu reservación");
                }
                ViewData["IdPersona"] = (int)HttpContext.Session.GetInt32("user_id");
                ViewData["Salas"] = new SelectList(darkManager.Sala.Get(), "IdSala", "Nombre", result.IdSala);
                return PartialView(result);
            }
            catch (GPSInformation.Exceptions.GpExceptions ex)
            {
                return BadRequest(ex.Message);
            }
            finally
            {
                darkManager.CloseConnection();
                darkManager = null;
            }
        }
        [HttpGet]
        //[ValidateAntiForgeryToken]
        [AccessDataSession(IdAction = new int[] { 33 })]
        public ActionResult Ismine(int id)
        {
            try
            {
                var result = darkManager.SalaReservacion.Get(id);
                if (result == null)
                {
                    return BadRequest("No se encontró ninguna sala");
                }
                if(result.IdPersona != (int)HttpContext.Session.GetInt32("user_id"))
                {
                    return BadRequest("No es tu reservación");
                }
                return Ok(result);
            }
            catch (GPSInformation.Exceptions.GpExceptions ex)
            {
                return BadRequest(ex.Message);
            }
            finally
            {
                darkManager.CloseConnection();
                darkManager = null;
            }
        }

        [HttpGet]
        //[ValidateAntiForgeryToken]
        [AccessDataSession(IdAction = new int[] { 33 })]
        public ActionResult DetailsSalaReservacion(int id)
        {
            try
            {
                var result = darkManager.SalaReservacion.Get(id);
                if (result == null)
                {
                    return BadRequest("No se encontró ninguna sala");
                }
                ViewData["IdPersona"] = (int)HttpContext.Session.GetInt32("user_id");
                ViewData["Sala"] = darkManager.Sala.Get(result.IdSala);
                result.CreadaPor = darkManager.View_empleado.Get(result.IdPersona).NombreCompleto;
                return PartialView(result);
            }
            catch (GPSInformation.Exceptions.GpExceptions ex)
            {
                return BadRequest(ex.Message);
            }
            finally
            {
                darkManager.CloseConnection();
                darkManager = null;
            }
        }


        [HttpGet]
        //[ValidateAntiForgeryToken]
        [AccessDataSession(IdAction = new int[] { 33 })]
        public ActionResult Delete(int id)
        {
            try
            {
                var result = darkManager.SalaReservacion.Get(id);
                if (result == null)
                {
                    return BadRequest("No se encontró ninguna sala");
                }
                if (result.IdPersona != (int)HttpContext.Session.GetInt32("user_id"))
                {
                    return BadRequest("No es tu reservación");
                }
                darkManager.SalaReservacion.Element = result;
                if (!darkManager.SalaReservacion.Delete())
                {
                    return BadRequest("Error al eliminar");
                }
                else
                {
                    return Ok("Se elimino la reservación");
                }
            }
            catch (GPSInformation.Exceptions.GpExceptions ex)
            {
                return BadRequest(ex.Message);
            }
            finally
            {
                darkManager.CloseConnection();
                darkManager = null;
            }
        }
        #endregion








    }
}