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
using GPSInformation.Exceptions;
using System.Collections.Generic;

namespace GestionPersonal.Controllers
{
    public class FormacionCapacitacionController : Controller
    {
        private DarkManager darkManager;
        private V2CapacitacionCtrl _V2CapacitacionCtrl;
        private readonly IViewRenderService _viewRenderService;

        public FormacionCapacitacionController(IConfiguration configuration, IViewRenderService viewRenderService)
        {
            this._viewRenderService = viewRenderService;
            darkManager = new DarkManager(configuration);
        }
        [AccessView]
        public IActionResult Capacitacion()
        {
            return View();
        }
        [AccessView]
        public IActionResult CrearTemplate(int id)
        {
            return View();
        }
        [AccessView]
        public IActionResult Programar()
        {
            return View();
        }
        [AccessView]
        public IActionResult Formacion()
        {
            return View();
        }

        #region Respuestas
        [HttpPost]
        public IActionResult CapEvaPrgResDelete(int IdCapEva, int IdVersion, int IdCapEvaPrg,int CapEvaPrgRes)
        {
            _V2CapacitacionCtrl = new V2CapacitacionCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            _V2CapacitacionCtrl._darkM.StartTransaction();
            try
            {
                _V2CapacitacionCtrl.CapEvaPrgResDelete(IdCapEva, IdVersion, IdCapEvaPrg, CapEvaPrgRes);
                _V2CapacitacionCtrl._darkM.Commit();
                return Ok("proceso completo");
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                _V2CapacitacionCtrl._darkM.RolBack();
                return BadRequest(ex.Message);
            }
            finally
            {
                _V2CapacitacionCtrl.Terminar();
            }
        }
        [HttpPost]
        public IActionResult CapEvaPrgResEdit(int IdCapEva, int IdVersion, int IdCapEvaPrg,int CapEvaPrgRes, string Respuesta, bool EsCorrecta)
        {
            _V2CapacitacionCtrl = new V2CapacitacionCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            _V2CapacitacionCtrl._darkM.StartTransaction();
            try
            {
                _V2CapacitacionCtrl.CapEvaPrgResEdit(IdCapEva, IdVersion, IdCapEvaPrg, CapEvaPrgRes, Respuesta, EsCorrecta);
                var data = _V2CapacitacionCtrl.CapEvaPrgResDetails(CapEvaPrgRes);
                _V2CapacitacionCtrl._darkM.Commit();
                return Ok(data);
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                _V2CapacitacionCtrl._darkM.RolBack();
                return BadRequest(ex.Message);
            }
            finally
            {
                _V2CapacitacionCtrl.Terminar();
            }
        }
        [HttpPost]
        public IActionResult CapEvaPrgResAdd(int IdCapEva, int IdVersion,int IdCapEvaPrg, string Respuesta, bool EsCorrecta)
        {
            _V2CapacitacionCtrl = new V2CapacitacionCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            _V2CapacitacionCtrl._darkM.StartTransaction();
            try
            {
                var result = _V2CapacitacionCtrl.CapEvaPrgResAdd(IdCapEva, IdVersion,IdCapEvaPrg, Respuesta, EsCorrecta);
                var data = _V2CapacitacionCtrl.CapEvaPrgResDetails(result);
                _V2CapacitacionCtrl._darkM.Commit();
                return Ok(data);
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                _V2CapacitacionCtrl._darkM.RolBack();
                return BadRequest(ex.Message);
            }
            finally
            {
                _V2CapacitacionCtrl.Terminar();
            }
        }
        public IActionResult CapEvaPrgResList(int IdCapEvaPrg, int IdVersion)
        {
            _V2CapacitacionCtrl = new V2CapacitacionCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            try
            {
                var result = _V2CapacitacionCtrl.CapEvaPrgResList(IdCapEvaPrg, IdVersion);
                return Ok(result);
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                return BadRequest(ex.Message);
            }
            finally
            {
                _V2CapacitacionCtrl.Terminar();
            }
        }
        public IActionResult CapEvaPrgResDetails(int IdCapEvaPrgRes)
        {
            _V2CapacitacionCtrl = new V2CapacitacionCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            try
            {
                var result = _V2CapacitacionCtrl.CapEvaPrgResDetails(IdCapEvaPrgRes);
                return Ok(result);
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                return BadRequest(ex.Message);
            }
            finally
            {
                _V2CapacitacionCtrl.Terminar();
            }
        }
        #endregion

