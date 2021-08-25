using System;
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
        [AccessJson]
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
        [AccessJson]
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
        [AccessJson]
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
        //[AccessJson]
        [HttpPost]
        [AccessJson]
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
        //[AccessJson]
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
        //[AccessJson]
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
        //[AccessJson]


        [AccessJson]
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
        [AccessJson]
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
                    Inicio = Funciones.GetFirtsDatWeek(DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd 03:00:00")));
                }
                else
                {
                    Inicio = Funciones.GetFirtsDatWeek(Inicio);
                }
                if (Inicio < Funciones.GetFirtsDatWeek(DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd 03:00:00"))))
                {
                    if (Permisos.Find(a => a.IdSubModulo == 1052).Autorization == false && Permisos.Find(a => a.IdSubModulo == 1048).Autorization == false)
                    {
                        Inicio = Funciones.GetFirtsDatWeek(DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd 03:00:00")));
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
                    Inicio = Funciones.GetFirtsDatWeek(DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd 03:00:00")));
                }
                else
                {
                    Inicio = Funciones.GetFirtsDatWeek(Inicio);
                }
                if (DateTime.Now < Inicio)
                {
                    if (Permisos.Find(a => a.IdSubModulo == 1052).Autorization == false && Permisos.Find(a => a.IdSubModulo == 1048).Autorization == false)
                    {
                        Inicio = Funciones.GetFirtsDatWeek(DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd 03:00:00")));
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
                    Inicio = Funciones.GetFirtsDatWeek(DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd 03:00:00")));
                }
                else
                {
                    Inicio = Funciones.GetFirtsDatWeek(Inicio);
                }
                if (DateTime.Now < Inicio)
                {
                    if (Permisos.Find(a => a.IdSubModulo == 1052).Autorization == false && Permisos.Find(a => a.IdSubModulo == 1048).Autorization == false)
                    {
                        Inicio = Funciones.GetFirtsDatWeek(DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd 03:00:00")));
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
                    Inicio = Funciones.GetFirtsDatWeek(DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd 03:00:00")));
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
        [AccessJson]
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
        [AccessJson]
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
        [AccessJson]
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
        [AccessJson]
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
                var lis = new List<GrupoCambios>();
                var file = new FileInfo(@"C:\Splittel\GestionPersonal\Produccion\carga.xlsx");
                using (var package = new ExcelPackage(file))
                {
                    var excelWorksheet = package.Workbook.Worksheets["hoja1"];
                    //int fila = 5;
                    int rows = excelWorksheet.Dimension.Rows; // 20
                    int columns = excelWorksheet.Dimension.Columns; // 7
                    int numeroCols = Int32.Parse(excelWorksheet.Cells[1, 1].Value.ToString());
                    for (int fila = 5; fila <= rows; fila++)
                    {
                        if (!string.IsNullOrEmpty(Funciones.ValObjString(excelWorksheet.Cells[fila, 1].Value)))
                        {
                            for (int col = 4; col < numeroCols; col++)
                            {
                                int IdPersona = Int32.Parse(excelWorksheet.Cells[fila, 2].Value.ToString());
                                string comentarios = $"Carga inicial de: {excelWorksheet.Cells[4, col].Value.ToString()}";
                                int IdGrupo = Int32.Parse(excelWorksheet.Cells[fila, 3].Value.ToString());
                                var scroe = excelWorksheet.Cells[fila, col].Value;
                                int dias = Int32.Parse(excelWorksheet.Cells[2, col].Value.ToString());
                                
                                var fecha = excelWorksheet.Cells[3, col].Value.ToString();
                                var data = new GrupoCambios
                                {
                                    IdGrupo = IdGrupo,
                                    IdPersona = IdPersona, 
                                    Comentarios = comentarios,
                                    Creado = DateTime.Parse(fecha).AddDays(dias * -1),
                                    Fecha = DateTime.Parse(fecha).AddDays(dias * -1),
                                    Modificado = DateTime.Now,
                                    FechaInicio = DateTime.Parse(fecha),
                                    
                                };
                                ProduccionV4Ctrl.darkManager.GrupoCambios.Element = data;
                                if (!ProduccionV4Ctrl.darkManager.GrupoCambios.Add())
                                {
                                    throw new GPSInformation.Exceptions.GpExceptions("Error al guardar: " + excelWorksheet.Cells[fila, 2].Value.ToString());
                                }
                                lis.Add(data);


                                //var corte = ProduccionV4Ctrl.darkManager.GrupoCorte.GetOpenquerys($"where IdPersona = {IdPersona} and Fecha = '{DateTime.Parse("2021-04-26").AddDays(dias * -1).ToString("yyyy-MM-dd")}'");
                                //if (corte != null)
                                //{
                                //    corte.HrsGrupo = ProduccionV4Ctrl.darkManager.GrupoCorte.GetIntValue($"select sum(Horas) from GrupoHorario where EsCruce = 0 and descanso = 0 and IdGrupo = {IdGrupo}");
                                //    ProduccionV4Ctrl.darkManager.GrupoCorte.Element = corte;
                                //    if (!ProduccionV4Ctrl.darkManager.GrupoCorte.Update())
                                //    {
                                //        throw new GPSInformation.Exceptions.GpExceptions("Error al guardar: " + excelWorksheet.Cells[fila, 2].Value.ToString());
                                //    }
                                //}


                                var corte = new GrupoCorte
                                {
                                    IdPersona = IdPersona,
                                    EsFinal = true,
                                    EsInicial = true,
                                    Extras = 0,
                                    HrsExtra = 0,
                                    Comentarios = comentarios,
                                    HrsGrupo = (double)ProduccionV4Ctrl.darkManager.GrupoCorte.GetDoubleValue($"select sum(Horas) from GrupoHorario where EsCruce = 0 and descanso = 0 and IdGrupo = {IdGrupo}"),
                                    HrsNomina = 0,
                                    HrsScoreGen = scroe is null ? 0 : Convert.ToDouble(scroe) * -1,
                                    HrsReal = 0,
                                    HrsTxT = 0,
                                    IdGrupoCorte = 0,
                                    Fecha = DateTime.Parse(fecha).AddDays(dias * -1),
                                    Score = 0
                                };
                                ProduccionV4Ctrl.darkManager.GrupoCorte.Element = corte;
                                if (!ProduccionV4Ctrl.darkManager.GrupoCorte.Add())
                                {
                                    throw new GPSInformation.Exceptions.GpExceptions("Error al guardar: " + excelWorksheet.Cells[fila, 2].Value.ToString());
                                }
                                //lis.Add(corte);

                            }
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

                AddRange("A3:O3", "Analisis semanal", excelWorksheet);
                AddRange("P3:Q3", "Analisis general", excelWorksheet);
                excelWorksheet.Cells["A3:O3"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                excelWorksheet.Cells["P3:Q3"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                //AddRange("A4:G4", "", excelWorksheet);
                

                AddRange("A4:A5", "Nomina", excelWorksheet);
                AddRange("B4:B5", "Empleado", excelWorksheet);
                AddRange("C4:C5", "Puesto", excelWorksheet);
                AddRange("D4:D5", "Hrs.Objetivo", excelWorksheet);
                AddRange("E4:E5", "Hrs.Reales", excelWorksheet);
                AddRange("F4:F5", "Hrs.Nomina", excelWorksheet);
                AddRange("G4:G5", "Hrs.Extras", excelWorksheet);
                AddRange("H4:I4", "Faltas", excelWorksheet);
                AddRange("J4:K4", "Vacaciones", excelWorksheet);
                AddRange("L4:M4", "Incapacidad", excelWorksheet);
                AddRange("N4:N5", "Hrs.TxT", excelWorksheet);
                AddRange("O4:O5", "Hrs.Score Genral", excelWorksheet);
                AddRange("P4:P5", "Hrs.TxT", excelWorksheet);
                AddRange("Q4:Q5", "Hrs.Score Genral", excelWorksheet);
                excelWorksheet.Cells[5, 8].Value = "Hrs.Falta";//H
                excelWorksheet.Cells[5, 9].Value = "Eq.Dias";//I

                excelWorksheet.Cells[5, 10].Value = "Hrs.Vacaciones";//J
                excelWorksheet.Cells[5, 11].Value = "Eq.Dias";//K

                excelWorksheet.Cells[5, 12].Value = "Hrs.Vacaciones";//L
                excelWorksheet.Cells[5, 13].Value = "Eq.Dias";//M
                excelWorksheet.Cells["D4:M5"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                for (int i = 1; i < 14; i++)
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

                    excelWorksheet.Cells[Fila, 4].Value = emp.GrupoCorte.HrsGrupo;
                    excelWorksheet.Cells[Fila, 4].Style.Numberformat.Format = "#,#0.0";

                    excelWorksheet.Cells[Fila, 5].Value = emp.GrupoCorte.HrsReal;
                    excelWorksheet.Cells[Fila, 5].Style.Numberformat.Format = "#,#0.0";

                    excelWorksheet.Cells[Fila, 6].Value = emp.GrupoCorte.HrsNomina;
                    excelWorksheet.Cells[Fila, 6].Style.Numberformat.Format = "#,#0.0";

                    excelWorksheet.Cells[Fila, 7].Value = emp.GrupoCorte.HrsExtra;
                    excelWorksheet.Cells[Fila, 7].Style.Numberformat.Format = "#,#0.0";

                    // faltas
                    if(emp.GrupoCorte.HrsFalta > 0)
                    {
                        excelWorksheet.Cells[Fila, 8].Value = emp.GrupoCorte.HrsFalta;
                        excelWorksheet.Cells[Fila, 8].Style.Numberformat.Format = "#,#0.0";
                        excelWorksheet.Cells[Fila, 9].Value = $"{Funciones.DarkStriForDouble((6 / emp.GrupoCorte.HrsGrupo) * emp.GrupoCorte.HrsFalta)} día(s)";
                    }
                    
                    //Vacaciones
                    if(emp.GrupoCorte.HrsVacaciones > 0)
                    {
                        excelWorksheet.Cells[Fila, 10].Value = emp.GrupoCorte.HrsVacaciones;
                        excelWorksheet.Cells[Fila, 10].Style.Numberformat.Format = "#,#0.0";
                        excelWorksheet.Cells[Fila, 11].Value = $"{Funciones.DarkStriForDouble((6 / emp.GrupoCorte.HrsGrupo) * emp.GrupoCorte.HrsVacaciones)} día(s)";
                    }
                   
                    //Permisos
                    if(emp.GrupoCorte.HrsIncapacidad > 0)
                    {
                        excelWorksheet.Cells[Fila, 12].Value = emp.GrupoCorte.HrsIncapacidad;
                        excelWorksheet.Cells[Fila, 12].Style.Numberformat.Format = "#,#0.0";
                        excelWorksheet.Cells[Fila, 13].Value = $"{Funciones.DarkStriForDouble((6 / emp.GrupoCorte.HrsGrupo) * emp.GrupoCorte.HrsIncapacidad)} día(s)";
                    }
                    excelWorksheet.Cells[Fila, 14].Value = emp.GrupoCorte.HrsTxT;
                    excelWorksheet.Cells[Fila, 14].Style.Numberformat.Format = "#,#0.0";

                    excelWorksheet.Cells[Fila, 15].Value = emp.GrupoCorte.HrsScoreGen;
                    excelWorksheet.Cells[Fila, 15].Style.Numberformat.Format = "#,#0.0";

                    excelWorksheet.Cells[Fila, 16].Value = emp.HrsTxt;
                    excelWorksheet.Cells[Fila, 16].Style.Numberformat.Format = "#,#0.0";

                    excelWorksheet.Cells[Fila, 17].Value = emp.HrsScoreGen;
                    excelWorksheet.Cells[Fila, 17].Style.Numberformat.Format = "#,#0.0";

                    if (emp.HrsTxt >= 0)
                    {
                        Color myColor = System.Drawing.ColorTranslator.FromHtml("#ff616f");
                        excelWorksheet.Cells[Fila, 16].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        excelWorksheet.Cells[Fila, 16].Style.Fill.BackgroundColor.SetColor(myColor);
                    }
                    else
                    {
                        Color myColor = System.Drawing.ColorTranslator.FromHtml("#66ffa6");
                        excelWorksheet.Cells[Fila, 16].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        excelWorksheet.Cells[Fila, 16].Style.Fill.BackgroundColor.SetColor(myColor);
                    }

                    if (emp.HrsScoreGen >= 0)
                    {
                        Color myColor = System.Drawing.ColorTranslator.FromHtml("#ff616f");
                        excelWorksheet.Cells[Fila, 17].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        excelWorksheet.Cells[Fila, 17].Style.Fill.BackgroundColor.SetColor(myColor);
                    }
                    else 
                    {
                        Color myColor = System.Drawing.ColorTranslator.FromHtml("#66ffa6");
                        excelWorksheet.Cells[Fila, 17].Style.Fill.PatternType = ExcelFillStyle.Solid;
                        excelWorksheet.Cells[Fila, 17].Style.Fill.BackgroundColor.SetColor(myColor);
                    }
                    //else
                    //{

                    //}
                    Fila++;
                });
                excelWorksheet.Cells[$"A3:Q{excelWorksheet.Dimension.Rows}"].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                excelWorksheet.Cells[$"A3:Q{excelWorksheet.Dimension.Rows}"].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                excelWorksheet.Cells[$"A3:Q{excelWorksheet.Dimension.Rows}"].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                excelWorksheet.Cells[$"A3:Q{excelWorksheet.Dimension.Rows}"].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                excelWorksheet.Cells.AutoFitColumns();
                package.Save();
            }

            stream.Position = 0;
            string excelName = $"Rep_ProduccionHrs_{Inicio.ToString("yyyyMMddHHmmssfff")}.xlsx";
            // above I define the name of the file using the current datetime.
            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelName); // this will be the actual export.
        }

        [NonAction]
        private void AddRange(string Range, string Nombre, ExcelWorksheet excelWorksheet)
        {
            ExcelRange rng = excelWorksheet.Cells[Range];
            rng.Merge = true;
            rng.Value = Nombre;
            rng.Style.Fill.PatternType = ExcelFillStyle.Solid;
            rng.Style.Fill.BackgroundColor.SetColor(System.Drawing.ColorTranslator.FromHtml("#ffab40"));
        }
        #endregion
    }
}