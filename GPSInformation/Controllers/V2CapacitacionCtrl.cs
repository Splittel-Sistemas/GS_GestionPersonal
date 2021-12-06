using System.Collections.Generic;
using GPSInformation.Exceptions;
using GPSInformation.Models;
using GPSInformation.Tools;
using GPSInformation.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using System.IO;
using Newtonsoft.Json;
using Itenso.TimePeriod;

namespace GPSInformation.Controllers
{
    public class V2CapacitacionCtrl
    {
        #region Atributos
        /// <summary>
        /// controlador de objetos 
        /// </summary>
        public DarkManager _darkM { get; internal set; }
        /// <summary>
        /// controlador para acciones de usuario
        /// </summary>
        public UsuarioCtrl _UsrCrt;
        /// <summary>
        /// Cargar transacciones por metodo
        /// </summary>
        public bool LoadTranssByMethod { get; set; }
        /// <summary>
        /// Id del usuario
        /// </summary>
        public int _IdUsuario { get; internal set; }
        /// <summary>
        /// Id de la persona
        /// </summary>
        public int _IdPersona { get; internal set; }
        public string _NombreCompleto { get; internal set; }
        public Dictionary<string, AccesosUs> _Accesos { get; internal set; }
        public int _IdVersionTeml { get; set; }
        public string _Key_templ_ = "TEMP";
        #endregion

        #region Constructores
        public V2CapacitacionCtrl(DarkManager darkManager, int IdUsuario, int IdPersona)
        {
            this._darkM = darkManager;
            this._IdUsuario = IdUsuario;
            this._IdPersona = IdPersona;
            this._darkM.OpenConnection();
            this._darkM.LoadObject(GpsManagerObjects.CatalogoOpcionesValores);
            this._darkM.LoadObject(GpsManagerObjects.View_empleado);
            this._darkM.LoadObject(GpsManagerObjects.View_EmpleadoJefe);
            this._darkM.LoadObject(GpsManagerObjects.AccesosSistema);
            this._darkM.LoadObject(GpsManagerObjects.Usuario);
            this._darkM.LoadObject(GpsManagerObjects.CapTempl);
            this._darkM.LoadObject(GpsManagerObjects.CapSess);
            this._darkM.LoadObject(GpsManagerObjects.CapTema);
            this._darkM.LoadObject(GpsManagerObjects.CapEva);
            this._darkM.LoadObject(GpsManagerObjects.CapEvaPrg);
            this._darkM.LoadObject(GpsManagerObjects.CapEvaPrgRes);
            //this._darkM.LoadObject(GpsManagerObjects.CapSessEva);
            this._darkM.LoadObject(GpsManagerObjects.CapProg);
            this._darkM.LoadObject(GpsManagerObjects.CapProgInstr);
            this._darkM.LoadObject(GpsManagerObjects.CapProgShedule);
            this._darkM.LoadObject(GpsManagerObjects.CapKardex);
            this._darkM.LoadObject(GpsManagerObjects.CapkardexCal);
            this._darkM.LoadObject(GpsManagerObjects.CapProgSheduleTimer);
            this._darkM.LoadObject(GpsManagerObjects.CapTemplShedule);
            this._darkM.LoadObject(GpsManagerObjects.CapRegistryStatus);
            this._darkM.LoadObject(GpsManagerObjects.CapRegistryVersion);
            this._darkM.LoadObject(GpsManagerObjects.CapRegistryVersionDet);

            _UsrCrt = new UsuarioCtrl(_darkM, true);

            _Accesos = new Dictionary<string, AccesosUs>();

            _NombreCompleto = _darkM.dBConnection.GetStringValue($"select NombreCompleto from View_empleado where IdPersona = {IdPersona}");

            _darkM.dBConnection._IdPersona = _IdPersona;
            _darkM.dBConnection._PersonaName = _NombreCompleto;

            //obtener permisos
            _Accesos["ACrearIncidencias"] = new AccesosUs { IdSubModulo = 25, TieneAcceso = _UsrCrt.ValidAction(IdUsuario, 1054) };
        }
        #endregion

