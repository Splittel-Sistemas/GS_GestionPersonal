using GestionPersonal.Areas.v2.Entities;
using GestionPersonal.Areas.v2.Helpers;
using GestionPersonal.Areas.v2.Models;
using GestionPersonal.Areas.v2.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionPersonal.Areas.v2.Controllers
{
    [Area("v2")]
    [Route("v2/api/[controller]")]
    [ApiController]
    public class FormacionController : ControllerBase
    {
        private readonly ILogger<FormacionController> _logger;
        private readonly IFormacion _formacion;

        public FormacionController(ILogger<FormacionController> logger, IFormacion formacion)
        {
            _logger = logger;
            _formacion = formacion;
        }
        [NonAction]
        public ActionResult<T> ValidException<T>(ApiException ex)
        {
            return StatusCode((int)ex.StatusCodes, string.IsNullOrEmpty(ex.Message) ? null : ex.Message);
        }
        [NonAction]
        public ActionResult ValidException(ApiException ex)
        {
            return StatusCode((int)ex.StatusCodes, string.IsNullOrEmpty(ex.Message) ? null : ex.Message);
        }


        [HttpDelete("DeleteContenido/{IdCF_Formacion}/{IdCF_Version}/{IdCF_PaginaContent}")]
        public async Task<ActionResult> DeleteContenido(int IdCF_Formacion, int IdCF_Version, int IdCF_PaginaContent)
        {
            try
            {
                await _formacion.DeleteContenido(IdCF_Formacion, IdCF_Version, IdCF_PaginaContent);
                return NoContent();
            }
            catch (ApiException ex)
            {
                return  ValidException(ex);
            }
        }
        [HttpGet("PublicarVersion/{IdCF_Formacion}/{IdCF_Version}")]
        public async Task<ActionResult> PublicarVersion(int IdCF_Formacion, int IdCF_Version)
        {
            try
            {
                await _formacion.PublicarVersion(IdCF_Formacion, IdCF_Version);
                return NoContent();
            }
            catch (ApiException ex)
            {
                return  ValidException(ex);
            }
        }
        [HttpPut("UpdateContenido/{IdCF_Formacion}/{IdCF_Version}/{IdCF_PaginaContent}")]
        public async Task<ActionResult> UpdateContenido(int IdCF_Formacion, int IdCF_Version, int IdCF_PaginaContent, [FromForm] CF_PaginaContent_updModel model)
        {
            try
            {
                await _formacion.UpdateContenido(IdCF_Formacion, IdCF_Version, IdCF_PaginaContent, model);
                return NoContent();
            }
            catch (ApiException ex)
            {
                return ValidException(ex);
            }
        }
        [HttpPost("AddContenido/{IdCF_Formacion}/{IdCF_Version}")]
        public async Task<ActionResult<CF_PaginaContent>> AddContenido(int IdCF_Formacion, int IdCF_Version, CF_PaginaContent_addModel model)
        {
            try
            {
                var data = await _formacion.AddContenido(IdCF_Formacion, IdCF_Version, model);
                return data;
            }
            catch (ApiException ex)
            {
                return ValidException(ex);
            }
        }
        [HttpGet("DetailsContenido")]
        public async Task<ActionResult<CF_PaginaContent>> DetailsContenido(int IdCF_Version, int CF_PaginaContent)
        {
            try
            {
                var data = await _formacion.DetailsContenido(IdCF_Version, CF_PaginaContent);
                return data;
            }
            catch (ApiException ex)
            {
                return ValidException(ex);
            }
        }
        [HttpGet("ListContenidos")]
        public async Task<ActionResult<IEnumerable<CF_PaginaContent>>> ListContenidos(int IdCF_Formacion, int IdCF_Version)
        {
            try
            {
                var data = await _formacion.ListContenidos(IdCF_Formacion, IdCF_Version);
                return Ok(data);
            }
            catch (ApiException ex)
            {
                return ValidException(ex);
            }
        }
        [HttpPut("UpdateVersion/{IdCF_Formacion:int}/{IdCF_Version:int}")]
        public async Task<ActionResult> UpdateVersion(int IdCF_Formacion, int IdCF_Version, CF_Version_updModel model)
        {
            try
            {
                await _formacion.UpdateVersion(IdCF_Formacion, IdCF_Version, model);
                return NoContent();
            }
            catch (ApiException ex)
            {
                return ValidException(ex);
            }
        }
        [HttpGet("DetailsVersion")]
        public async Task<ActionResult<CF_Version>> DetailsVersion(int IdCF_Formacion, int IdCF_Version)
        {
            try
            {
                var data = await _formacion.DetailsVersion(IdCF_Formacion, IdCF_Version);

                if (data is null) return NotFound();

                return data;
            }
            catch (ApiException ex)
            {
                return ValidException(ex);
            }
        }
        [HttpPost("AddVersion/{IdCF_Formacion:int}")]
        public async Task<ActionResult<CF_Version>> AddVersion(int IdCF_Formacion, CF_Version_addModel model)
        {
            try
            {
                var data = await _formacion.AddVersion(IdCF_Formacion, model);
                return Ok(data);
            }
            catch (ApiException ex)
            {
                return ValidException(ex);
            }
        }
        [HttpGet("ListVersiones")]
        public async Task<ActionResult<IEnumerable<CF_Version>>> ListVersiones(int IdCF_Formacion)
        {
            try
            {
                var data = await _formacion.ListVersiones(IdCF_Formacion);
                return Ok(data);
            }
            catch (ApiException ex)
            {
                return ValidException(ex);
            }
        }
        [HttpPut("UpdateFormacion")]
        public async Task<ActionResult> UpdateFormacion(int IdCF_Formacion, CF_Formacion_updModel model)
        {
            try
            {
                await _formacion.UpdateFormacion(IdCF_Formacion, model);
                return NoContent();
            }
            catch (ApiException ex)
            {
                return ValidException(ex);
            }
        }
        [HttpPost("AddFormacion")]
        public async Task<ActionResult<CF_Formacion>> AddFormacion(CF_Formacion_addModel model)
        {
            try
            {
                var data = await _formacion.AddFormacion(model);
                return Ok(data);
            }
            catch (ApiException ex)
            {
                return ValidException(ex);
            }
        }
        [HttpGet("DetailsFormacion")]
        public async Task<ActionResult<CF_Formacion>> DetailsFormacion(int IdCF_Formacion)
        {
            try
            {
                var data = await _formacion.DetailsFormacion(IdCF_Formacion);
                return Ok(data);
            }
            catch (ApiException ex)
            {
                return ValidException(ex);
            }
        }
        [HttpGet("ListFormaciones")]
        public async Task<ActionResult<IEnumerable<CF_Formacion>>> ListFormaciones()
        {
            try
            {
                var data = await _formacion.ListFormaciones();
                return Ok(data);
            }
            catch (ApiException ex)
            {
                return ValidException(ex);
            }
        }
        [HttpPost("AddEval/{IdCF_Formacion}/{IdCF_Version}")]
        public async Task<ActionResult<View_formacion_evaluacion>> AddEval(int IdCF_Formacion, int IdCF_Version, CF_FormacionEva_addModel model)
        {
            try
            {
                var data = await _formacion.AddEval(IdCF_Formacion, IdCF_Version, model);
                return Ok(data);
            }
            catch (ApiException ex)
            {
                return ValidException(ex);
            }
        }
        [HttpGet("ListEvalbyForm/{IdCF_Formacion}/{IdCF_Version}")]
        public async Task<ActionResult<IEnumerable<View_formacion_evaluacion>>> ListEvalbyForm(int IdCF_Formacion, int IdCF_Version)
        {
            try
            {
                var data = await _formacion.ListEvalbyForm(IdCF_Formacion, IdCF_Version);
                return Ok(data);
            }
            catch (ApiException ex)
            {
                return ValidException(ex);
            }
        }
        [HttpGet("DeleteEval/{IdCF_Formacion}/{IdCF_Version}/{IdCF_FormacionEval}")]
        public async Task<ActionResult> DeleteEval(int IdCF_Formacion, int IdCF_Version, int IdCF_FormacionEval)
        {
            try
            {
                await _formacion.DeleteEval(IdCF_Formacion, IdCF_Version, IdCF_FormacionEval);
                return NoContent();
            }
            catch (ApiException ex)
            {
                return ValidException(ex);
            }
        }
    }
}
