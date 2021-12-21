using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System;
using System.IO;
using Microsoft.Extensions.Logging;
using GestionPersonal.Areas.v2.Entities;
using GestionPersonal.Areas.v2.Helpers;
using GestionPersonal.Areas.v2.Models;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace GestionPersonal.Areas.v2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormacionContenidoController : ControllerBase
    {
        private readonly GPSctx _context;
        private readonly ILogger<FormacionContenidoController> _logger;
        private readonly IMapper _mapper;
        [Obsolete]
        private readonly IHostingEnvironment _environment;
        private readonly string _sms_versionPublicada = "Imposible realizar cambios en una version ya publicada.";

        public FormacionContenidoController(GPSctx context, ILogger<FormacionContenidoController> logger, IMapper mapper, IHostingEnvironment environment)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
            _environment = environment;
        }


        [HttpDelete("{IdCF_Formacion:int}/{IdCF_Version:int}/{IdCF_PaginaContent:int}")]
        public async Task<ActionResult> Delete(int IdCF_Formacion, int IdCF_Version, int IdCF_PaginaContent)
        {
            var data = await _context.CF_PaginaContent.FirstOrDefaultAsync(x => x.IdCF_Version == IdCF_Version && x.IdCF_PaginaContent == IdCF_PaginaContent);
            if (data is null)
                return NotFound();

            // validar version publicada
            if (await CheckPublish(IdCF_Formacion, IdCF_Version))
                return BadRequest(_sms_versionPublicada);

            _context.CF_PaginaContent.Remove(data);
            await _context.SaveChangesAsync();

            return NoContent();
        } 
            
        [HttpGet("{IdCF_Formacion:int}/{IdCF_Version:int}/{IdCF_PaginaContent:int}")]
        public async Task<ActionResult> Edit(int IdCF_Formacion, int IdCF_Version, int IdCF_PaginaContent, [FromBody] CF_PaginaContent_updModel model)
        {
            if (!_context.CF_PaginaContent.Any(x => x.IdCF_Version == IdCF_Version && x.IdCF_PaginaContent == IdCF_PaginaContent))
                return NotFound();

            // validar version publicada
            if (await CheckPublish(IdCF_Formacion, IdCF_Version))
                return BadRequest(_sms_versionPublicada);

            var contenido = _mapper.Map<CF_PaginaContent>(model);

            // validar que campos seral modificados
            _context.Entry(contenido).State = EntityState.Modified;
            _context.Entry(contenido).Property(x => x.CreatedAt).IsModified = false;
            _context.Entry(contenido).Property(x => x.NoPage).IsModified = false;
            _context.Entry(contenido).Property(x => x.IdCF_Version).IsModified = false;

            if (model.PageContent is null)
            {
                _context.Entry(contenido).Property(x => x.FilePath).IsModified = false;
            }
            else
            {
                contenido.FilePath = ValidateUploadFile(model.PageContent, IdCF_Formacion, IdCF_Version, model.NombrePage);
            }

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPost("{IdCF_Formacion:int}/{IdCF_Version:int}")]
        [Obsolete]
        public async Task<ActionResult<CF_PaginaContent>> Create(int IdCF_Formacion, int IdCF_Version,[FromBody] CF_PaginaContent_addModel model)
        {
            // validar version publicada
            if (await CheckPublish(IdCF_Formacion, IdCF_Version))
                return BadRequest(_sms_versionPublicada);

            if (model.IdCF_Version != IdCF_Version)
                return BadRequest("Datos incorrectos");

            var content = _mapper.Map<CF_PaginaContent>(model);

            content.FilePath = ValidateUploadFile(model.PageContent, IdCF_Formacion, IdCF_Version, model.NombrePage);
            _context.CF_PaginaContent.Add(content);

            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Details), new
            {
                IdCF_Formacion,
                IdCF_Version,
                content.IdCF_PaginaContent
            }, content);
        }

        [HttpGet("{IdCF_Formacion:int}/{IdCF_Version:int}/{IdCF_PaginaContent:int}")]
        public async Task<ActionResult<CF_PaginaContent>> Details(int IdCF_Formacion, int IdCF_Version, int IdCF_PaginaContent)
        {
            var data = await _context.CF_PaginaContent.FirstOrDefaultAsync(x => x.IdCF_Version == IdCF_Version && x.IdCF_PaginaContent == IdCF_PaginaContent);
            if (data is null)
                return NotFound();

            return Ok(data);
        }

        private async Task<bool> CheckPublish(int IdCF_Formacion, int IdCF_Version)
        {
            return await _context.CF_Version.Where(x => x.IdCF_Formacion == IdCF_Formacion && x.IdCF_Version == IdCF_Version).Select(x => x.Publicada).FirstAsync();
        }

        [Obsolete]
        private string ValidateUploadFile(IFormFile file, int IdCF_Formacion, int IdCF_Version, string Name)
        {
            if (file == null)
            {
                return "";
            }

            if (file.Length <= 0)
                throw new ApiException("Archivo de contenido dañado", EnumStatusCodes.BadRequest);

            string PathFolder = $"{_environment.WebRootPath}\\Formacion\\{IdCF_Formacion}\\{IdCF_Version}\\";
            string FolderFile = $"Formacion/{IdCF_Formacion}/{IdCF_Version}/{Name.Replace(" ","_")}.html";
            if (!Directory.Exists(PathFolder))
                Directory.CreateDirectory(PathFolder);

            if (System.IO.File.Exists(PathFolder))
                System.IO.File.Delete(PathFolder);

            using (FileStream fs = System.IO.File.Create($"{PathFolder}\\{Name.Replace(" ", "_")}.html"))
            {
                file.CopyTo(fs);
                fs.Flush();
            }
            return FolderFile;
        }
    }
}
