using GPSInformation.Views;
using GPSInformation.Reportes.ProduccionV3;
using System;
using System.Collections.Generic;
using System.Text;
using GPSInformation.Models.Produccion;
using System.Linq;
using GPSInformation.Tools;
using System.IO;

namespace GPSInformation.Controllers
{
    public class ProduccionV4Ctrl
    {
        #region Atributos
        private readonly string PathIncidenceFiles = @"C:\Splittel\GestionPersonal\Produccion";
        public DarkManager darkManager;
        #endregion

        #region Constructores
        public ProduccionV4Ctrl(DarkManager darkManager)
        {
            this.darkManager = darkManager;
            this.darkManager.OpenConnection();
            this.darkManager.LoadObject(GpsManagerObjects.CatalogoOpcionesValores);
            this.darkManager.LoadObject(GpsManagerObjects.View_empleadoEnsamble);
            this.darkManager.LoadObject(GpsManagerObjects.GrupoHorario);

            this.darkManager.LoadObject(GpsManagerObjects.GrupoCambios);
            this.darkManager.LoadObject(GpsManagerObjects.GrupoArreglo);
            this.darkManager.LoadObject(GpsManagerObjects.GrupoProdIncidencia);
            this.darkManager.LoadObject(GpsManagerObjects.GrupoProdCorte);
            this.darkManager.LoadObject(GpsManagerObjects.AccesosSistema);
            this.darkManager.LoadObject(GpsManagerObjects.Usuario);
            this.darkManager.LoadObject(GpsManagerObjects.SubModulo);

            this.darkManager.LoadObject(GpsManagerObjects.GrupoIncidenciaDetalle);
            this.darkManager.LoadObject(GpsManagerObjects.GrupoIncidencia);
            this.darkManager.LoadObject(GpsManagerObjects.GrupoCorte);

            darkManager.OpenConnectionAcces();
            darkManager.LoadObject(GpsControlAcceso.View_gps_ensambleSinFiltro);
        }
        #endregion

        #region Metodos

        #region Permisos
        public void ChangePermisos(List<PermisosBloq> Permisos)
        {
            Permisos.ForEach(a => {
                var permiso = darkManager.AccesosSistema.GetOpenquerys($"where " +
                        $"IdUsuario = {a.IdUsuario} " +
                        $"and IdSubModulo = {a.IdSubModulo}");
                if (permiso != null)
                {
                    permiso.TieneAcceso = a.Autorization;
                    permiso.Modificado = DateTime.Now;
                    darkManager.AccesosSistema.Element = permiso;
                    if (!darkManager.AccesosSistema.Update())
                    {
                        throw new Exceptions.GpExceptions("Error al guardar los cambios");
                    }
                }
                else
                {
                    permiso = new Models.AccesosSistema
                    {
                        IdUsuario = a.IdUsuario,
                        IdSubModulo = a.IdSubModulo,
                        TieneAcceso = a.Autorization,
                        Modificado = DateTime.Now,
                        Forzado = false
                    };
                    darkManager.AccesosSistema.Element = permiso;
                    if (!darkManager.AccesosSistema.Add())
                    {
                        throw new Exceptions.GpExceptions("Error al guardar los cambios");
                    }

                }
            });
        }
        public List<PermisosBloq> VerPermisos(int IdPersona_)
        {
            List<PermisosBloq> permis = new List<PermisosBloq>();

            var usuario = darkManager.Usuario.GetOpenquerys($"where IdPersona = {IdPersona_}");
            var permisos = darkManager.SubModulo.GetOpenquery($"Where IdSubModulo in (1048,1049,1050,1051,1052)");
            //var permisos = darkManager.SubModulo.GetOpenquery($"Where IdSubModulo in (53,55,56,57,58)");
            permisos.ForEach(a => {

                var permiso = darkManager.AccesosSistema.GetOpenquerys($"where " +
                    $"IdUsuario = {usuario.IdUsuario} " +
                    $"and IdSubModulo = {a.IdSubModulo}");

                permis.Add(new PermisosBloq
                {
                    IdUsuario = usuario.IdUsuario,
                    IdSubModulo = a.IdSubModulo,
                    Descripcion = a.Nombre,
                    Autorization = permiso is null ? false : permiso.TieneAcceso
                });

            });
            return permis;
        }
        #endregion

