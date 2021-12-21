using AutoMapper;
using GestionPersonal.Areas.v2.Entities;
using GestionPersonal.Areas.v2.Helpers;
using GestionPersonal.Areas.v2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace GestionPersonal.Areas.v2.Services
{
    public interface IFormacion
    {
        public Task DeleteContenido(int IdCF_Formacion, int IdCF_Version, int IdCF_PaginaContent);
        public Task UpdateContenido(int IdCF_Formacion, int IdCF_Version, int IdCF_PaginaContent, CF_PaginaContent_updModel model);
        public Task<CF_PaginaContent> AddContenido(int IdCF_Formacion, int IdCF_Version, CF_PaginaContent_addModel model);
        public Task<CF_PaginaContent> DetailsContenido(int IdCF_Version, int CF_PaginaContent);
        public Task<IEnumerable<CF_PaginaContent>> ListContenidos(int IdCF_Formacion, int IdCF_Version);

        public Task UpdateVersion(int IdCF_Formacion, int IdCF_Version, CF_Version_updModel model);
        public Task<CF_Version> DetailsVersion(int IdCF_Formacion, int IdCF_Version);
        public Task<CF_Version> AddVersion(int IdCF_Formacion, CF_Version_addModel model);
        public Task<IEnumerable<CF_Version>> ListVersiones(int IdCF_Formacion, bool showInactiveToo = false);
        public Task PublicarVersion(int IdCF_Formacion, int IdCF_Version);

        public Task UpdateFormacion(int IdCF_Formacion, CF_Formacion_updModel model);
        public Task<CF_Formacion> AddFormacion(CF_Formacion_addModel model);
        public Task<CF_Formacion> DetailsFormacion(int IdCF_Formacion);
        public Task<IEnumerable<CF_Formacion>> ListFormaciones(bool showInactiveToo = false);

        public bool ValidFormacionExists(int IdCF_Formacion);
        public bool ValidVersionExists(int IdCF_Formacion, int IdCF_Version);
        public bool ValidateContenido(int IdCF_Formacion, int IdCF_Version, int IdCF_PaginaContent);
        public bool ValidFormacionVerPub(int IdCF_Formacion, int IdCF_Version);

        public Task<View_formacion_evaluacion> AddEval(int IdCF_Formacion, int IdCF_Version,CF_FormacionEva_addModel model);
        public Task<IEnumerable<View_formacion_evaluacion>> ListEvalbyForm(int IdCF_Formacion, int IdCF_Version);
        public Task DeleteEval(int IdCF_Formacion, int IdCF_Version, int IdCF_FormacionEval);

    }
    public class FormacionServ : IFormacion
    {
        private readonly GPSctx _context;
        private readonly ILogger<FormacionServ> _logger;
        private readonly IMapper _mapper;
        [Obsolete]
        private readonly IHostingEnvironment _environment;
        private readonly string _sms_versionPublicada = "Imposible realizar cambios en una version ya publicada.";

        [Obsolete]
        public FormacionServ(GPSctx context, ILogger<FormacionServ> logger, IMapper mapper, IHostingEnvironment environment)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
            _environment = environment;
        }

        public async Task<CF_PaginaContent> AddContenido(int IdCF_Formacion, int IdCF_Version, CF_PaginaContent_addModel model)
        {
            // validar parametros
            if (model.IdCF_Version != IdCF_Version)
                throw new ApiException(EnumStatusCodes.BadRequest);

            if(!_context.CF_Version.Any(x => x.IdCF_Formacion == IdCF_Formacion && x.IdCF_Version == IdCF_Version))
                throw new ApiException(EnumStatusCodes.NotFound);
            
            // valdiar que la version no se encuentre publicada
            if (ValidFormacionVerPub(IdCF_Formacion, IdCF_Version))
                throw new ApiException(_sms_versionPublicada, EnumStatusCodes.BadRequest);
            
            var Contenido = _mapper.Map<CF_PaginaContent>(model);
            //no de verces que el nombre se repite
            int nameNoRepet = _context.CF_PaginaContent.Count(x => x.IdCF_Version == IdCF_Version && x.NombrePage == Contenido.NombrePage);
            Contenido.NombrePage = $"{Contenido.NombrePage} {(nameNoRepet > 0 ? $"({nameNoRepet})" : "")}";
            _context.CF_PaginaContent.Add(Contenido);

            await _context.SaveChangesAsync();

            return Contenido;
        }

        public async Task<CF_Formacion> AddFormacion(CF_Formacion_addModel model)
        {
            
            var formacion = _mapper.Map<CF_Formacion>(model);

            _context.CF_Formacion.Add(formacion);

            await _context.SaveChangesAsync();

            return formacion;
        }

        public async Task<CF_Version> AddVersion(int IdCF_Formacion, CF_Version_addModel model)
        {
            // validar parametros
            if (model.IdCF_Formacion != IdCF_Formacion )
                throw new ApiException(EnumStatusCodes.BadRequest);
            // validar si existe la formacion
            if(!_context.CF_Formacion.Any(x => x.IdCF_Formacion == IdCF_Formacion))
                throw new ApiException(EnumStatusCodes.NotFound);

            var version = _mapper.Map<CF_Version>(model);
            version.NoVersion = _context.CF_Version.Count(x => x.IdCF_Formacion == IdCF_Formacion) + 1;
            _context.CF_Version.Add(version);

            await _context.SaveChangesAsync();

            return version;
        }

        public async Task DeleteContenido(int IdCF_Formacion, int IdCF_Version, int IdCF_PaginaContent)
        {
            //valdiar que la version no se encuentre publicada
            if (ValidFormacionVerPub(IdCF_Formacion, IdCF_Version)) 
                throw new ApiException(_sms_versionPublicada, EnumStatusCodes.BadRequest);

            var contenido = await _context.CF_PaginaContent.SingleOrDefaultAsync(x => x.IdCF_PaginaContent == IdCF_PaginaContent && x.IdCF_Version == IdCF_Version);

            _context.CF_PaginaContent.Remove(contenido);

            await _context.SaveChangesAsync();
        }

        public async Task<CF_PaginaContent> DetailsContenido(int IdCF_Version, int CF_PaginaContent)
        {
            return await _context.CF_PaginaContent.FirstOrDefaultAsync(x => x.IdCF_PaginaContent == CF_PaginaContent && x.IdCF_Version == IdCF_Version);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="IdCF_Formacion"></param>
        /// <returns></returns>
        public async Task<CF_Formacion> DetailsFormacion(int IdCF_Formacion)
        {
            return await _context.CF_Formacion.FirstOrDefaultAsync(x => x.IdCF_Formacion == IdCF_Formacion);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="IdCF_Formacion"></param>
        /// <param name="IdCF_Version"></param>
        /// <returns></returns>
        public async Task<IEnumerable<CF_PaginaContent>> ListContenidos(int IdCF_Formacion, int IdCF_Version)
        {
            //ValidVersionExists(IdCF_Formacion, IdCF_Version);
            return await _context.CF_PaginaContent.Where(x => x.IdCF_Version == IdCF_Version).ToListAsync();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="showInactiveToo"></param>
        /// <returns></returns>
        public async Task<IEnumerable<CF_Formacion>> ListFormaciones(bool showInactiveToo = false)
        {
            return await _context.CF_Formacion.ToListAsync();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="IdCF_Formacion"></param>
        /// <param name="showInactiveToo"></param>
        /// <returns></returns>
        public async Task<IEnumerable<CF_Version>> ListVersiones(int IdCF_Formacion, bool showInactiveToo = false)
        {
            //ValidFormacionExists(IdCF_Formacion);
            return await _context.CF_Version.Where(x => x.IdCF_Formacion == IdCF_Formacion).ToListAsync();
        }

        public async Task UpdateContenido(int IdCF_Formacion, int IdCF_Version, int IdCF_PaginaContent, CF_PaginaContent_updModel model)
        {
            // validar parametros
            if (model.IdCF_Version != IdCF_Version || model.IdCF_PaginaContent != IdCF_PaginaContent)
                throw new ApiException(EnumStatusCodes.BadRequest);

            //valdiar que la version no se encuentre publicada
            if (ValidFormacionVerPub(IdCF_Formacion, IdCF_Version)) 
                throw new ApiException(_sms_versionPublicada, EnumStatusCodes.BadRequest);

            ValidateContenido(IdCF_Formacion, IdCF_Version, IdCF_PaginaContent);

            try
            {
                var contenido = _mapper.Map<CF_PaginaContent>(model);
                // validar que campos seral modificados
                _context.Entry(contenido).State = EntityState.Modified;
                _context.Entry(contenido).Property(x => x.CreatedAt).IsModified = false;
                _context.Entry(contenido).Property(x => x.NoPage).IsModified = false;
                _context.Entry(contenido).Property(x => x.IdCF_Version).IsModified = false;

                if(model.PageContent is null)
                {
                    _context.Entry(contenido).Property(x => x.FilePath).IsModified = false;
                }
                else
                {
                    contenido.FilePath = ValidateUploadFile(model.PageContent, IdCF_Formacion, IdCF_Version, IdCF_PaginaContent);
                }

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                _logger.LogError(ex.Message);
                throw new ApiException(EnumStatusCodes.InternalServerError);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="IdCF_Formacion"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task UpdateFormacion(int IdCF_Formacion, CF_Formacion_updModel model)
        {
            // validar parametros
            if(model.IdCF_Formacion != IdCF_Formacion)
                throw new ApiException(EnumStatusCodes.BadRequest);

            // validar que exista la capacitacion
            ValidFormacionExists(IdCF_Formacion);

            try
            {
                var fromacion = _mapper.Map<CF_Formacion>(model);
                // validar que campos seral modificados
                _context.Entry(fromacion).State = EntityState.Modified;
                _context.Entry(fromacion).Property(x => x.CreatedAt).IsModified = false;

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                _logger.LogError(ex.Message);
                throw new ApiException(EnumStatusCodes.InternalServerError);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="IdCF_Formacion"></param>
        /// <param name="IdCF_Version"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task UpdateVersion(int IdCF_Formacion, int IdCF_Version, CF_Version_updModel model)
        {
            // validar datos
            if (model.IdCF_Formacion != IdCF_Formacion || model.IdCF_Version != IdCF_Version)
                throw new ApiException(EnumStatusCodes.BadRequest);

            //valdiar pertenencia de version a formacion
            ValidVersionExists(IdCF_Formacion, IdCF_Version);
            //valdiar que la version no se encuentre publicada
            if (ValidFormacionVerPub(IdCF_Formacion, IdCF_Version)) 
                throw new ApiException(_sms_versionPublicada, EnumStatusCodes.BadRequest);

            try
            {
                var version = _mapper.Map<CF_Version>(model);
                // validar que campos seral modificados
                _context.Entry(version).State = EntityState.Modified;
                _context.Entry(version).Property(x => x.CreatedAt).IsModified = false;
                _context.Entry(version).Property(x => x.FechaPubli).IsModified = false;
                _context.Entry(version).Property(x => x.Publicada).IsModified = false;

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                _logger.LogError(ex.Message); // guardar log de excepcion 
                throw new ApiException(EnumStatusCodes.InternalServerError);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="IdCF_Formacion"></param>
        /// <returns></returns>
        public bool ValidFormacionExists(int IdCF_Formacion)
        {
            return _context.CF_Formacion.Any(x => x.IdCF_Formacion == IdCF_Formacion);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="IdCF_Formacion"></param>
        /// <param name="IdCF_Version"></param>
        /// <returns></returns>
        public bool ValidVersionExists(int IdCF_Formacion, int IdCF_Version)
        {
            // validar que exista la version y que forme parte de una formacion sin publicar
            return _context.CF_Version.Any(x => x.IdCF_Version == IdCF_Version && x.IdCF_Formacion == IdCF_Formacion && _context.CF_Formacion.Any(c => c.IdCF_Formacion == IdCF_Formacion));

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="IdCF_Formacion"></param>
        /// <param name="IdCF_Version"></param>
        /// <param name="IdCF_PaginaContent"></param>
        /// <returns></returns>
        public bool ValidateContenido(int IdCF_Formacion, int IdCF_Version, int IdCF_PaginaContent)
        {
            return _context.CF_PaginaContent.Any(d => d.IdCF_PaginaContent == IdCF_PaginaContent && d.IdCF_Version == IdCF_Version &&
                _context.CF_Version.Any(x => x.IdCF_Version == IdCF_Version && x.IdCF_Formacion == IdCF_Formacion &&
                    _context.CF_Formacion.Any(c => c.IdCF_Formacion == IdCF_Formacion)));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="IdCF_Formacion"></param>
        /// <param name="IdCF_Version"></param>
        /// <returns></returns>
        public bool ValidFormacionVerPub(int IdCF_Formacion, int IdCF_Version)
        {
            return _context.CF_Version.Where(x => x.IdCF_Formacion == IdCF_Formacion && x.IdCF_Version == IdCF_Version).Select(x => x.Publicada).First();
        }
        /// <summary>
        /// cargar file
        /// </summary>
        /// <param name="file"></param>
        /// <param name="IdCF_Formacion"></param>
        /// <param name="IdCF_Version"></param>
        /// <param name="IdCF_PaginaContent"></param>
        /// <param name="UploadFile"></param>
        /// <returns></returns>
        private string ValidateUploadFile(IFormFile file, int IdCF_Formacion, int IdCF_Version, int IdCF_PaginaContent)
        {
            if(file is null)
                throw new ApiException("Archivo de contenido no cargado",EnumStatusCodes.BadRequest);
            if(file.Length <= 0)
                throw new ApiException("Archivo de contenido dañado", EnumStatusCodes.BadRequest);

            string PathFolder = $"{_environment.WebRootPath}\\Formacion\\{IdCF_Formacion}\\{IdCF_Version}\\";
            string FolderFile = $"Formacion/{IdCF_Formacion}/{IdCF_Version}/contenido_{IdCF_PaginaContent}.html";
            if (!Directory.Exists(PathFolder))
                Directory.CreateDirectory(PathFolder);

            if (File.Exists(PathFolder))
                File.Delete(PathFolder);

            using (FileStream fs = System.IO.File.Create($"{PathFolder}\\contenido_{IdCF_PaginaContent}.html"))
            {
                file.CopyTo(fs);
                fs.Flush();
            }
            return FolderFile;
        }

        public async Task<CF_Version> DetailsVersion(int IdCF_Formacion, int IdCF_Version)
        {
            return await _context.CF_Version.FirstOrDefaultAsync(x => x.IdCF_Formacion == IdCF_Formacion && x.IdCF_Version == IdCF_Version);
        }

        public async Task PublicarVersion(int IdCF_Formacion, int IdCF_Version)
        {
            //valdiar que la version no se encuentre publicada
            if (ValidFormacionVerPub(IdCF_Formacion, IdCF_Version))
                throw new ApiException(_sms_versionPublicada, EnumStatusCodes.BadRequest);

            var data = await _context.CF_Version.FirstOrDefaultAsync(x => x.IdCF_Formacion == IdCF_Formacion && x.IdCF_Version == IdCF_Version);

            data.Publicada = true;
            data.FechaPubli = DateTime.Now;
            await _context.SaveChangesAsync();
        }

        public async Task<View_formacion_evaluacion> AddEval(int IdCF_Formacion, int IdCF_Version, CF_FormacionEva_addModel model)
        {
            //valdiar que la version no se encuentre publicada
            if (ValidFormacionVerPub(IdCF_Formacion, IdCF_Version))
                throw new ApiException(_sms_versionPublicada, EnumStatusCodes.BadRequest);

            if(model.IdCF_Version != IdCF_Version)
                throw new ApiException("Datos incorrectos", EnumStatusCodes.BadRequest);

            var eva = _mapper.Map<CF_FormacionEval>(model);

            _context.CF_FormacionEval.Add(eva);

            await _context.SaveChangesAsync();

            return await _context.View_formacion_evaluacion.FirstOrDefaultAsync(x => x.IdCF_FormacionEval == eva.IdCF_FormacionEval);
        }

        public async Task DeleteEval(int IdCF_Formacion, int IdCF_Version, int IdCF_FormacionEval)
        {
            //valdiar que la version no se encuentre publicada
            if (ValidFormacionVerPub(IdCF_Formacion, IdCF_Version))
                throw new ApiException(_sms_versionPublicada, EnumStatusCodes.BadRequest);

            var eva = await _context.CF_FormacionEval.FirstOrDefaultAsync(x => x.IdCF_FormacionEval == IdCF_FormacionEval && x.IdCF_Version == IdCF_Version);

            if(eva is null)
                throw new ApiException(EnumStatusCodes.NotFound);

            _context.CF_FormacionEval.Remove(eva);

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<View_formacion_evaluacion>> ListEvalbyForm(int IdCF_Formacion, int IdCF_Version)
        {
            return await _context.View_formacion_evaluacion.Where(x => x.EvaVersion == IdCF_Version).ToListAsync();
        }
    }
}
