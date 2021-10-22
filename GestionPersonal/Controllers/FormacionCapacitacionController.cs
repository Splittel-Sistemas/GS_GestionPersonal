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
        public IActionResult CrearTemplate(int id)
        {
            return View();
        }
        public IActionResult Template(int id)
        {
            ViewData["IdCapTempl"] = id;
            return View();
        }

        #region Respuestas
        [HttpPost]
        public IActionResult CapEvaPrgResDelete(int IdCapEvaPrg,int CapEvaPrgRes)
        {
            _V2CapacitacionCtrl = new V2CapacitacionCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            _V2CapacitacionCtrl._darkM.StartTransaction();
            try
            {
                _V2CapacitacionCtrl.CapEvaPrgResDelete(IdCapEvaPrg, CapEvaPrgRes);
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
        public IActionResult CapEvaPrgResEdit(int IdCapEvaPrg,int CapEvaPrgRes, string Respuesta, bool EsCorrecta)
        {
            _V2CapacitacionCtrl = new V2CapacitacionCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            _V2CapacitacionCtrl._darkM.StartTransaction();
            try
            {
                _V2CapacitacionCtrl.CapEvaPrgResEdit(IdCapEvaPrg, CapEvaPrgRes, Respuesta, EsCorrecta);
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
        public IActionResult CapEvaPrgResAdd(int IdCapEvaPrg, string Respuesta, bool EsCorrecta)
        {
            _V2CapacitacionCtrl = new V2CapacitacionCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            _V2CapacitacionCtrl._darkM.StartTransaction();
            try
            {
                var result = _V2CapacitacionCtrl.CapEvaPrgResAdd(IdCapEvaPrg, Respuesta, EsCorrecta);
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
        public IActionResult CapEvaPrgResList(int IdCapEvaPrg)
        {
            _V2CapacitacionCtrl = new V2CapacitacionCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            try
            {
                var result = _V2CapacitacionCtrl.CapEvaPrgResList(IdCapEvaPrg);
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
        public IActionResult CapEvaPrgDelete(int IdCapEva, int IdCapEvaPrg)
        {
            _V2CapacitacionCtrl = new V2CapacitacionCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            _V2CapacitacionCtrl._darkM.StartTransaction();
            try
            {
                _V2CapacitacionCtrl.CapEvaPrgDelete(IdCapEva, IdCapEvaPrg);
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
        public IActionResult CapEvaPrgEdit(int IdCapEva, int IdCapEvaPrg, string Pregunta, string Comentarios, int Puntaje, string Tipo)
        {
            _V2CapacitacionCtrl = new V2CapacitacionCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            _V2CapacitacionCtrl._darkM.StartTransaction();
            try
            {
                _V2CapacitacionCtrl.CapEvaPrgEdit(IdCapEva, IdCapEvaPrg, Pregunta, Comentarios, Puntaje, Tipo);
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
        public IActionResult CapEvaPrgAdd(int IdCapEva, string Pregunta, string Comentarios, int Puntaje, string Tipo, List<CapEvaPrgRes> CapEvaPrgList)
        {
            _V2CapacitacionCtrl = new V2CapacitacionCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            _V2CapacitacionCtrl._darkM.StartTransaction();
            try
            {
                var result = _V2CapacitacionCtrl.CapEvaPrgAdd(IdCapEva, Pregunta, Comentarios, Puntaje, Tipo, CapEvaPrgList);
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
        public IActionResult CapEvaPrgList(int IdCapEva)
        {
            _V2CapacitacionCtrl = new V2CapacitacionCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            try
            {
                var result = _V2CapacitacionCtrl.CapEvaPrgList(IdCapEva);
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
        /// 
        /// </summary>
        /// <param name="IdCapEva"></param>
        /// <param name="Nombre"></param>
        /// <param name="Instruccionesa"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult CapEvaEit(int IdCapEva,string Nombre, string Instruccionesa)
        {
            _V2CapacitacionCtrl = new V2CapacitacionCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            _V2CapacitacionCtrl._darkM.StartTransaction();
            try
            {
                _V2CapacitacionCtrl.CapEvaEit(IdCapEva,Nombre, Instruccionesa);
                var data = _V2CapacitacionCtrl.CapEvaDetails(IdCapEva);
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
                var data = _V2CapacitacionCtrl.CapEvaDetails(result);
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
        /// <param name="IdCapEva"></param>
        /// <returns></returns>
        public IActionResult CapEvaDetails(int IdCapEva)
        {
            _V2CapacitacionCtrl = new V2CapacitacionCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
            try
            {
                var result = _V2CapacitacionCtrl.CapEvaDetails(IdCapEva);
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
        public IActionResult CapTemplEdit(int IdCapTempl, string Clave, string Nombre, string Descripcion, string Objetivo, float CalRepet)
        {
            _V2CapacitacionCtrl = new V2CapacitacionCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
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

        public IActionResult CapTemplDetails( int id)
        {
            _V2CapacitacionCtrl = new V2CapacitacionCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
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

        public IActionResult GetShedule(int id)
        {
            _V2CapacitacionCtrl = new V2CapacitacionCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
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
        public IActionResult CapSessDetails(int IdCapTempl, int IdCapSess)
        {
            _V2CapacitacionCtrl = new V2CapacitacionCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
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
        public IActionResult CapSessEdit(int IdCapTempl, int IdCapSess, string Nombre, decimal Duracion, string Objetivo)
        {
            _V2CapacitacionCtrl = new V2CapacitacionCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
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
        public IActionResult CapSessCreate(CapSess capSess)
        {
            _V2CapacitacionCtrl = new V2CapacitacionCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
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
        public IActionResult CapSessDelete(int IdCapTempl, int IdRefer)
        {
            _V2CapacitacionCtrl = new V2CapacitacionCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
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
        public IActionResult CapTemaDelete(int IdCapTempl, int IdCapSess, int IdCapTema)
        {
            _V2CapacitacionCtrl = new V2CapacitacionCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
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
        public IActionResult CapTemaUpdate(int IdCapTempl, int IdCapSess, int IdCapTema, string Nombre, string Descripcion)
        {
            _V2CapacitacionCtrl = new V2CapacitacionCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
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
        public IActionResult CapTemaCreate(int IdCapTempl, int IdCapSess, string Nombre, string Descripcion)
        {
            _V2CapacitacionCtrl = new V2CapacitacionCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
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
        public IActionResult CapTemaDetails(int IdCapTema)
        {
            _V2CapacitacionCtrl = new V2CapacitacionCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
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
        public IActionResult CapTemaBySession(int IdCapSess)
        {
            _V2CapacitacionCtrl = new V2CapacitacionCtrl(darkManager, (int)HttpContext.Session.GetInt32("user_id_permiss"), (int)HttpContext.Session.GetInt32("user_id"));
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
    }
}