        #region Incidencias old format
        /// <summary>
        /// Eliminar evento de incidencia
        /// </summary>
        /// <param name="IdGrupoProdIncidencia"></param>
        /// <param name="IdPersona"></param>
        public void DeleteInci(int IdGrupoProdIncidencia, int IdPersona)
        {
            var res = darkManager.GrupoProdIncidencia.Get(IdGrupoProdIncidencia);
            if (res is null)
            {
                throw new Exceptions.GpExceptions("Error, no se encontro la incidencia");
            }
            darkManager.GrupoProdIncidencia.Element = res;
            if (!darkManager.GrupoProdIncidencia.Delete())
            {
                throw new Exceptions.GpExceptions("Error al guardar los cambios");
            }

            if (File.Exists($@"{PathIncidenceFiles}\{res.Adjunto}"))
            {
                File.Delete($@"{PathIncidenceFiles}\{res.Adjunto}");
            }
        }
        /// <summary>
        /// Detalles de incidencia
        /// </summary>
        /// <param name="IdGrupoProdIncidencia"></param>
        /// <param name="IdPersona"></param>
        /// <returns></returns>
        public GrupoProdIncidencia DetailsInci(int IdGrupoProdIncidencia, int IdPersona)
        {
            var res = darkManager.GrupoProdIncidencia.Get(IdGrupoProdIncidencia);
            return res;
        }
        /// <summary>
        /// DeleteFile
        /// </summary>
        /// <param name="Adjunto"></param>
        /// <returns></returns>
        public byte[] GetFileInc(string Adjunto)
        {
            try
            {
                string PathEmp = $@"{PathIncidenceFiles}\{Adjunto}";

                if (!File.Exists(PathEmp))
                {
                    throw new Exceptions.GpExceptions($"Error, no fue encontrado el archivo : {Adjunto}");
                }

                return System.IO.File.ReadAllBytes(PathEmp);
            }
            catch (Exceptions.GpExceptions)
            {
                throw;
            }

        }
        /// <summary>
        /// Registrar incidencias
        /// </summary>
        /// <param name="GrupoProdIncidencia"></param>
        public void RegisterIncidenciaAsync(GrupoProdIncidencia GrupoProdIncidencia)
        {
            darkManager.StartTransaction();
            try
            {
                if (GrupoProdIncidencia is null)
                    throw new Exceptions.GpExceptions("Datos incorrectos");
                if (string.IsNullOrEmpty(GrupoProdIncidencia.Comentarios))
                    throw new Exceptions.GpExceptions("Por favor introduce algun comentario");

                darkManager.GrupoProdIncidencia.Element = GrupoProdIncidencia;
                if (GrupoProdIncidencia.IdGrupoProdIncidencia == 0)
                {

                    if (GrupoProdIncidencia.TipoIncidecia.Trim() == "Per")
                    {
                        GrupoProdIncidencia.FechaPermiso = DateTime.Parse(GrupoProdIncidencia.FechaPermiso.ToString("yyyy-MM-dd 08:00:00"));
                        if (!(GrupoProdIncidencia.CorteInicio <= GrupoProdIncidencia.FechaPermiso && GrupoProdIncidencia.FechaPermiso <= GrupoProdIncidencia.CorteFin))
                        {
                            throw new Exceptions.GpExceptions("Error, Fecha del permiso fuera del periodo");
                        }
                    }
                    else
                    {
                        GrupoProdIncidencia.FechaRegVac = DateTime.Parse(GrupoProdIncidencia.FechaRegVac.ToString("yyyy-MM-dd 08:00:00"));
                        GrupoProdIncidencia.FechaSalVac = DateTime.Parse(GrupoProdIncidencia.FechaSalVac.ToString("yyyy-MM-dd 08:00:00"));

                        if (!(GrupoProdIncidencia.CorteInicio <= GrupoProdIncidencia.FechaSalVac && GrupoProdIncidencia.FechaSalVac <= GrupoProdIncidencia.CorteFin))
                        {
                            throw new Exceptions.GpExceptions("Error, Fecha Salida esta fuera del periodo");
                        }

                        if (!(GrupoProdIncidencia.CorteInicio <= GrupoProdIncidencia.FechaRegVac && GrupoProdIncidencia.FechaRegVac <= GrupoProdIncidencia.CorteFin))
                        {
                            throw new Exceptions.GpExceptions("Error, Fecha Ultimo dia esta fuera del periodo");
                        }


                    }

                    darkManager.GrupoProdIncidencia.Element.Creado = DateTime.Now;
                    darkManager.GrupoProdIncidencia.Element.Modificado = DateTime.Now;
                    if (GrupoProdIncidencia.AdjuntoFile != null && GrupoProdIncidencia.AdjuntoFile.Length <= 0)
                        throw new Exceptions.GpExceptions($"Error, el archivo '{GrupoProdIncidencia.AdjuntoFile.FileName}' esta dañado");

                    if (GrupoProdIncidencia.AdjuntoFile != null)
                    {
                        if (!Directory.Exists(PathIncidenceFiles))
                            Directory.CreateDirectory(PathIncidenceFiles);
                        darkManager.GrupoProdIncidencia.Element.Adjunto = $"{DateTime.Now.ToString("MMddHHmmss")}_{GrupoProdIncidencia.AdjuntoFile.FileName}";
                        using (var stream = System.IO.File.Create($@"{PathIncidenceFiles}\{darkManager.GrupoProdIncidencia.Element.Adjunto}"))
                        {
                            GrupoProdIncidencia.AdjuntoFile.CopyTo(stream);
                        }
                    }

                    if (!darkManager.GrupoProdIncidencia.Add())
                    {
                        throw new Exceptions.GpExceptions("Error al guardar los cambios");
                    }
                }
                else
                {
                    darkManager.GrupoProdIncidencia.Element.Modificado = DateTime.Now;
                    if (!darkManager.GrupoProdIncidencia.Update())
                    {
                        throw new Exceptions.GpExceptions("Error al guardar los cambios");
                    }
                }

                darkManager.Commit();
            }
            catch (Exceptions.GpExceptions ex)
            {
                darkManager.RolBack();
                Tools.Funciones.EscribeLog(ex.ToString());
                throw ex;
            }
            catch (Exception ex)
            {
                darkManager.RolBack();
                Tools.Funciones.EscribeLog(ex.ToString());
                throw new Exceptions.GpExceptions(ex.Message);
            }
        }
        #endregion

        #region CRUD Horarios control de accesos
        /// <summary>
        /// Eliminar evento
        /// </summary>
        /// <param name="IdEvent"></param>
        /// <param name="IdPersona"></param>
        public void DeleteArreglo(int IdEvent, int IdPersona)
        {
            darkManager.GrupoArreglo.Element = darkManager.GrupoArreglo.GetOpenquerys($"where IdPersona = {IdPersona} and IdGrupoArreglo = {IdEvent}");
            if (darkManager.GrupoArreglo.Element is null)
            {
                throw new Exceptions.GpExceptions("No se encontro el evento de tipo arreglo");
            }

            if (!darkManager.GrupoArreglo.Delete())
            {
                throw new Exceptions.GpExceptions("Error al guardar los cambios");
            }
        }
        /// <summary>
        /// Agregar evento de chequeo
        /// </summary>
        /// <param name="IdEvent"></param>
        /// <param name="IdPersona"></param>
        /// <param name="Fecha"></param>
        /// <param name="Comentarios"></param>
        public void AddArreglo(int IdEvent, int IdPersona, DateTime Fecha, string Comentarios)
        {
            darkManager.GrupoArreglo.Element = new GrupoArreglo
            {
                IdEvent = IdEvent,
                IdPersona = IdPersona,
                FechaHora = Fecha,
                Comentarios = Comentarios,
                EsIgnorado = true,
                Creado = DateTime.Now,
                Modificado = DateTime.Now,
            };
            if (string.IsNullOrEmpty(Comentarios))
                throw new Exceptions.GpExceptions("Por favor introduce algun comentario");
            if (!darkManager.GrupoArreglo.Add())
            {
                throw new Exceptions.GpExceptions("Error al guardar los cambios");
            }
        }
        #endregion

