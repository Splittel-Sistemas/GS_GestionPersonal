using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using GestionPersonal.Areas.v2.Entities;
using GestionPersonal.Areas.v2.Models;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace GestionPersonal.Areas.v2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormacionObjectController : ControllerBase
    {
        private readonly GPSctx _context;
        private readonly ILogger<FormacionObjectController> _logger;
        private readonly IMapper _mapper;
        [Obsolete]
        private readonly IHostingEnvironment _environment;
        private readonly string _sms_versionPublicada = "Imposible realizar cambios en una version ya publicada.";

        public FormacionObjectController(GPSctx context, ILogger<FormacionObjectController> logger, IMapper mapper, IHostingEnvironment environment)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
            _environment = environment;
        }

        [HttpGet("{IdCF_Formacion:int}/{IdCF_Version:int}/{IdCF_versionObject:int}")]
        public async Task<ActionResult> Delete(int IdCF_Formacion, int IdCF_Version, int IdCF_versionObject)
        {
            var data = await _context.CF_versionObject.FirstOrDefaultAsync(x => x.IdCF_Version == IdCF_Version && x.IdCF_versionObject == IdCF_versionObject);
            if (data is null) return NotFound();
            // validar version publicada
            if (await CheckPublish(IdCF_Formacion, IdCF_Version))
                return BadRequest(_sms_versionPublicada);

            _context.CF_versionObject.Remove(data);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("{IdCF_Formacion:int}/{IdCF_Version:int}")]
        public async Task<ActionResult<CF_versionObject>> Create(int IdCF_Formacion, int IdCF_Version, CF_versionObject_AddModel model)
        {
            if (!_context.CF_Version.Any(x => x.IdCF_Formacion == IdCF_Formacion && x.IdCF_Version == IdCF_Version))
                return NotFound();
            // validar version publicada
            if (await CheckPublish(IdCF_Formacion, IdCF_Version))
                return BadRequest(_sms_versionPublicada);

            var obj = _mapper.Map<CF_versionObject>(model);

            _context.CF_versionObject.Add(obj);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Details), new
            {
                IdCF_Formacion,
                IdCF_Version,
                obj.IdCF_versionObject
            }, obj);
        }

        [HttpGet("{IdCF_Formacion:int}/{IdCF_Version:int}/{IdCF_versionObject:int}")]
        public async Task<ActionResult<CF_versionObject>> Details(int IdCF_Formacion, int IdCF_Version, int IdCF_versionObject)
        {
            var data = await _context.CF_versionObject.FirstOrDefaultAsync(x => x.IdCF_Version == IdCF_Version && x.IdCF_versionObject == IdCF_versionObject);
            if (data is null) return NotFound();

            return Ok(data);
        }

        [HttpGet("{IdCF_Formacion:int}/{IdCF_Version:int}")]
        public async Task<ActionResult<IEnumerable<CF_versionObject>>> List(int IdCF_Formacion, int IdCF_Version)
        {
            if (!_context.CF_Version.Any(x => x.IdCF_Formacion == IdCF_Formacion && x.IdCF_Version == IdCF_Version))
                return NotFound();

            var data = await _context.CF_versionObject.Where( x => x.IdCF_Version == IdCF_Version).ToListAsync();

            return data;
        }

        private async Task<bool> CheckPublish(int IdCF_Formacion, int IdCF_Version)
        {
            return await _context.CF_Version.Where(x => x.IdCF_Formacion == IdCF_Formacion && x.IdCF_Version == IdCF_Version).Select(x => x.Publicada).FirstAsync();
        }
    }
}