        #region Programacion de capacitacioes
        /// <summary>
        /// delee persona
        /// </summary>
        /// <param name="IdCapProg"></param>
        /// <param name="IdPersonaPart"></param>
        public void CapKardexDelete(int IdCapProg, int IdPersonaPart)
        {
            var Prog = CapProgValidations(IdCapProg);
            var data = _darkM.CapKardex.GetOpenquerys($"where IdCapProg = {IdCapProg} and IdPersona = {IdPersonaPart}");
            if (data == null)
            {
                throw new GPException { Description = $"No fue encontrado el participante seleccionado", ErrorCode = 0, Category = TypeException.NotFound };
            }
            _darkM.CapKardex.Element = data;
            _darkM.CapKardex.Delete();

        }
        /// <summary>
        /// agregar persona
        /// </summary>
        /// <param name="IdCapProg"></param>
        /// <param name="IdPersonaPart"></param>
        /// <returns></returns>
        public CapKardex CapKardexCreate(int IdCapProg, int IdPersonaPart)
        {
            var Prog = CapProgValidations(IdCapProg);

            if(_darkM.CapKardex.Count($" IdCapProg = {IdCapProg} and IdPersona = {IdPersonaPart}") != 0)
            {
                throw new GPException { Description = $"Ya fue agregado esta persona a esta capacitacion", ErrorCode = 0, Category = TypeException.Info };
            }

            var data = new CapKardex
            {
                IdCapKardex = _darkM.CapKardex.GetLastId() + 1,
                IdCapProg = IdCapProg,
                IdPersona = IdPersonaPart,
                Nombre = _darkM.dBConnection.GetStringValue($"select NombreCompleto from View_empleado where IdPersona = {IdPersonaPart}"),
                Puesto = _darkM.dBConnection.GetStringValue($"select PuestoNombre from View_empleado where IdPersona = {IdPersonaPart}"),
                Departamento = _darkM.dBConnection.GetStringValue($"select NombreDepartamento from View_empleado where IdPersona = {IdPersonaPart}"),
                CalInicial = 0,
                CalFinal = 0,
                Intento = _darkM.dBConnection.GetIntegerValue($"select count(*) from CapKardex where IdPersona = {IdPersonaPart} and IdCapProg in(select IdCapProg from CapProg where IdCapTempl = {Prog.IdCapTempl})") + 1,
                Comentarios = "",
                Estatus = 1
            };
            _darkM.CapKardex.Element = data;
            _darkM.CapKardex.Add();
            return data;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="IdCapProg"></param>
        /// <param name="IdPersonaPart"></param>
        /// <returns></returns>
        public CapKardex CapKardexDetailsByEmp(int IdCapProg, int IdPersona)
        {
            return _darkM.CapKardex.GetOpenquerys($"where IdCapProg = {IdCapProg} and IdPersona = {IdPersona} and Estatus = 1");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="IdCapProg"></param>
        /// <returns></returns>
        public List<CapKardex> CapKardexDetailsProg(int IdCapProg)
        {
            return _darkM.CapKardex.GetOpenquery($"where IdCapProg = {IdCapProg} and Estatus = 1");
        }
        /// <summary>
        /// modificar horario de shedule tipo session
        /// </summary>
        /// <param name="IdCapProg"></param>
        /// <param name="IdCapProgShedule"></param>
        /// <param name="Fecha"></param>
        /// <param name="Inicio"></param>
        /// <param name="Fin"></param>
        /// <param name="Modalidad"></param>
        public void CapProgSheduleEdit(int IdCapProg,int IdCapProgShedule,  DateTime Fecha, TimeSpan Inicio, TimeSpan Fin, string Modalidad)
        {
            var Prog = CapProgValidations(IdCapProg);
            var data = _darkM.CapProgShedule.GetOpenquerys($"where IdCapProgShedule = {IdCapProgShedule} and IdCapProg ={IdCapProg}");
            if (data is null)
            {
                throw new GPException { Description = $"No se encontró el shedule", ErrorCode = 0, Category = TypeException.NotFound };
            }
            ////"SES" :"EVA",
            //if (data.TipoShedule != "SES")
            //{
            //    throw new GPException { Description = $"Acción no valida para Sesiones", ErrorCode = 0, Category = TypeException.Info };
            //}

            data.Fecha = Fecha;
            data.Inicio = Inicio;
            data.Fin = Fin;
            data.Modalidad = Modalidad;

            _darkM.CapProgShedule.Element = data;
            _darkM.CapProgShedule.Update();


            // actualizar fecha
            CapProgUpdateDate(Prog);
        }
        /// <summary>
        /// eliminar instructor
        /// </summary>
        /// <param name="IdCapProg"></param>
        /// <param name="IdCapProgInstr"></param>
        public void CapProgInstrDelete(int IdCapProg, int IdCapProgInstr)
        {
            var Prog = CapProgValidations(IdCapProg);
            var data = _darkM.CapProgInstr.GetOpenquerys($"where IdCapProgInstr = {IdCapProgInstr} and IdCapProg ={IdCapProg}");
            if(data is null)
            {
                throw new GPException { Description = $"El instructor seleccionado no fue encontrado o no pertence a esta capacitación", ErrorCode = 0, Category = TypeException.NotFound };
            }

            _darkM.CapProgInstr.Element = data;
            _darkM.CapProgInstr.Delete();
            // actualizar fecha
            CapProgUpdateDate(Prog);
        }
        /// <summary>
        /// agregar un instructor
        /// </summary>
        /// <param name="IdCapProg"></param>
        /// <param name="IdPersonaIns"></param>
        /// <param name="Tipo"></param>
        /// <param name="Nombre"></param>
        /// <param name="Ocupacion"></param>
        /// <returns></returns>
        public CapProgInstr CapProgInstrCreate(int IdCapProg, int IdPersonaIns, string Tipo, string Nombre, string Ocupacion)
        {
            var Prog = CapProgValidations(IdCapProg);

            //validar datos del instructor
            if(Tipo == "EXT")
            {
                if(string.IsNullOrEmpty(Nombre) || string.IsNullOrEmpty(Ocupacion)) 
                    throw new GPException { Description = $"Por favor introduce el nombre y ocupacion del instructor", ErrorCode = 0, Category = TypeException.Info };
            }
            else
            {
                if(IdPersonaIns == 0 || IdPersonaIns != 0 && string.IsNullOrEmpty(_darkM.dBConnection.GetStringValue($"select NombreCompleto from View_empleado where IdPersona = {IdPersonaIns}")))
                    throw new GPException { Description = $"Por favor selecciona un instructor", ErrorCode = 0, Category = TypeException.Info };
            }

            // crear midelo de ingreso a base de datos
            var data = new CapProgInstr
            {
                IdCapProgInstr = _darkM.CapProgInstr.GetLastId() + 1,
                IdPersona = IdPersonaIns,
                IdCapProg = IdCapProg,
                Tipo =Tipo,
                Nombre = Tipo == "EXT" ?  Nombre : _darkM.dBConnection.GetStringValue($"select NombreCompleto from View_empleado where IdPersona = {IdPersonaIns}"),
                Ocupacion = Tipo == "EXT" ? Ocupacion : _darkM.dBConnection.GetStringValue($"select PuestoNombre from View_empleado where IdPersona = {IdPersonaIns}"),
                Creada = DateTime.Now,
                Editada = DateTime.Now,
            };
            _darkM.CapProgInstr.Element = data;
            _darkM.CapProgInstr.Add();

            // actualizar fecha
            CapProgUpdateDate(Prog);
            return data;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<CapProgInstr> CapProgInstrByProg(int IdCapProg)
        {
            return _darkM.CapProgInstr.GetOpenquery($"where IdCapProg = {IdCapProg}");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Prog"></param>
        private void CapProgUpdateDate(CapProg Prog)
        {
            // actualizar fecha
            Prog.Editada = DateTime.Now;
            _darkM.CapProg.Element = Prog;
            _darkM.CapProg.Update();
        }
        /// <summary>
        /// editar programacion de capacitacion
        /// </summary>
        /// <param name="IdCapProg"></param>
        /// <param name="Modalidad"></param>
        public void CapProgEdit(int IdCapProg, string Modalidad)
        {
            var data = CapProgValidations(IdCapProg);
            if (data.Modalidad != Modalidad)
            {
                data.Modalidad = Modalidad;
                data.Editada = DateTime.Now;

                _darkM.CapProg.Element = data;
                _darkM.CapProg.Update();
            }
            
        }
        /// <summary>
        /// Crear una nueva programacion de capacitacion
        /// </summary>
        /// <param name="IdCapTempl"></param>
        /// <param name="IdVersion"></param>
        /// <param name="Modalidad"></param>
        /// <returns></returns>
        public CapProg CapProgCreate(int IdCapTempl, int IdVersion, string Modalidad)
        {
            _IdVersionTeml = IdVersion;
            if (CapVersionGetLastValue(_Key_templ_, IdCapTempl, "Estatus", "0", VersionLogTypeData.int_) != 4)
            {
                throw new GPException { Description = $"La capacitacion seleccionada no se encuentra dispoible", ErrorCode = 0, Category = TypeException.Info };
            }
            var det_temp = CapTemplDetails(IdCapTempl);
            var data = new CapProg
            {
                IdCapProg = _darkM.CapProg.GetLastId() + 1,
                NombreCap = det_temp.Nombre,
                IdVersion = IdVersion,
                IdCapTempl = IdCapTempl,
                Modalidad = Modalidad,
                Estatus = 1,
                Creada = DateTime.Now,
                Editada = DateTime.Now,
            };
            _darkM.CapProg.Element = data;
            _darkM.CapProg.Add();

            ////obtener esquema de estructura
            var agenda = GetShedule(IdCapTempl);
            int index = 0;
            agenda.ForEach(age =>
            {
                _IdVersionTeml = IdVersion;
                var shedl = new CapProgShedule
                {
                    IdCapProgShedule = _darkM.CapProgShedule.GetLastId() + 1,
                    IdCapProg = data.IdCapProg,
                    IdCapTemplShedule = age.IdCapTemplShedule,
                    IdVersion = age.Tipo == 1 ? IdVersion : age.IdCapRegistryVersionDet,
                    Modalidad = Modalidad,
                    FijarTime = false,
                    TipoEva =  "--",
                    TipoShedule = age.Tipo == 1 ? "SES" :"EVA",
                    Actual = index == 0 ?  true: false,
                    NombreStep = age.Tipo == 1 ? CapSessDetails(IdCapTempl,age.IdRefer).Nombre : CapEvaDetails(age.IdRefer, age.IdCapRegistryVersionDet).Nombre
                };
                index++;

                _darkM.CapProgShedule.Element = shedl;
                _darkM.CapProgShedule.Add();

            });

            return data;
        }
        /// <summary>
        /// obtener data y aplciar validaciones
        /// </summary>
        /// <param name="IdCapProg"></param>
        /// <returns></returns>
        private CapProg CapProgValidations(int IdCapProg, bool ApplyExceptions = true)
        {
            var data = _darkM.CapProg.Get(IdCapProg);
            if (data is null)
            {
                throw new GPException { Description = $"La capacitacion seleccionada no fue encontrada", ErrorCode = 0, Category = TypeException.NotFound };
            }

            if(data.Estatus != 1 && ApplyExceptions)
            {
                throw new GPException { Description = $"La capacitacion se encuentra en estatus: {data.LabelStatus()} y no puede ser editada", ErrorCode = 0, Category = TypeException.Info };
            }
            return data;
        }
        /// <summary>
        /// /
        /// </summary>
        /// <param name="IdCapProg"></param>
        /// <returns></returns>
        public CapProg CapProgdetails(int IdCapProg)
        {
            return CapProgValidations(IdCapProg, false);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="IdCapProg"></param>
        /// <returns></returns>
        public List<CapProgShedule> CapProgSheduleListProg(int IdCapProg)
        {
            var data =  _darkM.CapProgShedule.GetOpenquery($"where IdCapProg = {IdCapProg}", "");

            data.ForEach(a =>
            {
                var agenda = CapProgSheduleTimerDetails(a.IdCapProgShedule, getactive: true);
                if(agenda != null)
                {
                    a.Fecha = agenda.Fecha;
                    a.Inicio = agenda.Inicio;
                    a.Fin = agenda.Fin;
                    a.Modalidad = agenda.Modalidad;
                }
            });

            return data;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<CapProg> CapCapProgList()
        {
            return _darkM.CapProg.GetOpenquery($"", "");
        }

        /// <summary>
        /// Lista de capcaitaciones por usuario
        /// </summary>
        /// <param name="IdPersona"></param>
        /// <returns></returns>
        public List<CapProg> CapCapProgListByeEmp(int IdPersona)
        {
            return _darkM.CapProg.GetOpenquery($"where Estatus = 4 and IdCapProg in(select IdCapProg  from CapKardex where IdPersona = {IdPersona})", "Order by Creada Desc");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="IdCapProg"></param>
        /// <param name="Estatus"></param>
        public void CapProgSetEstatus(int IdCapProg, int Estatus)
        {
            var Prog = CapProgValidations(IdCapProg, false);

            if(Prog.Estatus != Estatus && Estatus > Prog.Estatus)
            {

                if(Estatus == 4 && _darkM.CapProg.GetIntValue($"select count(*) from CapProgShedule where IdCapProg = {IdCapProg} and Fecha is null") > 0)
                {
                    throw new GPException { Description = $"Por favor define todas las fechas para las sesiones y evaluaciones", ErrorCode = 0, Category = TypeException.Info };
                }

                Prog.Estatus = Estatus;
                _darkM.CapProg.Element = Prog;
                _darkM.CapProg.Update();
            }
            else
            {
                throw new GPException { Description = $"Por favor selecciona un estatus correcto", ErrorCode = 0, Category = TypeException.Info };
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="IdCapProg"></param>
        /// <returns></returns>
        public ITimePeriodCollection GetGapsShedule(int IdCapProg)
        {
            var horario = CapProgSheduleListProg(IdCapProg);

            TimePeriodCollection allappointments = new TimePeriodCollection();
            horario.ForEach(she =>
            {
                if (she.Fecha != null)
                {
                    allappointments.Add(new TimeRange(DateTime.Parse($"{string.Format("{0:yyyy-MM-dd}",she.Fecha)} {string.Format("{0:C}", she.Inicio)}"), DateTime.Parse($"{string.Format("{0:yyyy-MM-dd}", she.Fecha)} {string.Format("{0:C}", she.Fin)}")));
                }
            });
            TimePeriodIntersector<TimeRange> periodIntersector = new TimePeriodIntersector<TimeRange>();

            ITimePeriodCollection timePeriods = periodIntersector.IntersectPeriods(allappointments);

            return timePeriods;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="IdCapProg"></param>
        /// <param name="IdCapProgShedule"></param>
        /// <param name="Fecha"></param>
        /// <param name="Inicio"></param>
        /// <param name="Fin"></param>
        /// <param name="Modalidad"></param>
        /// <returns></returns>
        public CapProgShedule CapProgSheduleTimerAdd(int IdCapProg, int IdCapProgShedule, DateTime? Fecha, TimeSpan Inicio, TimeSpan Fin, string Modalidad, string TipoEVa)
        {
            var Prog = CapProgValidations(IdCapProg, false);
            var old = CapProgSheduleTimerDetails(IdCapProgShedule, getactive: true);
            if (Prog.Estatus != 1 && Prog.Estatus != 4)
            {
                throw new GPException { Description = $"La capacitacion se encuentra en estatus: {Prog.LabelStatus()} y no puede ser editada", ErrorCode = 0, Category = TypeException.Info };
            }
            try
            {
                DateTime MiFechita = DateTime.MinValue;
                _darkM.dBConnection.StartProcedure($"SP_CapValidSheduleTimerAgenda", new List<ProcedureModel>
                {
                    new ProcedureModel { Namefield = "IdCapProg", value = IdCapProg },
                    new ProcedureModel { Namefield = "IdCapProgShedule", value = IdCapProgShedule },
                    new ProcedureModel { Namefield = "Fecha", value = Fecha },
                    new ProcedureModel { Namefield = "Inicio", value = Inicio },
                    new ProcedureModel { Namefield = "Fin", value = Fin },
                    new ProcedureModel { Namefield = "Modalidad", value = Modalidad },
                    new ProcedureModel { Namefield = "TipoEVa", value = TipoEVa },
                    new ProcedureModel { Namefield = "IdPersona", value = _IdPersona },
                    new ProcedureModel { Namefield = "NombreCompleto", value = _NombreCompleto },
                });

                if (_darkM.dBConnection.ErrorCode != 0)
                    throw new GPException { Description = _darkM.GetLastMessage(), ErrorCode = 0, Category = TypeException.Info, IdAux = "" };
            }
            catch (GpExceptions ex)
            {
                throw new GPException { Description = $"Error al procesar esta solicitud", ErrorCode = 0, Category = TypeException.Info };
            }
            catch (GPException ex )
            {
                throw ex;
            }
            //if (string.Format("{0:c}", Inicio) == string.Format("{0:c}", Fin))
            //{
            //    throw new GPException { Description = $"La hora de inicio y fin no pueden ser iguales", ErrorCode = 0, Category = TypeException.Info };
            //}
            //if(Inicio > Fin)
            //{
            //    throw new GPException { Description = $"La hora de inicio es mayor a la hora fin", ErrorCode = 0, Category = TypeException.Info };
            //}
            //var a = _darkM.CapProgShedule.GetOpenquerys($"where IdCapProg = {IdCapProg} and  IdCapProgShedule = {IdCapProgShedule}");

            //if (old != null)
            //{
            //    if(old.Fecha != Fecha || old.Inicio != Inicio || old.Fin != Fin)
            //    {
            //        if(Prog.Estatus == 1)
            //        {
            //            old.Fecha = Fecha;
            //            old.Inicio = Inicio;
            //            old.Fin = Fin;
            //            _darkM.CapProgSheduleTimer.Element = old;
            //            _darkM.CapProgSheduleTimer.Update();
            //        }
            //        else
            //        {
            //            old.Actual = false;
            //            _darkM.CapProgSheduleTimer.Element = old;
            //            _darkM.CapProgSheduleTimer.Update();
            //        }
            //        // actualizar fecha
            //        CapProgUpdateDate(Prog);
            //    }
            //}
            //if(Prog.Estatus == 1)
            //{
            //    var newdata = new CapProgSheduleTimer
            //    {
            //        IdCapProgShedule = IdCapProgShedule,
            //        Actual = true,
            //        Fecha = Fecha,
            //        Fin = Fin,
            //        Inicio = Inicio,
            //        IdPersona = _IdPersona,
            //        Nombre = _NombreCompleto,
            //        Modalidad = Modalidad
            //    };
            //    _darkM.CapProgSheduleTimer.Element = newdata;
            //    _darkM.CapProgSheduleTimer.Add();

            //    a.Fecha = newdata.Fecha;
            //    a.Inicio = newdata.Inicio;
            //    a.Fin = newdata.Fin;
            //    a.Modalidad = newdata.Modalidad;
            //    a.TipoEva = TipoEVa;
            //    _darkM.CapProgShedule.Element = a;
            //    _darkM.CapProgShedule.Update();

            //    // actualizar fecha
            //    CapProgUpdateDate(Prog);
            //}
            return _darkM.CapProgShedule.GetOpenquerys($"where IdCapProg = {IdCapProg} and  IdCapProgShedule = {IdCapProgShedule}"); ;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="IdCapProgShedule"></param>
        /// <param name="IdCapProgSheduleTimer"></param>
        /// <param name="getactive"></param>
        /// <returns></returns>
        public CapProgSheduleTimer CapProgSheduleTimerDetails(int IdCapProgShedule, int IdCapProgSheduleTimer = 0, bool getactive= false)
        {
            CapProgSheduleTimer data = null;
            if(!getactive)
                data = _darkM.CapProgSheduleTimer.GetOpenquerys($"where IdCapProgSheduleTimer = {IdCapProgSheduleTimer} and IdCapProgShedule = {IdCapProgShedule}");
            else
            {
                data = _darkM.CapProgSheduleTimer.GetOpenquerys($"where IdCapProgSheduleTimer = {IdCapProgSheduleTimer}  and Actual = 1");
            }
            return data;
        }
        #endregion

        #region Log versions
        //private Func<string, string, bool> ValidDet = (TipoRef_,IdRefer_) => this._darkM.CapRegistryVersionDet.Count($" IdCapRegistryVersion = {_IdVersionTeml} and IdRefer = '{IdRefer_}' and Accion = 'DEL' and TipoRef = '{TipoRef_}'") != 0 ? true : false;
        /// <summary>
        /// verificar si un log ADD fue eliminado
        /// </summary>
        /// <param name="TipoRef_"></param>
        /// <param name="IdRefer_"></param>
        /// <returns></returns>
        private bool CapVersionIsDeletedDet(string TipoRef_, int IdRefer_)
        {
            return _darkM.CapRegistryVersionDet.Count($" IdCapRegistryVersion = {_IdVersionTeml} and IdRefer = '{IdRefer_}' and Accion = 'DEL' and TipoRef = '{TipoRef_}'") != 0 ? true : false;
        }
        /// <summary>
        /// obtener ultimo valor de cambio sobre una columna
        /// </summary>
        /// <param name="TipoRef_"></param>
        /// <param name="IdRefer_"></param>
        /// <param name="_ColName"></param>
        /// <param name="_ActualVal"></param>
        /// <returns></returns>
        private dynamic CapVersionGetLastValue(string TipoRef_, int IdRefer_, string _ColName, string _ActualVal, VersionLogTypeData typeData = VersionLogTypeData.string_)
        {
            var data = _darkM.CapRegistryVersionDet.GetOpenquerys($" where IdCapRegistryVersion = {_IdVersionTeml} and TipoRef= '{TipoRef_}' and IdRefer = '{IdRefer_}' and Accion = 'UPD' and Columna = '{_ColName}' order by Creada desc");
            if(data is null)
            {
                if(typeData == VersionLogTypeData.string_)
                    return string.IsNullOrEmpty(_ActualVal) ? "" : _ActualVal;
                else
                    return string.IsNullOrEmpty(_ActualVal) ? 0 : Int32.Parse(_ActualVal);
            }
            else
            {
                if (typeData == VersionLogTypeData.string_)
                    return string.IsNullOrEmpty(data.ValorNew) ? _ActualVal : data.ValorNew;
                else
                    return string.IsNullOrEmpty(data.ValorNew) ? Int32.Parse(_ActualVal) : Int32.Parse(data.ValorNew);
            }
        }
        /// <summary>
        /// activar version
        /// </summary>
        /// <param name="IdVersion"></param>
        /// <param name="TipoRef_"></param>
        /// <param name="IdRefer_"></param>
        public void CapVersionSetActive(int IdVersion, string TipoRef_, int IdRefer_)
        {
            var data = CapVersionDetails(TipoRef_, IdRefer_, IdVersion, true, true);

            var struc = CapEvaPrgList(IdRefer_, IdVersion);
            if(struc.Count == 0)
            {
                throw new GPException { Description = $"NO puede ser publicada una versión con cero preguntas, por favor agrega almenos una", ErrorCode = 0, Category = TypeException.Error };
            }
            else
            {
                if(struc.Where(a => a.Tipo == "O" && a.CapEvaPrgList.Count() == 0 || a.Tipo == "M" && a.CapEvaPrgList.Count() == 0).Count() > 0)
                {
                    throw new GPException { Description = $"Existen preguntas de opcion multiple sin ninguna respuesta", ErrorCode = 0, Category = TypeException.Error };
                }
                else
                {
                    if(struc.Where(a => a.Tipo == "O" && a.CapEvaPrgList.Where(b => b.EsCorrecta).Count() == 0).Count() != 0)
                    {
                        throw new GPException { Description = $"Existen preguntas tipo OPCIONAL sin ninguna respuesta correcta definida", ErrorCode = 0, Category = TypeException.Error };
                    }
                    else if (struc.Where(a => a.Tipo == "O" && a.CapEvaPrgList.Where(b => b.EsCorrecta).Count() == 0).Count() > 1)
                    {
                        throw new GPException { Description = $"Existen preguntas tipo OPCIONAL mas de una respuesta correcta definida", ErrorCode = 0, Category = TypeException.Error };
                    }else if (struc.Where(a => a.Tipo == "M" && a.CapEvaPrgList.Where(b => b.EsCorrecta).Count() == 0).Count() != 0)
                    {
                        throw new GPException { Description = $"Existen preguntas tipo MULTIPLE sin ninguna respuesta correcta definida", ErrorCode = 0, Category = TypeException.Error };
                    }

                }
            }

            data.Actual = true;

            _darkM.CapRegistryVersion.Element = data;
            _darkM.CapRegistryVersion.Update();

        }
        /// <summary>
        /// agregar detalle de log a version
        /// </summary>
        /// <param name="IdCapRegistryVersion_"></param>
        /// <param name="TipoRef_"></param>
        /// <param name="IdRefer_"></param>
        /// <param name="verDetAction"></param>
        /// <param name="Columna_"></param>
        /// <param name="ValorA_"></param>
        /// <param name="ValorNew_"></param>
        /// <returns></returns>
        private int CapVersionDetAdd(int IdCapRegistryVersion_, string TipoRef_, int IdRefer_, CapRegVerDetAction verDetAction, string Columna_ = "", string ValorA_ = "", string ValorNew_ = "") 
        {
            var data = new CapRegistryVersionDet
            {
                IdCapRegistryVersion = IdCapRegistryVersion_,
                TipoRef = TipoRef_,
                IdRefer = IdRefer_,
                IdPersona = _IdPersona,
                Nombre = _NombreCompleto,
                Accion = verDetAction == CapRegVerDetAction.Create ? "ADD" : verDetAction == CapRegVerDetAction.Update ? "UPD" : "DEL",
                Columna = Columna_,
                ValorA = ValorA_,
                ValorNew = ValorNew_
            };

            _darkM.CapRegistryVersionDet.Element = data;
            _darkM.CapRegistryVersionDet.Add();

            return _darkM.CapRegistryVersionDet.GetLastId();
        }
        /// <summary>
        /// crear version
        /// </summary>
        /// <param name="TipoRef_"></param>
        /// <param name="IdRefer_"></param>
        /// <param name="Data"></param>
        /// <param name="Comentarios"></param>
        /// <returns></returns>
        private int CapVersionAdd(string TipoRef_, int IdRefer_, object Data, string Comentarios)
        {
            var data = new CapRegistryVersion
            {
                TipoRef = TipoRef_,
                IdRefer = IdRefer_,
                Comentarios= Comentarios,
                Actual = false,
                IdPersona = _IdPersona,
                Nombre = _NombreCompleto,
                EstructuraJSON = JsonConvert.SerializeObject(Data),
            };

            _darkM.CapRegistryVersion.Element = data;
            _darkM.CapRegistryVersion.Add();


            return _darkM.CapRegistryVersion.GetLastId();
        }
        /// <summary>
        /// get version
        /// </summary>
        /// <param name="TipoRef_">Tipo de referencia</param>
        /// <param name="IdRefer_">objeto de versiones</param>
        /// <param name="IdVersion">Id de la version</param>
        /// <param name="valisExists"></param>
        /// <param name="activeModeEditRestr"></param>
        /// <returns></returns>
        public CapRegistryVersion CapVersionDetails(string TipoRef_, int IdRefer_,int IdVersion_, bool valisExists = false, bool activeModeEditRestr = false)
        {
            var data = _darkM.CapRegistryVersion.GetOpenquerys($"where TipoRef = '{TipoRef_}' and IdRefer = {IdRefer_} and IdCapRegistryVersion = {IdVersion_}");

            if(data is null && valisExists)
            {
                throw new GPException { Description = $"No fue contrada la versión dele elemento", ErrorCode = 0, Category = TypeException.Error };
            }

            if(data != null && data.Actual && activeModeEditRestr)
            {
                throw new GPException { Description = $"No es posible editar esta versión, si deseas editarla for favor genera otra versión", ErrorCode = 0, Category = TypeException.Error };
            }
            return data;
        }
        /// <summary>
        /// obtener versiones
        /// </summary>
        /// <param name="IdRefer_"></param>
        /// <param name="TipoRef_"></param>
        /// <returns></returns>
        public List<CapRegistryVersion> CapVersionList(int IdRefer_, string TipoRef_)
        {
            return _darkM.CapRegistryVersion.GetOpenquery($"where TipoRef = '{TipoRef_}' and IdRefer = {IdRefer_}", "");
        }
        #endregion

        #region Evaluaciones

        #region Preguntas
        /// <summary>
        /// Eliminar pregunta
        /// </summary>
        /// <param name="IdCapEva"></param>
        /// <param name="IdCapEvaPrg"></param>
        public void CapEvaPrgDelete(int IdCapEva, int IdVersion, int IdCapEvaPrg)
        {
            //var CapEva = CapEvaDetails(IdCapEva, true);
            //if (CapEva.Estatus != 1 && CapEva.Estatus != 2)
            //{
            //    throw new GPException { Description = $"No se puede modificar la evalución seleccionada, estatus actual: {CapEva.LabelStatus()}", ErrorCode = 0, Category = TypeException.Info };
            //}
            // obtener y validar version a editar
            var version = CapVersionDetails("EVA", IdCapEva, IdVersion, true, true);

            var CapEvaPrg_res = CapEvaPrgDeetails(IdCapEvaPrg, true);

            //borrar respuestas
            CapEvaPrg_res.CapEvaPrgList.ForEach(a =>
            {
                CapEvaPrgResDelete(IdCapEva, IdVersion, a.IdCapEvaPrg, a.IdCapEvaPrgRes);
            });
            CapEvaPrg_res.Eliminada = true;
            _darkM.CapEvaPrg.Element = CapEvaPrg_res;
            _darkM.CapEvaPrg.Update();

            // create log change version
            CapVersionDetAdd(
                version.IdCapRegistryVersion,
                "PRG",
                IdCapEvaPrg,
                CapRegVerDetAction.Delete
            );

        }
        /// <summary>
        /// editar pregunta
        /// </summary>
        /// <param name="IdCapEva"></param>
        /// <param name="IdCapEvaPrg"></param>
        /// <param name="Pregunta"></param>
        /// <param name="Comentarios"></param>
        /// <param name="Puntaje"></param>
        /// <param name="Tipo"></param>
        public void CapEvaPrgEdit(int IdCapEva, int IdVersion , int IdCapEvaPrg, string Pregunta, string Comentarios, int Puntaje, string Tipo)
        {
            //var CapEva = CapEvaDetails(IdCapEva, true);
            //if (CapEva.Estatus != 1 && CapEva.Estatus != 2)
            //{
            //    throw new GPException { Description = $"No se puede modificar la evalución seleccionada, estatus actual: {CapEva.LabelStatus()}", ErrorCode = 0, Category = TypeException.Info };
            //}
            // obtener y validar version a editar
            var version = CapVersionDetails("EVA", IdCapEva, IdVersion, true, true);

            var CapEvaPrg_res = CapEvaPrgDeetails(IdCapEvaPrg, true);

            if (Pregunta != CapEvaPrg_res.Pregunta || Comentarios != CapEvaPrg_res.Comentarios || Puntaje != CapEvaPrg_res.Puntaje || Tipo != CapEvaPrg_res.Tipo)
            {
                // create log change version
                if(CapEvaPrg_res.Pregunta != Pregunta) CapVersionDetAdd(version.IdCapRegistryVersion, "PRG", IdCapEvaPrg, CapRegVerDetAction.Update, "Pregunta", CapEvaPrg_res.Pregunta, Pregunta);
                if(CapEvaPrg_res.Comentarios != Comentarios) CapVersionDetAdd(version.IdCapRegistryVersion, "PRG", IdCapEvaPrg, CapRegVerDetAction.Update, "Comentarios", CapEvaPrg_res.Comentarios, Comentarios);
                if(CapEvaPrg_res.Tipo != Tipo) CapVersionDetAdd(version.IdCapRegistryVersion, "PRG", IdCapEvaPrg, CapRegVerDetAction.Update, "Tipo", CapEvaPrg_res.Tipo, Tipo);
                if(CapEvaPrg_res.Puntaje != Puntaje) CapVersionDetAdd(version.IdCapRegistryVersion, "PRG", IdCapEvaPrg, CapRegVerDetAction.Update, "Puntaje", CapEvaPrg_res.Puntaje+"", Puntaje+"");
                
                CapEvaPrg_res.Pregunta = Pregunta;
                CapEvaPrg_res.Comentarios = Comentarios;
                CapEvaPrg_res.Tipo = Tipo;
                CapEvaPrg_res.Puntaje = Puntaje;
                _darkM.CapEvaPrg.Element = CapEvaPrg_res;
                _darkM.CapEvaPrg.Update();

            }
        }
        /// <summary>
        /// Agregar pregunta a evaluacion
        /// </summary>
        /// <param name="IdCapEva"></param>
        /// <param name="Pregunta"></param>
        /// <param name="Comentarios"></param>
        /// <param name="Puntaje"></param>
        /// <param name="Tipo"></param>
        /// <returns></returns>
        public int CapEvaPrgAdd(int IdCapEva, int IdVersion, string Pregunta, string Comentarios, int Puntaje, string Tipo, List<CapEvaPrgRes> CapEvaPrgList)
        {
            //var CapEva = CapEvaDetails(IdCapEva, true);
            //if (CapEva.Estatus != 1 && CapEva.Estatus != 2)
            //{
            //    throw new GPException { Description = $"No se puede modificar la evalución seleccionada, estatus actual: {CapEva.LabelStatus()}", ErrorCode = 0, Category = TypeException.Info };
            //}
            // obtener y validar version a editar
            var version = CapVersionDetails("EVA", IdCapEva, IdVersion, true, true);
            //validar pregunta de tipo opcion 
            if (CapEvaPrgList == null || CapEvaPrgList != null && CapEvaPrgList.Count == 0 && Tipo != "T")
            {
                throw new GPException { Description = $"Por favor define las posibles respuestas a tu pregunta", ErrorCode = 0, Category = TypeException.Info };
            }
            var CapEvaPrg_res = new CapEvaPrg
            {
                IdCapEva = IdCapEva,
                Comentarios = Comentarios,
                Pregunta = Pregunta,
                Puntaje = Puntaje,
                Tipo = Tipo,
                IdCapEvaPrg = _darkM.CapEvaPrg.GetLastId() + 1
            };

            _darkM.CapEvaPrg.Element = CapEvaPrg_res;
            _darkM.CapEvaPrg.Add();
            CapVersionDetAdd(version.IdCapRegistryVersion, "PRG", CapEvaPrg_res.IdCapEvaPrg, CapRegVerDetAction.Create,ValorNew_: JsonConvert.SerializeObject(CapEvaPrg_res));
            CapEvaPrgList.ForEach(a =>
            {
                CapEvaPrgResAdd(IdCapEva, IdVersion, CapEvaPrg_res.IdCapEvaPrg, a.Respuesta, a.EsCorrecta);
            });

            return CapEvaPrg_res.IdCapEvaPrg;
        }
        /// <summary>
        /// Listar preguntas porevaluacion
        /// </summary>
        /// <param name="IdCapEvaPrg"></param>
        /// <returns></returns>
        public List<CapEvaPrg> CapEvaPrgList(int IdCapEva, int IdVersion)
        {
            // obtener preguntas
            var data = _darkM.CapEvaPrg.GetOpenquery($"where IdCapEva = {IdCapEva} and IdCapEvaPrg in (select IdRefer from CapRegistryVersionDet where IdCapRegistryVersion = {IdVersion} and TipoRef = 'PRG' and Accion = 'ADD' group by IdRefer)", "order by Creada asc");
            // obtener cambios en la version
            var changes = _darkM.CapRegistryVersionDet.GetOpenquery($"Where IdCapRegistryVersion = {IdVersion}");

            // eliminar preguntas
            changes.Where(a => a.TipoRef == "PRG" && a.Accion == "DEL").Select(a => a.IdRefer).ToList().ForEach(b =>
            {
                data.RemoveAll(c => c.IdCapEvaPrg == b);
            });
            // eliminar respuestas
            data.ForEach(a =>
            {
                // extraer datos de objeto agregado en esa version
                var logAdd = changes.Find(c => c.TipoRef == "PRG" && c.IdRefer == a.IdCapEvaPrg && c.Accion == "ADD");
                if(logAdd != null && logAdd.ValorNew.Trim() != "")
                {
                    var actua = JsonConvert.DeserializeObject<CapEvaPrg>(logAdd.ValorNew.Trim());
                    a.Comentarios = string.IsNullOrEmpty(actua.Comentarios) ? "" : actua.Comentarios;
                    a.Tipo = actua.Tipo;
                    a.Pregunta = actua.Pregunta;
                    a.Puntaje = actua.Puntaje;
                }


                var logs = changes.Where(c => c.TipoRef == "PRG" && c.IdRefer == a.IdCapEvaPrg && c.Accion == "UPD").ToList();


                var coment_last = logs.FindLast(c => c.Columna == "Comentarios");
                var tipo_last = logs.FindLast(c => c.Columna == "Tipo");
                var preg_last = logs.FindLast(c => c.Columna == "Pregunta");
                var puntaje_last = logs.FindLast(c => c.Columna == "Puntaje");


                a.Comentarios = coment_last != null ? coment_last.ValorNew : a.Comentarios;
                a.Tipo = tipo_last != null ? tipo_last.ValorNew : a.Tipo;
                a.Pregunta = preg_last != null ? preg_last.ValorNew : a.Pregunta;
                a.Puntaje = puntaje_last != null ? Int32.Parse(puntaje_last.ValorNew == "" ? "0" : puntaje_last.ValorNew)  : a.Puntaje;


                if (a.Tipo == "O" || a.Tipo == "M")
                {
                    a.CapEvaPrgList = new List<CapEvaPrgRes>();
                    CapEvaPrgResList(a.IdCapEvaPrg, IdVersion).ForEach(b =>
                    {

                        var last = changes.Where(c => c.TipoRef == "RES" && c.IdRefer == b.IdCapEvaPrgRes).ToList();
                        // procesar solo respuestas que no fueron eliminadas
                        if (last.Find(c => c.Accion == "DEL") is null && last.Find(c => c.Accion == "ADD") != null)
                        {
                            // extraer datos de objeto agregado en esa version
                            var logAdd_resp = last.Find(c => c.TipoRef == "RES" && c.IdRefer == b.IdCapEvaPrgRes && c.Accion == "ADD");
                            if (logAdd_resp != null && logAdd_resp.ValorNew.Trim() != "")
                            {
                                var actua = JsonConvert.DeserializeObject<CapEvaPrgRes>(logAdd_resp.ValorNew.Trim());
                                b.Respuesta = actua.Respuesta;
                                b.EsCorrecta = actua.EsCorrecta;
                            }



                            var resp_last_upd = last.FindLast(c => c.Accion == "UPD" && c.Columna == "Respuesta");
                            var esCorrecta_last_upd = last.FindLast(c => c.Accion == "UPD" && c.Columna == "EsCorrecta");

                            b.Respuesta = resp_last_upd != null ? resp_last_upd.ValorNew : b.Respuesta;
                            b.EsCorrecta = esCorrecta_last_upd != null ? (esCorrecta_last_upd.ValorNew == "Y" ? true : false) : b.EsCorrecta;

                            a.CapEvaPrgList.Add(b);
                        }

                    });
                }
            });

            return data;
        }
        /// <summary>
        /// Detalles de pregunta
        /// </summary>
        /// <param name="IdCapEvaPrg"></param>
        /// <param name="ShowExceNotFound"></param>
        /// <returns></returns>
        public CapEvaPrg CapEvaPrgDeetails(int IdCapEvaPrg, bool ShowExceNotFound = false)
        {
            var data = _darkM.CapEvaPrg.GetOpenquerys($"where IdCapEvaPrg = {IdCapEvaPrg}");

            if (data is null && ShowExceNotFound)
            {
                throw new GPException { Description = $"Registro no encontrado", ErrorCode = 0, Category = TypeException.NotFound };
            }

            data.CapEvaPrgList = CapEvaPrgResList(data.IdCapEvaPrg, 0);
            return data;
        }

        #endregion

        #region Respuestas
        /// <summary>
        /// eliminar 
        /// </summary>
        /// <param name="IdCapEvaPrg"></param>
        /// <param name="CapEvaPrgRes"></param>
        public void CapEvaPrgResDelete(int IdCapEva, int IdVersion, int IdCapEvaPrg, int CapEvaPrgRes)
        {
            var pregunta = CapEvaPrgDeetails(IdCapEvaPrg, true);
            //var CapEva = CapEvaDetails(pregunta.IdCapEva, true);

            //if (CapEva.Estatus != 1 && CapEva.Estatus != 2)
            //{
            //    throw new GPException { Description = $"No se puede modificar la evalución seleccionada, estatus actual: {CapEva.LabelStatus()}", ErrorCode = 0, Category = TypeException.Info };
            //}

            // obtener y validar version a editar
            var version = CapVersionDetails("EVA", IdCapEva, IdVersion, true, true);

            if (pregunta.Tipo == "T")
                throw new GPException { Description = $"No se pueden agregar respuestas a la pregunta: '{pregunta.Pregunta}', es tipo: '{pregunta.LabelStatus()}'", ErrorCode = 0, Category = TypeException.Info };

            var respuesta_obj = CapEvaPrgResDetails(CapEvaPrgRes);
            respuesta_obj.Eliminada = true;
            _darkM.CapEvaPrgRes.Element = respuesta_obj;
            _darkM.CapEvaPrgRes.Update();

            CapVersionDetAdd(version.IdCapRegistryVersion, "RES", CapEvaPrgRes, CapRegVerDetAction.Delete);
        }
        /// <summary>
        /// Editar respuesta
        /// </summary>
        /// <param name="IdCapEvaPrg"></param>
        /// <param name="CapEvaPrgRes"></param>
        /// <param name="Respuesta"></param>
        /// <param name="EsCorrect"></param>
        public void CapEvaPrgResEdit(int IdCapEva, int IdVersion, int IdCapEvaPrg, int CapEvaPrgRes, string Respuesta, bool EsCorrect)
        {
            var pregunta = CapEvaPrgDeetails(IdCapEvaPrg, true);
            //var CapEva = CapEvaDetails(pregunta.IdCapEva, true);

            //if (CapEva.Estatus != 1 && CapEva.Estatus != 2)
            //{
            //    throw new GPException { Description = $"No se puede modificar la evalución seleccionada, estatus actual: {CapEva.LabelStatus()}", ErrorCode = 0, Category = TypeException.Info };
            //}

            // obtener y validar version a editar
            var version = CapVersionDetails("EVA", IdCapEva, IdVersion, true, true);
            if (pregunta.Tipo == "T")
                throw new GPException { Description = $"No se pueden agregar respuestas a la pregunta: '{pregunta.Pregunta}', es tipo: '{pregunta.LabelStatus()}'", ErrorCode = 0, Category = TypeException.Info };

            var respuesta_obj = CapEvaPrgResDetails(CapEvaPrgRes);
            
            if(respuesta_obj.Respuesta != Respuesta) CapVersionDetAdd(version.IdCapRegistryVersion, "RES", CapEvaPrgRes, CapRegVerDetAction.Update, "Respuesta", respuesta_obj.Respuesta, Respuesta);
            if(respuesta_obj.EsCorrecta != EsCorrect) CapVersionDetAdd(version.IdCapRegistryVersion, "RES", CapEvaPrgRes, CapRegVerDetAction.Update, "EsCorrecta", respuesta_obj.EsCorrecta ? "Y" : "N", EsCorrect ? "Y" : "N");
            
            respuesta_obj.Respuesta = Respuesta;
            respuesta_obj.EsCorrecta = EsCorrect;
            _darkM.CapEvaPrgRes.Element = respuesta_obj;
            _darkM.CapEvaPrgRes.Update();

        }
        /// <summary>
        /// Agregar respuesta 
        /// </summary>
        /// <param name="IdCapEvaPrg"></param>
        /// <param name="Respuesta"></param>
        /// <param name="EsCorrecta"></param>
        /// <returns></returns>
        public int CapEvaPrgResAdd(int IdCapEva, int IdVersion, int IdCapEvaPrg, string Respuesta, bool EsCorrecta)
        {
            var pregunta = CapEvaPrgDeetails(IdCapEvaPrg, true);
            //var CapEva = CapEvaDetails(pregunta.IdCapEva, true);

            //if (CapEva.Estatus != 1 && CapEva.Estatus != 2)
            //{
            //    throw new GPException { Description = $"No se puede modificar la evalución seleccionada, estatus actual: {CapEva.LabelStatus()}", ErrorCode = 0, Category = TypeException.Info };
            //}

            // obtener y validar version a editar
            var version = CapVersionDetails("EVA", IdCapEva, IdVersion, true, true);

            if (pregunta.Tipo == "T")
                throw new GPException { Description = $"No se pueden agregar respuestas a la pregunta: '{pregunta.Pregunta}', es tipo: '{pregunta.LabelStatus()}'", ErrorCode = 0, Category = TypeException.Info };



            var respuesta = new CapEvaPrgRes
            {
                IdCapEvaPrgRes = _darkM.CapEvaPrgRes.GetLastId() + 1,
                IdCapEvaPrg = IdCapEvaPrg,
                Respuesta = Respuesta,
                EsCorrecta = EsCorrecta
            };

            _darkM.CapEvaPrgRes.Element = respuesta;
            _darkM.CapEvaPrgRes.Add();

            CapVersionDetAdd(version.IdCapRegistryVersion, "RES", respuesta.IdCapEvaPrgRes, CapRegVerDetAction.Create, ValorNew_: JsonConvert.SerializeObject(respuesta));

            return respuesta.IdCapEvaPrgRes;

        }
        /// <summary>
        /// Listado de respuestas por preguntas
        /// </summary>
        /// <param name="IdCapEvaPrg"></param>
        /// <returns></returns>
        public List<CapEvaPrgRes> CapEvaPrgResList(int IdCapEvaPrg, int IdVersion)
        {
            return _darkM.CapEvaPrgRes.GetOpenquery($"where IdCapEvaPrg = {IdCapEvaPrg} and IdCapEvaPrgRes in (select IdRefer from CapRegistryVersionDet where IdCapRegistryVersion <= {IdVersion} and TipoRef = 'RES' and Accion = 'ADD' group by IdRefer)", "");
        }
        /// <summary>
        /// extraer detalle de respuesta
        /// </summary>
        /// <param name="IdCapEvaPrgRes"></param>
        /// <param name="ShowExceNotFound"></param>
        /// <returns></returns>
        public CapEvaPrgRes CapEvaPrgResDetails(int IdCapEvaPrgRes, bool ShowExceNotFound = false)
        {
            var data = _darkM.CapEvaPrgRes.GetOpenquerys($"where IdCapEvaPrgRes = {IdCapEvaPrgRes}");

            if (data is null && ShowExceNotFound)
            {
                throw new GPException { Description = $"Registro no encontrado", ErrorCode = 0, Category = TypeException.NotFound };
            }

            



            return data;
        }

        #endregion

        #region Master eva
        /// <summary>
        /// listar versiones activas por capacitacion
        /// </summary>
        /// <returns></returns>
        public List<Object_version> CapTemplVersions()
        {
            var lista = new List<Object_version>();
            CapTemplList().ForEach(temp =>
            {
                var add_eva = new Object_version
                {
                    Id = temp.IdCapTempl,
                    Name = temp.Nombre,
                    Versiones = new List<Version_list>(),
                    Created = temp.Creada,
                    Updated = temp.Editada
                };
                //buscar versiones
                CapVersionList(temp.IdCapTempl, _Key_templ_).ForEach(ver =>
                {
                    _IdVersionTeml = ver.IdCapRegistryVersion;
                    if (CapVersionGetLastValue(_Key_templ_, temp.IdCapTempl, "Estatus", "0", VersionLogTypeData.int_) == 4)
                    {
                        add_eva.Versiones.Add(new Version_list
                        {
                            Id = ver.IdCapRegistryVersion,
                            Nombre = ver.Comentarios,
                            Autor = ver.Nombre,
                            Created = ver.Creada,
                            Updated = ver.Editada
                        });
                    }
                });
                if (add_eva.Versiones.Count > 0)
                {
                    lista.Add(add_eva);
                }
            });

            return lista;
        }
        /// <summary>
        /// listar evaluaciones con su respectiva version
        /// </summary>
        /// <returns></returns>
        public List<Object_version> CapEvaVersions()
        {
            var lista = new List<Object_version>();
            //obtener y procesar evaluaciones
            CapEvaList().ForEach(eva =>
            {
                var add_eva = new Object_version
                {
                    Id = eva.IdCapEva,
                    Name = eva.Nombre,
                    Versiones = new List<Version_list>(),
                    Created = eva.Creada,
                    Updated = eva.Editada
                };
                //buscar versiones
                CapVersionList(eva.IdCapEva, "EVA").ForEach(ver =>
                {
                    _IdVersionTeml = ver.IdCapRegistryVersion;
                    if (CapVersionGetLastValue("EVA", eva.IdCapEva,"Estatus", "0", VersionLogTypeData.int_) == 4)
                    {
                        add_eva.Versiones.Add(new Version_list
                        {
                            Id = ver.IdCapRegistryVersion,
                            Nombre =  ver.Comentarios,
                            Autor = ver.Nombre,
                            Created =  ver.Creada,
                            Updated =  ver.Editada
                        });
                    }
                });
                if(add_eva.Versiones.Count > 0)
                {
                    lista.Add(add_eva);
                }
            });
            return lista;
        }
        /// <summary>
        /// activar evaluacion 
        /// </summary>
        /// <param name="IdCapEva"></param>
        /// <param name="IdVersion"></param>
        /// <param name="Estatus"></param>
        public void CapEvaSetEstatus(int IdCapEva, int IdVersion, int Estatus) 
        {
            var cap = CapEvaDetails(IdCapEva, IdVersion, true);
            if (cap.Estatus != Estatus && Estatus != 0)
            {
                CapVersionDetAdd(IdVersion, "EVA", IdCapEva, CapRegVerDetAction.Update, "Estatus", cap.Estatus + "", Estatus + "");
            }
        }
        /// <summary>
        /// Editar evaluacion
        /// </summary>
        /// <param name="IdCapEva"></param>
        /// <param name="Nombre"></param>
        /// <param name="Instrucciones"></param>
        public void CapEvaEit(int IdCapEva, int IdVersion, string Nombre, string Instrucciones)
        {
            var capEva_res = CapEvaDetails(IdCapEva, IdVersion, true);

            if (capEva_res.Nombre != Nombre || capEva_res.Decripcion != Instrucciones)
            {
                if (capEva_res.Nombre != Nombre) CapVersionDetAdd(IdVersion, "EVA", IdCapEva, CapRegVerDetAction.Update, "Nombre", capEva_res.Nombre, Nombre);
                if (capEva_res.Decripcion != Instrucciones) CapVersionDetAdd(IdVersion, "EVA", IdCapEva, CapRegVerDetAction.Update, "Decripcion", capEva_res.Decripcion, Instrucciones);

                //    capEva_res.Nombre = Nombre;
                //    capEva_res.Decripcion = Instrucciones;
                //    _darkM.CapEva.Element = capEva_res;
                //    _darkM.CapEva.Update();
            }
        }
        /// <summary>
        /// registrar version de evaluacion
        /// </summary>
        /// <param name="IdCapEva"></param>
        /// <param name="Status_"></param>
        /// <param name="IdVersion"></param>
        /// <param name="Comentarios"></param>
        /// <returns></returns>
        public int CapEvaRegistryVersion(int IdCapEva, int Status_, int IdVersion, string Comentarios)
        {
            var capEva_res = CapEvaDetails(IdCapEva, IdVersion, true);
            if (Status_ == 0)
            {
                throw new GPException { Description = $"Por favor selecciona un estatus valido", ErrorCode = 0, Category = TypeException.Info };
            }
            // validar si el estao anterir es diferente al nuevo estatus
            //if (capEva_res.Estatus != Status_)
            //{
                //capEva_res.Estatus = Status_;
                //_darkM.CapEva.Element = capEva_res;
                //_darkM.CapEva.Update();

                // varlidar si estatus nuevo sera igual a DISPONIBLlE(4)
                int versionNEw = CapVersionAdd("EVA", IdCapEva, "", Comentarios);
                // registrar cambio de estatus
                //CapAddRegistryStatus(versionNEw, IdCapEva, Status_, "EVA");

                var ejemplo = CapEvaPrgList(IdCapEva, IdVersion);

                ejemplo.ForEach(pr =>
                {
                    var CapEvaPrg_res = new CapEvaPrg
                    {
                        IdCapEvaPrg = pr.IdCapEvaPrg,
                        Pregunta = pr.Pregunta,
                        Comentarios = pr.Comentarios,
                        Tipo = pr.Tipo,
                        Puntaje = pr.Puntaje,
                    };
                    CapVersionDetAdd(versionNEw, "PRG", CapEvaPrg_res.IdCapEvaPrg, CapRegVerDetAction.Create, ValorNew_: JsonConvert.SerializeObject(CapEvaPrg_res));
                    if(pr.CapEvaPrgList != null && pr.CapEvaPrgList.Count > 0)
                    {
                        pr.CapEvaPrgList.ForEach(rs =>
                        {
                            var respuesta = new CapEvaPrgRes
                            {
                                IdCapEvaPrgRes = rs.IdCapEvaPrgRes,
                                Respuesta = rs.Respuesta,
                                EsCorrecta = rs.EsCorrecta,
                            };
                            CapVersionDetAdd(versionNEw, "RES", respuesta.IdCapEvaPrgRes, CapRegVerDetAction.Create, ValorNew_: JsonConvert.SerializeObject(respuesta));
                        });
                    }
                    
                });

            return versionNEw;

            //}
        }
        /// <summary>
        /// Crearnueva evaluacion
        /// </summary>
        /// <param name="Nombre"></param>
        /// <param name="Instrucciones"></param>
        /// <returns></returns>
        public int CapEvaAdd(string Nombre, string Instrucciones)
        {
            CapEva capEva_res = null;

            if (string.IsNullOrEmpty(Nombre))
                throw new GPException { Description = $"El nombre de la evaluación no es valido", ErrorCode = 0, Category = TypeException.Info };

            capEva_res = new CapEva
            {
                Nombre = Nombre,
                Decripcion = Instrucciones,
                AplTime = false,
                HrsDurac = 1,
                Estatus = 1,
                IdCapEva = _darkM.CapEva.GetLastId() + 1
            };

            _darkM.CapEva.Element = capEva_res;

            _darkM.CapEva.Add();

            int versionNEw = CapVersionAdd("EVA", capEva_res.IdCapEva, "","Version creada por default");
            //CapAddRegistryStatus(versionNEw, capEva_res.IdCapEva, 1, "EVA");

            return capEva_res.IdCapEva;
        }
        /// <summary>
        /// Listar evaluaciones
        /// </summary>
        /// <returns></returns>
        public List<CapEva> CapEvaList()
        {
            return _darkM.CapEva.GetOpenquery($"", "order by Nombre desc");
        }
        /// <summary>
        /// Detalle de evaluacion
        /// </summary>
        /// <param name="IdCapEva"></param>
        /// <param name="ShowExceNotFound"></param>
        /// <returns></returns>
        public CapEva CapEvaDetails(int IdCapEva, int IdVersion, bool ShowExceNotFound = false)
        {
            var data = _darkM.CapEva.GetOpenquerys($"where IdCapEva = {IdCapEva}");

            if (data is null && ShowExceNotFound)
            {
                throw new GPException { Description = $"Registro no encontrado", ErrorCode = 0, Category = TypeException.NotFound };
            }
            _IdVersionTeml = IdVersion;
            data.Decripcion = CapVersionGetLastValue("EVA", IdCapEva, "Decripcion", data.Decripcion);
            data.Nombre = CapVersionGetLastValue("EVA", IdCapEva, "Nombre", data.Nombre);
            data.Estatus = CapVersionGetLastValue("EVA", IdCapEva, "Estatus", data.Estatus+"", VersionLogTypeData.int_);

            return data;
        }
        #endregion

        #endregion

        #region CapTema
        /// <summary>
        /// 
        /// </summary>
        /// <param name="IdCapTempl"></param>
        /// <param name="IdCapSess"></param>
        /// <param name="IdCapTema"></param>
        public void CapTemaDelete(int IdCapTempl, int IdCapSess, int IdCapTema)
        {
            var data_templ = CapTemplDetails(IdCapTempl, true);
            CapTemplValidActions(data_templ);

            var data_sess_ = CapSessDetails(IdCapTempl, IdCapSess, true);
            CapSessValidate(data_sess_);

            var data = CapTemaDetails(IdCapTema, true);

            CapVersionDetAdd(_IdVersionTeml, "TEM", IdCapTema, CapRegVerDetAction.Delete);

            //_darkM.CapTema.Element = data;
            //_darkM.CapTema.Delete();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="IdCapTempl"></param>
        /// <param name="IdCapSess"></param>
        /// <param name="IdCapTema"></param>
        /// <param name="Nombre"></param>
        /// <param name="Descripcion"></param>
        public void CapTemaUpdate(int IdCapTempl, int IdCapSess, int IdCapTema, string Nombre, string Descripcion)
        {
            var data_templ = CapTemplDetails(IdCapTempl, true);
            CapTemplValidActions(data_templ);

            var data_sess_ = CapSessDetails(IdCapTempl, IdCapSess, true);
            CapSessValidate(data_sess_);

            var data = CapTemaDetails(IdCapTema, true);

            if (data.Descripcion != Descripcion)
                CapVersionDetAdd(_IdVersionTeml, _Key_templ_, IdCapTema, CapRegVerDetAction.Update, "Descripcion", data.Descripcion, Descripcion);
            if (data.Nombre != Nombre)
                CapVersionDetAdd(_IdVersionTeml, _Key_templ_, IdCapTema, CapRegVerDetAction.Update, "Nombre", data.Nombre, Nombre);

            data.Nombre = Nombre;
            data.Descripcion = Descripcion;

            //_darkM.CapTema.Element = data;
            //_darkM.CapTema.Update();
        }
        /// <summary>
        /// Registrar tema para sessión
        /// </summary>
        /// <param name="capTema"></param>
        /// <returns></returns>
        public int CapTemaCreate(int IdCapTempl, int IdCapSess, string Nombre, string Descripcion)
        {
            var data_sess_ = CapSessDetails(IdCapTempl, IdCapSess, true);
            CapSessValidate(data_sess_);

            // validar estatus del template
            var data_templ = CapTemplDetails(data_sess_.IdCapTempl, true);
            CapTemplValidActions(data_templ);
            var data = new CapTema
            {
                IdCapTema = _darkM.CapTema.GetLastId() + 1,
                IdCapSess = IdCapSess,
                Nombre = Nombre,
                Descripcion = Descripcion,
                Eliminada = false
            };

            _darkM.CapTema.Element = data;
            _darkM.CapTema.Add();
            CapVersionDetAdd(_IdVersionTeml, "TEM", data.IdCapTema, CapRegVerDetAction.Create, ValorNew_: JsonConvert.SerializeObject(data));
            return data.IdCapTema;
        }
        /// <summary>
        /// Detalle de tema de una session
        /// </summary>
        /// <param name="IdCapTema"></param>
        /// <param name="ShowExceNotFound"></param>
        /// <returns></returns>
        public CapTema CapTemaDetails(int IdCapTema, bool ShowExceNotFound = false)
        {
            var log_data = _darkM.CapRegistryVersionDet.GetOpenquerys($"where IdCapRegistryVersion = {_IdVersionTeml} and IdRefer = '{IdCapTema}' and Accion = 'ADD' and TipoRef = 'TEM'");
            // validar si la session a ver detalles este agregada a lav ersion seleccionada
            if (log_data is null && ShowExceNotFound)
                throw new GPException { Description = $"No se encontró el tema seleccionado", ErrorCode = 0, Category = TypeException.NotFound };

            if (log_data!= null && ShowExceNotFound && CapVersionIsDeletedDet("TEM", IdCapTema))
                throw new GPException { Description = $"El tema seleccionado ha sido eliminado", ErrorCode = 0, Category = TypeException.NotFound };

            if (log_data is null)
                return null;


            var data = JsonConvert.DeserializeObject<CapTema>(log_data.ValorNew.Trim());
            //var data = _darkM.CapSess.GetOpenquerys($"where IdCapSess = {IdCapSess} and IdCapTempl = {IdCapTempl}");
            data.Creada = log_data.Creada;
            data.Editada = log_data.Editada;


            data.Nombre = CapVersionGetLastValue("TEM", IdCapTema, "Nombre", data.Nombre);
            data.Descripcion = CapVersionGetLastValue("TEM", IdCapTema, "Descripcion", data.Descripcion);


            //var data = _darkM.CapTema.Get(IdCapTema);
            //if (data is null && ShowExceNotFound)
            //    throw new GPException { Description = $"No se encontró el tema seleccionada", ErrorCode = 0, Category = TypeException.NotFound };



            return data;
        }
        /// <summary>
        /// Lista de temas por session seleccionada
        /// </summary>
        /// <param name="IdCapSess"></param>
        /// <returns></returns>
        public List<CapTema> CapTemaBySession(int IdCapSess)
        {
            List<CapTema> capTemas = new List<CapTema>();
           var data = _darkM.CapTema.GetOpenquery($" where IdCapSess = {IdCapSess}", "");
            data.RemoveAll(a => CapVersionIsDeletedDet("TEM", a.IdCapTema));
            data.ForEach(a => {
                var tem_det = CapTemaDetails(a.IdCapTema);
                if(tem_det != null) capTemas.Add(tem_det);
            });
            return data;
        }
        #endregion

        #region CapSess CRUD
        /// <summary>
        /// eliminar session de capacitacion
        /// </summary>
        /// <param name="IdCapTempl"></param>
        /// <param name="IdRefer"></param>
        public void CapSessDelete(int IdCapTempl, int IdRefer )
        {
            // validar que exista la capacitacion
            var CapTempl = CapTemplDetails(IdCapTempl, true);
            
            // validar que solo capacitaciones en estatus En proceso y En mantenimiento puedan ser editadas
            CapTemplValidActions(CapTempl);

            var CapSesDetails = CapSessDetails(IdCapTempl, IdRefer, true);
            CapVersionDetAdd(_IdVersionTeml, "SES", IdRefer, CapRegVerDetAction.Delete);


            //var capSess = GetSheduleid(IdCapTempl, IdRefer, true);
            /////eliminar los registros solo cuando el diseño esta siendo creado (Estatus = 1 - En proceso)
            //if(CapTempl.Estatus == 1)
            //{
            //    _darkM.CapTemplShedule.Element = capSess;
            //    _darkM.CapTemplShedule.Delete();


            //    _darkM.CapSess.Element = CapSessDetails(IdCapTempl, IdRefer, true);
            //    _darkM.CapSess.Element.Eliminada = true;
            //    _darkM.CapSess.Update();

            //}

            //if (capSess != null && !capSess.Eliminada)
            //{
            //    capSess.Eliminada = true;
            //    _darkM.CapTemplShedule.Element = capSess;
            //    _darkM.CapTemplShedule.Update();
            //}
        }
        /// <summary>
        /// /
        /// </summary>
        /// <param name="IdCapTempl"></param>
        /// <param name="IdCapSess"></param>
        /// <param name="Nombre"></param>
        /// <param name="Duracion"></param>
        public void CapSessEdit(int IdCapTempl, int IdCapSess, string Nombre, decimal Duracion, string Objetivo)
        {
            //validar objecto
            var capSess = CapSessDetails(IdCapTempl, IdCapSess, true);
            CapSessValidate(capSess);

            // validar que exista la capacitacion
            var CapTempl = CapTemplDetails(capSess.IdCapTempl, true);

            // validar que solo capacitaciones en estatus En proceso y En mantenimiento puedan ser editadas
            CapTemplValidActions(CapTempl);

            //crear copia para session cuando se tenga un estatus mayor

            //Editat capacitacion a nivel log y data registry
            if (capSess.Nombre != Nombre)
                CapVersionDetAdd(_IdVersionTeml, "SES", IdCapSess, CapRegVerDetAction.Update, "Clave", capSess.Nombre, Nombre);
            if (capSess.Objetivo != Objetivo)
                CapVersionDetAdd(_IdVersionTeml, "SES", IdCapSess, CapRegVerDetAction.Update, "Objetivo", capSess.Objetivo, Objetivo);
            if (capSess.Duracion != Duracion)
                CapVersionDetAdd(_IdVersionTeml, "SES", IdCapSess, CapRegVerDetAction.Update, "Duracion", capSess.Duracion + "", Duracion + "");

        }
        /// <summary>
        /// agregar session a capacitacion
        /// </summary>
        /// <param name="capSess"></param>
        /// <returns></returns>
        public int CapSessCreate(CapSess capSess)
        {
            //validar objecto
            ValidObj(capSess, $"Error, no se puede agregar la solicitud a la capacitación seleccionada");
            // validar que exista la capacitacion
            var CapTempl = CapTemplDetails(capSess.IdCapTempl, true);
            // validar que solo capacitaciones en estatus En proceso y En mantenimiento puedan ser editadas
            CapTemplValidActions(CapTempl);
            // registrar nueva sesion
            capSess.IdCapSess = _darkM.CapSess.GetLastId() + 1;
            capSess.NoSession = _darkM.CapSess.Count($" IdCapTempl = {capSess.IdCapTempl}  and Eliminada = 0") + 1;
            _darkM.CapSess.Element = capSess;
            _darkM.CapSess.Add();

            _darkM.CapTemplShedule.Element = new CapTemplShedule
            {
                IdCapTemplShedule = _darkM.CapTemplShedule.GetLastId() + 1,
                IdCapTempl = capSess.IdCapTempl,
                IdRefer = capSess.IdCapSess,
                Tipo = 1,
                Eliminada = false,
                Ordern = _darkM.CapTemplShedule.Count($" IdCapTempl = {capSess.IdCapTempl}") + 1
            };
            _darkM.CapTemplShedule.Add();
            // add log adding new session to the course
            CapVersionDetAdd(_IdVersionTeml, "SES", capSess.IdCapSess, CapRegVerDetAction.Create, ValorNew_: JsonConvert.SerializeObject(capSess));
            // editar numero de sesiones en el header de la capacitacion
            CapSessUpdateTotalTempl(CapTempl);

            return capSess.IdCapSess;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="CapTempl"></param>
        public void CapSessUpdateTotalTempl(CapTempl CapTempl)
        {
            //CapTempl.NoSesions = _darkM.CapSess.Count($" IdCapTempl = {CapTempl.IdCapTempl}  and Eliminada = 0");
            //_darkM.CapTempl.Element = CapTempl;
            //_darkM.CapTempl.Update();
        }
        /// <summary>
        /// xxxxxx Obtener lista de sessiones por capactacion
        /// </summary>
        /// <param name="IdCapTempl"></param>
        /// <returns></returns>
        public List<CapSess> CapSessByCapTempl(int IdCapTempl)
        {
            var data = _darkM.CapSess.GetOpenquery($"where IdCapTempl = {IdCapTempl}", "rder by NoSession");

            return data;
        }
        /// <summary>
        /// Obtener detalle de session
        /// </summary>
        /// <param name="IdCapSess">id de la session</param>
        /// <param name="ShowExceNotFound">Forzar excepcion</param>
        /// <returns></returns>ñ
        public CapSess CapSessDetails(int IdCapTempl, int IdCapSess, bool ShowExceNotFound = false)
        {
            var log_data = _darkM.CapRegistryVersionDet.GetOpenquerys($"where IdCapRegistryVersion = {_IdVersionTeml} and IdRefer = '{IdCapSess}' and Accion = 'ADD' and TipoRef = 'SES'");
            // validar si la session a ver detalles este agregada a lav ersion seleccionada
            if (log_data is null && ShowExceNotFound )
                throw new GPException { Description = $"No se encontró la sesión seleccionada", ErrorCode = 0, Category = TypeException.NotFound };

            if (ShowExceNotFound && _darkM.CapRegistryVersionDet.Count($" IdCapRegistryVersion = {_IdVersionTeml} and IdRefer = '{IdCapSess}' and Accion = 'DEL' and TipoRef = 'SES'") != 0)
                throw new GPException { Description = $"La sesión seleccionada ha sido eliminda", ErrorCode = 0, Category = TypeException.NotFound };

            var data = JsonConvert.DeserializeObject<CapSess>(log_data.ValorNew.Trim());
            //var data = _darkM.CapSess.GetOpenquerys($"where IdCapSess = {IdCapSess} and IdCapTempl = {IdCapTempl}");
            data.Creada = log_data.Creada;
            data.Editada = log_data.Editada;

            if (data.Objetivo is null) data.Objetivo = "";
            if (data.Nombre is null) data.Nombre = "";

            data.NoSession = Int32.Parse(CapVersionGetLastValue("SES", IdCapSess, "NoSession", data.NoSession + ""));
            data.Nombre = CapVersionGetLastValue("SES", IdCapSess, "Nombre", data.Nombre);
            data.Objetivo = CapVersionGetLastValue("SES", IdCapSess, "Objetivo", data.Objetivo);
            data.Duracion = decimal.Parse(CapVersionGetLastValue("SES", IdCapSess, "Duracion", data.Duracion + ""));

            return data;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="capSess"></param>
        private void CapSessValidate(CapSess capSess)
        {
            //if (capSess.Eliminada)
            //{
            //    throw new GPException { Description = $"No se encontró la sesión seleccionada", ErrorCode = 0, Category = TypeException.NotFound };
            //}
        }

        #endregion

        #region CapTempl CRUD

        public void CapTemplEvaDel(int IdCapTempl, int IdEvaCap, int IdCapRegistryVersionDet)
        {
            var data = _darkM.CapRegistryVersionDet.Get(IdCapRegistryVersionDet);
            if(data == null)
            {
                throw new GPException { Description = $"No se encontró GetSheduleid", ErrorCode = 0, Category = TypeException.NotFound };
            }
            if(data.ValorNew == "DEL")
            {
                throw new GPException { Description = $"Ya ha sido eliminada esta evaluación", ErrorCode = 0, Category = TypeException.NotFound };
            }
            CapVersionDetAdd(_IdVersionTeml, "EVA", data.IdRefer, CapRegVerDetAction.Delete, ValorNew_: "DEL");
            data.ValorNew = "DEL";
            _darkM.CapRegistryVersionDet.Element = data;

            _darkM.CapRegistryVersionDet.Update();
        }
        public CapTemplShedule CapTemplEvaAdd(int IdCapTempl, int IdEvaCap, int IdVersionEva)
        {
            _darkM.CapTemplShedule.Element = new CapTemplShedule
            {
                IdCapTemplShedule = _darkM.CapTemplShedule.GetLastId() + 1,
                IdCapTempl = IdCapTempl,
                IdRefer = IdEvaCap,
                IdVersion = IdVersionEva,
                Tipo = 2,
                Eliminada = false,
                Ordern = _darkM.CapTemplShedule.Count($" IdCapTempl = {IdCapTempl}") + 1
            };
            _darkM.CapTemplShedule.Add();
            // add log adding new session to the course
            _darkM.CapTemplShedule.Element.IdCapRegistryVersionDet = CapVersionDetAdd(_IdVersionTeml, "EVA", _darkM.CapTemplShedule.Element.IdCapTemplShedule, CapRegVerDetAction.Create, ValorA_: $"{IdEvaCap}#{IdVersionEva}");
            return _darkM.CapTemplShedule.Element;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="IdCapTempl"></param>
        /// <param name="Estatus"></param>
        public void CapTemplChageStatus(int IdCapTempl, int Estatus) 
        {
            var cap = CapTemplDetails(IdCapTempl, true);
            if(cap.Estatus != Estatus && Estatus != 0)
            {
                CapVersionDetAdd(_IdVersionTeml, _Key_templ_, IdCapTempl, CapRegVerDetAction.Update, "Estatus", cap.Estatus + "", Estatus + "");
            }
        }
        /// <summary>
        /// crear nueva version d un template
        /// </summary>
        /// <param name="IdCapTempl"></param>
        /// <param name="comentarios"></param>
        /// <returns></returns>
        public int CapTemplNewVersion(int IdCapTempl, string comentarios)
        {
            var data_cap = CapTemplDetails(IdCapTempl, true);
            data_cap.Estatus = 1;
            // guardar ultimo cambio de la version a continuar
            int newversion = CapVersionAdd(_Key_templ_, IdCapTempl, JsonConvert.SerializeObject(data_cap), comentarios);
            CapVersionDetAdd(newversion, _Key_templ_, IdCapTempl, CapRegVerDetAction.Create, ValorNew_: JsonConvert.SerializeObject(data_cap));
            // obtener shedule y agregar ultimo detalle 
            GetShedule(IdCapTempl).ForEach(shedl =>
            {
                if(shedl.Tipo == 1)
                {
                    var session = CapSessDetails(IdCapTempl, shedl.IdRefer);
                    CapVersionDetAdd(newversion, "SES", shedl.IdRefer, CapRegVerDetAction.Create, ValorNew_: JsonConvert.SerializeObject(session));

                    CapTemaBySession(shedl.IdRefer).ForEach(tem =>
                    {
                        CapVersionDetAdd(newversion, "TEM", tem.IdCapTema, CapRegVerDetAction.Create, ValorNew_: JsonConvert.SerializeObject(tem));
                    });
                }  
            });
            return newversion;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="IdCapTempl"></param>
        /// <param name="Clave"></param>
        /// <param name="Nombre"></param>
        /// <param name="Objetivo"></param>
        /// <param name="CalRepet"></param>
        public void CapTemplEdit(int IdCapTempl, string Clave, string Nombre, string Descripcion, string Objetivo, decimal CalRepet)
        {
            var data = CapTemplDetails(IdCapTempl, true);

            CapTemplValidActions(data);

            if (data.Clave != Clave)
                CapVersionDetAdd(_IdVersionTeml, _Key_templ_, IdCapTempl, CapRegVerDetAction.Update, "Clave", data.Clave, Clave);
            if (data.Nombre != Nombre)
                CapVersionDetAdd(_IdVersionTeml, _Key_templ_, IdCapTempl, CapRegVerDetAction.Update, "Nombre", data.Nombre, Nombre);
            if (data.Descripcion != Descripcion)
                CapVersionDetAdd(_IdVersionTeml, _Key_templ_, IdCapTempl, CapRegVerDetAction.Update, "Descripcion", data.Descripcion, Descripcion);
            if (data.Objetivo != Objetivo)
                CapVersionDetAdd(_IdVersionTeml, _Key_templ_, IdCapTempl, CapRegVerDetAction.Update, "Objetivo", data.Objetivo, Objetivo);
            if (data.CalRepet != CalRepet)
                CapVersionDetAdd(_IdVersionTeml, _Key_templ_, IdCapTempl, CapRegVerDetAction.Update, "CalRepet", data.CalRepet+"", CalRepet+"");

            //data.Clave = Clave;
            //data.Nombre = Nombre;
            //data.Descripcion = Descripcion;
            //data.Objetivo = Objetivo;
            //data.CalRepet = CalRepet;

            //_darkM.CapTempl.Element = data;

            //_darkM.CapTempl.Update();

        }
        /// <summary>
        /// Crear template header
        /// </summary>
        /// <param name="capTempl">dataset para crear nuevo template de capacitacion</param>
        /// <returns></returns>
        public int CapTemplCreate(CapTempl capTempl)
        {
            ValidObj(capTempl, $"Información incorrecta o no enviada");

            //if (_darkM.dBConnection.GetIntegerValue($"select count(*) from CapTempl where ClvVersion = '{capTempl.ClvVersion}'") > 0)
            //    throw new GPException { Description = $"Por favor selecciona otra clave, la clave '{capTempl.ClvVersion}' ya se encuentra en uso", ErrorCode = 0, Category = TypeException.Info, IdAux = "ClvVersion" };

            capTempl.IdCapTempl = _darkM.CapTempl.GetLastId() + 1;
            capTempl.Estatus = 1;

            _darkM.CapTempl.Element = capTempl;

            _darkM.CapTempl.Add();

            _IdVersionTeml = CapVersionAdd(_Key_templ_, capTempl.IdCapTempl, JsonConvert.SerializeObject(capTempl), "Versión creada por GPS");
            CapVersionDetAdd(_IdVersionTeml, _Key_templ_, capTempl.IdCapTempl, CapRegVerDetAction.Create, ValorNew_: JsonConvert.SerializeObject(capTempl));
            return capTempl.IdCapTempl;
        }
        /// <summary>
        /// detalle de template header
        /// </summary>
        /// <param name="IdCapTempl">Id del template de capacitacion</param>
        /// <param name="ShowExceNotFound">Mostrar excepcion si no se encuentra el template</param>
        /// <returns></returns>
        public CapTempl CapTemplDetails(int IdCapTempl, bool ShowExceNotFound = false)
        {
            var log_data = _darkM.CapRegistryVersionDet.GetOpenquerys($"where IdCapRegistryVersion = {_IdVersionTeml} and IdRefer = '{IdCapTempl}' and Accion = 'ADD' and TipoRef = '{_Key_templ_}'");
            // validar si la session a ver detalles este agregada a lav ersion seleccionada
            if (log_data is null && ShowExceNotFound)
                throw new GPException { Description = $"No se encontró la evaluación seleccionada", ErrorCode = 0, Category = TypeException.NotFound };

            //if (ShowExceNotFound && _darkM.CapRegistryVersionDet.Count($" IdCapRegistryVersion = {_IdVersionTeml} and IdRefer = '{IdCapTempl}' and Accion = 'DEL' and TipoRef = '{_Key_templ_}'") != 0)
            //    throw new GPException { Description = $"La sesión seleccionada ha sido eliminda", ErrorCode = 0, Category = TypeException.NotFound };

            var data = JsonConvert.DeserializeObject<CapTempl>(log_data.ValorNew.Trim());

            data.Clave = CapVersionGetLastValue(_Key_templ_, IdCapTempl, "Clave", data.Clave);
            data.Nombre = CapVersionGetLastValue(_Key_templ_, IdCapTempl, "Nombre", data.Nombre);
            data.Descripcion = CapVersionGetLastValue(_Key_templ_, IdCapTempl, "Descripcion", data.Descripcion);
            data.Objetivo = CapVersionGetLastValue(_Key_templ_, IdCapTempl, "Objetivo", data.Objetivo);
            data.Estatus = Int32.Parse(CapVersionGetLastValue(_Key_templ_, IdCapTempl, "Estatus", data.Estatus + ""));

            string callRepet = CapVersionGetLastValue(_Key_templ_, IdCapTempl, "CalRepet", data.CalRepet + "");
            data.CalRepet = string.IsNullOrEmpty(callRepet) ? 0 : decimal.Parse(callRepet);

            return data;
        }
        /// <summary>
        /// listado del esquema de capacitacion
        /// </summary>
        /// <param name="IdCapTempl"></param>
        /// <returns></returns>
        public List<CapTemplShedule> GetShedule(int IdCapTempl)
        {
            List<CapTemplShedule> list = new List<CapTemplShedule>();
            var data = _darkM.CapTemplShedule.GetOpenquery($"where IdCapTempl = {IdCapTempl}", "");

            // obtener cambios en la version
            var changes = _darkM.CapRegistryVersionDet.GetOpenquery($"Where IdCapRegistryVersion = {_IdVersionTeml}");
            data.ForEach(a =>
            {
                if(a.Tipo == 1)
                {
                    if(changes.Count(b => b.TipoRef == "SES" && b.Accion == "ADD" && b.IdRefer == a.IdRefer) > 0)
                    {
                        if (changes.Count(b => b.TipoRef == "SES" && b.Accion == "DEL" && b.IdRefer == a.IdRefer) <= 0) 
                        {
                            //a.IdCapRegistryVersionDet = b.IdCapRegistryVersionDet;
                            list.Add(a);
                        }
                    }
                }
                if (a.Tipo == 2)
                {
                    var FindLog = changes.Find(b => b.TipoRef == "EVA" && b.Accion == "ADD" && b.IdRefer == a.IdCapTemplShedule && string.IsNullOrEmpty(b.ValorNew) );
                    if (FindLog != null)
                    {
                        a.IdCapRegistryVersionDet = FindLog.IdCapRegistryVersionDet;
                        list.Add(a);
                    }
                }
            });
            list.ForEach(a =>
            {
                a.Ordern = CapVersionGetLastValue("SHD", a.IdCapTemplShedule, "Ordern", a.Ordern+"", VersionLogTypeData.int_);
            });
            //// eliminar sessiones o evaluaciones
            //data.RemoveAll(a => changes.Where(b => b.Accion == "DEL" && b.TipoRef == "SES" || b.Accion == "DEL" && b.TipoRef == "EVA").Select(b => b.IdRefer).Contains(a.IdRefer) || !changes.Where(b => b.Accion == "ADD").Select(b => b.IdRefer).Contains(a.IdRefer));
            ////data.ForEach(a =>
            ////{
            ////    if(a.Tipo == 1)
            ////        a.Title = _darkM.CapTemplShedule.GetStringValue($"select top 1 Nombre from CapSess where IdCapSess = {a.IdRefer}");
            ////});
            return list.OrderBy(a => a.Ordern).ToList();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="IdCapTempl"></param>
        /// <param name="IdRefer"></param>
        /// <param name="ShowExceNotFound"></param>
        /// <returns></returns>
        public CapTemplShedule GetSheduleid(int IdCapTempl, int IdRefer, bool ShowExceNotFound = false)
        {
            var data = _darkM.CapTemplShedule.GetOpenquerys($"where IdCapTempl = {IdCapTempl} and IdRefer = {IdRefer}");

            if (data is null && ShowExceNotFound)
                throw new GPException { Description = $"No se encontró GetSheduleid", ErrorCode = 0, Category = TypeException.NotFound };

            if (data != null && data.Tipo == 1)
                data.Title = _darkM.CapTemplShedule.GetStringValue($"select top 1 Nombre from CapSess where IdCapSess = {data.IdRefer}");
            return data;
        }
        /// <summary>
        /// List de templates de capacitaciones
        /// </summary>
        /// <param name="capTemplEstatus">Tipo de capacitaciones a Mostrar</param>
        /// <returns></returns>
        public List<CapTempl> CapTemplList(CapTemplEstatus capTemplEstatus = CapTemplEstatus.Todas)
        {
            if (capTemplEstatus == CapTemplEstatus.Todas)
                return _darkM.CapTempl.GetOpenquery($"", "Order by Nombre");
            else
                return _darkM.CapTempl.GetOpenquery($"where Estatus = {((int)capTemplEstatus)}", "Order by Nombre");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        private void CapTemplValidActions(CapTempl data)
        {
            if (data.Estatus != 1 && data.Estatus != 2)
                throw new GPException { Description = $"No se puede modificar la capacitacion: '{data.Nombre}', estatus actual: '{data.LabelStatus()}'", ErrorCode = 0, Category = TypeException.Info, IdAux = "ClvVersion" };

        }
        #endregion

        #region Generales
        /// <summary>
        /// /control de estatus de elemento
        /// </summary>
        /// <param name="IdRefer_">Id referncia</param>
        /// <param name="Status_">status</param>
        /// <param name="TipoRef_">Tipo de referencia [EVA, TEMP]</param>
        private void CapAddRegistryStatus(int IdCapRegistryVersion_, int IdRefer_, int Status_, string TipoRef_)
        {
            var OldReg = _darkM.CapRegistryStatus.GetOpenquerys($"where TipoRef = '{TipoRef_}' and IdRefer = {IdRefer_} and Actual = 1");
            if(OldReg != null)
            {
                if(OldReg.Estatus != Status_)
                {
                    //OldReg.Actual = false;
                    OldReg.Fin = DateTime.Now;
                    _darkM.CapRegistryStatus.Element = OldReg;
                    _darkM.CapRegistryStatus.Update();
                }
            }

            if(OldReg is null || OldReg != null && OldReg.Estatus != Status_)
            {
                var newreg = new CapRegistryStatus
                {
                    TipoRef = TipoRef_,
                    Nombre = this._NombreCompleto,
                    Inicio = DateTime.Now,
                    Fin = DateTime.Now,
                    IdPersona = this._IdPersona,
                    IdRefer = IdRefer_,
                    Estatus = Status_,
                    Actual = true,
                    IdCapRegistryVersion = IdCapRegistryVersion_
                };

                _darkM.CapRegistryStatus.Element = newreg;
                _darkM.CapRegistryStatus.Add();





            }
        }
        /// <summary>
        /// get log from object
        /// </summary>
        /// <param name="IdRefer_"></param>
        /// <param name="TipoRef_"></param>
        /// <returns></returns>
        public List<CapRegistryStatus> CapRegistrtList(int IdRefer_,  string TipoRef_)
        {
            return _darkM.CapRegistryStatus.GetOpenquery($"where TipoRef = '{TipoRef_}' and IdRefer = {IdRefer_}", "");
        }

        private void ValidObj(object data, string mensaje)
        {
            if (data is null) throw new GPException { Description = mensaje, ErrorCode = 0, Category = TypeException.Info };
        }
        public void Terminar()
        {
            _darkM.CloseConnection();
            _darkM = null;
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }
        #endregion
    }

    public enum VersionLogTypeData
    {
        int_ = 0,
        string_ = 1
    }
    public class Object_version
    {
        public int Id { get; set; }
        public string  Name { get; set; }
        public List<Version_list> Versiones { get; set; }
        public DateTime  Created { get; set; }
        public DateTime Updated { get; set; }
    }
    public class Version_list
    {
        public int Id { get; set; }
        public string Clave { get; set; }
        public string Nombre { get; set; }
        public string Autor { get; set; }

        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
   
}