        #region Procesar empledos
        /// <summary>
        /// Procesar reporte de empleados
        /// </summary>
        /// <param name="Inicio_"></param>
        /// <returns></returns>
        public ReporteProd ProcesarEmpleados(DateTime Inicio_)
        {
            ReporteProd reporteProd = new ReporteProd
            {
                Inicio = Inicio_,
                Fin = Inicio_.AddDays(7),
                EmpleadoProds = new List<EmpleadoProd>()
            };
            darkManager.View_empleadoEnsamble.Get().ForEach(a => {
                reporteProd.EmpleadoProds.Add(ProcesarEmpleado(a, 0, Inicio_));
            });
            return reporteProd;
        }
        /// <summary>
        /// Procesar reporte de horas trabajadas por empleado
        /// </summary>
        /// <param name="Empleado"></param>
        /// <param name="IdPersona"></param>
        /// <param name="Inicio_"></param>
        /// <returns></returns>
        public EmpleadoProd ProcesarEmpleado(View_empleadoEnsamble Empleado, int IdPersona, DateTime Inicio_)
        {
            if (IdPersona != 0)
            {
                Empleado = darkManager.View_empleadoEnsamble.Get(IdPersona);
            }
            EmpleadoProd EmpleadoProd = new EmpleadoProd
            {
                IdPersona = Empleado.IdPersona,
                NombreCompleto = Empleado.NombreCompleto,
                NumeroNomina = Empleado.NumeroNomina,
                PuestoNombre = Empleado.PuestoNombre,
                Antiguedad = Empleado.Antiguedad,
                Incio = Inicio_,
                Fin = Inicio_.AddDays(7),
                Accessos = new List<AccessLog>(),
                JornadaGrupos = new List<JornadaGrupo>(),
                GrupoCambios = new List<GrupoCambios>(),
                //GrupoCambios = ListCambiosgrupo(Empleado.IdPersona, Inicio_),
                NewIncidence = new List<NewIncidence>(),
                GrupoCorte = new GrupoCorte(),
                HrsTxt = 0,
                HrsScoreGen = 0,
                GrupoName = ""
            };

            #region Procesar logs
            var Logs = darkManager.View_gps_ensambleSinFiltro.GetOpenquery(
                                    $"where tIdentification = '{Empleado.NumeroNomina}' " +
                                    $"AND dtEventReal >= '{EmpleadoProd.Incio.ToString("yyyy-MM-dd 05:50:00")}' " +
                                    $"AND dtEventReal <= '{EmpleadoProd.Fin.ToString("yyyy-MM-dd 05:45:00")}' " +
                                    $"AND IdReader = 17",
                                    $"ORDER BY iEmployeeNum , dtEventReal");

            Logs.ForEach(log => {
                //validar ignorar log
                var logIgnore = darkManager.GrupoArreglo.GetOpenquerys($"where IdEvent = '{log.IdAutoEvents}' and IdPersona = { Empleado.IdPersona}");

                EmpleadoProd.Accessos.Add(new AccessLog
                {
                    IdEventChec = log.IdAutoEvents,
                    IdGrupoArreglo = logIgnore != null ? logIgnore.IdGrupoArreglo : 0,
                    Descripcion = logIgnore != null ? logIgnore.Comentarios : log.tDesc,
                    Fecha = log.dtEventReal,
                    Activo = logIgnore is null ? true : false,
                    Forzado = false,
                    IdAccessLog = 0
                });
            });
            #endregion

            #region procesar arreglos a logs
            var arreglos = darkManager.GrupoArreglo.GetOpenquery($"where " +
               $"IdEvent is null and IdPersona = { Empleado.IdPersona} " +
               $"AND FechaHora >= '{EmpleadoProd.Incio.ToString("yyyy-MM-dd 05:50:00")}' " +
               $"AND FechaHora <= '{EmpleadoProd.Fin.ToString("yyyy-MM-dd 05:45:00")}' ",
               $"Order by FechaHora");

            arreglos.ForEach(arr => {
                EmpleadoProd.Accessos.Add(new AccessLog
                {
                    IdEventChec = 0,
                    Descripcion = arr.Comentarios,
                    Fecha = arr.FechaHora,
                    Activo = true,
                    Forzado = true,
                    IdAccessLog = arr.IdGrupoArreglo
                });
            });
            #endregion

            #region Procesar dias por grupo asginado
            DateTime Corte = DateTime.Parse(EmpleadoProd.Incio.ToString("yyyy-MM-dd 00:00:00")).AddDays(0);
            DateTime Fin = DateTime.Parse(EmpleadoProd.Fin.ToString("yyyy-MM-dd 00:00:00")).AddDays(0);
            //var UltimoCambio = darkManager.GrupoCambios.GetOpenquerys($"where IdPersona = {Empleado.IdPersona} and Fecha = '{EmpleadoProd.Incio.ToString("yyyy-MM-dd")}'");
            var UltimoCambio = GetUltimoCambio(EmpleadoProd.Incio, Empleado.IdPersona);
            while (Corte < Fin)
            {
                if (UltimoCambio != null)
                {
                    // obtener dia de acuerdo al grupo
                    var DiaHorario_re = darkManager.GrupoHorario.GetOpenquerys($"where IdGrupo = '{UltimoCambio.IdGrupo}' and dia = '{(int)Corte.DayOfWeek}'");
                    var diaLog = new JornadaGrupo
                    {
                        IdGrupo = DiaHorario_re.IdGrupo,
                        HorasMeta = DiaHorario_re.Horas,
                        TipoJornada = DiaHorario_re.TipoDia,
                        Fecha = Corte + DiaHorario_re.Entrada,
                        ComentariosSistema = $"cambio de turno aplicado desde el dia: {UltimoCambio.Fecha.ToString("D")}"
                    };
                    diaLog.GrupoName = GetNameGrup(diaLog.IdGrupo);
                    diaLog.Salida = diaLog.Fecha.AddHours(diaLog.HorasMeta);
                    EmpleadoProd.JornadaGrupos.Add(diaLog);
                }

                Corte = Corte.AddDays(1);
            }
            EmpleadoProd.GrupoCambio = UltimoCambio;
            if(UltimoCambio != null)
                EmpleadoProd.GrupoName = GetNameGrup(UltimoCambio.IdGrupo);
            #endregion

            #region Validando entradas
            EmpleadoProd.Accessos = EmpleadoProd.Accessos.OrderBy(a => a.Fecha).ToList();

            int Pos = 1;

            EmpleadoProd.Accessos.ForEach(a => {
                if (a.Activo)
                {
                    a.Position = Pos;
                    Pos++;
                }
            });

            #endregion

            #region procesar horas meta
            DateTime Entrada = DateTime.Parse("0001-01-01 00:00:00");
            int AccesosActivos = EmpleadoProd.Accessos.Count(a => a.Activo);
            if ((AccesosActivos % 2 != 0))
            {
                AccesosActivos = AccesosActivos - 1;
            }
            EmpleadoProd.Accessos.ForEach(a => {
                if (a.Activo && AccesosActivos >= 0)
                {
                    if (a.TipoAcceso == TipoAcceso.Entrada)
                    {
                        if (Entrada < a.Fecha)
                        {
                            Entrada = a.Fecha;
                        }
                    }
                    else
                    {
                        EmpleadoProd.HorasReal += Funciones.DifFechashoras((DateTime)a.Fecha, (DateTime)Entrada);
                    }
                    AccesosActivos--;
                }
            });


            EmpleadoProd.JornadaGrupos.ForEach(a => {
                EmpleadoProd.HorasMeta += a.HorasMeta;
            });
            #endregion

            #region obtener incidencias
            //var Incidencias = darkManager.GrupoProdIncidencia.GetOpenquery($"where " +
            //   $"IdPersona = { Empleado.IdPersona}  and TipoIncidecia = 'Per'" +
            //   $"AND FechaPermiso >= '{EmpleadoProd.Incio.ToString("yyyy-MM-dd 05:50:00")}' " +
            //   $"AND FechaPermiso <= '{EmpleadoProd.Fin.ToString("yyyy-MM-dd 05:45:00")}' ",
            //   $"Order by FechaPermiso");

            //EmpleadoProd.GrupoProdIncidencias = Incidencias;

            //var vacaciones = darkManager.GrupoProdIncidencia.GetOpenquery($"where " +
            //   $"IdPersona = { Empleado.IdPersona}  and TipoIncidecia = 'Vac'" +
            //   $"AND FechaSalVac >= '{EmpleadoProd.Incio.ToString("yyyy-MM-dd 05:50:00")}' " +
            //   $"AND FechaSalVac <= '{EmpleadoProd.Fin.ToString("yyyy-MM-dd 05:45:00")}' " +
            //   $"AND FechaRegVac >= '{EmpleadoProd.Incio.ToString("yyyy-MM-dd 05:50:00")}' " +
            //   $"AND FechaRegVac <= '{EmpleadoProd.Fin.ToString("yyyy-MM-dd 05:45:00")}' ",
            //   $"Order by FechaRegVac");

            //vacaciones.ForEach(eve => {
            //    EmpleadoProd.GrupoProdIncidencias.Add(eve);
            //});


            //EmpleadoProd.GrupoProdIncidencias.ForEach(a => {
            //    if (a.TipoIncidecia == "Per")
            //    {
            //        var opc = darkManager.CatalogoOpcionesValores.Get(a.TipoPermiso);
            //        if (opc != null)
            //        {
            //            a.NameTipoPermiso = opc.Descripcion;
            //        }
            //    }

            //    EmpleadoProd.HorasAprobadas += a.HorasJustific;
            //});

            #endregion

            //EmpleadoProd.GrupoProdCorteAct = darkManager.GrupoProdCorte.GetOpenquerys($"where IdPersona = {Empleado.IdPersona} and FechaCorte = '{EmpleadoProd.Fin.ToString("yyyy-MM-dd")}'");
            //EmpleadoProd.GrupoProdCorteLast = darkManager.GrupoProdCorte.GetOpenquerys($"where IdPersona = {Empleado.IdPersona} and FechaCorte = '{EmpleadoProd.Incio.ToString("yyyy-MM-dd")}'");


            #region get incidencias nuevo formato
            darkManager.GrupoIncidencia.GetOpenquery($"where " +
               $"IdPersona = { Empleado.IdPersona} " +
               $"AND Fecha >= '{EmpleadoProd.Incio.ToString("yyyy-MM-dd 05:50:00")}' " +
               $"AND Fecha <= '{EmpleadoProd.Fin.ToString("yyyy-MM-dd 05:45:00")}' ",
               $"Order by Fecha").ForEach(inc =>
               {
                   if (inc.TipoIncidencia == "Per")
                   {
                       inc.DescPermiso = darkManager.CatalogoOpcionesValores.Get(inc.TipoPermiso).Descripcion;
                   }

                   EmpleadoProd.NewIncidence.Add(new NewIncidence { Incidencia = inc, Detalle = darkManager.GrupoIncidenciaDetalle.GetOpenquery($"where IdGrupoIncidencia = {inc.IdGrupoIncidencia}", "") });
               });
            #endregion

            #region get corte real
            //obtner corte anterior
            EmpleadoProd.GrupoCorteLast = darkManager.GrupoCorte.GetOpenquerys($"where IdPersona = {Empleado.IdPersona} and Fecha = '{EmpleadoProd.Incio.AddDays(-7).ToString("yyyy-MM-dd")}'");
            //obtener corte actual
            var CorteSave = darkManager.GrupoCorte.GetOpenquerys($"where IdPersona = {Empleado.IdPersona} and Fecha = '{EmpleadoProd.Incio.ToString("yyyy-MM-dd")}'");
            if (CorteSave != null && CorteSave.EsInicial == true && CorteSave.EsFinal == true)
            {
                EmpleadoProd.GrupoCorte = CorteSave;
            }
            else
            {

                EmpleadoProd.GrupoCorte = CorteSave is null ? new GrupoCorte { } : CorteSave;
                EmpleadoProd.GrupoCorte.HrsGrupo = EmpleadoProd.HorasMeta;
                EmpleadoProd.GrupoCorte.HrsReal = Math.Round(EmpleadoProd.HorasReal);
                EmpleadoProd.GrupoCorte.HrsTxT = 0;
                EmpleadoProd.GrupoCorte.HrsScoreGen = 0;
                EmpleadoProd.GrupoCorte.HrsNomina = 0;
                EmpleadoProd.GrupoCorte.HrsExtra = 0;
                EmpleadoProd.GrupoCorte.HrsVacaciones = 0;
                EmpleadoProd.GrupoCorte.HrsFalta = 0;
                //EmpleadoProd.GrupoCorte.HrsPermisos = 0;

                //if (EmpleadoProd.GrupoCorte.HrsReal > EmpleadoProd.GrupoCorte.HrsGrupo)
                //{
                //    EmpleadoProd.GrupoCorte.HrsNomina = EmpleadoProd.GrupoCorte.HrsGrupo;
                //    EmpleadoProd.GrupoCorte.HrsExtra = EmpleadoProd.GrupoCorte.HrsReal - EmpleadoProd.GrupoCorte.HrsGrupo;
                //}
                //else
                //{

                //    EmpleadoProd.GrupoCorte.HrsNomina = EmpleadoProd.GrupoCorte.HrsReal;
                //}


                //procesar indicencias
               
                EmpleadoProd.NewIncidence.ForEach(inc =>
                {
                    var total = inc.Detalle.Sum(a => a.Horas);
                    if (inc.Incidencia.TipoIncidencia == "Vac")
                    {
                        EmpleadoProd.GrupoCorte.HrsVacaciones = total;
                    } 
                    else if (inc.Incidencia.TipoIncidencia == "Fal")
                    {
                        EmpleadoProd.GrupoCorte.HrsFalta = total;
                    }
                    else if (inc.Incidencia.TipoIncidencia == "Inc")
                    {
                        EmpleadoProd.GrupoCorte.HrsIncapacidad = total;
                    }
                    else if (inc.Incidencia.TipoIncidencia == "Per")
                    {
                       
                        //40  Permiso con goce de sueldo
                        //41  Permiso sin goce de sueldo
                        //42  permiso tiempo por tiempo
                        //43  salario emocional: cumpleaños
                        //44  salario emocional: medio dia libre
                        switch (inc.Incidencia.TipoPermiso)
                        {
                            case 40:
                                EmpleadoProd.GrupoCorte.HrsNomina += total;
                                // sumar hrs a total de horas de incidencias
                                EmpleadoProd.HrsIncidecias += total;
                                break;
                            case 41:

                                break;
                            case 42:

                                if (inc.Incidencia.EsScoreGeneral)
                                    EmpleadoProd.GrupoCorte.HrsScoreGen += total;
                                else
                                    EmpleadoProd.GrupoCorte.HrsTxT += total;

                                EmpleadoProd.GrupoCorte.HrsNomina += total;
                                // sumar hrs a total de horas de incidencias
                                EmpleadoProd.HrsIncidecias += total;
                                break;
                            case 43:
                                EmpleadoProd.GrupoCorte.HrsNomina += total;
                                // sumar hrs a total de horas de incidencias
                                EmpleadoProd.HrsIncidecias += total;
                                break;
                            case 44:
                                EmpleadoProd.GrupoCorte.HrsNomina += total;
                                // sumar hrs a total de horas de incidencias
                                EmpleadoProd.HrsIncidecias += total;
                                break;
                            default:
                                break;
                        }
                    }
                });

                // validar horas nomina
                // sumar horas incidencias mas horas reales
                EmpleadoProd.GrupoCorte.HrsNomina += 
                        EmpleadoProd.GrupoCorte.HrsReal + 
                        EmpleadoProd.GrupoCorte.HrsIncapacidad + 
                        EmpleadoProd.GrupoCorte.HrsVacaciones;
                //validar si el empleado tiene horas de mas 
                if (EmpleadoProd.GrupoCorte.HrsNomina > EmpleadoProd.GrupoCorte.HrsGrupo)
                {
                    EmpleadoProd.GrupoCorte.HrsExtra = EmpleadoProd.GrupoCorte.HrsNomina - EmpleadoProd.GrupoCorte.HrsGrupo;
                    EmpleadoProd.GrupoCorte.HrsNomina = EmpleadoProd.GrupoCorte.HrsGrupo;
                }
                else
                {

                    EmpleadoProd.GrupoCorte.HrsExtra = 0;
                    //if (EmpleadoProd.GrupoCorte.HrsReal > EmpleadoProd.GrupoCorte.HrsGrupo)
                    //{
                    //    EmpleadoProd.GrupoCorte.HrsNomina = EmpleadoProd.GrupoCorte.HrsGrupo;
                    //    EmpleadoProd.GrupoCorte.HrsExtra = EmpleadoProd.GrupoCorte.HrsReal - EmpleadoProd.GrupoCorte.HrsGrupo;
                    //}
                    //else
                    //{
                    //    EmpleadoProd.GrupoCorte.HrsExtra = 0;
                    //}

                }




                if (CorteSave is null)
                {
                    if (EmpleadoProd.HorasMeta > 0)
                    {
                        EmpleadoProd.GrupoCorte.HrsTxT -= EmpleadoProd.GrupoCorte.Extras;
                        EmpleadoProd.GrupoCorte.HrsScoreGen -= EmpleadoProd.GrupoCorte.Score;
                        EmpleadoProd.GrupoCorte.IdPersona = EmpleadoProd.IdPersona;
                        EmpleadoProd.GrupoCorte.Fecha = DateTime.Parse(EmpleadoProd.Incio.ToString("yyyy-MM-dd 13:00:00"));
                        EmpleadoProd.GrupoCorte.Comentarios = "Se ha creado un corte para revision";
                        darkManager.GrupoCorte.Element = EmpleadoProd.GrupoCorte;
                        darkManager.GrupoCorte.Add();
                    }
                }
                else if (CorteSave != null && CorteSave.EsFinal == false && CorteSave.EsFinal == false)
                {
                    if (EmpleadoProd.HorasMeta > 0)
                    {
                        EmpleadoProd.GrupoCorte.HrsTxT -= EmpleadoProd.GrupoCorte.Extras;
                        EmpleadoProd.GrupoCorte.HrsScoreGen -= EmpleadoProd.GrupoCorte.Score;
                        EmpleadoProd.GrupoCorte.IdPersona = EmpleadoProd.IdPersona;
                        EmpleadoProd.GrupoCorte.Fecha = DateTime.Parse(EmpleadoProd.Incio.ToString("yyyy-MM-dd 13:00:00"));
                        EmpleadoProd.GrupoCorte.Comentarios = "Se ha creado un corte para revision";
                        darkManager.GrupoCorte.Element = EmpleadoProd.GrupoCorte;
                        darkManager.GrupoCorte.Update();
                    }
                }


            }
            #endregion
            var Txt = darkManager.GrupoCorte.GetValue($"select sum(HrsTxt) from GrupoCorte where IdPersona = {EmpleadoProd.IdPersona}");
            var ScoreGen = darkManager.GrupoCorte.GetValue($"select sum(HrsScoreGen) from GrupoCorte where IdPersona = {EmpleadoProd.IdPersona}");
            EmpleadoProd.HrsTxt = Txt is System.DBNull ? 0 : (double)Txt;
            EmpleadoProd.HrsScoreGen = ScoreGen is System.DBNull ? 0 : (double)ScoreGen;

            return EmpleadoProd;
        }
        public void SaveDivHoras(int IdCorte, double Txt, double Score)
        {
            var CorteSave = darkManager.GrupoCorte.Get(IdCorte);
            if (CorteSave is null)
                throw new Exceptions.GpExceptions("Por favor selecciona unn corte");


            CorteSave.Extras = Txt;
            CorteSave.Score = Score;

            darkManager.GrupoCorte.Element = CorteSave;
            if (!darkManager.GrupoCorte.Update())
            {
                throw new Exceptions.GpExceptions("Error al guardar los cambios");
            }
        }
        #endregion

