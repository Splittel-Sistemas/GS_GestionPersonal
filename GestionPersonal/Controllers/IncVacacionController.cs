using GPSInformation;
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
using System.IO;
using OfficeOpenXml;
using System.Linq;
using GPSInformation.Tools;

namespace GestionPersonal.Controllers
{
    public class IncVacacionController : Controller
    {
        private DarkManager darkManager;
        private V2IncVacacionesCtrl _V2IncVacacionesCtrl;
        private readonly IViewRenderService _viewRenderService;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="viewRenderService"></param>
        public IncVacacionController(IConfiguration configuration, IViewRenderService viewRenderService)
        {
            this._viewRenderService = viewRenderService;
            darkManager = new DarkManager(configuration);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IActionResult ProcessPeriodosAll()
        {
            _V2IncVacacionesCtrl = new V2IncVacacionesCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            _V2IncVacacionesCtrl._darkM.StartTransaction();
            try
            {
                _V2IncVacacionesCtrl.ProcessPeriodos();
                _V2IncVacacionesCtrl._darkM.Commit();
                return Ok("Complete");
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                _V2IncVacacionesCtrl._darkM.RolBack();
                return BadRequest(ex);
            }
            finally
            {
                _V2IncVacacionesCtrl.Terminar();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult ProcessPeriodos(int id)
        {
            _V2IncVacacionesCtrl = new V2IncVacacionesCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            _V2IncVacacionesCtrl._darkM.StartTransaction();
            try
            {
                if(id == 0)
                {
                    return BadRequest("persona no encontrada");
                }
                _V2IncVacacionesCtrl.ProcessPeriodos(id);
                _V2IncVacacionesCtrl._darkM.Commit();
                return Ok("Complete");
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                _V2IncVacacionesCtrl._darkM.RolBack();
                return BadRequest(ex);
            }
            finally
            {
                _V2IncVacacionesCtrl.Terminar();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [AccessView]
        public IActionResult ProcessPeriodosFile()
        {
            _V2IncVacacionesCtrl = new V2IncVacacionesCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            _V2IncVacacionesCtrl._darkM.StartTransaction();
            string Nomina = "";
            string Hoja = "";
            int columna = 0;
            try
            {

                var file = new FileInfo(@"C:\Users\Luis Martinez\Desktop\VACACIONES SPLITTEL 2021.2.xlsx");
                using (var package = new ExcelPackage(file))
                {
                    var periodos = _V2IncVacacionesCtrl._darkM.VacacionesDiasRegla.Get();
                    for (int i = 1; i <= package.Workbook.Worksheets.Count; i++)
                    {
                        var excelWorksheet = package.Workbook.Worksheets[i];
                        var vacacion = new VacionesPeriodo();

                        int rows = excelWorksheet.Dimension.Rows; // 20
                        for (int row = 3; row <= rows; row++)
                        {

                            var NumeroNomina = excelWorksheet.Cells[row, 1].Value;
                            if(NumeroNomina != null)
                            {
                                Nomina = NumeroNomina.ToString().Trim();
                                Hoja = package.Workbook.Worksheets[i].Name;
                                int IdPersona = _V2IncVacacionesCtrl._darkM.dBConnection.GetIntegerValue($"select IdPersona from View_empleado where NumeroNomina = '{NumeroNomina.ToString().Trim()}'");
                                if (IdPersona == 0)
                                {
                                    throw new GPSInformation.Exceptions.GPException
                                    {
                                        Description = $"no se encontro el empleado con Nomina: {NumeroNomina.ToString().Trim()} de la hoja: {package.Workbook.Worksheets[i].Name}"
                                    };
                                }
                                for (int col = 5; col <= 23; col++)
                                {
                                    columna = col;
                                    int noPeriodo = GPSInformation.Tools.Funciones.ValObjInteger(excelWorksheet.Cells[1, col].Value);
                                    var celdaProce = excelWorksheet.Cells[row, col];
                                    if (excelWorksheet.Cells[row, col].Value != null && noPeriodo != 0 && !string.IsNullOrEmpty(excelWorksheet.Cells[row, col].Value.ToString().Trim()))
                                    {
                                        var diaRegla = periodos.Find(a => a.NoAnio == noPeriodo);
                                        if (diaRegla is null)
                                            diaRegla = periodos.Find(a => a.NoAnio == periodos.Max(b => b.NoAnio));


                                        var periodo = _V2IncVacacionesCtrl._darkM.VacionesPeriodo.GetOpenquerys($"where IdPersona = {IdPersona} and NumeroPeriodo = {noPeriodo}");

                                        if(periodo != null)
                                        {
                                            periodo.comentarios = excelWorksheet.Cells[row, col].Comment != null ? excelWorksheet.Cells[row, col].Comment.Text : "N/A";
                                            periodo.DiasDisp = GPSInformation.Tools.Funciones.ValObjDouble(excelWorksheet.Cells[row, col].Value);
                                            periodo.DiasUsados = periodo.DiasAprobadors - GPSInformation.Tools.Funciones.ValObjDouble(excelWorksheet.Cells[row, col].Value);
                                            _V2IncVacacionesCtrl._darkM.VacionesPeriodo.Element = periodo;
                                            _V2IncVacacionesCtrl._darkM.VacionesPeriodo.Update();
                                        }
                                        else
                                        {
                                            var diaRegla1 = periodos.Find(a => a.NoAnio == noPeriodo);
                                            if (diaRegla1 is null)
                                                diaRegla1 = periodos.Find(a => a.NoAnio == periodos.Max(b => b.NoAnio));
                                            periodo = new VacionesPeriodo
                                            {
                                                IdPersona = IdPersona,
                                                NumeroPeriodo = noPeriodo,
                                                Completo = true,
                                                DiasAprobadors = diaRegla1.NoDias,
                                                DiasUsados = 0,
                                            };
                                            periodo.comentarios = excelWorksheet.Cells[row, col].Comment != null ? excelWorksheet.Cells[row, col].Comment.Text : "N/A";
                                            periodo.DiasDisp = GPSInformation.Tools.Funciones.ValObjDouble(excelWorksheet.Cells[row, col].Value);
                                            periodo.DiasUsados = periodo.DiasAprobadors - GPSInformation.Tools.Funciones.ValObjDouble(excelWorksheet.Cells[row, col].Value);
                                            _V2IncVacacionesCtrl._darkM.VacionesPeriodo.Element = periodo;
                                            _V2IncVacacionesCtrl._darkM.VacionesPeriodo.Add();
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                _V2IncVacacionesCtrl._darkM.Commit();
                return Ok("Se han procesado los periodos");
            }
            catch (FormatException ex)
            {
                _V2IncVacacionesCtrl._darkM.RolBack();
                return BadRequest($"{Hoja} - {Nomina} - {columna} - {ex.ToString()}");
            }
            catch (NullReferenceException ex)
            {
                _V2IncVacacionesCtrl._darkM.RolBack();
                return BadRequest($"{Hoja} - {Nomina} - {columna} - {ex.ToString()}");
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                _V2IncVacacionesCtrl._darkM.RolBack();
                return BadRequest($"{Hoja} - {Nomina} - {columna} - {ex.ToString()}");
            }
            finally
            {
                _V2IncVacacionesCtrl.Terminar();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [AccessView]
        public IActionResult Notification(int id)
        {
            _V2IncVacacionesCtrl = new V2IncVacacionesCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            try
            {
                var incidencia = _V2IncVacacionesCtrl.Details(id, true);
                if (incidencia.Estatus == 2 || incidencia.Estatus == 3)
                    incidencia.Link = Url.Action("Autorizar", "IncVacacion", new { id = id, Mode = incidencia.Estatus });
                else
                    incidencia.Link = Url.Action("Details", "IncVacacion", new { id = id });
                return View(incidencia);
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                return ValidateException(ex);
            }
            finally
            {
                _V2IncVacacionesCtrl.Terminar();
            }
        }
        [AccessView]
        public IActionResult CompleteProcess(int id, string status, string link, string link2, string link2Name)
        {
            _V2IncVacacionesCtrl = new V2IncVacacionesCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            try
            {
                var incidencia = _V2IncVacacionesCtrl.Details(id, true);
                incidencia.Link = Url.Action("Details", "IncVacacion", new { id = id });
                ViewData["status"] = status;
                ViewData["link"] = link;
                ViewData["link2"] = link2;
                ViewData["link2Name"] = link2Name;
                return View(incidencia);
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                return ValidateException(ex);
            }
            finally
            {
                _V2IncVacacionesCtrl.Terminar();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="IdPersona"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public ActionResult DowloadFile(int IdPersona, string fileName)
        {
            try
            {
                byte[] fileBytes = System.IO.File.ReadAllBytes($"C:\\Splittel\\GestionPersonal\\{IdPersona}\\IncVacaciones\\{fileName}");
                return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
            }
            catch (GPSInformation.Exceptions.GpExceptions ex)
            {
                return NotFound(ex.Message);
            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="Mode"></param>
        /// <returns></returns>
        [AccessView]
        public IActionResult Autorizar(string id, string Mode)
        {
            _V2IncVacacionesCtrl = new V2IncVacacionesCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            
            try
            {
                
                int _id = Int32.Parse(GPSInformation.Tools.EncryptData.Decrypt(id));
                int _Mode = Int32.Parse(GPSInformation.Tools.EncryptData.Decrypt(Mode));
                var incidencia = _V2IncVacacionesCtrl.Details(_id, true);

                if (_Mode == 10)
                {
                    _V2IncVacacionesCtrl.ValidarAcciones(V2IncValidation.AproveCancelation, _id, incidencia.Estatus);
                }
                else if(_Mode == 2 || _Mode == 3)
                    _V2IncVacacionesCtrl.ValidarAcciones(V2IncValidation.Aprove, _id, _Mode);
                else
                    throw new GPSInformation.Exceptions.GPException { Description = $"Pagina no encontrada", ErrorCode = 0, Category = GPSInformation.Exceptions.TypeException.Error, IdAux = "" };

                ViewData["Details"] = incidencia;
                return View(new InAutorizacion { IdAutorizante = (int)HttpContext.Session.GetInt32("user_id"), IdIncidencia = _id, Modee = _Mode, Autoriza = true });
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                return ValidateException(ex);
            }
            finally
            {
                _V2IncVacacionesCtrl.Terminar();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="inAutorizacion"></param>
        /// <returns></returns>
        [AccessView]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Autorizar(InAutorizacion inAutorizacion)
        {
            _V2IncVacacionesCtrl = new V2IncVacacionesCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            _V2IncVacacionesCtrl._darkM.StartTransaction();
            try
            {
                if (inAutorizacion.Modee == 10)
                {
                    _V2IncVacacionesCtrl.ValidarAcciones(V2IncValidation.AproveCancelation, inAutorizacion.IdIncidencia, inAutorizacion.Modee);
                    _V2IncVacacionesCtrl.CancelSolAutorizar(inAutorizacion);
                }
                else if (inAutorizacion.Modee == 2 || inAutorizacion.Modee == 3)
                {
                    _V2IncVacacionesCtrl.ValidarAcciones(V2IncValidation.Aprove, inAutorizacion.IdIncidencia, inAutorizacion.Modee);
                    _V2IncVacacionesCtrl.Autorizar(inAutorizacion);
                }
                SendNotificationAsync(inAutorizacion.IdIncidencia);
                _V2IncVacacionesCtrl._darkM.Commit();

                string Link = $"{((HttpContext.Request.IsHttps ? "https:" : "http:"))}//{HttpContext.Request.Host}{Url.Action("Autorizar", "IncVacacion", new { id = GPSInformation.Tools.EncryptData.Encrypt(inAutorizacion.IdIncidencia + ""), Mode = GPSInformation.Tools.EncryptData.Encrypt(inAutorizacion.Modee + "") })}";
                string Method = (inAutorizacion.Modee == 3 || inAutorizacion.Modee == 10) ? "SolicitudesN2" : "SolicitudesN1";
                string Link2 = $"{((HttpContext.Request.IsHttps ? "https:" : "http:"))}//{HttpContext.Request.Host}{Url.Action(Method, "Incidencias", new { Tab = "Vacaciones" })}";
                //SolicitudesN2
                //Incidencias
                return RedirectToAction("CompleteProcess", new
                {
                    id = inAutorizacion.IdIncidencia,
                    status = "Autorizada",
                    link = Link,
                    link2 = Link2,
                    link2Name = $"Ir a Solicitudes {((inAutorizacion.Modee == 3 || inAutorizacion.Modee == 10) ? "Solicitudes N2" : "Solicitudes N1")}"
                });
                //return RedirectToAction("Autorizar", new { id = GPSInformation.Tools.EncryptData.Encrypt(inAutorizacion.IdIncidencia + ""), Mode = GPSInformation.Tools.EncryptData.Encrypt(inAutorizacion.Modee + "") });
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                _V2IncVacacionesCtrl._darkM.RolBack();
                return ValidateException(ex, inAutorizacion);
            }
            finally
            {
                _V2IncVacacionesCtrl.Terminar();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="isPartial"></param>
        /// <returns></returns>
        [AccessView]
        public IActionResult Delete(int id, bool isPartial)
        {
            _V2IncVacacionesCtrl = new V2IncVacacionesCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            _V2IncVacacionesCtrl._darkM.StartTransaction();
            try
            {
                int idPersonaa =  _V2IncVacacionesCtrl.GetIdPersona(id);
                _V2IncVacacionesCtrl.ValidarAcciones(V2IncValidation.Delete, id);
                _V2IncVacacionesCtrl.Eliminar(id);
                _V2IncVacacionesCtrl._darkM.Commit();
                return RedirectToAction("MisSolicitudes","Incidencias", new { id = idPersonaa, isPartial = isPartial, Tab="Vacaciones" });
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                _V2IncVacacionesCtrl._darkM.RolBack();
                return ValidateException(ex, null, true);
            }
            finally
            {
                _V2IncVacacionesCtrl.Terminar();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="isPartial"></param>
        /// <returns></returns>
        [AccessView]
        public IActionResult Cancelar(int id, bool isPartial)
        {
            _V2IncVacacionesCtrl = new V2IncVacacionesCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            _V2IncVacacionesCtrl._darkM.StartTransaction();
            try
            {
                _V2IncVacacionesCtrl.ValidarAcciones(V2IncValidation.Cancel, id);
                _V2IncVacacionesCtrl.Cancelar(id);
                SendNotificationAsync(id);
                _V2IncVacacionesCtrl._darkM.Commit();

                if (isPartial)
                    return RedirectToAction("Details", new { id = id, isPartial = isPartial });
                else
                    return RedirectToAction("CompleteProcess", new
                    {
                        id = id,
                        status = "Cancelada",
                        link2 = $"{((HttpContext.Request.IsHttps ? "https:" : "http:"))}//{HttpContext.Request.Host}{Url.Action("MisSolicitudes", "Incidencias", new { Tab = "Vacaciones" })}",
                        link2Name = "Ir a Mis solcitudes"
                    });
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                _V2IncVacacionesCtrl._darkM.RolBack();
                return ValidateException(ex, null, true, isPartial);
            }
            finally
            {
                _V2IncVacacionesCtrl.Terminar();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="isPartial"></param>
        /// <returns></returns>
        [AccessView]
        [HttpPost]
        public IActionResult CancelSolCreate(int IdIncidenciaVacacion, string comentarios, bool isPartial)
        {
            _V2IncVacacionesCtrl = new V2IncVacacionesCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            _V2IncVacacionesCtrl._darkM.StartTransaction();
            try
            {
                _V2IncVacacionesCtrl.CancelSolCreate(IdIncidenciaVacacion, comentarios);
                SendNotificationAsync(IdIncidenciaVacacion);
                _V2IncVacacionesCtrl._darkM.Commit();
                return Ok("se ha registrado tu solicitud  de cancelación");
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                _V2IncVacacionesCtrl._darkM.RolBack();
                return BadRequest(ex.Message);
            }
            finally
            {
                _V2IncVacacionesCtrl.Terminar();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="isPartial"></param>
        /// <returns></returns>
        [AccessView]
        public IActionResult Details(int id, bool isPartial)
        {
            _V2IncVacacionesCtrl = new V2IncVacacionesCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            try
            {
                var incidencia = _V2IncVacacionesCtrl.Details(id, true);
                var accessoAd = _V2IncVacacionesCtrl._Accesos.Find(a => a.IdSubModulo == _V2IncVacacionesCtrl._ALecturaEscrituraAdmin);

                if (isPartial)
                {
                    if(incidencia.CreadoPor == "A" && incidencia.Estatus < 4 && accessoAd.TieneAcceso || incidencia.CreadoPor == "E" && incidencia.Estatus < 4 && accessoAd.TieneAcceso)
                        ViewData["ShowCancel"] = true;
                    else
                        ViewData["ShowCancel"] = false;
                    if (incidencia.CreadoPor == "A" && incidencia.Estatus == 4 && accessoAd.TieneAcceso || incidencia.CreadoPor == "E" && incidencia.Estatus == 4 && accessoAd.TieneAcceso)
                        ViewData["ShowSolCancel"] = true;
                    else
                        ViewData["ShowSolCancel"] = false;
                }
                else
                {
                    if(incidencia.CreadoPor == "E" && incidencia.Estatus < 4 && incidencia.IdPersona == (int)HttpContext.Session.GetInt32("user_id"))
                        ViewData["ShowCancel"] = true;
                    else
                        ViewData["ShowCancel"] = false;

                    if (incidencia.CreadoPor == "E" && incidencia.Estatus == 4 && incidencia.IdPersona == (int)HttpContext.Session.GetInt32("user_id"))
                        ViewData["ShowSolCancel"] = true;
                    else
                        ViewData["ShowSolCancel"] = false;
                }

                ViewData["ShowDelete"] = accessoAd.TieneAcceso ? true : false;
                ViewData["isPartial"] = isPartial;
                if (isPartial) return PartialView(incidencia);
                else return View(incidencia);
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                return ValidateException(ex, null,false, isPartial);
            }
            finally
            {
                _V2IncVacacionesCtrl.Terminar();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="incidencia"></param>
        /// <param name="isPartial"></param>
        /// <returns></returns>
        [AccessView]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(IncidenciaVacacion incidencia, bool isPartial)
        {
            _V2IncVacacionesCtrl = new V2IncVacacionesCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            _V2IncVacacionesCtrl._darkM.StartTransaction();
            try
            {
                ViewData["isPartial"] = isPartial;
                _V2IncVacacionesCtrl.Edit(incidencia);
                ViewData["MessageSuccess"] = "Incidencia guardada";
                _V2IncVacacionesCtrl._darkM.Commit();
                return RedirectToAction("Details", new { id = incidencia.IdIncidenciaVacacion });
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                _V2IncVacacionesCtrl._darkM.RolBack();
                return ValidateException(ex, incidencia, false, isPartial);
            }
            finally
            {
                _V2IncVacacionesCtrl.Terminar();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="isPartial"></param>
        /// <returns></returns>
        [AccessView]
        public IActionResult Edit(int id, bool isPartial)
        {
            _V2IncVacacionesCtrl = new V2IncVacacionesCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            try
            {

                var incidencia = _V2IncVacacionesCtrl.Details(id, true);
                _V2IncVacacionesCtrl.ValidarAcciones(V2IncValidation.Edit, 0, 0, incidencia);

                ViewData["isPartial"] = isPartial;
                if (isPartial) return PartialView(incidencia);
                else return View(incidencia);
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                return ValidateException(ex,null,true, isPartial);
            }
            finally
            {
                _V2IncVacacionesCtrl.Terminar();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idPersona_"></param>
        /// <param name="isPartial"></param>
        /// <returns></returns>
        [AccessView]
        public IActionResult Create(int idPersona_,bool isPartial)
        {
            _V2IncVacacionesCtrl = new V2IncVacacionesCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            ViewData["TiposPermisos"] = new SelectList(darkManager.CatalogoOpcionesValores.GetOpenquery("where IdCatalogoOpciones = 1009", "order by Descripcion"), "IdCatalogoOpcionesValores", "Descripcion");
            ViewData["PagoPermisoPersonal"] = new SelectList(darkManager.CatalogoOpcionesValores.GetOpenquery("where IdCatalogoOpciones = 1010", "order by Descripcion"), "IdCatalogoOpcionesValores", "Descripcion");
            try
            {
                ViewData["isPartial"] = isPartial;
                var nuevo = new IncidenciaVacacion { IdPersona = idPersona_ == 0 ? (int)HttpContext.Session.GetInt32("user_id") : idPersona_, Inicio = System.DateTime.Now, Fin = System.DateTime.Now.AddDays(1) };
                _V2IncVacacionesCtrl.ValidarAcciones(V2IncValidation.Edit, 0, 0, nuevo);
                
                if (isPartial) return PartialView(nuevo);
                else return View(nuevo);
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                return ValidateException(ex,null, false, isPartial);
            }
            finally
            {
                _V2IncVacacionesCtrl.Terminar();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="incidencia"></param>
        /// <param name="isPartial"></param>
        /// <returns></returns>
        [AccessView]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(IncidenciaVacacion incidencia,bool isPartial)
        {
            _V2IncVacacionesCtrl = new V2IncVacacionesCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            _V2IncVacacionesCtrl._darkM.StartTransaction();
            try
            {
                ViewData["isPartial"] = isPartial;
                var _id = _V2IncVacacionesCtrl.Create(incidencia);
                SendNotificationAsync(_id);
                _V2IncVacacionesCtrl._darkM.Commit();
                if (isPartial)
                    return RedirectToAction("Details", new { id = _id, isPartial = isPartial });
                else
                    return RedirectToAction("CompleteProcess", new
                    {
                        id = _id,
                        status = "Creada",
                        link2 = $"{((HttpContext.Request.IsHttps ? "https:" : "http:"))}//{HttpContext.Request.Host}{Url.Action("MisSolicitudes", "Incidencias", new { Tab = "Vacaciones" })}",
                        link2Name = "Ir a Mis solcitudes"
                    });
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                _V2IncVacacionesCtrl._darkM.RolBack();
                return ValidateException(ex, incidencia,false, isPartial);
            }
            finally
            {
                _V2IncVacacionesCtrl.Terminar();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [AccessView]
        public IActionResult MisSolicitudes(int id)
        {
            _V2IncVacacionesCtrl = new V2IncVacacionesCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            try
            {
                return PartialView(new ResV2Inicidencias { Vacaciones = _V2IncVacacionesCtrl.GetByUsuario(id) });
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                return ValidateException(ex);
            }
            finally
            {
                _V2IncVacacionesCtrl.Terminar();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [AccessView]
        public IActionResult SolicitudesN1()
        {
            _V2IncVacacionesCtrl = new V2IncVacacionesCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            try
            {
                return View(new ResV2Inicidencias { Vacaciones = _V2IncVacacionesCtrl.GetByJefeInmediato() });
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                return ValidateException(ex);
            }
            finally
            {
                _V2IncVacacionesCtrl.Terminar();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [AccessView]
        public IActionResult SolicitudesN2()
        {
            _V2IncVacacionesCtrl = new V2IncVacacionesCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            try
            {
                return View(new ResV2Inicidencias { Vacaciones = _V2IncVacacionesCtrl.GetByGPSAdmin() });
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                return ValidateException(ex);
            }
            finally
            {
                _V2IncVacacionesCtrl.Terminar();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="IdPermiso"></param>
        [NonAction]
        private async void SendNotificationAsync(int IdPermiso)
        {
            try
            {
                var incidencia = _V2IncVacacionesCtrl.Details(IdPermiso, true);

                #region Notifiacion
                //-------------------------------------------------------
                //--estatus de acuerdo a la incidencias nueva version
                //------------------------------------------------------ -
                //--1 - Solicitud creada
                //--2 - Jefe inmediado
                //--3 - Gestión personal
                //--4 - Autorizada
                //--5 - Councluida
                //--6 - Cancelada
                //--7 - Rechazada
                //--8 - Eliminada
                //--9 - Expirada
                //--10 - Solicitud de vacaciones

                var Notificaciones = new V2NotificacionCtrl(_V2IncVacacionesCtrl._darkM, _V2IncVacacionesCtrl._IdUsuario, _V2IncVacacionesCtrl._IdPersona);
                if (incidencia.Estatus == 10)
                {
                    Notificaciones.AddToPermiso(
                        $"Solicitud <strong>{incidencia.Folio}</strong> cancelada",
                        $"El colaborador@ <strong>{_V2IncVacacionesCtrl._NombreCompleto}</strong> ha cancelado la solicitud: <strong>{incidencia.Folio}</strong>",
                        Url.Action("Autorizar", "IncVacacion", new { id = incidencia.EncriptId, Mode = GPSInformation.Tools.EncryptData.Encrypt(incidencia.Estatus + "") }),
                        "Link",
                        36);
                }
                if (incidencia.Estatus == 3 && incidencia.CreadoPor == "E")
                {
                    Notificaciones.AddToPermiso(
                        $"Nueva solicitud <strong>{incidencia.Folio}</strong>",
                        $"El colaborador@ <strong>{_V2IncVacacionesCtrl._NombreCompleto}</strong> ha creado una solicitud con folio: <strong>{incidencia.Folio}</strong>",
                        Url.Action("Autorizar", "IncVacacion", new { id = incidencia.EncriptId, Mode = GPSInformation.Tools.EncryptData.Encrypt(incidencia.Estatus + "") }),
                        "Link",
                        36); ;
                }
                #endregion

                //solo se envian notificaciones email a solicitudes creadas por empleados
                if (incidencia.CreadoPor == "E" || incidencia.CreadoPor == "A" && incidencia.Estatus == 10)
                {
                    /*
                     * 
                     *2 Jefe inmediato
                     *3 GPS
                     *10 solicitud de cancelación
                     * 
                     */
                    if (incidencia.Estatus == 2 || incidencia.Estatus == 3 || incidencia.Estatus == 10)
                        incidencia.Link = $"{((HttpContext.Request.IsHttps ? "https:" : "http:"))}//{HttpContext.Request.Host}{Url.Action("Autorizar", "IncVacacion", new { id = incidencia.EncriptId, Mode = GPSInformation.Tools.EncryptData.Encrypt(incidencia.Estatus + "") })}";
                    else
                        incidencia.Link = $"{((HttpContext.Request.IsHttps ? "https:" : "http:"))}//{HttpContext.Request.Host}{Url.Action("Details", "IncVacacion", new { id = incidencia.IdIncidenciaVacacion })}";

                    var result = await _viewRenderService.RenderToStringAsync("IncVacacion/Notification", incidencia);

                    _V2IncVacacionesCtrl.EnviarNotificacion(IdPermiso, result);
                }

                Notificaciones = null;
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {

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
        private IActionResult ValidateException(GPSInformation.Exceptions.GPException ex, object DataModel = null, bool SinVista = false, bool isPartial = false)
        {
            if (ex.Category == GPSInformation.Exceptions.TypeException.Noautorizado)
            {
                ViewData["MessageError"] = ex.Message;
                if (isPartial)
                    return PartialView("../ErrorPages/NoAccess");
                else 
                    return View("../ErrorPages/NoAccess");
            }
            else if (ex.Category == GPSInformation.Exceptions.TypeException.NotFound)
            {
                ViewData["MessageError"] = ex.Message;
                if (isPartial)
                    return PartialView("../Home/NotFoundPage");
                else
                    return View("../Home/NotFoundPage");
            }
            else if (ex.Category == GPSInformation.Exceptions.TypeException.Info)
            {
                if (SinVista)
                {
                    ViewData["MessageError"] = ex.Message;
                    if (isPartial)
                        return PartialView("../ErrorPages/Error");
                    else
                        return View("../ErrorPages/Error");
                }
                else
                {
                    ViewData["MessageError"] = ex.Message;
                    ModelState.AddModelError(string.IsNullOrEmpty(ex.IdAux) ? "" : ex.IdAux, ex.Message);
                    if (isPartial)
                        return PartialView(DataModel);
                    else
                        return View(DataModel);
                }

            }
            else
            {
                ViewData["MessageError"] = ex.Message;
                if (isPartial)
                    return PartialView("../ErrorPages/Error");
                else
                    return View("../ErrorPages/Error");
            }
        }
    }
}
