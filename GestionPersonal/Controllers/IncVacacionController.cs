using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GestionPersonal.Models;
using GPSInformation;
using GPSInformation.Controllers;
using GPSInformation.Exceptions;
using GPSInformation.Models;
using GPSInformation.Models.Produccion;
using GPSInformation.Reportes.ProduccionV3;
using GPSInformation.Responses;
using GPSInformation.Tools;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace GestionPersonal.Controllers
{
    public class IncVacacionController : Controller
    {
        private IncVacacionesCtrl IncVacacionesCtrl;
        private UsuarioCtrl UsuarioCtrl;

        public IncVacacionController(IConfiguration configuration)
        {
            IncVacacionesCtrl = new IncVacacionesCtrl(new DarkManager(configuration));
            UsuarioCtrl = new UsuarioCtrl(IncVacacionesCtrl._Dkma);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Mode"></param>
        /// <returns></returns>
        [AccessView]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Eliminar(int id, string Mode)
        {
            try
            {
                IncVacacionesCtrl.Eliminar(id, (int)HttpContext.Session.GetInt32("user_id"));
                return View(IncVacacionesCtrl.Details(id));
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
                return View(IncVacacionesCtrl.Details(id));
            }
            finally
            {
                IncVacacionesCtrl.Terminar();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [AccessView]
        public IActionResult Eliminar(int id)
        {
            try
            {
                var data = IncVacacionesCtrl.Details(id);
                return View(data);
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                return NotFound(ex.Message);
            }
            finally
            {
                IncVacacionesCtrl.Terminar();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Mode"></param>
        /// <returns></returns>
        [AccessView]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Cancelar(int id, string Mode)
        {
            try
            {
                IncVacacionesCtrl.Cancel(id, (int)HttpContext.Session.GetInt32("user_id"));
                return View(IncVacacionesCtrl.Details(id));
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
                return View(IncVacacionesCtrl.Details(id));
            }
            finally
            {
                IncVacacionesCtrl.Terminar();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [AccessView]
        public IActionResult Cancelar(int id)
        {
            try
            {
                var data = IncVacacionesCtrl.Details(id);
                return View(data);
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                return NotFound(ex.Message);
            }
            finally
            {
                IncVacacionesCtrl.Terminar();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="IncidenciaProcess"></param>
        /// <returns></returns>
        [AccessView]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Autorizar(IncidenciaProcess IncidenciaProcess)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(IncidenciaProcess);
                }
                IncVacacionesCtrl.Autorizar(IncidenciaProcess);
                ViewData["Mode"] = "Procesado";
                return View(IncidenciaProcess);
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                if (ex.IdAux != "" || ex.IdAux != null)
                {
                    ModelState.AddModelError(ex.IdAux, ex.Message);
                }
                else
                {
                    ModelState.AddModelError("", ex.Message);
                }
               
                return View(IncidenciaProcess);
            }
            finally
            {
                IncVacacionesCtrl.Terminar();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Mode"></param>
        /// <returns></returns>
        [AccessView]
        public IActionResult Autorizar(int id, int Mode)
        {
            try
            {
                var estatus = IncVacacionesCtrl._Dkma.IncidenciaProcess.GetOpenquerys($" where IdIncidenciaVacacion = {id} and Nivel = {Mode}");
                if (estatus is null)
                {
                    return NotFound("Incidencia no encontrada");
                }
                if(Mode == 2)
                {
                    //jefe
                    var empleadOIncidencia = IncVacacionesCtrl._Dkma.IncidenciaProcess.GetIntValue($"select IdPersona from IncidenciaVacacion where IdIncidenciaVacacion= {id}");
                    var empeladojefe = IncVacacionesCtrl._Dkma.View_EmpleadoJefe.GetOpenquerys($"where EIdPersona = {empleadOIncidencia} and JIdpersona = {(int)HttpContext.Session.GetInt32("user_id")}");
                    if (empeladojefe is null)
                    {
                        throw new GPException { ErrorCode = 300, Category = TypeException.Info, Description = "Sin autorizacion para autorizar o rechazar", IdAux = "" };
                    }
                }
                else if(Mode == 3)
                {
                    if (!new UsuarioCtrl(IncVacacionesCtrl._Dkma).ValidAction((int)HttpContext.Session.GetInt32("user_id"), 36))
                    {
                        throw new GPException { ErrorCode = 300, Category = TypeException.Info, Description = "Sin autorizacion para autorizar o rechazar GPS", IdAux = "" };
                    }
                }
                else
                {
                    return NotFound("Nivel de aprobacion no valido");
                }
                ViewData["Incidencia"] = IncVacacionesCtrl.Details(id);
                ViewData["Mode"] = "Autorizar";
                return View(estatus);
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                return NotFound(ex.Message);
            }
            finally
            {
                IncVacacionesCtrl.Terminar();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="IncidenciaVacacion"></param>
        /// <returns></returns>
        [AccessView]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(IncidenciaVacacion IncidenciaVacacion)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(IncidenciaVacacion);
                }
                if (IncidenciaVacacion.IdPersona == (int)HttpContext.Session.GetInt32("user_id"))
                {
                     IncVacacionesCtrl.Edit(IncidenciaVacacion, (int)HttpContext.Session.GetInt32("user_id"));
                    //here sent email
                    ViewData["Mode"] = "Updated";
                    return View("Detalle", IncidenciaVacacion);
                }
                else
                {
                    if (!UsuarioCtrl.ValidAction((int)HttpContext.Session.GetInt32("user_id_permiss"), 1054)) return View("../ErrorPages/NoAccess");
                    else
                    {
                        IncVacacionesCtrl.Edit(IncidenciaVacacion, (int)HttpContext.Session.GetInt32("user_id"));
                        //here sent email
                        ViewData["Mode"] = "Updated";
                        return View("Detalle", IncidenciaVacacion);
                    }
                }
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                if (ex.IdAux != "" || ex.IdAux != null)
                {
                    ModelState.AddModelError(ex.IdAux, ex.Message);
                }
                else
                {
                    ModelState.AddModelError("", ex.Message);
                }
                return View(IncidenciaVacacion);
            }
            finally
            {
                IncVacacionesCtrl.Terminar();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [AccessView]
        public IActionResult Editar(int id)
        {
            try
            {
                var data = IncVacacionesCtrl.Details(id);
                if(data is null)
                {
                    return NotFound("Incidencia no encontrada");
                }

                if ((int)HttpContext.Session.GetInt32("user_id") == data.IdPersona || UsuarioCtrl.ValidAction((int)HttpContext.Session.GetInt32("user_id_permiss"), 1054))
                {
                    ViewData["Mode"] = "Edit";
                    return View(data);
                }
                else
                {
                    return View("../ErrorPages/NoAccess");
                }
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                return NotFound(ex.Message);
            }
            finally
            {
                IncVacacionesCtrl.Terminar();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="IncidenciaVacacion"></param>
        /// <returns></returns>
        [AccessView]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Solicitar(IncidenciaVacacion IncidenciaVacacion)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(IncidenciaVacacion);
                }
                if (IncidenciaVacacion.IdPersona == (int)HttpContext.Session.GetInt32("user_id"))
                {
                    var idCreated = IncVacacionesCtrl.Create(IncidenciaVacacion, (int)HttpContext.Session.GetInt32("user_id"));
                    //here sent email
                    var incidenciaReg = IncVacacionesCtrl.Details(idCreated);
                    ViewData["Mode"] = "Created";
                    return View("Detalle", incidenciaReg);
                }
                else
                {
                    if (!UsuarioCtrl.ValidAction((int)HttpContext.Session.GetInt32("user_id_permiss"), 1054)) return View("../ErrorPages/NoAccess");
                    else
                    {
                        var idCreated = IncVacacionesCtrl.Create(IncidenciaVacacion, (int)HttpContext.Session.GetInt32("user_id"));
                        //here sent email
                        var incidenciaReg = IncVacacionesCtrl.Details(idCreated);
                        ViewData["Mode"] = "Created";
                        return View("Detalle", incidenciaReg);
                    }
                }
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                if(ex.IdAux != "" || ex.IdAux != null)
                {
                    ModelState.AddModelError(ex.IdAux, ex.Message);
                }
                else
                {
                    ModelState.AddModelError("", ex.Message);
                }
                return View(IncidenciaVacacion);
            }
            finally
            {
                IncVacacionesCtrl.Terminar();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [AccessView]
        public IActionResult Solicitar(int id)
        {
            try
            {
                if (id == 0 || (int)HttpContext.Session.GetInt32("user_id") == id)
                {
                    return View(new IncidenciaVacacion { Creado = DateTime.Now, IdPersona = (int)HttpContext.Session.GetInt32("user_id") });
                }
                else
                {
                    if (!UsuarioCtrl.ValidAction((int)HttpContext.Session.GetInt32("user_id_permiss"), 1054)) return View("../ErrorPages/NoAccess");
                    else
                    {
                        return View(new IncidenciaVacacion { Creado = DateTime.Now, IdPersona = id });
                    }
                }
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                return NotFound(ex.Message);
            }
            finally
            {
                IncVacacionesCtrl.Terminar();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        [AccessView]
        public IActionResult Solicitudes(int id, int status = 0)
        {
            try
            {
                if(id == 0 || (int)HttpContext.Session.GetInt32("user_id") == id)
                {
                    var data = IncVacacionesCtrl.GetVacacions( status, (int)HttpContext.Session.GetInt32("user_id"));
                    return View(data);
                }
                else
                {
                    if (UsuarioCtrl.ValidAction((int)HttpContext.Session.GetInt32("user_id_permiss"), 1054))
                    {
                        var data = IncVacacionesCtrl.GetVacacions(status, id);
                        return View(data);
                    }
                    else
                    {
                        return View("../ErrorPages/NoAccess");
                    }
                }
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                return NotFound(ex.Message);
            }
            finally
            {
                IncVacacionesCtrl.Terminar();
            }
        }
    }
}