        #region Cambios de turno
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Corte"></param>
        /// <param name="IdPersona_"></param>
        /// <returns></returns>
        private GrupoCambios GetUltimoCambio(DateTime Corte, int IdPersona_)
        {
            var UltimoCambio = darkManager.GrupoCambios.GetUnicSatatment($"select top 1 * from GrupoCambios where IdPersona = {IdPersona_} and Fecha <= '{Corte.ToString("yyyy-MM-dd")}' order by Fecha desc ");

            if (UltimoCambio != null)
            {
                UltimoCambio.GrupoName = GetNameGrup(UltimoCambio.IdGrupo);
            }
            return UltimoCambio;
        }
        /// <summary>
        /// Listar cambios realizados durante la semana
        /// </summary>
        /// <param name="IdPersona"></param>
        /// <param name="Inicio"></param>
        /// <returns></returns>
        public List<GrupoCambios> ListCambiosgrupo(int IdPersona, DateTime Inicio)
        {
            var Incidencias = darkManager.GrupoCambios.GetOpenquery($"where " +
               $"IdPersona = { IdPersona}  " +
               $"AND Fecha >= '{Inicio.ToString("yyyy-MM-dd 05:50:00")}' " +
               $"AND Fecha <= '{Inicio.AddDays(6).ToString("yyyy-MM-dd 23:59:59")}' ",
               $"Order by Fecha");
            Incidencias.ForEach(a => a.GrupoName = GetNameGrup(a.IdGrupo));
            return Incidencias;
        }
        /// <summary>
        /// Eliminar un cambio de turno
        /// </summary>
        /// <param name="IdGrupoCambios"></param>
        /// <param name="IdPersona"></param>
        public void DeleteCambio(int IdGrupoCambios, int IdPersona)
        {
            var UltimoCambio = darkManager.GrupoCambios.GetOpenquerys($"where IdPersona = {IdPersona} and IdGrupoCambios = {IdGrupoCambios}");
            if (UltimoCambio is null)
            {
                throw new Exceptions.GpExceptions("Error, no se encontro el cambio");
            }

            darkManager.GrupoCambios.Element = UltimoCambio;
            if (!darkManager.GrupoCambios.Delete())
            {
                throw new Exceptions.GpExceptions("Error al remover el cambio de turno seleccionado");
            }
        }
        /// <summary>
        /// registrar nuevos cambios
        /// </summary>
        /// <param name="grupoCambios"></param>
        public void AddCambio(GrupoCambios grupoCambios)
        {
            if (grupoCambios is null)
            {
                throw new Exceptions.GpExceptions("Error, datos incorrectos");
            }


            if (grupoCambios.Fecha < grupoCambios.FechaInicio && grupoCambios.Fecha > grupoCambios.FechaInicio.AddDays(6))
            {
                throw new Exceptions.GpExceptions("Error, por favor introduce una fecha de acuerdo al bloque del reporte");
            }

            var UltimoCambio = darkManager.GrupoCambios.GetOpenquerys($"where IdPersona = {grupoCambios.IdPersona} and Fecha = '{grupoCambios.Fecha.ToString("yyyy-MM-dd")}'");
            if (string.IsNullOrEmpty(grupoCambios.Comentarios))
            {
                throw new Exceptions.GpExceptions("Error, por favor introduce algun comentario");
            }

            if (UltimoCambio != null)
            {
                //throw new Exceptions.GpExceptions($"Ya existe un cambio de grupo, el grupo definido fue '{ GetNameGrup(UltimoCambio.IdGrupo)}', por favor elimina dicho cambo y vuelve a intentar");
                //UltimoCambio.Creado = DateTime.Now;
                UltimoCambio.Modificado = DateTime.Now;
                UltimoCambio.IdGrupo = grupoCambios.IdGrupo;
                UltimoCambio.Comentarios = grupoCambios.Comentarios;
                darkManager.GrupoCambios.Element = UltimoCambio;
                if (!darkManager.GrupoCambios.Update())
                {
                    throw new Exceptions.GpExceptions("Error al guardar los cambios");
                }
            }
            else
            {
                grupoCambios.Creado = DateTime.Now;
                grupoCambios.Modificado = DateTime.Now;
                darkManager.GrupoCambios.Element = grupoCambios;
                if (!darkManager.GrupoCambios.Add())
                {
                    throw new Exceptions.GpExceptions("Error al guardar los cambios");
                }
            }
            
        }
        #endregion

