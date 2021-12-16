using GestionPersonal.Areas.v2.Entities;
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
    [Route("v2/api/[controller]/[action]")]
    [ApiController]
    public class FormacionEvaController : ControllerBase
    {
        private readonly ILogger<FormacionEvaController> _logger;
        private readonly ICF_Evaluacion _formacion;

        public FormacionEvaController(ILogger<FormacionEvaController> logger, ICF_Evaluacion formacion)
        {
            _logger = logger;
            _formacion = formacion;
        }

        [HttpPost]
        public async Task<ActionResult<CF_Evaluacion>> EvaCreate(CF_Evaluacion_addModel model)
        {
            var data = await _formacion.EvaCreate(model);
            return CreatedAtAction(nameof(EvaDetails), new
            {
                data.IdCF_Evaluacion
            }, data);
        }
        [HttpGet("{IdCF_Evaluacion}")]
        public async Task<ActionResult<CF_Evaluacion>> EvaDetails(int IdCF_Evaluacion)
        {
            var data = await _formacion.EvaDetails(IdCF_Evaluacion);
            if (data is null) return NotFound();
            return data;
        }
        [HttpPut("{IdCF_Evaluacion}")]
        public async Task<ActionResult> EvaEdit(int IdCF_Evaluacion, CF_Evaluacion_updModel model)
        {
            await _formacion.EvaEdit(IdCF_Evaluacion, model);
            return NoContent();
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CF_Evaluacion>>> EvaList()
        {
            return Ok(await _formacion.EvaList());
        }
        [HttpPost("{IdCF_EvaluacionVersion}")]
        public async Task<ActionResult<CF_EvaluacionPreg>> EvaPregCreate(int IdCF_EvaluacionVersion, CF_EvaluacionPreg_addModel model)
        {
            var data = await _formacion.EvaPregCreate(IdCF_EvaluacionVersion, model);
            return CreatedAtAction(nameof(EvaPregDetails), new
            {
                data.IdCF_EvaluacionPreg,
                data.IdCF_EvaluacionVersion
            }, data);
        }
        [HttpPost("{IdCF_EvaluacionVersion}/{IdCF_EvaluacionSeccion}")]
        public async Task<ActionResult<CF_EvaluacionPreg>> EvaPregCreateSeccion(int IdCF_EvaluacionVersion, int IdCF_EvaluacionSeccion, CF_EvaluacionPreg_addModel model)
        {
            var data = await _formacion.EvaPregCreateSeccion(IdCF_EvaluacionVersion, IdCF_EvaluacionSeccion, model);
            return CreatedAtAction(nameof(EvaPregDetailsSeccion), new
            {
                data.IdCF_EvaluacionPreg,
                data.IdCF_EvaluacionVersion,
                data.IdCF_EvaluacionSeccion
            }, data);
        }
        [HttpDelete("{IdCF_EvaluacionVersion}/{IdCF_EvaluacionPreg}")]
        public async Task<ActionResult> EvaPregDelete(int IdCF_EvaluacionVersion, int IdCF_EvaluacionPreg)
        {
            await _formacion.EvaPregDelete(IdCF_EvaluacionVersion, IdCF_EvaluacionPreg);
            return NoContent();
        }
        [HttpDelete("{IdCF_EvaluacionVersion}/{IdCF_EvaluacionSeccion}/{IdCF_EvaluacionPreg}")]
        public async Task<ActionResult> EvaPregDeleteSeccion(int IdCF_EvaluacionVersion, int IdCF_EvaluacionSeccion, int IdCF_EvaluacionPreg)
        {
            await _formacion.EvaPregDeleteSeccion(IdCF_EvaluacionVersion, IdCF_EvaluacionSeccion, IdCF_EvaluacionPreg);
            return NoContent();
        }
        [HttpGet("{IdCF_EvaluacionVersion}/{IdCF_EvaluacionPreg}")]
        public async Task<ActionResult<CF_EvaluacionPreg>> EvaPregDetails(int IdCF_EvaluacionVersion, int IdCF_EvaluacionPreg)
        {
            var data = await _formacion.EvaPregDetails(IdCF_EvaluacionVersion, IdCF_EvaluacionPreg);
            if (data is null) return NotFound();
            return data;
        }
        [HttpGet("{IdCF_EvaluacionVersion}/{IdCF_EvaluacionSeccion}/{IdCF_EvaluacionPreg}")]
        public async Task<ActionResult<CF_EvaluacionPreg>> EvaPregDetailsSeccion(int IdCF_EvaluacionVersion, int IdCF_EvaluacionSeccion, int IdCF_EvaluacionPreg)
        {
            var data = await _formacion.EvaPregDetailsSeccion(IdCF_EvaluacionVersion, IdCF_EvaluacionSeccion, IdCF_EvaluacionPreg);
            if (data is null) return NotFound();
            return data;
        }
        [HttpPut("{IdCF_EvaluacionVersion}/{IdCF_EvaluacionPreg}")]
        public async Task<ActionResult> EvaPregEdit(int IdCF_EvaluacionVersion, int IdCF_EvaluacionPreg, [FromForm] CF_EvaluacionPreg_updModel model)
        {
            await _formacion.EvaPregEdit(IdCF_EvaluacionVersion, IdCF_EvaluacionPreg, model);
            return NoContent();
        }
        [HttpPut("{IdCF_EvaluacionVersion}/{IdCF_EvaluacionSeccion}/{IdCF_EvaluacionPreg}")]
        public async Task<ActionResult> EvaPregEditSeccion(int IdCF_EvaluacionVersion, int IdCF_EvaluacionSeccion, int IdCF_EvaluacionPreg, [FromForm] CF_EvaluacionPreg_updModel model)
        {
            await _formacion.EvaPregEditSeccion(IdCF_EvaluacionVersion, IdCF_EvaluacionSeccion, IdCF_EvaluacionPreg, model);
            return NoContent();
        }
        [HttpGet("{IdCF_EvaluacionVersion}")]
        public async Task<ActionResult<IEnumerable<CF_EvaluacionPreg>>> EvaPregList(int IdCF_EvaluacionVersion)
        {
            return Ok( await _formacion.EvaPregList(IdCF_EvaluacionVersion));
        }
        [HttpGet("{IdCF_EvaluacionVersion}/{IdCF_EvaluacionSeccion}")]
        public async Task<ActionResult<IEnumerable<CF_EvaluacionPreg>>> EvaPregListSeccion(int IdCF_EvaluacionVersion, int IdCF_EvaluacionSeccion)
        {
            return Ok(await _formacion.EvaPregListSeccion(IdCF_EvaluacionVersion, IdCF_EvaluacionSeccion));
        }
        [HttpPost("{IdCF_EvaluacionVersion}/{IdCF_EvaluacionPreg}")]
        public async Task<ActionResult<CF_EvaluacionPregRes>> EvaPregRespCreate(int IdCF_EvaluacionVersion, int IdCF_EvaluacionPreg, CF_EvaluacionPregRes_addModel model)
        {
            var data = await _formacion.EvaPregRespCreate(IdCF_EvaluacionVersion, IdCF_EvaluacionPreg, model);
            return CreatedAtAction(nameof(EvaPregRespDetails), new
            {
                IdCF_EvaluacionVersion,
                data.IdCF_EvaluacionPreg,
                data.IdCF_EvaluacionPregRes
            }, data);
        }
        [HttpDelete("{IdCF_EvaluacionVersion}/{IdCF_EvaluacionPreg}/{IdCF_EvaluacionPregRes}")]
        public async Task<ActionResult> EvaPregRespDelete(int IdCF_EvaluacionVersion, int IdCF_EvaluacionPreg, int IdCF_EvaluacionPregRes)
        {
            await _formacion.EvaPregRespDelete(IdCF_EvaluacionVersion, IdCF_EvaluacionPreg, IdCF_EvaluacionPregRes);
            return NoContent();
        }
        [HttpGet("{IdCF_EvaluacionVersion}/{IdCF_EvaluacionPreg}/{IdCF_EvaluacionPregRes}")]
        public async Task<ActionResult<CF_EvaluacionPregRes>> EvaPregRespDetails(int IdCF_EvaluacionVersion, int IdCF_EvaluacionPreg, int IdCF_EvaluacionPregRes)
        {
            var data = await _formacion.EvaPregRespDetails(IdCF_EvaluacionVersion, IdCF_EvaluacionPreg, IdCF_EvaluacionPregRes);
            if (data is null) return NotFound();

            return data;
        }
        [HttpPut("{IdCF_EvaluacionVersion}/{IdCF_EvaluacionPreg}/{IdCF_EvaluacionPregRes}")]
        public async Task<ActionResult> EvaPregRespEdit(int IdCF_EvaluacionVersion, int IdCF_EvaluacionPreg, int IdCF_EvaluacionPregRes, CF_EvaluacionPregRes_updModel model)
        {
            await _formacion.EvaPregRespEdit(IdCF_EvaluacionVersion, IdCF_EvaluacionPreg, IdCF_EvaluacionPregRes, model);
            return NoContent();
        }
        [HttpGet("{IdCF_EvaluacionVersion}/{IdCF_EvaluacionPreg}")]
        public async Task<ActionResult<IEnumerable<CF_EvaluacionPregRes>>> EvaPregRespList(int IdCF_EvaluacionVersion, int IdCF_EvaluacionPreg)
        {
            var data = await _formacion.EvaPregRespList(IdCF_EvaluacionVersion, IdCF_EvaluacionPreg);
            return Ok(data);
        }
        [HttpPost("{IdCF_EvaluacionVersion}")]
        public async Task<ActionResult<CF_EvaluacionSeccion>> EvaSeccionCreate(int IdCF_EvaluacionVersion, CF_EvaluacionSeccion_addModel model)
        {
            var data = await _formacion.EvaSeccionCreate(IdCF_EvaluacionVersion, model);
            return CreatedAtAction(nameof(EvaSeccionDetails), new
            {
                IdCF_EvaluacionVersion,
                data.IdCF_EvaluacionSeccion,
            }, data);
        }
        [HttpDelete("{IdCF_EvaluacionVersion}/{IdCF_EvaluacionSeccion}")]
        public async Task<ActionResult> EvaSeccionDelete(int IdCF_EvaluacionVersion, int IdCF_EvaluacionSeccion)
        {
            await _formacion.EvaSeccionDelete(IdCF_EvaluacionVersion, IdCF_EvaluacionSeccion);
            return NoContent();
        }
        [HttpGet("{IdCF_EvaluacionVersion}/{IdCF_EvaluacionSeccion}")]
        public async Task<ActionResult<CF_EvaluacionSeccion>> EvaSeccionDetails(int IdCF_EvaluacionVersion, int IdCF_EvaluacionSeccion)
        {
            var data = await _formacion.EvaSeccionDetails(IdCF_EvaluacionVersion, IdCF_EvaluacionSeccion);
            if (data is null) return NotFound();

            return data;
        }
        [HttpPut("{IdCF_EvaluacionVersion}/{IdCF_EvaluacionSeccion}")]
        public async Task<ActionResult> EvaSeccionEdit(int IdCF_EvaluacionVersion, int IdCF_EvaluacionSeccion, CF_EvaluacionSeccion_updModel model)
        {
            await _formacion.EvaSeccionEdit(IdCF_EvaluacionVersion, IdCF_EvaluacionSeccion, model);
            return NoContent();
        }
        [HttpGet("{IdCF_EvaluacionVersion}")]
        public async Task<ActionResult<IEnumerable<CF_EvaluacionSeccion>>> EvaSeccionList(int IdCF_EvaluacionVersion)
        {
            var data = await _formacion.EvaSeccionList(IdCF_EvaluacionVersion);
            return Ok(data);
        }
        [HttpPost("{IdCF_Evaluacion}")]
        public async Task<ActionResult<CF_EvaluacionVersion>> EvaVersionCreate(int IdCF_Evaluacion, CF_EvaluacionVersion_addModel model)
        {
            var data = await _formacion.EvaVersionCreate(IdCF_Evaluacion, model);
            return CreatedAtAction(nameof(EvaVersionDetails), new
            {
                IdCF_Evaluacion,
                data.IdCF_EvaluacionVersion,
            }, data);
        }
        [HttpDelete("{IdCF_Evaluacion}/{IdCF_EvaluacionVersion}")]
        public async Task<ActionResult> EvaVersionDelete(int IdCF_Evaluacion, int IdCF_EvaluacionVersion)
        {
            await _formacion.EvaVersionDelete(IdCF_Evaluacion, IdCF_EvaluacionVersion);
            return NoContent();
        }
        [HttpGet("{IdCF_Evaluacion}/{IdCF_EvaluacionVersion}")]
        public async Task<ActionResult<CF_EvaluacionVersion>> EvaVersionDetails(int IdCF_Evaluacion, int IdCF_EvaluacionVersion)
        {
            var data = await _formacion.EvaVersionDetails(IdCF_Evaluacion, IdCF_EvaluacionVersion);
            if (data is null) return NotFound();

            return data;
        }
        [HttpPut("{IdCF_Evaluacion}/{IdCF_EvaluacionVersion}")]
        public async Task<ActionResult> EvaVersionEdit(int IdCF_Evaluacion, int IdCF_EvaluacionVersion, CF_EvaluacionVersion_updModel model)
        {
            await _formacion.EvaVersionEdit(IdCF_Evaluacion, IdCF_EvaluacionVersion, model);
            return NoContent();
        }
        [HttpGet("{IdCF_Evaluacion}")]
        public async Task<ActionResult<IEnumerable<CF_EvaluacionVersion>>> EvaVersionList(int IdCF_Evaluacion)
        {
            var data = await _formacion.EvaVersionList(IdCF_Evaluacion);
            return Ok(data);
        }
        [HttpGet("{IdCF_Evaluacion}/{IdCF_EvaluacionVersion}")]
        public async Task<ActionResult> EvaVersionPublicar(int IdCF_Evaluacion, int IdCF_EvaluacionVersion)
        {
            await _formacion.EvaVersionPublicar(IdCF_Evaluacion, IdCF_EvaluacionVersion);
            return NoContent();
        }
    }
}
