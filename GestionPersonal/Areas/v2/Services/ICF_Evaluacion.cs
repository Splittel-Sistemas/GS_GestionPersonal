using AutoMapper;
using GestionPersonal.Areas.v2.Entities;
using GestionPersonal.Areas.v2.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionPersonal.Areas.v2.Helpers;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace GestionPersonal.Areas.v2.Services
{
    public interface ICF_Evaluacion
    {
        public Task EvaEdit(int IdCF_Evaluacion, CF_Evaluacion_updModel model);
        public Task<CF_Evaluacion> EvaCreate(CF_Evaluacion_addModel model);
        public Task<CF_Evaluacion> EvaDetails(int IdCF_Evaluacion);
        public Task<IEnumerable<CF_Evaluacion>> EvaList();

        public Task EvaVersionPublicar(int IdCF_Evaluacion, int IdCF_EvaluacionVersion);
        public Task EvaVersionDelete(int IdCF_Evaluacion, int IdCF_EvaluacionVersion);
        public Task EvaVersionEdit(int IdCF_Evaluacion, int IdCF_EvaluacionVersion, CF_EvaluacionVersion_updModel model);
        public Task<CF_EvaluacionVersion> EvaVersionCreate(int IdCF_Evaluacion, CF_EvaluacionVersion_addModel model);
        public Task<CF_EvaluacionVersion> EvaVersionDetails(int IdCF_Evaluacion, int IdCF_EvaluacionVersion);
        public Task<IEnumerable<CF_EvaluacionVersion>> EvaVersionList(int IdCF_Evaluacion);


        public Task EvaSeccionDelete(int IdCF_EvaluacionVersion, int IdCF_EvaluacionSeccion);
        public Task EvaSeccionEdit(int IdCF_EvaluacionVersion, int IdCF_EvaluacionSeccion, CF_EvaluacionSeccion_updModel model);
        public Task<CF_EvaluacionSeccion> EvaSeccionCreate(int IdCF_EvaluacionVersion, CF_EvaluacionSeccion_addModel model);
        public Task<CF_EvaluacionSeccion> EvaSeccionDetails(int IdCF_EvaluacionVersion, int IdCF_EvaluacionSeccion);
        public Task<IEnumerable<CF_EvaluacionSeccion>> EvaSeccionList(int IdCF_EvaluacionVersion);


        public Task EvaPregDelete(int IdCF_EvaluacionVersion, int IdCF_EvaluacionPreg);
        public Task EvaPregDeleteSeccion(int IdCF_EvaluacionVersion, int IdCF_EvaluacionSeccion, int IdCF_EvaluacionPreg);
        public Task EvaPregEdit(int IdCF_EvaluacionVersion,int IdCF_EvaluacionPreg, CF_EvaluacionPreg_updModel model);
        public Task EvaPregEditSeccion(int IdCF_EvaluacionVersion, int IdCF_EvaluacionSeccion, int IdCF_EvaluacionPreg, CF_EvaluacionPreg_updModel model);
        public Task<CF_EvaluacionPreg> EvaPregCreate(int IdCF_EvaluacionVersion, CF_EvaluacionPreg_addModel model);
        public Task<CF_EvaluacionPreg> EvaPregCreateSeccion(int IdCF_EvaluacionVersion, int IdCF_EvaluacionSeccion, CF_EvaluacionPreg_addModel model);
        public Task<CF_EvaluacionPreg> EvaPregDetails(int IdCF_EvaluacionVersion, int IdCF_EvaluacionPreg);
        public Task<CF_EvaluacionPreg> EvaPregDetailsSeccion(int IdCF_EvaluacionVersion, int IdCF_EvaluacionSeccion, int IdCF_EvaluacionPreg);
        public Task<IEnumerable<CF_EvaluacionPreg>> EvaPregListSeccion(int IdCF_EvaluacionVersion, int IdCF_EvaluacionSeccion);
        public Task<IEnumerable<CF_EvaluacionPreg>> EvaPregList(int IdCF_EvaluacionVersion);


        public Task EvaPregRespDelete(int IdCF_EvaluacionVersion, int IdCF_EvaluacionPreg, int IdCF_EvaluacionPregRes);
        public Task EvaPregRespEdit(int IdCF_EvaluacionVersion, int IdCF_EvaluacionPreg, int IdCF_EvaluacionPregRes, CF_EvaluacionPregRes_updModel model);
        public Task<CF_EvaluacionPregRes> EvaPregRespCreate(int IdCF_EvaluacionVersion, int IdCF_EvaluacionPreg, CF_EvaluacionPregRes_addModel model);
        public Task<CF_EvaluacionPregRes> EvaPregRespDetails(int IdCF_EvaluacionVersion, int IdCF_EvaluacionPreg, int IdCF_EvaluacionPregRes);
        public Task<IEnumerable<CF_EvaluacionPregRes>> EvaPregRespList(int IdCF_EvaluacionVersion, int IdCF_EvaluacionPreg);

    }

    public class CF_EvaluacionServ : ICF_Evaluacion
    {
        #region Atributos
        private readonly GPSctx _context;
        private readonly ILogger<CF_EvaluacionServ> _logger;
        private readonly IMapper _mapper;
        [Obsolete]
        private readonly IHostingEnvironment _environment;
        private readonly string _sms_versionPublicada = "Imposible realizar cambios en una version ya publicada.";
        #endregion

        #region Constructores
        [Obsolete]
        public CF_EvaluacionServ(GPSctx context, ILogger<CF_EvaluacionServ> logger, IMapper mapper, IHostingEnvironment environment)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
            _environment = environment;
        }

        #endregion

        #region Evaluaciones
        public async Task<CF_Evaluacion> EvaCreate(CF_Evaluacion_addModel model)
        {
            var evaluacion = _mapper.Map<CF_Evaluacion>(model);
            _context.CF_Evaluacion.Add(evaluacion);

            await _context.SaveChangesAsync();
            return evaluacion;
        }

        public async Task<CF_Evaluacion> EvaDetails(int IdCF_Evaluacion)
        {
            return await _context.CF_Evaluacion.FirstOrDefaultAsync(x => x.IdCF_Evaluacion == IdCF_Evaluacion);
        }

        public async Task EvaEdit(int IdCF_Evaluacion, CF_Evaluacion_updModel model)
        {
            if (model.IdCF_Evaluacion != IdCF_Evaluacion)
                throw new ApiException(EnumStatusCodes.NotFound);

            if(!_context.CF_Evaluacion.Any(x => x.IdCF_Evaluacion == IdCF_Evaluacion))
                throw new ApiException(EnumStatusCodes.NotFound);

            var evaluacion = _mapper.Map<CF_Evaluacion>(model);
            try
            {
                _context.Entry(evaluacion).State = EntityState.Modified;
                _context.Entry(evaluacion).Property(x => x.CreatedAt).IsModified = false;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new ApiException(EnumStatusCodes.InternalServerError);
            }
        }
        
        public async Task<IEnumerable<CF_Evaluacion>> EvaList()
        {
            return await _context.CF_Evaluacion.ToListAsync();
        }


        #endregion

        #region vVersiones
        public async Task EvaVersionPublicar(int IdCF_Evaluacion, int IdCF_EvaluacionVersion)
        {
            var version = await _context.CF_EvaluacionVersion.FirstOrDefaultAsync(x => x.IdCF_Evaluacion == IdCF_Evaluacion && x.IdCF_EvaluacionVersion == IdCF_EvaluacionVersion);

            if (version is null)
                throw new ApiException(EnumStatusCodes.NotFound);

            if (!version.Publicada)
            {
                try
                {
                    version.Publicada = true;
                    version.FechaPubli = DateTime.Now;
                    _context.Entry(version).State = EntityState.Modified;
                    _context.Entry(version).Property(x => x.CreatedAt).IsModified = false;
                    _context.Entry(version).Property(x => x.IdCF_Evaluacion).IsModified = false;
                    _context.Entry(version).Property(x => x.Aleatory).IsModified = false;
                    _context.Entry(version).Property(x => x.BySecciones).IsModified = false;
                    _context.Entry(version).Property(x => x.Comentarios).IsModified = false;
                    _context.Entry(version).Property(x => x.NoVersion).IsModified = false;
                    _context.Entry(version).Property(x => x.Instrucciones).IsModified = false;
                    _context.Entry(version).Property(x => x.MinCalificacion).IsModified = false;
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw new ApiException(EnumStatusCodes.InternalServerError);
                }
            }
        }
        public async Task<CF_EvaluacionVersion> EvaVersionCreate(int IdCF_Evaluacion, CF_EvaluacionVersion_addModel model)
        {
            if(!_context.CF_Evaluacion.Any(x => x.IdCF_Evaluacion == IdCF_Evaluacion))
                throw new ApiException(EnumStatusCodes.NotFound);

            var version = _mapper.Map<CF_EvaluacionVersion>(model);
            _context.CF_EvaluacionVersion.Add(version);

            await _context.SaveChangesAsync();

            return version;
        }

        public async Task EvaVersionDelete(int IdCF_Evaluacion, int IdCF_EvaluacionVersion)
        {

            var version = await _context.CF_EvaluacionVersion.FirstOrDefaultAsync(x => x.IdCF_Evaluacion == IdCF_Evaluacion && x.IdCF_EvaluacionVersion == IdCF_EvaluacionVersion);

            if (version is null)
                throw new ApiException(EnumStatusCodes.NotFound);

            if (version.Publicada)
                throw new ApiException("La version ya ha sido publicada", EnumStatusCodes.BadRequest);

            _context.CF_EvaluacionVersion.Remove(version);
            await _context.SaveChangesAsync();
        }

        public async Task<CF_EvaluacionVersion> EvaVersionDetails(int IdCF_Evaluacion, int IdCF_EvaluacionVersion)
        {
            return await _context.CF_EvaluacionVersion.FirstOrDefaultAsync(x => x.IdCF_Evaluacion == IdCF_Evaluacion && x.IdCF_EvaluacionVersion == IdCF_EvaluacionVersion);
        }

        public async Task EvaVersionEdit(int IdCF_Evaluacion, int IdCF_EvaluacionVersion, CF_EvaluacionVersion_updModel model)
        {
            if(model.IdCF_Evaluacion != IdCF_Evaluacion || model.IdCF_EvaluacionVersion != IdCF_EvaluacionVersion)
                throw new ApiException(EnumStatusCodes.NotFound);

            var version = _mapper.Map<CF_EvaluacionVersion>(model);
            try
            {
                _context.Entry(version).State = EntityState.Modified;
                _context.Entry(version).Property(x => x.CreatedAt).IsModified = false;
                _context.Entry(version).Property(x => x.IdCF_Evaluacion).IsModified = false;
                _context.Entry(version).Property(x => x.Publicada).IsModified = false;
                _context.Entry(version).Property(x => x.FechaPubli).IsModified = false;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new ApiException(EnumStatusCodes.InternalServerError);
            }

        }

        public async Task<IEnumerable<CF_EvaluacionVersion>> EvaVersionList(int IdCF_Evaluacion)
        {
            return await _context.CF_EvaluacionVersion.Where(x => x.IdCF_Evaluacion == IdCF_Evaluacion).ToListAsync();
        }
        #endregion

        #region Secciones
        public async Task EvaSeccionDelete(int IdCF_EvaluacionVersion, int IdCF_EvaluacionSeccion)
        {
            var seccion = await _context.CF_EvaluacionSeccion.FirstOrDefaultAsync(x => x.IdCF_EvaluacionVersion == IdCF_EvaluacionVersion && x.IdCF_EvaluacionSeccion == IdCF_EvaluacionSeccion);
            if (seccion is null)
                throw new ApiException(EnumStatusCodes.NotFound);

            if (_context.CF_EvaluacionVersion.Any(x => x.IdCF_EvaluacionVersion == IdCF_EvaluacionVersion && x.Publicada))
                throw new ApiException(_sms_versionPublicada, EnumStatusCodes.BadRequest);

            var preguntas = await _context.CF_EvaluacionPreg.Where(x => x.IdCF_EvaluacionSeccion == IdCF_EvaluacionSeccion && x.IdCF_EvaluacionVersion == IdCF_EvaluacionVersion).ToListAsync();
            preguntas.ForEach(x =>
            {
                if(!string.IsNullOrEmpty(x.DescipcionPath) && File.Exists($"{_environment.WebRootPath}\\{x.DescipcionPath.Replace("/", "\\")}"))
                {
                    File.Delete($"{_environment.WebRootPath}\\{x.DescipcionPath.Replace("/", "\\")}");
                }

                var respuestas = _context.CF_EvaluacionPregRes.Where(s => s.IdCF_EvaluacionPreg == x.IdCF_EvaluacionPreg).ToList();
                respuestas.ForEach(r => _context.CF_EvaluacionPregRes.Remove(r) );

                _context.CF_EvaluacionPreg.Remove(x);
            });
            _context.CF_EvaluacionSeccion.Remove(seccion);

            await _context.SaveChangesAsync();
        }

        public async Task<CF_EvaluacionSeccion> EvaSeccionDetails(int IdCF_EvaluacionVersion, int IdCF_EvaluacionSeccion)
        {
            var seccion = await _context.CF_EvaluacionSeccion.FirstOrDefaultAsync(x => x.IdCF_EvaluacionVersion == IdCF_EvaluacionVersion && x.IdCF_EvaluacionSeccion == IdCF_EvaluacionSeccion);
            return seccion;
        }

        public async Task EvaSeccionEdit(int IdCF_EvaluacionVersion, int IdCF_EvaluacionSeccion, CF_EvaluacionSeccion_updModel model)
        {
            if (!_context.CF_EvaluacionSeccion.Any(x => x.IdCF_EvaluacionVersion == IdCF_EvaluacionVersion && x.IdCF_EvaluacionSeccion == IdCF_EvaluacionSeccion))
                throw new ApiException(EnumStatusCodes.NotFound);

            if (_context.CF_EvaluacionVersion.Any(x => x.IdCF_EvaluacionVersion == IdCF_EvaluacionVersion && x.Publicada))
                throw new ApiException(_sms_versionPublicada, EnumStatusCodes.BadRequest);

            var seccion = _mapper.Map<CF_EvaluacionSeccion>(model);
            try
            {
                _context.Entry(seccion).State = EntityState.Modified;
                _context.Entry(seccion).Property(x => x.CreatedAt).IsModified = false;
                _context.Entry(seccion).Property(x => x.IdCF_EvaluacionVersion).IsModified = false;

                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw new ApiException(EnumStatusCodes.InternalServerError);
            }
        }

        public async Task<IEnumerable<CF_EvaluacionSeccion>> EvaSeccionList(int IdCF_EvaluacionVersion)
        {
            if (!_context.CF_EvaluacionVersion.Any(x => x.IdCF_EvaluacionVersion == IdCF_EvaluacionVersion))
                throw new ApiException(EnumStatusCodes.NotFound);

            return await _context.CF_EvaluacionSeccion.Where(x => x.IdCF_EvaluacionVersion == IdCF_EvaluacionVersion).ToListAsync();
        }

        public async Task<CF_EvaluacionSeccion> EvaSeccionCreate(int IdCF_EvaluacionVersion, CF_EvaluacionSeccion_addModel model)
        {
            if (!_context.CF_EvaluacionVersion.Any(x => x.IdCF_EvaluacionVersion == IdCF_EvaluacionVersion))
                throw new ApiException(EnumStatusCodes.NotFound);

            if(_context.CF_EvaluacionVersion.Any(x => x.IdCF_EvaluacionVersion == IdCF_EvaluacionVersion && x.Publicada))
                throw new ApiException(_sms_versionPublicada,EnumStatusCodes.BadRequest);

            var seccion = _mapper.Map<CF_EvaluacionSeccion>(model);
            _context.CF_EvaluacionSeccion.Add(seccion);
            await _context.SaveChangesAsync();

            return seccion;
        }
        #endregion

        #region Preguntas
        public async Task EvaPregDelete(int IdCF_EvaluacionVersion, int IdCF_EvaluacionPreg)
        {
            var version = await ValidVersionPublish(IdCF_EvaluacionVersion);

            var pregunta = await _context.CF_EvaluacionPreg.FirstOrDefaultAsync(x => x.IdCF_EvaluacionSeccion == null && x.IdCF_EvaluacionPreg == IdCF_EvaluacionPreg);

            if (pregunta is null)
                throw new ApiException(EnumStatusCodes.NotFound);
            if (!string.IsNullOrEmpty(pregunta.DescipcionPath) && File.Exists($"{_environment.WebRootPath}\\{pregunta.DescipcionPath.Replace("/", "\\")}"))
            {
                File.Delete($"{_environment.WebRootPath}\\{pregunta.DescipcionPath.Replace("/", "\\")}");
            }

            var respuestas = await _context.CF_EvaluacionPregRes.Where(x => x.IdCF_EvaluacionPreg == IdCF_EvaluacionPreg).ToListAsync();

            respuestas.ForEach(r => _context.CF_EvaluacionPregRes.Remove(r));

            _context.CF_EvaluacionPreg.Remove(pregunta);
            await _context.SaveChangesAsync();
        }

        public async Task EvaPregDeleteSeccion(int IdCF_EvaluacionVersion, int IdCF_EvaluacionSeccion, int IdCF_EvaluacionPreg)
        {
            var version = await ValidVersionPublish(IdCF_EvaluacionVersion);
            var pregunta = await _context.CF_EvaluacionPreg.FirstOrDefaultAsync(x => x.IdCF_EvaluacionSeccion == IdCF_EvaluacionSeccion && x.IdCF_EvaluacionPreg == IdCF_EvaluacionPreg);

            if(pregunta is null)
                throw new ApiException(EnumStatusCodes.NotFound);

            if(!string.IsNullOrEmpty(pregunta.DescipcionPath) && File.Exists(pregunta.DescipcionPath))
            {
                File.Delete($"{_environment.WebRootPath}\\{pregunta.DescipcionPath.Replace("/","\\")}");
            }

            var respuestas = await _context.CF_EvaluacionPregRes.Where(x => x.IdCF_EvaluacionPreg == IdCF_EvaluacionPreg).ToListAsync();

            respuestas.ForEach(r => _context.CF_EvaluacionPregRes.Remove(r));

            _context.CF_EvaluacionPreg.Remove(pregunta);
            await _context.SaveChangesAsync();
        }

        public async Task EvaPregEdit(int IdCF_EvaluacionVersion, int IdCF_EvaluacionPreg, CF_EvaluacionPreg_updModel model)
        {
            var version = await ValidVersionPublish(IdCF_EvaluacionVersion);

            if (!_context.CF_EvaluacionPreg.Any(x => x.IdCF_EvaluacionSeccion == null && x.IdCF_EvaluacionPreg == IdCF_EvaluacionPreg))
                throw new ApiException(EnumStatusCodes.NotFound);

            var pregunta = _mapper.Map<CF_EvaluacionPreg>(model);

            try
            {
                _context.Entry(pregunta).State = EntityState.Modified;
                _context.Entry(pregunta).Property(x => x.CreatedAt).IsModified = false;
                _context.Entry(pregunta).Property(x => x.IdCF_EvaluacionSeccion).IsModified = false;
                _context.Entry(pregunta).Property(x => x.IdCF_EvaluacionVersion).IsModified = false;

                if (model.Contenido == null)
                {
                    string pathContent = await _context.CF_EvaluacionPreg.Where(x => x.IdCF_EvaluacionPreg == IdCF_EvaluacionPreg).Select(x => x.DescipcionPath).FirstOrDefaultAsync();

                    if (!string.IsNullOrEmpty(pathContent) && File.Exists(pathContent))
                    {
                        File.Delete($"{_environment.WebRootPath}\\{pathContent.Replace("/", "\\")}");
                    }
                    pregunta.DescipcionPath = "";
                    //_context.Entry(pregunta).Property(x => x.DescipcionPath).IsModified = false;
                }
                else
                {
                    var pth = ValidateUploadFile(model.Contenido, version.IdCF_Evaluacion, IdCF_EvaluacionVersion, IdCF_EvaluacionPreg);
                    pregunta.DescipcionPath = pth;
                }

                await _context.SaveChangesAsync();

            }
            catch (DbUpdateConcurrencyException)
            {
                throw new ApiException(EnumStatusCodes.InternalServerError);
            }
        }

        public async Task EvaPregEditSeccion(int IdCF_EvaluacionVersion, int IdCF_EvaluacionSeccion, int IdCF_EvaluacionPreg, CF_EvaluacionPreg_updModel model)
        {
            var version = await ValidVersionPublish(IdCF_EvaluacionVersion);

            if (!_context.CF_EvaluacionPreg.Any(x => x.IdCF_EvaluacionSeccion == IdCF_EvaluacionSeccion && x.IdCF_EvaluacionPreg == IdCF_EvaluacionPreg))
                throw new ApiException(EnumStatusCodes.NotFound);

            var pregunta = _mapper.Map<CF_EvaluacionPreg>(model);

            try
            {
                _context.Entry(pregunta).State = EntityState.Modified;
                _context.Entry(pregunta).Property(x => x.CreatedAt).IsModified = false;
                _context.Entry(pregunta).Property(x => x.IdCF_EvaluacionSeccion).IsModified = false;
                _context.Entry(pregunta).Property(x => x.IdCF_EvaluacionVersion).IsModified = false;

                if (model.Contenido == null)
                {
                    string pathContent = await _context.CF_EvaluacionPreg.Where(x => x.IdCF_EvaluacionPreg == IdCF_EvaluacionPreg).Select(x => x.DescipcionPath).FirstOrDefaultAsync();

                    if (!string.IsNullOrEmpty(pathContent) && File.Exists(pathContent))
                    {
                        File.Delete($"{_environment.WebRootPath}\\{pathContent.Replace("/", "\\")}");
                    }
                    pregunta.DescipcionPath = "";
                    //_context.Entry(pregunta).Property(x => x.DescipcionPath).IsModified = false;
                }
                else
                {
                    var pth = ValidateUploadFile(model.Contenido, version.IdCF_Evaluacion, IdCF_EvaluacionVersion, IdCF_EvaluacionPreg);
                    pregunta.DescipcionPath = pth;
                }

                await _context.SaveChangesAsync();

            }
            catch (DbUpdateConcurrencyException)
            {
                throw new ApiException(EnumStatusCodes.InternalServerError);
            }
        }

        public async Task<CF_EvaluacionPreg> EvaPregCreate(int IdCF_EvaluacionVersion, CF_EvaluacionPreg_addModel model)
        {
            await ValidVersionPublish(IdCF_EvaluacionVersion);

            var pregunta = _mapper.Map<CF_EvaluacionPreg>(model);

            pregunta.IdCF_EvaluacionSeccion = null;
            _context.CF_EvaluacionPreg.Add(pregunta);
            await _context.SaveChangesAsync();
            return pregunta;
        }

        public async Task<CF_EvaluacionPreg> EvaPregCreateSeccion(int IdCF_EvaluacionVersion, int IdCF_EvaluacionSeccion, CF_EvaluacionPreg_addModel model)
        {
            await ValidVersionPublish(IdCF_EvaluacionVersion);

            if(!_context.CF_EvaluacionSeccion.Any(x => x.IdCF_EvaluacionSeccion == IdCF_EvaluacionSeccion && x.IdCF_EvaluacionVersion == IdCF_EvaluacionVersion))
                throw new ApiException(EnumStatusCodes.NotFound);

            var pregunta = _mapper.Map<CF_EvaluacionPreg>(model);
            _context.CF_EvaluacionPreg.Add(pregunta);
            await _context.SaveChangesAsync();
            return pregunta;
        }

        public async Task<CF_EvaluacionPreg> EvaPregDetails(int IdCF_EvaluacionVersion, int IdCF_EvaluacionPreg)
        {
            return await _context.CF_EvaluacionPreg
                .FirstOrDefaultAsync(x => x.IdCF_EvaluacionVersion == IdCF_EvaluacionVersion  && x.IdCF_EvaluacionPreg == IdCF_EvaluacionPreg);
        }

        public async Task<CF_EvaluacionPreg> EvaPregDetailsSeccion(int IdCF_EvaluacionVersion, int IdCF_EvaluacionSeccion, int IdCF_EvaluacionPreg)
        {
            return await _context.CF_EvaluacionPreg
                .FirstOrDefaultAsync(x => x.IdCF_EvaluacionVersion == IdCF_EvaluacionVersion && x.IdCF_EvaluacionSeccion == IdCF_EvaluacionSeccion && x.IdCF_EvaluacionPreg == IdCF_EvaluacionPreg);
        }

        public async Task<IEnumerable<CF_EvaluacionPreg>> EvaPregListSeccion(int IdCF_EvaluacionVersion, int IdCF_EvaluacionSeccion)
        {
            await ValidVersionPublish(IdCF_EvaluacionVersion);
            return await _context.CF_EvaluacionPreg
                .Where(x => x.IdCF_EvaluacionVersion == IdCF_EvaluacionVersion && x.IdCF_EvaluacionSeccion == IdCF_EvaluacionSeccion)
                .ToListAsync();
        }

        public async Task<IEnumerable<CF_EvaluacionPreg>> EvaPregList(int IdCF_EvaluacionVersion)
        {
            await ValidVersionPublish(IdCF_EvaluacionVersion);
            return await _context.CF_EvaluacionPreg
                .Where(x => x.IdCF_EvaluacionVersion == IdCF_EvaluacionVersion && x.IdCF_EvaluacionSeccion == null)
                .ToListAsync();
        }
        #endregion

        private async Task<CF_EvaluacionVersion> ValidVersionPublish(int IdCF_EvaluacionVersion, bool validPublishedAction = false)
        {
            var dato = await _context.CF_EvaluacionVersion
                .Where(x => x.IdCF_EvaluacionVersion == IdCF_EvaluacionVersion)
                .FirstOrDefaultAsync();
            if (dato is null)
                throw new ApiException(EnumStatusCodes.NotFound);

            if (dato.Publicada && validPublishedAction)
                throw new ApiException(_sms_versionPublicada,EnumStatusCodes.BadRequest);

            return dato;
        }

        private string ValidateUploadFile(IFormFile file, int IdCF_Evaluacion, int IdCF_EvaluacionVersion, int IdCF_EvaluacionPreg)
        {
            if (file is null)
                throw new ApiException("Archivo de contenido no cargado", EnumStatusCodes.BadRequest);
            if (file.Length <= 0)
                throw new ApiException("Archivo de contenido dañado", EnumStatusCodes.BadRequest);

            string PathFolder = $"{_environment.WebRootPath}\\Evaluaciones\\{IdCF_Evaluacion}\\{IdCF_EvaluacionVersion}\\";
            string FolderFile = $"Evaluaciones/{IdCF_Evaluacion}/{IdCF_EvaluacionVersion}/contenido_{IdCF_EvaluacionPreg}.html";
            if (!Directory.Exists(PathFolder))
                Directory.CreateDirectory(PathFolder);

            if (File.Exists(PathFolder))
                File.Delete(PathFolder);

            using (FileStream fs = System.IO.File.Create($"{PathFolder}\\contenido_{IdCF_EvaluacionPreg}.html"))
            {
                file.CopyTo(fs);
                fs.Flush();
            }
            return FolderFile;
        }

        public async Task EvaPregRespDelete(int IdCF_EvaluacionVersion, int IdCF_EvaluacionPreg, int IdCF_EvaluacionPregRes)
        {
            await ValidVersionPublish(IdCF_EvaluacionVersion, true);
            var respuesta = await _context.CF_EvaluacionPregRes.FirstOrDefaultAsync(x => x.IdCF_EvaluacionPreg == IdCF_EvaluacionPreg && x.IdCF_EvaluacionPregRes == IdCF_EvaluacionPregRes);
            if(respuesta is null)
                throw new ApiException(EnumStatusCodes.NotFound);

            _context.CF_EvaluacionPregRes.Remove(respuesta);
            await _context.SaveChangesAsync();
        }

        public async Task EvaPregRespEdit(int IdCF_EvaluacionVersion, int IdCF_EvaluacionPreg, int IdCF_EvaluacionPregRes, CF_EvaluacionPregRes_updModel model)
        {
            await ValidVersionPublish(IdCF_EvaluacionVersion, true);

            if (!_context.CF_EvaluacionPregRes.Any(x => x.IdCF_EvaluacionPreg == IdCF_EvaluacionPreg && x.IdCF_EvaluacionPregRes == IdCF_EvaluacionPregRes))
                throw new ApiException(EnumStatusCodes.NotFound);

            try
            {
                var pregunta = _mapper.Map<CF_EvaluacionPregRes>(model);
                _context.Entry(pregunta).State = EntityState.Modified;
                _context.Entry(pregunta).Property(x => x.CreatedAt).IsModified = false;
                _context.Entry(pregunta).Property(x => x.ImagenPath).IsModified = false;

                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<CF_EvaluacionPregRes> EvaPregRespCreate(int IdCF_EvaluacionVersion, int IdCF_EvaluacionPreg, CF_EvaluacionPregRes_addModel model)
        {
            await ValidVersionPublish(IdCF_EvaluacionVersion, true);

            if(!_context.CF_EvaluacionPreg.Any(x => x.IdCF_EvaluacionPreg == IdCF_EvaluacionPreg))
                throw new ApiException(EnumStatusCodes.NotFound);

            var pregunta = _mapper.Map<CF_EvaluacionPregRes>(model);

            _context.CF_EvaluacionPregRes.Add(pregunta);
            await _context.SaveChangesAsync();

            return pregunta;
        }

        public async Task<CF_EvaluacionPregRes> EvaPregRespDetails(int IdCF_EvaluacionVersion, int IdCF_EvaluacionPreg, int IdCF_EvaluacionPregRes)
        {
            await ValidVersionPublish(IdCF_EvaluacionVersion);
            return await _context.CF_EvaluacionPregRes.FirstOrDefaultAsync(x => x.IdCF_EvaluacionPreg == IdCF_EvaluacionPreg && x.IdCF_EvaluacionPregRes == IdCF_EvaluacionPregRes);
        }

        public async Task<IEnumerable<CF_EvaluacionPregRes>> EvaPregRespList(int IdCF_EvaluacionVersion, int IdCF_EvaluacionPreg)
        {
            await ValidVersionPublish(IdCF_EvaluacionVersion);
            return await _context.CF_EvaluacionPregRes.Where(x => x.IdCF_EvaluacionPreg == IdCF_EvaluacionPreg).ToListAsync();
        }
    }
}