        #region Cortes old
        /// <summary>
        /// Generar corte
        /// </summary>
        /// <param name="IdPersona"></param>
        /// <param name="Corte"></param>
        public void CreateCorte(int IdPersona, DateTime Corte)
        {
            var Procesa = ProcesarEmpleado(new View_empleadoEnsamble(), IdPersona, Corte);
            if (Procesa is null)
            {
                throw new Exceptions.GpExceptions("Error, no se proceso el cliente solicitado");
            }
            var CorteAnterio = darkManager.GrupoProdCorte.GetOpenquerys($"where IdPersona = {IdPersona} and FechaCorte = '{Corte.ToString("yyyy-MM-dd")}'");
            if (CorteAnterio is null)
            {
                throw new Exceptions.GpExceptions($"Error, aun no se ha creado el corte de la semana anterior: semana faltante {Corte.AddDays(-7).ToString("F")}");
            }
            var CorteActual = darkManager.GrupoProdCorte.GetOpenquerys($"where IdPersona = {IdPersona} and FechaCorte = '{Corte.AddDays(7).ToString("yyyy-MM-dd")}'");
            if (CorteActual != null)
            {
                throw new Exceptions.GpExceptions("Error, ya fue creado un corte");
            }

            GrupoProdCorte grupoProdCorte = new GrupoProdCorte
            {
                IdPersona = IdPersona,
                Comentarios = "Generacion del corte",
                Creado = DateTime.Now,
                FechaCorte = Corte.AddDays(7),
                Modificado = DateTime.Now,
                HorasJusti = Procesa.HorasAprobadas,
                HorasMeta = Procesa.HorasMeta,
                HorasReal = Procesa.HorasReal,
                Score = CorteAnterio.Score - (Procesa.HorasScore)
            };

            darkManager.GrupoProdCorte.Element = grupoProdCorte;
            if (!darkManager.GrupoProdCorte.Add())
            {
                throw new Exceptions.GpExceptions("Error al guardar los cambios");
            }
        }
        #endregion