        #region Preguntas
        /// <summary>
        /// 
        /// </summary>
        /// <param name="IdCapEva"></param>
        /// <param name="IdCapEvaPrg"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CapEvaPrgDelete(int IdCapEva, int IdVersion, int IdCapEvaPrg)
        {
            _V2CapacitacionCtrl = new V2CapacitacionCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            _V2CapacitacionCtrl._darkM.StartTransaction();
            try
            {
                _V2CapacitacionCtrl.CapEvaPrgDelete(IdCapEva, IdVersion, IdCapEvaPrg);
                _V2CapacitacionCtrl._darkM.Commit();
                return Ok("preguna eliminada");
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                _V2CapacitacionCtrl._darkM.RolBack();
                return BadRequest(ex.Message);
            }
            finally
            {
                _V2CapacitacionCtrl.Terminar();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="IdCapEva"></param>
        /// <param name="IdCapEvaPrg"></param>
        /// <param name="Pregunta"></param>
        /// <param name="Comentarios"></param>
        /// <param name="Puntaje"></param>
        /// <param name="Tipo"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CapEvaPrgEdit(int IdCapEva, int IdVersion, int IdCapEvaPrg, string Pregunta, string Comentarios, int Puntaje, string Tipo)
        {
            _V2CapacitacionCtrl = new V2CapacitacionCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            _V2CapacitacionCtrl._darkM.StartTransaction();
            try
            {
                _V2CapacitacionCtrl.CapEvaPrgEdit(IdCapEva, IdVersion, IdCapEvaPrg, Pregunta, Comentarios, Puntaje, Tipo);
                var data = _V2CapacitacionCtrl.CapEvaPrgDeetails(IdCapEva);
                _V2CapacitacionCtrl._darkM.Commit();
                return Ok(data);
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                _V2CapacitacionCtrl._darkM.RolBack();
                return BadRequest(ex.Message);
            }
            finally
            {
                _V2CapacitacionCtrl.Terminar();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="IdCapEva"></param>
        /// <param name="Pregunta"></param>
        /// <param name="Comentarios"></param>
        /// <param name="Puntaje"></param>
        /// <param name="Tipo"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CapEvaPrgAdd(int IdCapEva, int IdVersion, string Pregunta, string Comentarios, int Puntaje, string Tipo, List<CapEvaPrgRes> CapEvaPrgList)
        {
            _V2CapacitacionCtrl = new V2CapacitacionCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            _V2CapacitacionCtrl._darkM.StartTransaction();
            try
            {
                var result = _V2CapacitacionCtrl.CapEvaPrgAdd(IdCapEva, IdVersion, Pregunta, Comentarios, Puntaje, Tipo, CapEvaPrgList);
                var data = _V2CapacitacionCtrl.CapEvaPrgDeetails(result);
                _V2CapacitacionCtrl._darkM.Commit();
                return Ok(data);
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                _V2CapacitacionCtrl._darkM.RolBack();
                return BadRequest(ex.Message);
            }
            finally
            {
                _V2CapacitacionCtrl.Terminar();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="IdCapEva"></param>
        /// <returns></returns>
        public IActionResult CapEvaPrgList(int IdCapEva, int IdVersion)
        {
            _V2CapacitacionCtrl = new V2CapacitacionCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            try
            {
                var result = _V2CapacitacionCtrl.CapEvaPrgList(IdCapEva, IdVersion);
                return Ok(result);
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                return BadRequest(ex.Message);
            }
            finally
            {
                _V2CapacitacionCtrl.Terminar();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="IdCapEvaPrg"></param>
        /// <returns></returns>
        public IActionResult CapEvaPrgDeetails(int IdCapEvaPrg)
        {
            _V2CapacitacionCtrl = new V2CapacitacionCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            try
            {
                var result = _V2CapacitacionCtrl.CapEvaPrgDeetails(IdCapEvaPrg);
                return Ok(result);
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                return BadRequest(ex.Message);
            }
            finally
            {
                _V2CapacitacionCtrl.Terminar();
            }
        }
        #endregion

        #region Evaluaciones
        /// <summary>
        /// cambiar estatus de evaluacion
        /// </summary>
        /// <param name="IdCapEva"></param>
        /// <param name="IdVersion">id de la version base</param>CapRegistrtList
        /// <param name="Status_"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CapEvaRegistryVersion(int IdCapEva, int Status_, int IdVersion, string Comentarios)
        {
            _V2CapacitacionCtrl = new V2CapacitacionCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            _V2CapacitacionCtrl._darkM.StartTransaction();
            try
            {
                int newversion_ = _V2CapacitacionCtrl.CapEvaRegistryVersion(IdCapEva, Status_, IdVersion, Comentarios);
                var data = _V2CapacitacionCtrl.CapVersionDetails("EVA", IdCapEva, newversion_);
                _V2CapacitacionCtrl._darkM.Commit();
                return Ok(data);
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                _V2CapacitacionCtrl._darkM.RolBack();
                return BadRequest(ex.Message);
            }
            finally
            {
                _V2CapacitacionCtrl.Terminar();
            }
        }
        [HttpPost]
        public IActionResult CapVersionSetActive(int IdVersion, string TipoRef_, int IdRefer_)
        {
            _V2CapacitacionCtrl = new V2CapacitacionCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            _V2CapacitacionCtrl._darkM.StartTransaction();
            try
            {
                _V2CapacitacionCtrl.CapVersionSetActive(IdVersion, TipoRef_, IdRefer_);
                _V2CapacitacionCtrl._darkM.Commit();
                return Ok();
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                _V2CapacitacionCtrl._darkM.RolBack();
                return BadRequest(ex.Message);
            }
            finally
            {
                _V2CapacitacionCtrl.Terminar();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="IdCapEva"></param>
        /// <param name="Nombre"></param>
        /// <param name="Instruccionesa"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CapEvaEit(int IdCapEva, int IdVersion, string Nombre, string Instruccionesa)
        {
            _V2CapacitacionCtrl = new V2CapacitacionCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            _V2CapacitacionCtrl._darkM.StartTransaction();
            try
            {
                _V2CapacitacionCtrl.CapEvaEit(IdCapEva, IdVersion, Nombre, Instruccionesa);
                var data = _V2CapacitacionCtrl.CapEvaDetails(IdCapEva, IdVersion);
                _V2CapacitacionCtrl._darkM.Commit();
                return Ok(data);
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                _V2CapacitacionCtrl._darkM.RolBack();
                return BadRequest(ex.Message);
            }
            finally
            {
                _V2CapacitacionCtrl.Terminar();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Nombre"></param>
        /// <param name="Instruccionesa"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CapEvaAdd(string Nombre, string Instruccionesa)
        {
            _V2CapacitacionCtrl = new V2CapacitacionCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            _V2CapacitacionCtrl._darkM.StartTransaction();
            try
            {
                var result = _V2CapacitacionCtrl.CapEvaAdd(Nombre, Instruccionesa);
                var data = _V2CapacitacionCtrl.CapEvaDetails(result, 0);
                _V2CapacitacionCtrl._darkM.Commit();
                return Ok(data);
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                _V2CapacitacionCtrl._darkM.RolBack();
                return BadRequest(ex.Message);
            }
            finally
            {
                _V2CapacitacionCtrl.Terminar();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IActionResult CapEvaList()
        {
            _V2CapacitacionCtrl = new V2CapacitacionCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            try
            {
                var result = _V2CapacitacionCtrl.CapEvaList();
                return Ok(result);
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                return BadRequest(ex.Message);
            }
            finally
            {
                _V2CapacitacionCtrl.Terminar();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IActionResult CapEvaVersions()
        {
            _V2CapacitacionCtrl = new V2CapacitacionCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            try
            {
                var result = _V2CapacitacionCtrl.CapEvaVersions();
                return Ok(result);
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                return BadRequest(ex.Message);
            }
            finally
            {
                _V2CapacitacionCtrl.Terminar();
            }
        }
        public IActionResult CapTemplVersions()
        {
            _V2CapacitacionCtrl = new V2CapacitacionCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            try
            {
                var result = _V2CapacitacionCtrl.CapTemplVersions();
                return Ok(result);
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                return BadRequest(ex.Message);
            }
            finally
            {
                _V2CapacitacionCtrl.Terminar();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="IdCapEva"></param>
        /// <returns></returns>
        public IActionResult CapEvaDetails(int IdCapEva, int IdVersion)
        {
            _V2CapacitacionCtrl = new V2CapacitacionCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            try
            {
                var result = _V2CapacitacionCtrl.CapEvaDetails(IdCapEva, IdVersion);
                return Ok(new { eva = result, version = _V2CapacitacionCtrl.CapVersionDetails("EVA", IdCapEva, IdVersion,false) });
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                return BadRequest(ex.Message);
            }
            finally
            {
                _V2CapacitacionCtrl.Terminar();
            }
        }
        [HttpPost]
        public IActionResult CapEvaSetEstatus(int IdCapEva, int IdVersion, int Estatus)
        {
            _V2CapacitacionCtrl = new V2CapacitacionCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            try
            {
                 _V2CapacitacionCtrl.CapEvaSetEstatus(IdCapEva, IdVersion, Estatus);
                return Ok("Complete");
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                return BadRequest(ex.Message);
            }
            finally
            {
                _V2CapacitacionCtrl.Terminar();
            }
        }
        #endregion

        #region CapTempl CRUD

        [HttpGet]
        public IActionResult CapTemplList()
        {
            _V2CapacitacionCtrl = new V2CapacitacionCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            try
            {
                var rest = _V2CapacitacionCtrl.CapTemplList(CapTemplEstatus.Todas);
                return Ok(rest);
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                return BadRequest(ex.Message);
            }
            finally
            {
                _V2CapacitacionCtrl.Terminar();
            }
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult CapTemplEvaAdd(int IdCapTempl, int IdVersion, int IdEvaCap, int IdVersionEva)
        {
            _V2CapacitacionCtrl = new V2CapacitacionCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            _V2CapacitacionCtrl._IdVersionTeml = IdVersion;
            _V2CapacitacionCtrl._darkM.StartTransaction();
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Error, por favor llena todos los campos");
                }
                var data = _V2CapacitacionCtrl.CapTemplEvaAdd(IdCapTempl, IdEvaCap, IdVersionEva);
                _V2CapacitacionCtrl._darkM.Commit();
                return Ok(data);
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                _V2CapacitacionCtrl._darkM.RolBack();
                return BadRequest(ex.Message);
                //return ValidateException(ex, DataModel: capTempl, SinModel: false, IsPartial: false);
            }
            finally
            {
                _V2CapacitacionCtrl.Terminar();
            }
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult CapTemplEvaDel(int IdCapTempl, int IdVersion, int IdEvaCap, int IdCapRegistryVersionDet)
        {
            _V2CapacitacionCtrl = new V2CapacitacionCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            _V2CapacitacionCtrl._IdVersionTeml = IdVersion;
            _V2CapacitacionCtrl._darkM.StartTransaction();
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Error, por favor llena todos los campos");
                }
                _V2CapacitacionCtrl.CapTemplEvaDel(IdCapTempl, IdEvaCap, IdCapRegistryVersionDet);
                _V2CapacitacionCtrl._darkM.Commit();
                return Ok("Proceso Completo!!!");
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                _V2CapacitacionCtrl._darkM.RolBack();
                return BadRequest(ex.Message);
                //return ValidateException(ex, DataModel: capTempl, SinModel: false, IsPartial: false);
            }
            finally
            {
                _V2CapacitacionCtrl.Terminar();
            }
        }


        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult CapTemplEdit(int IdCapTempl, int IdVersion, string Clave, string Nombre, string Descripcion, string Objetivo, decimal CalRepet)
        {
            _V2CapacitacionCtrl = new V2CapacitacionCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            _V2CapacitacionCtrl._IdVersionTeml = IdVersion;
            _V2CapacitacionCtrl._darkM.StartTransaction();
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Error, por favor llena todos los campos");
                }
                _V2CapacitacionCtrl.CapTemplEdit(IdCapTempl, Clave, Nombre, Descripcion, Objetivo, CalRepet);
                _V2CapacitacionCtrl._darkM.Commit();
                return Ok("Proceso Completo!!!");
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                _V2CapacitacionCtrl._darkM.RolBack();
                return BadRequest(ex.Message);
                //return ValidateException(ex, DataModel: capTempl, SinModel: false, IsPartial: false);
            }
            finally
            {
                _V2CapacitacionCtrl.Terminar();
            }
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult CapTemplNewVersion(int IdVersion,int IdCapTempl, string comentarios)
        {
            _V2CapacitacionCtrl = new V2CapacitacionCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            _V2CapacitacionCtrl._IdVersionTeml = IdVersion;
            _V2CapacitacionCtrl._darkM.StartTransaction();
            try
            {
                int newversion_ = _V2CapacitacionCtrl.CapTemplNewVersion(IdCapTempl, comentarios);
                var data = _V2CapacitacionCtrl.CapVersionDetails(_V2CapacitacionCtrl._Key_templ_, IdCapTempl, newversion_);
                _V2CapacitacionCtrl._darkM.Commit();
                return Ok(data);
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                _V2CapacitacionCtrl._darkM.RolBack();
                return BadRequest(ex.Message);
                //return ValidateException(ex, DataModel: capTempl, SinModel: false, IsPartial: false);
            }
            finally
            {
                _V2CapacitacionCtrl.Terminar();
            }
        }
        
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult CapTemplChageStatus(int IdVersion, int IdCapTempl, int Estatus)
        {
            _V2CapacitacionCtrl = new V2CapacitacionCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            _V2CapacitacionCtrl._IdVersionTeml = IdVersion;
            _V2CapacitacionCtrl._darkM.StartTransaction();
            try
            {
                _V2CapacitacionCtrl.CapTemplChageStatus(IdCapTempl, Estatus);
                _V2CapacitacionCtrl._darkM.Commit();
                return Ok("Proceso Completo!!!");
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                _V2CapacitacionCtrl._darkM.RolBack();
                return BadRequest(ex.Message);
                //return ValidateException(ex, DataModel: capTempl, SinModel: false, IsPartial: false);
            }
            finally
            {
                _V2CapacitacionCtrl.Terminar();
            }
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult CapTemplCreate(CapTempl capTempl)
        {
            _V2CapacitacionCtrl = new V2CapacitacionCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            
            _V2CapacitacionCtrl._darkM.StartTransaction();
            try
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest("Error, por favor llena todos los campos");
                }
                int rest = _V2CapacitacionCtrl.CapTemplCreate(capTempl);
                _V2CapacitacionCtrl._darkM.Commit();
                return Ok(rest);
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                _V2CapacitacionCtrl._darkM.RolBack();
                return BadRequest(ex.Message);
                //return ValidateException(ex, DataModel: capTempl, SinModel: false, IsPartial: false);
            }
            finally
            {
                _V2CapacitacionCtrl.Terminar();
            }
        }

        public IActionResult CapTemplDetails( int id, int IdVersion)
        {
            _V2CapacitacionCtrl = new V2CapacitacionCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            _V2CapacitacionCtrl._IdVersionTeml = IdVersion;
            try
            {
                var rest = _V2CapacitacionCtrl.CapTemplDetails(id, ShowExceNotFound: true);
                return Ok(rest);
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                return BadRequest(ex.Message);
            }
            finally
            {
                _V2CapacitacionCtrl.Terminar();
            }
        }

        public IActionResult GetShedule(int id, int IdVersion)
        {
            _V2CapacitacionCtrl = new V2CapacitacionCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            _V2CapacitacionCtrl._IdVersionTeml = IdVersion;
            try
            {
                var rest = _V2CapacitacionCtrl.GetShedule(id);
                return Ok(rest);
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                return BadRequest(ex.Message);
            }
            finally
            {
                _V2CapacitacionCtrl.Terminar();
            }
        }
        #endregion

        #region Sessiones
        public IActionResult CapSessDetails(int IdCapTempl, int IdVersion, int IdCapSess)
        {
            _V2CapacitacionCtrl = new V2CapacitacionCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            _V2CapacitacionCtrl._IdVersionTeml = IdVersion;
            try
            {
                var rest = _V2CapacitacionCtrl.CapSessDetails(IdCapTempl, IdCapSess);
                return Ok(rest);
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                return BadRequest(ex.Message);
            }
            finally
            {
                _V2CapacitacionCtrl.Terminar();
            }
        }
        
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult CapSessEdit(int IdCapTempl, int IdCapSess, int IdVersion, string Nombre, decimal Duracion, string Objetivo)
        {
            _V2CapacitacionCtrl = new V2CapacitacionCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            _V2CapacitacionCtrl._IdVersionTeml = IdVersion;
            _V2CapacitacionCtrl._darkM.StartTransaction();
            try
            {
                 _V2CapacitacionCtrl.CapSessEdit(IdCapTempl, IdCapSess, Nombre, Duracion, Objetivo);
                var rest_data = _V2CapacitacionCtrl.CapSessDetails(IdCapTempl, IdCapSess);
                _V2CapacitacionCtrl._darkM.Commit();
                return Ok(rest_data);
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                _V2CapacitacionCtrl._darkM.RolBack();
                return BadRequest(ex.Message);
            }
            finally
            {
                _V2CapacitacionCtrl.Terminar();
            }
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult CapSessCreate(CapSess capSess, int IdVersion)
        {
            _V2CapacitacionCtrl = new V2CapacitacionCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            _V2CapacitacionCtrl._IdVersionTeml = IdVersion;
            _V2CapacitacionCtrl._darkM.StartTransaction();
            try
            {
                int rest = _V2CapacitacionCtrl.CapSessCreate(capSess);
                var rest_data = _V2CapacitacionCtrl.CapSessDetails(capSess.IdCapTempl, rest);
                _V2CapacitacionCtrl._darkM.Commit();
                return Ok(rest_data);
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                _V2CapacitacionCtrl._darkM.RolBack();
                return BadRequest(ex.Message);
            }
            finally
            {
                _V2CapacitacionCtrl.Terminar();
            }
        }
        public IActionResult CapSessDelete(int IdCapTempl, int IdRefer, int IdVersion)
        {
            _V2CapacitacionCtrl = new V2CapacitacionCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            _V2CapacitacionCtrl._IdVersionTeml = IdVersion;
            _V2CapacitacionCtrl._darkM.StartTransaction();
            try
            {
                _V2CapacitacionCtrl.CapSessDelete(IdCapTempl, IdRefer);
                _V2CapacitacionCtrl._darkM.Commit();
                return Ok("Proceso completo!");
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                _V2CapacitacionCtrl._darkM.RolBack();
                return BadRequest(ex.Message);
            }
            finally
            {
                _V2CapacitacionCtrl.Terminar();
            }
        }



        #endregion

        #region Temas
        public IActionResult CapTemaDelete(int IdCapTempl, int IdCapSess, int IdCapTema, int IdVersion)
        {
            _V2CapacitacionCtrl = new V2CapacitacionCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            _V2CapacitacionCtrl._IdVersionTeml = IdVersion;
            _V2CapacitacionCtrl._darkM.StartTransaction();
            try
            {
                _V2CapacitacionCtrl.CapTemaDelete(IdCapTempl, IdCapSess, IdCapTema);
                _V2CapacitacionCtrl._darkM.Commit();
                return Ok("Proceso completo");
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                _V2CapacitacionCtrl._darkM.RolBack();
                return BadRequest(ex.Message);
            }
            finally
            {
                _V2CapacitacionCtrl.Terminar();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CapTemaUpdate(int IdCapTempl, int IdCapSess, int IdCapTema, int IdVersion, string Nombre, string Descripcion)
        {
            _V2CapacitacionCtrl = new V2CapacitacionCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            _V2CapacitacionCtrl._IdVersionTeml = IdVersion;
            _V2CapacitacionCtrl._darkM.StartTransaction();
            try
            {
                _V2CapacitacionCtrl.CapTemaUpdate(IdCapTempl, IdCapSess, IdCapTema, Nombre, Descripcion);
                var data = _V2CapacitacionCtrl.CapTemaDetails(IdCapTema);
                _V2CapacitacionCtrl._darkM.Commit();
                return Ok(data);
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                _V2CapacitacionCtrl._darkM.RolBack();
                return BadRequest(ex.Message);
            }
            finally
            {
                _V2CapacitacionCtrl.Terminar();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CapTemaCreate(int IdCapTempl, int IdCapSess, int IdVersion, string Nombre, string Descripcion)
        {
            _V2CapacitacionCtrl = new V2CapacitacionCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            _V2CapacitacionCtrl._IdVersionTeml = IdVersion;
            _V2CapacitacionCtrl._darkM.StartTransaction();
            try
            {
                var rest = _V2CapacitacionCtrl.CapTemaCreate(IdCapTempl, IdCapSess, Nombre, Descripcion);
                var data = _V2CapacitacionCtrl.CapTemaDetails(rest);
                _V2CapacitacionCtrl._darkM.Commit();
                return Ok(data);
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                _V2CapacitacionCtrl._darkM.RolBack();
                return BadRequest(ex.Message);
            }
            finally
            {
                _V2CapacitacionCtrl.Terminar();
            }
        }
        public IActionResult CapTemaDetails(int IdCapTema, int IdVersion)
        {
            _V2CapacitacionCtrl = new V2CapacitacionCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            _V2CapacitacionCtrl._IdVersionTeml = IdVersion;
            try
            {
                var rest = _V2CapacitacionCtrl.CapTemaDetails(IdCapTema);
                return Ok(rest);
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                return BadRequest(ex.Message);
            }
            finally
            {
                _V2CapacitacionCtrl.Terminar();
            }
        }
        public IActionResult CapTemaBySession(int IdCapSess, int IdVersion)
        {
            _V2CapacitacionCtrl = new V2CapacitacionCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            _V2CapacitacionCtrl._IdVersionTeml = IdVersion;
            try
            {
                var rest = _V2CapacitacionCtrl.CapTemaBySession(IdCapSess);
                return Ok(rest);
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                return BadRequest(ex.Message);
            }
            finally
            {
                _V2CapacitacionCtrl.Terminar();
            }
        }
        #endregion

        #region genrales
        public IActionResult CapVersionList(int IdRefer_, string TipoRef_)
        {
            _V2CapacitacionCtrl = new V2CapacitacionCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            try
            {
                var result = _V2CapacitacionCtrl.CapVersionList(IdRefer_, TipoRef_);
                return Ok(result);
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                return BadRequest(ex.Message);
            }
            finally
            {
                _V2CapacitacionCtrl.Terminar();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="DataModel"></param>
        /// <param name="SinModel"> set false for return view with model</param>
        /// <returns></returns>
        [NonAction]
        private IActionResult ValidateException(GPSInformation.Exceptions.GPException ex, object DataModel = null, bool SinModel = true, bool IsPartial = true)
        {
            if (ex.Category == GPSInformation.Exceptions.TypeException.Noautorizado)
            {
                ViewData["MessageError"] = ex.Message;
                if (!IsPartial)
                    return View("../ErrorPages/NoAccess");
                else
                    return PartialView("../ErrorPages/NoAccess");
            }
            else if (ex.Category == GPSInformation.Exceptions.TypeException.NotFound)
            {
                ViewData["MessageError"] = ex.Message;
                //no es vista
                if (!IsPartial)
                    return View("../ErrorPages/NotFoundPage");
                else
                    return PartialView("../Home/NotFoundPage");
            }
            else if (ex.Category == GPSInformation.Exceptions.TypeException.Info)
            {
                if (SinModel)
                {
                    ViewData["MessageError"] = ex.Message;
                    if (!IsPartial)
                        return View("../ErrorPages/Error");
                    else
                        return PartialView("../ErrorPages/Error");
                }
                else
                {
                    ViewData["MessageError"] = ex.Message;
                    ModelState.AddModelError(string.IsNullOrEmpty(ex.IdAux) ? "" : ex.IdAux, ex.Message);
                    if (!IsPartial)
                        return View(DataModel);
                    else
                        return PartialView(DataModel);
                }

            }
            else
            {
                ViewData["MessageError"] = ex.Message;
                if (!IsPartial)
                    return View("../ErrorPages/Error");
                else
                    return PartialView("../ErrorPages/Error");
            }
        }
        #endregion

        #region Programar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CapKardexDelete(int IdCapProg, int IdPersonaPart)
        {
            _V2CapacitacionCtrl = new V2CapacitacionCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            _V2CapacitacionCtrl._darkM.StartTransaction();
            try
            {
                _V2CapacitacionCtrl.CapKardexDelete(IdCapProg, IdPersonaPart);
                _V2CapacitacionCtrl._darkM.Commit();
                return Ok("Proceso completo");
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                _V2CapacitacionCtrl._darkM.RolBack();
                return BadRequest(ex.Message);
            }
            finally
            {
                _V2CapacitacionCtrl.Terminar();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CapKardexCreate(int IdCapProg, int IdPersonaPart)
        {
            _V2CapacitacionCtrl = new V2CapacitacionCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            _V2CapacitacionCtrl._darkM.StartTransaction();
            try
            {
                var data = _V2CapacitacionCtrl.CapKardexCreate(IdCapProg, IdPersonaPart);
                _V2CapacitacionCtrl._darkM.Commit();
                return Ok(data);
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                _V2CapacitacionCtrl._darkM.RolBack();
                return BadRequest(ex.Message);
            }
            finally
            {
                _V2CapacitacionCtrl.Terminar();
            }
        }
        public IActionResult CapKardexDetailsProg(int IdCapProg)
        {
            _V2CapacitacionCtrl = new V2CapacitacionCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            _V2CapacitacionCtrl._darkM.StartTransaction();
            try
            {
                var data = _V2CapacitacionCtrl.CapKardexDetailsProg(IdCapProg);
                _V2CapacitacionCtrl._darkM.Commit();
                return Ok(data);
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                _V2CapacitacionCtrl._darkM.RolBack();
                return BadRequest(ex.Message);
            }
            finally
            {
                _V2CapacitacionCtrl.Terminar();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CapProgSheduleEdit(int IdCapProg, int IdCapProgShedule, DateTime Fecha, TimeSpan Inicio, TimeSpan Fin, string Modalidad)
        {
            _V2CapacitacionCtrl = new V2CapacitacionCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            _V2CapacitacionCtrl._darkM.StartTransaction();
            try
            {
                _V2CapacitacionCtrl.CapProgSheduleEdit(IdCapProg, IdCapProgShedule, Fecha, Inicio, Fin, Modalidad);
                _V2CapacitacionCtrl._darkM.Commit();
                return Ok("Proceso completo");
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                _V2CapacitacionCtrl._darkM.RolBack();
                return BadRequest(ex.Message);
            }
            finally
            {
                _V2CapacitacionCtrl.Terminar();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CapProgInstrDelete(int IdCapProg, int IdCapProgInstr)
        {
            _V2CapacitacionCtrl = new V2CapacitacionCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            _V2CapacitacionCtrl._darkM.StartTransaction();
            try
            {
                _V2CapacitacionCtrl.CapProgInstrDelete(IdCapProg, IdCapProgInstr);
                _V2CapacitacionCtrl._darkM.Commit();
                return Ok("Proceso completo");
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                _V2CapacitacionCtrl._darkM.RolBack();
                return BadRequest(ex.Message);
            }
            finally
            {
                _V2CapacitacionCtrl.Terminar();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CapProgInstrCreate(int IdCapProg, int IdPersonaIns, string Tipo, string Nombre, string Ocupacion)
        {
            _V2CapacitacionCtrl = new V2CapacitacionCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            _V2CapacitacionCtrl._darkM.StartTransaction();
            try
            {
                var data = _V2CapacitacionCtrl.CapProgInstrCreate(IdCapProg, IdPersonaIns, Tipo, Nombre, Ocupacion);
                _V2CapacitacionCtrl._darkM.Commit();
                return Ok(data);
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                _V2CapacitacionCtrl._darkM.RolBack();
                return BadRequest(ex.Message);
            }
            finally
            {
                _V2CapacitacionCtrl.Terminar();
            }
        }
        public IActionResult CapProgInstrByProg(int IdCapProg)
        {
            _V2CapacitacionCtrl = new V2CapacitacionCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            _V2CapacitacionCtrl._darkM.StartTransaction();
            try
            {
                var data = _V2CapacitacionCtrl.CapProgInstrByProg(IdCapProg);
                _V2CapacitacionCtrl._darkM.Commit();
                return Ok(data);
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                _V2CapacitacionCtrl._darkM.RolBack();
                return BadRequest(ex.Message);
            }
            finally
            {
                _V2CapacitacionCtrl.Terminar();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CapProgEdit(int IdCapProg, string Modalidad)
        {
            _V2CapacitacionCtrl = new V2CapacitacionCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            _V2CapacitacionCtrl._darkM.StartTransaction();
            try
            {
                _V2CapacitacionCtrl.CapProgEdit(IdCapProg, Modalidad);
                _V2CapacitacionCtrl._darkM.Commit();
                return Ok("Proceso completo");
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                _V2CapacitacionCtrl._darkM.RolBack();
                return BadRequest(ex.Message);
            }
            finally
            {
                _V2CapacitacionCtrl.Terminar();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CapProgCreate(int IdCapTempl, int IdVersion, string Modalidad)
        {
            _V2CapacitacionCtrl = new V2CapacitacionCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            _V2CapacitacionCtrl._darkM.StartTransaction();
            try
            {
                var data = _V2CapacitacionCtrl.CapProgCreate(IdCapTempl, IdVersion, Modalidad);
                _V2CapacitacionCtrl._darkM.Commit();
                return Ok(data);
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                _V2CapacitacionCtrl._darkM.RolBack();
                return BadRequest(ex.Message);
            }
            finally
            {
                _V2CapacitacionCtrl.Terminar();
            }
        }
        public IActionResult CapProgdetails(int IdCapProg)
        {
            _V2CapacitacionCtrl = new V2CapacitacionCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            //_V2CapacitacionCtrl._darkM.StartTransaction();
            try
            {
                var data = _V2CapacitacionCtrl.CapProgdetails(IdCapProg);
                //_V2CapacitacionCtrl._darkM.Commit();

                if (data is null) return NotFound();
                return Ok(data);
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                //_V2CapacitacionCtrl._darkM.RolBack();
                return BadRequest(ex.Message);
            }
            finally
            {
                _V2CapacitacionCtrl.Terminar();
            }
        }
        public IActionResult CapProgSheduleListProg(int IdCapProg)
        {
            _V2CapacitacionCtrl = new V2CapacitacionCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            _V2CapacitacionCtrl._darkM.StartTransaction();
            try
            {
                var data = _V2CapacitacionCtrl.CapProgSheduleListProg(IdCapProg);
                _V2CapacitacionCtrl._darkM.Commit();
                return Ok(data);
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                _V2CapacitacionCtrl._darkM.RolBack();
                return BadRequest(ex.Message);
            }
            finally
            {
                _V2CapacitacionCtrl.Terminar();
            }
        }
        public IActionResult CapCapProgList()
        {
            _V2CapacitacionCtrl = new V2CapacitacionCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            _V2CapacitacionCtrl._darkM.StartTransaction();
            try
            {
                var data = _V2CapacitacionCtrl.CapCapProgList();
                _V2CapacitacionCtrl._darkM.Commit();
                return Ok(data);
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                _V2CapacitacionCtrl._darkM.RolBack();
                return BadRequest(ex.Message);
            }
            finally
            {
                _V2CapacitacionCtrl.Terminar();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CapProgSheduleTimerAdd(int IdCapProg, int IdCapProgShedule, DateTime? Fecha, TimeSpan Inicio, TimeSpan Fin, string Modalidad, string TipoEVa)
        {
            _V2CapacitacionCtrl = new V2CapacitacionCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            _V2CapacitacionCtrl._darkM.StartTransaction();
            try
            {
                var data = _V2CapacitacionCtrl.CapProgSheduleTimerAdd(IdCapProg, IdCapProgShedule, Fecha, Inicio, Fin, Modalidad, TipoEVa);
                _V2CapacitacionCtrl._darkM.Commit();
                return Ok(data);
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                _V2CapacitacionCtrl._darkM.RolBack();
                _V2CapacitacionCtrl._darkM.dBConnection.ProcessGPSMessages();
                return BadRequest(ex.Message);
            }
            finally
            {
                _V2CapacitacionCtrl.Terminar();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CapProgSetEstatus(int IdCapProg, int Estatus)
        {
            _V2CapacitacionCtrl = new V2CapacitacionCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            _V2CapacitacionCtrl._darkM.StartTransaction();
            try
            {
                 _V2CapacitacionCtrl.CapProgSetEstatus(IdCapProg, Estatus);
                _V2CapacitacionCtrl._darkM.Commit();
                return Ok("¡Proceso completo!");
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                _V2CapacitacionCtrl._darkM.RolBack();
                return BadRequest(ex.Message);
            }
            finally
            {
                _V2CapacitacionCtrl.Terminar();
            }
        }
        public IActionResult  CapProgSheduleTimerDetails(int IdCapProgShedule, int IdCapProgSheduleTimer)
        {
            _V2CapacitacionCtrl = new V2CapacitacionCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            _V2CapacitacionCtrl._darkM.StartTransaction();
            try
            {
                var data = _V2CapacitacionCtrl.CapProgSheduleTimerDetails(IdCapProgShedule, IdCapProgSheduleTimer);
                _V2CapacitacionCtrl._darkM.Commit();
                return Ok(data);
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                _V2CapacitacionCtrl._darkM.RolBack();
                return BadRequest(ex.Message);
            }
            finally
            {
                _V2CapacitacionCtrl.Terminar();
            }
        }
        public IActionResult GetGapsShedule(int IdCapProg)
        {
            _V2CapacitacionCtrl = new V2CapacitacionCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            //_V2CapacitacionCtrl._darkM.StartTransaction();
            try
            {
                var data = _V2CapacitacionCtrl.GetGapsShedule(IdCapProg);
                //_V2CapacitacionCtrl._darkM.Commit();
                return Ok(data);
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                //_V2CapacitacionCtrl._darkM.RolBack();
                return BadRequest(ex.Message);
            }
            finally
            {
                _V2CapacitacionCtrl.Terminar();
            }
        }
        public IActionResult CapCapProgListByeEmp(int id)
        {
            _V2CapacitacionCtrl = new V2CapacitacionCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            //_V2CapacitacionCtrl._darkM.StartTransaction();
            try
            {
                var data = _V2CapacitacionCtrl.CapCapProgListByeEmp((int)HttpContext.Session.GetInt32("user_id"));
                //_V2CapacitacionCtrl._darkM.Commit();
                return Ok(data);
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                //_V2CapacitacionCtrl._darkM.RolBack();
                return BadRequest(ex.Message);
            }
            finally
            {
                _V2CapacitacionCtrl.Terminar();
            }
        }
        public IActionResult CapKardexDetailsByEmp(int id, int IdPersona)
        {
            _V2CapacitacionCtrl = new V2CapacitacionCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            //_V2CapacitacionCtrl._darkM.StartTransaction();
            try
            {
                var data = _V2CapacitacionCtrl.CapKardexDetailsByEmp(id, (int)HttpContext.Session.GetInt32("user_id"));
                if (data is null) return NotFound();
                //_V2CapacitacionCtrl._darkM.Commit();
                return Ok(data);
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                //_V2CapacitacionCtrl._darkM.RolBack();
                return BadRequest(ex.Message);
            }
            finally
            {
                _V2CapacitacionCtrl.Terminar();
            }
        }

        #endregion


    }
}
