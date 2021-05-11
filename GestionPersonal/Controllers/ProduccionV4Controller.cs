﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GestionPersonal.Models;
using GPSInformation;
using GPSInformation.Controllers;
using GPSInformation.Models.Produccion;
using GPSInformation.Reportes.ProduccionV3;
using GPSInformation.Tools;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace GestionPersonal.Controllers
{
    public class ProduccionV4Controller : Controller
    {
        private ProduccionV4Ctrl ProduccionV4Ctrl;

        public ProduccionV4Controller(IConfiguration configuration)
        {
            ProduccionV4Ctrl = new ProduccionV4Ctrl(new DarkManager(configuration));
        }

        #region Incidencias
        [HttpPost]
        public IActionResult RegisterIncidenciaNew(ProdIncidencia prodIncidencia)
        {
            try
            {
                ProduccionV4Ctrl.AddIncidence(prodIncidencia, HttpContext.Session.GetString("user_fullname"));
                return Ok("Cambios guardados");
            }
            catch (GPSInformation.Exceptions.GpExceptions ex)
            {
                ProduccionV4Ctrl.Terminar();
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult DeleteInciNew(int Folio)
        {
            try
            {
                ProduccionV4Ctrl.DeleteInidencia2(Folio);
                return Ok("Cambios guardados");
            }
            catch (GPSInformation.Exceptions.GpExceptions ex)
            {
                ProduccionV4Ctrl.Terminar();
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult SaveDivHoras(int IdCorte, double Txt, double Score)
        {
            try
            {
                ProduccionV4Ctrl.SaveDivHoras(IdCorte, Txt, Score);
                return Ok("Cambios guardados");
            }
            catch (GPSInformation.Exceptions.GpExceptions ex)
            {
                ProduccionV4Ctrl.Terminar();
                return BadRequest(ex.Message);
            }
        }
        //[AccessDataSession]
        [HttpPost]
        public IActionResult DetailsInciNew(int Folio)
        {
            try
            {
                var data = ProduccionV4Ctrl.GetIncidencia(Folio);
                return Ok(data);
            }
            catch (GPSInformation.Exceptions.GpExceptions ex)
            {
                ProduccionV4Ctrl.Terminar();
                return BadRequest(ex.Message);
            }
        }
        #region old
        [HttpPost]
        public IActionResult DeleteInci(int IdGrupoProdIncidencia, int IdPersona)
        {
            try
            {
                ProduccionV4Ctrl.DeleteInci(IdGrupoProdIncidencia, IdPersona);
                return Ok("Cambios guardados");
            }
            catch (GPSInformation.Exceptions.GpExceptions ex)
            {
                ProduccionV4Ctrl.Terminar();
                return BadRequest(ex.Message);
            }
        }
        //[AccessDataSession]
        [HttpPost]
        public IActionResult DetailsInci(int IdGrupoProdIncidencia, int IdPersona)
        {
            try
            {
                var data = ProduccionV4Ctrl.DetailsInci(IdGrupoProdIncidencia, IdPersona);
                return Ok(data);
            }
            catch (GPSInformation.Exceptions.GpExceptions ex)
            {
                ProduccionV4Ctrl.Terminar();
                return BadRequest(ex.Message);
            }
        }
        //[AccessDataSession]
        [HttpPost]
        public IActionResult RegisterIncidencia(GrupoProdIncidencia GrupoProdIncidencia)
        {
            try
            {
                ProduccionV4Ctrl.RegisterIncidenciaAsync(GrupoProdIncidencia);
                return Ok("Cambios guardados");
            }
            catch (GPSInformation.Exceptions.GpExceptions ex)
            {
                ProduccionV4Ctrl.Terminar();
                return BadRequest(ex.Message);
            }
        }
        #endregion

        /// <summary>
        /// Descargar
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public ActionResult Dowload(string fileName)
        {
            try
            {
                byte[] fileBytes = ProduccionV4Ctrl.GetFileInc(fileName);
                return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
            }
            catch (GPSInformation.Exceptions.GpExceptions ex)
            {
                return NotFound(ex.Message);
            }

        }
        #endregion

        #region Arreglos eventos
        //[AccessDataSession]


        //[AccessDataSession]
        [HttpPost]
        public IActionResult AddArregloEvento(int IdEvent, int IdPersona, DateTime Fecha, string Comentarios)
        {
            try
            {
                if (string.IsNullOrEmpty(Comentarios))
                {
                    return BadRequest("Por favor llena todos los campos");
                }
                ProduccionV4Ctrl.AddArreglo(IdEvent, IdPersona, Fecha, Comentarios);
                return Ok("Datos cambiados");
            }
            catch (GPSInformation.Exceptions.GpExceptions ex)
            {
                ProduccionV4Ctrl.Terminar();
                return BadRequest(ex.Message);
            }
        }
        //[AccessDataSession]
        [HttpPost]
        public IActionResult DeleteArreglo(int IdEvent, int IdPersona)
        {
            try
            {
                ProduccionV4Ctrl.DeleteArreglo(IdEvent, IdPersona);
                return Ok("Datos cambiados");
            }
            catch (GPSInformation.Exceptions.GpExceptions ex)
            {
                ProduccionV4Ctrl.Terminar();
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region Reporte
        [AccessMultipleView(IdAction = new int[] { 1047 })]
        public IActionResult Index(DateTime Inicio)
        {
            try
            {
                var Permisos = ProduccionV4Ctrl.VerPermisos((int)HttpContext.Session.GetInt32("user_id"));



                if (Permisos.Count(a => a.Autorization == true) <= 0)
                {
                    return RedirectToAction("MiReporte");
                }
                ViewData["Permisos"] = Permisos;
                if (Inicio == DateTime.Parse("0001-01-01 00:00:00"))
                {
                    Inicio = Funciones.GetFirtsDatWeek(DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd 05:45:00")));
                }
                else
                {
                    Inicio = Funciones.GetFirtsDatWeek(Inicio);
                }
                if (Inicio < Funciones.GetFirtsDatWeek(DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd 05:45:00"))))
                {
                    if (Permisos.Find(a => a.IdSubModulo == 1052).Autorization == false && Permisos.Find(a => a.IdSubModulo == 1048).Autorization == false)
                    {
                        Inicio = Funciones.GetFirtsDatWeek(DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd 05:45:00")));
                    }
                }

                var result = ProduccionV4Ctrl.ProcesarEmpleados(Inicio);
                return View(result);
            }
            catch (GPSInformation.Exceptions.GpExceptions ex)
            {
                ProduccionV4Ctrl.Terminar();
                return NotFound(ex.Message);
            }
        }
        [AccessMultipleView(IdAction = new int[] { 1047 })]
        public IActionResult Details(int IdPersona, DateTime Inicio)
        {
            try
            {
                var Permisos = ProduccionV4Ctrl.VerPermisos((int)HttpContext.Session.GetInt32("user_id"));
                if (Inicio == DateTime.Parse("0001-01-01 00:00:00"))
                {
                    Inicio = Funciones.GetFirtsDatWeek(DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd 05:45:00")));
                }
                else
                {
                    Inicio = Funciones.GetFirtsDatWeek(Inicio);
                }
                if (DateTime.Now < Inicio)
                {
                    if (Permisos.Find(a => a.IdSubModulo == 1052).Autorization == false && Permisos.Find(a => a.IdSubModulo == 1048).Autorization == false)
                    {
                        Inicio = Funciones.GetFirtsDatWeek(DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd 05:45:00")));
                    }
                }

                ViewData["Permisos"] = Permisos;
                ViewData["Autor"] = HttpContext.Session.GetString("user_fullname");
                var result = ProduccionV4Ctrl.ProcesarEmpleado(new GPSInformation.Views.View_empleadoEnsamble(), IdPersona, Inicio);
                ViewData["PagoPermisoPersonal"] = new SelectList(ProduccionV4Ctrl.darkManager.CatalogoOpcionesValores.Get("" + 1010, "IdCatalogoOpciones").OrderBy(a => a.Descripcion).ToList(), "IdCatalogoOpcionesValores", "Descripcion");
                return View(result);
            }
            catch (GPSInformation.Exceptions.GpExceptions ex)
            {
                ProduccionV4Ctrl.Terminar();
                return NotFound(ex.Message);
            }
        }
        [AccessMultipleView(IdAction = new int[] { 1047 })]
        public IActionResult Details2(int IdPersona, DateTime Inicio)
        {
            try
            {
                var Permisos = ProduccionV4Ctrl.VerPermisos((int)HttpContext.Session.GetInt32("user_id"));
                if (Inicio == DateTime.Parse("0001-01-01 00:00:00"))
                {
                    Inicio = Funciones.GetFirtsDatWeek(DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd 05:45:00")));
                }
                else
                {
                    Inicio = Funciones.GetFirtsDatWeek(Inicio);
                }
                if (DateTime.Now < Inicio)
                {
                    if (Permisos.Find(a => a.IdSubModulo == 1052).Autorization == false && Permisos.Find(a => a.IdSubModulo == 1048).Autorization == false)
                    {
                        Inicio = Funciones.GetFirtsDatWeek(DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd 05:45:00")));
                    }
                }

                ViewData["Permisos"] = Permisos;
                ViewData["Autor"] = HttpContext.Session.GetString("user_fullname");
                var result = ProduccionV4Ctrl.ProcesarEmpleado(new GPSInformation.Views.View_empleadoEnsamble(), IdPersona, Inicio);
                ViewData["PagoPermisoPersonal"] = new SelectList(ProduccionV4Ctrl.darkManager.CatalogoOpcionesValores.Get("" + 1010, "IdCatalogoOpciones").OrderBy(a => a.Descripcion).ToList(), "IdCatalogoOpcionesValores", "Descripcion");
                return View(result);
            }
            catch (GPSInformation.Exceptions.GpExceptions ex)
            {
                ProduccionV4Ctrl.Terminar();
                return NotFound(ex.Message);
            }
        }
        [AccessView]
        public IActionResult MiReporte(DateTime Inicio)
        {
            try
            {
                var Permisos = ProduccionV4Ctrl.VerPermisos((int)HttpContext.Session.GetInt32("user_id"));
                int IdPersona = (int)HttpContext.Session.GetInt32("user_id");
                if (Inicio == DateTime.Parse("0001-01-01 00:00:00"))
                {
                    Inicio = Funciones.GetFirtsDatWeek(DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd 05:45:00")));
                }
                else
                {
                    Inicio = Funciones.GetFirtsDatWeek(Inicio);
                }
                var result = ProduccionV4Ctrl.ProcesarEmpleado(new GPSInformation.Views.View_empleadoEnsamble(), IdPersona, Inicio);
                ViewData["Permisos"] = Permisos;
                ViewData["PagoPermisoPersonal"] = new SelectList(ProduccionV4Ctrl.darkManager.CatalogoOpcionesValores.Get("" + 1010, "IdCatalogoOpciones").OrderBy(a => a.Descripcion).ToList(), "IdCatalogoOpcionesValores", "Descripcion");
                return View(result);
            }
            catch (GPSInformation.Exceptions.GpExceptions ex)
            {
                ProduccionV4Ctrl.Terminar();
                return NotFound(ex.Message);
            }
        }

        #endregion

        #region Cambios de turno
        [HttpPost]
        public IActionResult CreateCorte(int IdPersona, DateTime Corte)
        {
            try
            {
                ProduccionV4Ctrl.CreateCorte(IdPersona, Corte);
                return Ok("Datos cambiados");
            }
            catch (GPSInformation.Exceptions.GpExceptions ex)
            {
                ProduccionV4Ctrl.Terminar();
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult DeleteCambio(int IdPersona, int IdGrupoCambios)
        {
            try
            {
                ProduccionV4Ctrl.DeleteCambio(IdGrupoCambios, IdPersona);
                return Ok("Datos cambiados");
            }
            catch (GPSInformation.Exceptions.GpExceptions ex)
            {
                ProduccionV4Ctrl.Terminar();
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult CreateCambio([FromBody] GrupoCambios createCambio)
        {
            try
            {
                ProduccionV4Ctrl.AddCambio(createCambio);
                return Ok("Datos cambiados");
            }
            catch (GPSInformation.Exceptions.GpExceptions ex)
            {
                ProduccionV4Ctrl.Terminar();
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region Permisos
        [HttpPost]
        public IActionResult ChangePermisos([FromBody] List<PermisosBloq> Permisos)
        {
            try
            {
                ProduccionV4Ctrl.ChangePermisos(Permisos);
                return Ok("Datos cambiados");
            }
            catch (GPSInformation.Exceptions.GpExceptions ex)
            {
                ProduccionV4Ctrl.Terminar();
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult VerPermisos(int IdPersona_)
        {
            try
            {
                var data = ProduccionV4Ctrl.VerPermisos(IdPersona_);
                return Ok(data);
            }
            catch (GPSInformation.Exceptions.GpExceptions ex)
            {
                ProduccionV4Ctrl.Terminar();
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region reporte Excel
        public ActionResult ProcesLoad()
        {
            ProduccionV4Ctrl.darkManager.StartTransaction();
            try
            {
                var lis = new List<GrupoCorte>();
                var file = new FileInfo(@"C:\Splittel\GestionPersonal\Produccion\carga.xlsx");
                using (var package = new ExcelPackage(file))
                {
                    var excelWorksheet = package.Workbook.Worksheets["hoja1"];
                    //int fila = 5;
                    int rows = excelWorksheet.Dimension.Rows; // 20
                    int columns = excelWorksheet.Dimension.Columns; // 7

                    for (int fila = 5; fila < 61; fila++)
                    {
                        for (int col = 4; col < 12; col++)
                        {
                            int IdPersona = Int32.Parse(excelWorksheet.Cells[fila, 2].Value.ToString());
                            string comentarios = $"Carga inicial de: {excelWorksheet.Cells[4, col].Value.ToString()}";
                            int IdGrupo = Int32.Parse(excelWorksheet.Cells[fila, 3].Value.ToString());
                            var scroe = excelWorksheet.Cells[fila, col].Value;
                            int dias = Int32.Parse(excelWorksheet.Cells[2, col].Value.ToString());
                            var corte = new GrupoCorte
                            {
                                IdPersona = IdPersona,
                                EsFinal = true,
                                EsInicial = true,
                                Extras = 0,
                                HrsExtra = 0,
                                Comentarios = comentarios,
                                HrsGrupo = ProduccionV4Ctrl.darkManager.GrupoCorte.GetIntValue($"select sum(Horas) from GrupoHorario where EsCruce = 0 and descanso = 0 and IdGrupo = {IdGrupo}"),
                                HrsNomina = 0,
                                HrsScoreGen = scroe is null ? 0 : Convert.ToDouble(scroe)*-1,
                                HrsReal = 0,
                                HrsTxT = 0,
                                IdGrupoCorte = 0,
                                Fecha = DateTime.Parse("2021-04-26").AddDays(dias * -1),
                                Score = 0
                            };
                            ProduccionV4Ctrl.darkManager.GrupoCorte.Element = corte;
                            if (!ProduccionV4Ctrl.darkManager.GrupoCorte.Add())
                            {
                                throw new GPSInformation.Exceptions.GpExceptions("Error al guardar: " + excelWorksheet.Cells[fila, 2].Value.ToString());
                            }
                            lis.Add(corte);
                        }

                    }
                    package.Dispose();
                    
                }
                ProduccionV4Ctrl.darkManager.Commit();
                return Ok(lis);
            }
            catch (Exception)
            {
                ProduccionV4Ctrl.darkManager.RolBack();
                throw;
            }
            

        }
        [HttpGet]
        public ActionResult DescargarReporte(DateTime Inicio)
        {
            var stream = new MemoryStream();

            using (var package = new ExcelPackage(stream))
            {
                package.Workbook.Worksheets.Add("Worksheet1");
                var excelWorksheet = package.Workbook.Worksheets["Worksheet1"];

                var respuesta = ProduccionV4Ctrl.ProcesarEmpleados(Inicio);



                #region Agregar columnas
                excelWorksheet.Cells[1, 1].Value = "Inicio";
                excelWorksheet.Cells[2, 1].Value = "Fin";
                excelWorksheet.Cells[1, 2].Value = respuesta.Inicio.ToString("F");
                excelWorksheet.Cells[2, 2].Value = respuesta.Fin.ToString("F");

                excelWorksheet.Cells[5, 1].Value = "Nomina";
                excelWorksheet.Cells[5, 2].Value = "Empleado";
                excelWorksheet.Cells[5, 3].Value = "Puesto";
                excelWorksheet.Cells[5, 4].Value = "Hrs.Semana";
                excelWorksheet.Cells[5, 5].Value = "Hrs.Trabajadas";
                excelWorksheet.Cells[5, 6].Value = "Hrs.Justificadas";
                excelWorksheet.Cells[5, 7].Value = "Horas Score";
                excelWorksheet.Cells[5, 8].Value = "Estatus";

                for (int i = 1; i < 9; i++)
                {
                    Color myColor = System.Drawing.ColorTranslator.FromHtml("#ffab40");
                    excelWorksheet.Cells[5, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    excelWorksheet.Cells[5, i].Style.Fill.BackgroundColor.SetColor(myColor);
                }

                #endregion

                int Fila = 6;
                respuesta.EmpleadoProds.OrderBy(a => a.NombreCompleto).ToList().ForEach(emp =>
                {
                    excelWorksheet.Cells[Fila, 1].Value = emp.NumeroNomina;
                    excelWorksheet.Cells[Fila, 2].Value = emp.NombreCompleto;
                    excelWorksheet.Cells[Fila, 3].Value = emp.PuestoNombre;
                    excelWorksheet.Cells[Fila, 4].Value = string.Format("{0:#.##}", emp.HorasMeta);
                    excelWorksheet.Cells[Fila, 5].Value = string.Format("{0:#.##}", emp.HorasReal);
                    excelWorksheet.Cells[Fila, 6].Value = string.Format("{0:#.##}", emp.HorasAprobadas);
                    excelWorksheet.Cells[Fila, 7].Value = string.Format("{0:#.##}", emp.HorasScore);






                    if (emp.HorasScore > 0)
                    {
                        excelWorksheet.Cells[Fila, 8].Value = "Debe horas";
                        Color myColor = System.Drawing.ColorTranslator.FromHtml("#ff616f");
                        excelWorksheet.Cells[Fila, 8].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        excelWorksheet.Cells[Fila, 8].Style.Fill.BackgroundColor.SetColor(myColor);
                    }
                    else
                    {
                        excelWorksheet.Cells[Fila, 8].Value = "Horas a empleado";
                        Color myColor = System.Drawing.ColorTranslator.FromHtml("#66ffa6");
                        excelWorksheet.Cells[Fila, 8].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        excelWorksheet.Cells[Fila, 8].Style.Fill.BackgroundColor.SetColor(myColor);
                    }
                    Fila++;


                });

                excelWorksheet.Cells.AutoFitColumns();
                package.Save();
            }

            stream.Position = 0;
            string excelName = $"Rep_ProduccionHrs_{Inicio.ToString("yyyyMMddHHmmssfff")}.xlsx";
            // above I define the name of the file using the current datetime.
            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelName); // this will be the actual export.
        }
        [HttpGet]
        public ActionResult DescargarReporte2(DateTime Inicio)
        {
            var stream = new MemoryStream();

            using (var package = new ExcelPackage(stream))
            {
                package.Workbook.Worksheets.Add("Worksheet1");
                var excelWorksheet = package.Workbook.Worksheets["Worksheet1"];

                var respuesta = ProduccionV4Ctrl.ProcesarEmpleados(Inicio);



                #region Agregar columnas
                excelWorksheet.Cells[1, 1].Value = "Inicio";
                excelWorksheet.Cells[2, 1].Value = "Fin";
                excelWorksheet.Cells[1, 2].Value = respuesta.Inicio.ToString("F");
                excelWorksheet.Cells[2, 2].Value = respuesta.Fin.ToString("F");

                excelWorksheet.Cells[5, 1].Value = "Nomina";
                excelWorksheet.Cells[5, 2].Value = "Empleado";
                excelWorksheet.Cells[5, 3].Value = "Puesto";
                excelWorksheet.Cells[5, 4].Value = "Hrs.Grupo";
                excelWorksheet.Cells[5, 5].Value = "Hrs.Reales";
                excelWorksheet.Cells[5, 6].Value = "Hrs.Nomina";
                excelWorksheet.Cells[5, 7].Value = "Hrs.Extras";
                excelWorksheet.Cells[5, 8].Value = "Hrs.TxT";
                excelWorksheet.Cells[5, 9].Value = "Hrs.Score general";

                for (int i = 1; i < 10; i++)
                {
                    Color myColor = System.Drawing.ColorTranslator.FromHtml("#ffab40");
                    excelWorksheet.Cells[5, i].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    excelWorksheet.Cells[5, i].Style.Fill.BackgroundColor.SetColor(myColor);
                }

                #endregion

                int Fila = 6;
                respuesta.EmpleadoProds.OrderBy(a => a.NombreCompleto).ToList().ForEach(emp =>
                {
                    excelWorksheet.Cells[Fila, 1].Value = emp.NumeroNomina;
                    excelWorksheet.Cells[Fila, 2].Value = emp.NombreCompleto;
                    excelWorksheet.Cells[Fila, 3].Value = emp.PuestoNombre;
                    excelWorksheet.Cells[Fila, 4].Value = string.Format("{0:#.##}", emp.GrupoCorte.HrsGrupo);
                    excelWorksheet.Cells[Fila, 5].Value = string.Format("{0:#.##}", emp.GrupoCorte.HrsReal);
                    excelWorksheet.Cells[Fila, 6].Value = string.Format("{0:#.##}", emp.GrupoCorte.HrsNomina);
                    excelWorksheet.Cells[Fila, 7].Value = string.Format("{0:#.##}", (emp.GrupoCorte.HrsExtra - emp.GrupoCorte.Extras - emp.GrupoCorte.Score));
                    excelWorksheet.Cells[Fila, 8].Value = string.Format("{0:#.##}", emp.HrsTxt);
                    excelWorksheet.Cells[Fila, 9].Value = string.Format("{0:#.##}", emp.HrsScoreGen);


                    if (emp.HrsTxt > 0)
                    {
                        Color myColor = System.Drawing.ColorTranslator.FromHtml("#ff616f");
                        excelWorksheet.Cells[Fila, 8].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        excelWorksheet.Cells[Fila, 8].Style.Fill.BackgroundColor.SetColor(myColor);
                    }
                    else if (emp.HrsTxt < 0)
                    {
                        Color myColor = System.Drawing.ColorTranslator.FromHtml("#66ffa6");
                        excelWorksheet.Cells[Fila, 8].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        excelWorksheet.Cells[Fila, 8].Style.Fill.BackgroundColor.SetColor(myColor);
                    }
                    else
                    {

                    }
                    Fila++;
                });

                excelWorksheet.Cells.AutoFitColumns();
                package.Save();
            }

            stream.Position = 0;
            string excelName = $"Rep_ProduccionHrs_{Inicio.ToString("yyyyMMddHHmmssfff")}.xlsx";
            // above I define the name of the file using the current datetime.
            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelName); // this will be the actual export.
        }
        #endregion
    }
}