        #region Incidencias new format
        public void EditIncidene(ProdIncidencia prodIncidencia, string Creador)
        {

        }
        /// <summary>
        /// eliminar incidencia
        /// </summary>
        /// <param name="folio"></param>
        public void DeleteInidencia2(int folio)
        {
            darkManager.StartTransaction();
            if (folio == 0)
                throw new Exceptions.GpExceptions("Por favor selecciona una incidencia");
            try
            {
                var inc = GetIncidencia(folio);
                if (inc is null)
                {
                    throw new Exceptions.GpExceptions("PNo se encontro la incidencia solicitada");
                }
                inc.Detalle.ForEach(det =>
                {
                    darkManager.GrupoIncidenciaDetalle.Element = det;
                    if (!darkManager.GrupoIncidenciaDetalle.Delete())
                    {
                        throw new Exceptions.GpExceptions("Error al eliminar detalle de incidencia");
                    }
                });

                darkManager.GrupoIncidencia.Element = inc.Incidencia;
                if (!darkManager.GrupoIncidencia.Delete())
                {
                    throw new Exceptions.GpExceptions("Error al eliminar  incidencia");
                }
                if (!string.IsNullOrEmpty(inc.Incidencia.Adjunto))
                {
                    if (File.Exists($@"{PathIncidenceFiles}\{inc.Incidencia.Adjunto}"))
                    {
                        File.Delete($@"{PathIncidenceFiles}\{inc.Incidencia.Adjunto}");
                    }
                }

                darkManager.Commit();
            }
            catch (Exceptions.GpExceptions ex)
            {
                darkManager.RolBack();
                Tools.Funciones.EscribeLog(ex.ToString());
                throw ex;
            }
            catch (Exception ex)
            {
                darkManager.RolBack();
                Tools.Funciones.EscribeLog(ex.ToString());
                throw new Exceptions.GpExceptions(ex.Message);
            }
        }
        /// <summary>
        /// Detalles de incidencia
        /// </summary>
        /// <param name="folio">folio de la inc</param>
        /// <returns></returns>
        public NewIncidence GetIncidencia(int folio)
        {
            var inc = darkManager.GrupoIncidencia.Get(folio);

            return inc != null ? new NewIncidence { Incidencia = inc, Detalle = darkManager.GrupoIncidenciaDetalle.GetOpenquery($"where IdGrupoIncidencia = {folio}", "") } : null;
        }
        /// <summary>
        /// reistrar nueva incencias
        /// </summary>
        /// <param name="prodIncidencia"></param>
        /// <param name="Creador"></param>
        public void AddIncidence(ProdIncidencia prodIncidencia, string Creador)
        {
            darkManager.StartTransaction();
            if (prodIncidencia is null)
                throw new Exceptions.GpExceptions("Datos incorrectos");

            try
            {
                if (prodIncidencia.TipoPermiso == 0 && prodIncidencia.TipoIncidencia == "Per")
                    throw new Exceptions.GpExceptions("Por favor selecciona alguno de los tipos de permisos");

                if (string.IsNullOrEmpty(prodIncidencia.Comentarios)) throw new Exceptions.GpExceptions("Por favor escribe un comentario para el registro de la incidencia");
                if (prodIncidencia.Semana.Count(a => a.Apply == true) <= 0)
                {
                    throw new Exceptions.GpExceptions("Por favor selecciona almenos un dia para aplicar la incidencia");
                }

                var Incidencia = new GrupoIncidencia
                {
                    IdPersona = prodIncidencia.IdPersona,
                    TipoIncidencia = prodIncidencia.TipoIncidencia,
                    Fecha = DateTime.Parse(prodIncidencia.Fecha.ToString("yyyy-MM-dd 13:00:00")),
                    Descripcion = prodIncidencia.Comentarios,
                    TipoPermiso = prodIncidencia.TipoPermiso,
                    CreadoPor = Creador,
                    Creado = DateTime.Now,
                    EsScoreGeneral = prodIncidencia.EsScoreGeneral
                };

                if (prodIncidencia.AdjuntoFile != null && prodIncidencia.AdjuntoFile.Length <= 0)
                    throw new Exceptions.GpExceptions($"Error, el archivo '{prodIncidencia.AdjuntoFile.FileName}' esta dañado");

                if (prodIncidencia.AdjuntoFile != null)
                {
                    if (!Directory.Exists(PathIncidenceFiles))
                        Directory.CreateDirectory(PathIncidenceFiles);
                    Incidencia.Adjunto = $"{DateTime.Now.ToString("MMddHHmmss")}_{prodIncidencia.AdjuntoFile.FileName}";
                    using (var stream = System.IO.File.Create($@"{PathIncidenceFiles}\{Incidencia.Adjunto}"))
                    {
                        prodIncidencia.AdjuntoFile.CopyTo(stream);
                    }
                }

                darkManager.GrupoIncidencia.Element = Incidencia;
                if (!darkManager.GrupoIncidencia.Add())
                {
                    throw new Exceptions.GpExceptions("Error al registrar la incidencia");
                }

                int LastInserted = darkManager.GrupoIncidencia.LastInserted($"select max([IdGrupoIncidencia]) from [GrupoIncidencia] where IdPersona = '{prodIncidencia.IdPersona}'");

                if (darkManager.GrupoIncidenciaDetalle.GetOpenquery($"where IdGrupoIncidencia = {LastInserted}", "").Count > 0)
                {
                    throw new Exceptions.GpExceptions("Esta incidencia tiene detalles");
                }
                prodIncidencia.Semana.ForEach(det =>
                {
                    if (det.Apply)
                    {
                        var detalle = new GrupoIncidenciaDetalle();
                        detalle.Fecha = prodIncidencia.Fecha.AddDays(det.Dia);
                        detalle.Horas = det.Horas;
                        detalle.IdGrupoIncidencia = LastInserted;
                        if (det.Horas == 0)
                        {
                            throw new Exceptions.GpExceptions("Info, por favor introduce la horas para el dia :" + det.Nombre);
                        }
                        darkManager.GrupoIncidenciaDetalle.Element = detalle;
                        if (!darkManager.GrupoIncidenciaDetalle.Add())
                        {
                            throw new Exceptions.GpExceptions("Error al registrar el detalle de la incidencia");
                        }
                    }
                });
                darkManager.dBConnection.StartProcedure($"SP_ProdV4_Inc", new List<ProcedureModel>
                {
                    new ProcedureModel { Namefield = "IdGrupoIncidencia", value = LastInserted }
                });

                if (darkManager.dBConnection.ErrorCode != 0)
                {
                    throw new GPSInformation.Exceptions.GpExceptions(darkManager.GetLastMessage());
                }
                darkManager.Commit();
            }
            catch (Exceptions.GpExceptions ex)
            {
                darkManager.RolBack();
                Tools.Funciones.EscribeLog(ex.ToString());
                throw ex;
            }
            catch (Exception ex)
            {
                darkManager.RolBack();
                Tools.Funciones.EscribeLog(ex.ToString());
                throw new Exceptions.GpExceptions(ex.Message);
            }
        }
        #endregion

        #region Procesos internos
        /// <summary>
        /// Terminar controlador 
        /// </summary>
        public void Terminar()
        {
            darkManager.CloseConnection();
            darkManager.CloseConnectionAccess();
            darkManager.CatalogoOpcionesValores = null;
            darkManager.View_empleadoEnsamble = null;
            darkManager.GrupoHorario = null;
            darkManager.View_gps_ensambleSinFiltro = null;
            darkManager.GrupoCambios = null;
            darkManager.GrupoArreglo = null;
        }
        /// <summary>
        /// Obtener nombre del Grupo
        /// </summary>
        /// <param name="IdGrupo"></param>
        /// <returns></returns>
        public string GetNameGrup(int IdGrupo)
        {
            return IdGrupo == 2086 ? "Gris" : IdGrupo == 2087 ? "Rojo" : IdGrupo == 2088 ? "Verde" : "Sin asginar";
        }
        #endregion

        #endregion
    }

    public class AnalisisHoras
    {
        public bool IsDay { get; set; }
        public int NumCols { get; set; }
        public AccessLog Entrada { get; set; }
        public AccessLog Salida { get; set; }
    }
}