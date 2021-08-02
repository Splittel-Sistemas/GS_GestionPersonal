using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestionPersonal.Models;
using GPSInformation;
using GPSInformation.Controllers;
using GPSInformation.Models;
using GPSInformation.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;

namespace GestionPersonal.Controllers
{
    public class OrganigramaController : Controller
    {
        private DarkManager darkManager;
        private V2OrganCtrl _V2OrganCtrl;

        public OrganigramaController(IConfiguration configuration)
        {
            darkManager = new DarkManager(configuration);
            //darkManager.OpenConnection();
            //darkManager.LoadObject(GpsManagerObjects.OrganigramaVersion);
            //darkManager.LoadObject(GpsManagerObjects.OrganigramaStructura);
            //darkManager.LoadObject(GpsManagerObjects.Puesto);
            //darkManager.LoadObject(GpsManagerObjects.Departamento);
            //darkManager.LoadObject(GpsManagerObjects.AccesosSistema);
        }

        ~OrganigramaController()
        {

        }

        #region Programacion JSON

        #endregion
        #region Nuevo
        [AccessMultipleView(IdAction = new int[] { 5 })]
        public ActionResult Editor(int id)
        {
            _V2OrganCtrl = new V2OrganCtrl(darkManager);
            try
            {
                var data = _V2OrganCtrl.OrgValidExistVer(id);
                int CountNodes = _V2OrganCtrl._darkM.OrganigramaStructura.Count($" IdOrganigramaVersion = {data.IdOrganigramaVersion}");
                ViewData["CountNodes"] = CountNodes;
                if(CountNodes == 0)
                {
                    ViewData["Puestos"] = new SelectList(_V2OrganCtrl._darkM.Puesto.GetOpenquery("", "Order by Nombre"), "IdPuesto", "Nombre");
                }
                return View(data);
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                return NotFound(ex.Message);
            }
            finally
            {
                _V2OrganCtrl.Terminar();
            }
            
        }
        [HttpPost]
        [AccessDataSession(IdAction = new int[] { 5 })]
        public ActionResult OrgCopyTo(int IdOrganigramaVersion, string Comentario)
        {
            _V2OrganCtrl = new V2OrganCtrl(darkManager);
            _V2OrganCtrl._darkM.StartTransaction();
            try
            {
                //if (orgNodeReq is null) return BadRequest("Información incompleta, intenta nuevamente");
                var result = _V2OrganCtrl.OrgCopyTo(Comentario, IdOrganigramaVersion);
                _V2OrganCtrl._darkM.Commit();
                return Ok($"{((HttpContext.Request.IsHttps ? "https:" : "http:"))}//{HttpContext.Request.Host}{Url.Action("Editor", "Organigrama", new { id = result })}");
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                _V2OrganCtrl._darkM.RolBack();
                return BadRequest(ex.Message);
            }
            finally
            {
                _V2OrganCtrl.Terminar();
            }
        }
        [HttpPost]
        [AccessDataSession(IdAction = new int[] { 9 })]
        public ActionResult OrgAutorizar(int IdOrganigramaVersion)
        {
            _V2OrganCtrl = new V2OrganCtrl(darkManager);
            _V2OrganCtrl._darkM.StartTransaction();
            try
            {
                 _V2OrganCtrl.OrgAutorizar(IdOrganigramaVersion);
                _V2OrganCtrl._darkM.Commit();
                return Ok("Proceso compelto");
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                _V2OrganCtrl._darkM.RolBack();
                return BadRequest(ex.Message);
            }
            finally
            {
                _V2OrganCtrl.Terminar();
            }
        }
        [HttpPost]
        [AccessDataSession(IdAction = new int[] { 5 })]
        public ActionResult OrgCreate(string Comentario)
        {
            _V2OrganCtrl = new V2OrganCtrl(darkManager);
            _V2OrganCtrl._darkM.StartTransaction();
            try
            {
                //if (orgNodeReq is null) return BadRequest("Información incompleta, intenta nuevamente");
                var result = _V2OrganCtrl.OrgCreate(Comentario);
                _V2OrganCtrl._darkM.Commit();
                return Ok($"{((HttpContext.Request.IsHttps ? "https:" : "http:"))}//{HttpContext.Request.Host}{Url.Action("Editor", "Organigrama", new { id = result })}");
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                _V2OrganCtrl._darkM.RolBack();
                return BadRequest(ex.Message);
            }
            finally
            {
                _V2OrganCtrl.Terminar();
            }
        }
        [HttpPost]
        [AccessDataSession(IdAction = new int[] { 5 })]
        public ActionResult OrgNodeMoveTo(OrgNodeReq orgNodeReq)
        {
            _V2OrganCtrl = new V2OrganCtrl(darkManager);
            _V2OrganCtrl._darkM.StartTransaction();
            try
            {
                if (orgNodeReq is null) return BadRequest("Información incompleta, intenta nuevamente");
                _V2OrganCtrl.OrgNodeMoveTo(orgNodeReq.IdOrganigramaVersion, orgNodeReq.IdPuesto, orgNodeReq.IdPuestoParent);
                _V2OrganCtrl._darkM.Commit();
                return Ok("Proceso completo");
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                _V2OrganCtrl._darkM.RolBack();
                return BadRequest(ex.Message);
            }
            finally
            {
                _V2OrganCtrl.Terminar();
            }
        }
        [HttpPost]
        [AccessDataSession(IdAction = new int[] { 5 })]
        public ActionResult OrgNodeDelete(OrgNodeReq orgNodeReq)
        {
            _V2OrganCtrl = new V2OrganCtrl(darkManager);
            _V2OrganCtrl._darkM.StartTransaction();
            try
            {
                if (orgNodeReq is null) return BadRequest("Información incompleta, intenta nuevamente");
                _V2OrganCtrl.OrgNodeDelete(orgNodeReq.IdOrganigramaVersion, orgNodeReq.IdPuesto);
                _V2OrganCtrl._darkM.Commit();
                return Ok("Proceso completo");
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                _V2OrganCtrl._darkM.RolBack();
                return BadRequest(ex.Message);
            }
            finally
            {
                _V2OrganCtrl.Terminar();
            }
        }
        [HttpPost]
        [AccessDataSession(IdAction = new int[] { 5 })]
        public ActionResult OrgNodeDetails(int IdOrganigramaVersion, int IdPuesto)
        {
            _V2OrganCtrl = new V2OrganCtrl(darkManager);
            try
            {
                var data = _V2OrganCtrl._darkM.OrganigramaStructura.GetOpenquerys($"where IdOrganigramaVersion = {IdOrganigramaVersion} and IdPuesto = {IdPuesto}");
                if (data is null)
                {
                    return NotFound("Puesto no encontrado");
                }
                var node = _V2OrganCtrl._darkM.Puesto.Get(IdPuesto);
                if (node != null)
                {
                    ViewData["PuestosChild"] = _V2OrganCtrl.OrgNodeChilds(IdOrganigramaVersion, IdPuesto);
                }
                ViewData["Puesto"] = node;
                ViewData["Ocupantes"] = _V2OrganCtrl.OrgNodeOcupantes(IdPuesto);
                ViewData["Puestos"] = new SelectList(_V2OrganCtrl.OrgNodePuestosFree(IdOrganigramaVersion, false), "Value", "Label");
                return PartialView(new GPSInformation.Request.OrgNodeReq { IdOrganigramaVersion = IdOrganigramaVersion, IdPuesto = IdPuesto, IdPuestoParent = data.IdPuestoParent });
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                return BadRequest(ex.Message);
            }
            finally
            {
                _V2OrganCtrl.Terminar();
            }
        }
        [HttpPost]
        [AccessDataSession(IdAction = new int[] { 5 })]
        public ActionResult OrgNodeAdd(OrgNodeReq orgNodeReq)
        {
            _V2OrganCtrl = new V2OrganCtrl(darkManager);
            _V2OrganCtrl._darkM.StartTransaction();
            ViewData["PuestoParent"] = _V2OrganCtrl._darkM.Puesto.Get(orgNodeReq.IdPuestoParent);
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewData["PuestosFree"] = new SelectList(_V2OrganCtrl.OrgNodePuestosFree(orgNodeReq.IdOrganigramaVersion), "Value", "Label", orgNodeReq.IdPuesto);
                    return PartialView(orgNodeReq);
                }
                _V2OrganCtrl.OrgNodeAdd(orgNodeReq);
                
                ViewData["PuestosFree"] = new SelectList(_V2OrganCtrl.OrgNodePuestosFree(orgNodeReq.IdOrganigramaVersion), "Value", "Label");
                ViewData["MessageSuccess"] = "Se agrego el puesto: " + _V2OrganCtrl._darkM.Puesto.GetStringValue($"select Nombre from Puesto where IdPuesto = {orgNodeReq.IdPuesto}");
                _V2OrganCtrl._darkM.Commit();
                orgNodeReq.IdPuesto = 0;
                return PartialView(orgNodeReq);
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                ModelState.AddModelError(!string.IsNullOrEmpty(ex.IdAux) ? ex.IdAux : "", ex.Message);
                ViewData["PuestosFree"] = new SelectList(_V2OrganCtrl.OrgNodePuestosFree(orgNodeReq.IdOrganigramaVersion), "Value", "Label", orgNodeReq.IdPuesto);
                _V2OrganCtrl._darkM.RolBack();
                return PartialView(orgNodeReq);
            }
            finally
            {
                _V2OrganCtrl.Terminar();
            }
        }
        [HttpGet]
        [AccessDataSession(IdAction = new int[] { 5 })]
        public ActionResult OrgNodeAdd(int IdOrganigramaVersion, int IdPuestParent)
        {
            _V2OrganCtrl = new V2OrganCtrl(darkManager);
            try
            {
                if(IdOrganigramaVersion == 0) 
                {
                    return NotFound("Organigrama no encontrado");
                }
                ViewData["PuestosFree"] = new SelectList(_V2OrganCtrl.OrgNodePuestosFree(IdOrganigramaVersion), "Value", "Label");
                ViewData["PuestoParent"] = _V2OrganCtrl._darkM.Puesto.Get(IdPuestParent);
                return PartialView(new GPSInformation.Request.OrgNodeReq { IdOrganigramaVersion = IdOrganigramaVersion, IdPuestoParent = IdPuestParent, Nivel = 1 });
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                return BadRequest(ex.Message);
            }
            finally
            {
                _V2OrganCtrl.Terminar();
            }
        }
        [AccessMultipleView(IdAction = new int[] { 4, 2 })]
        public ActionResult Details(int id)
        {
            _V2OrganCtrl = new V2OrganCtrl(darkManager);
            try
            {
                /**
                    2.-Ver organigrama
                    4.-Lectura de organigramas
                    5.-Escritura de organigramas
                    9.-Autorizar organigrama
                 */

                if(darkManager.AccesosSistema.GetOpenquerys($"where IdUsuario = {(int)HttpContext.Session.GetInt32("user_id_permiss")} and IdSubModulo = 4").TieneAcceso)
                {
                    if(id != 0)
                    {
                        ViewData["CountNodes"] = _V2OrganCtrl._darkM.OrganigramaStructura.Count($" IdOrganigramaVersion = {id}");
                        return View(_V2OrganCtrl.OrgValidExistVer(id));
                    }
                    else
                    {
                        var data = _V2OrganCtrl._darkM.OrganigramaVersion.GetByColumn("2", "Autirizada");
                        ViewData["CountNodes"] = _V2OrganCtrl._darkM.OrganigramaStructura.Count($" IdOrganigramaVersion = {data.IdOrganigramaVersion}");
                        return View(data);
                    }
                }
                else
                {
                    var data = _V2OrganCtrl._darkM.OrganigramaVersion.GetByColumn("2", "Autirizada");
                    ViewData["CountNodes"] = _V2OrganCtrl._darkM.OrganigramaStructura.Count($" IdOrganigramaVersion = {data.IdOrganigramaVersion}");
                    return View(data);
                }

            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                return NotFound(ex.Message);
            }
            finally
            {
                _V2OrganCtrl.Terminar();
            }
        }

        [AccessMultipleView(IdAction = new int[] { 4, 5, 9 })]
        public ActionResult Index()
        {
            _V2OrganCtrl = new V2OrganCtrl(darkManager);
            try
            {
                var result = _V2OrganCtrl._darkM.OrganigramaVersion.Get();
                ViewData["AccesoEdit5"] = darkManager.AccesosSistema.GetOpenquerys($"where IdUsuario = {(int)HttpContext.Session.GetInt32("user_id_permiss")} and IdSubModulo = 5").TieneAcceso;
                //ViewData["AccesoEdit9"] = darkManager.AccesosSistema.GetOpenquerys($"where IdUsuario = {(int)HttpContext.Session.GetInt32("user_id_permiss")} and IdSubModulo = 9").TieneAcceso;
                ViewData["AccesoEdit4"] = darkManager.AccesosSistema.GetOpenquerys($"where IdUsuario = {(int)HttpContext.Session.GetInt32("user_id_permiss")} and IdSubModulo = 4").TieneAcceso;
                return View(result);
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                return NotFound(ex.Message);
            }
            finally
            {
                _V2OrganCtrl.Terminar();
            }

        }

        [HttpPost]
        //[AccessDataSession(IdAction = new int[] { 2, 5 })]
        [AccessJson]
        public ActionResult GetNodes(int IdVersion)
        {
            _V2OrganCtrl = new V2OrganCtrl(darkManager);
            try
            {
                var result = _V2OrganCtrl._darkM.OrganigramaStructura.Get("" + IdVersion, "IdOrganigramaVersion");
                if (result is null) return BadRequest("Organigrama no encontrado");
                return Ok(result);
            }
            catch (GPSInformation.Exceptions.GPException ex)
            {
                return BadRequest(ex.Message);
            }
            finally
            {
                _V2OrganCtrl.Terminar();
            }
        }
        #endregion

        #region Organigrama viejo
        //[AccessMultipleView(IdAction = new int[] { 2 })]
        //public ActionResult Vigente()
        //{
        //    var result = darkManager.OrganigramaVersion.GetByColumn("2", "Autirizada");
        //    return View(result);
        //}



        //[AccessMultipleView(IdAction = new int[] { 4, 5 })]
        //public ActionResult Edit(int id)
        //{
        //    var result = darkManager.OrganigramaVersion.Get(id);
        //    if (result != null)
        //    {
        //        ViewData["AccesoEdit5"] = darkManager.AccesosSistema.GetOpenquerys($"where IdUsuario = {(int)HttpContext.Session.GetInt32("user_id_permiss")} and IdSubModulo = 5").TieneAcceso;
        //        ViewData["AccesoEdit9"] = darkManager.AccesosSistema.GetOpenquerys($"where IdUsuario = {(int)HttpContext.Session.GetInt32("user_id_permiss")} and IdSubModulo = 9").TieneAcceso;
        //        return View(result);
        //    }
        //    else
        //    {
        //        return NotFound();
        //    }
        //}
        //[AccessMultipleView(IdAction = new int[] { 5 })]
        //public ActionResult Create()
        //{
        //    return View();
        //}



        //[HttpPost]
        //[AccessDataSession(IdAction = new int[] { 5 })]
        //public ActionResult<List<PuestoOrg>> GetPuestos()
        //{
        //    List<PuestoOrg> puestoOrgs = ListPuestos();

        //    return Ok(puestoOrgs);
        //}

        //[HttpPost]
        //[AccessMultipleView(IdAction = new int[] { 5 })]
        //public ActionResult CreateNewVersion()
        //{
        //    darkManager.OrganigramaVersion.Element = new GPSInformation.Models.OrganigramaVersion();
        //    darkManager.OrganigramaVersion.Element.FechaCreacion = DateTime.Now;
        //    darkManager.OrganigramaVersion.Element.FechaActualizacion = DateTime.Now;
        //    darkManager.OrganigramaVersion.Element.Autirizada = 1;
        //    var result = darkManager.OrganigramaVersion.Add();
        //    if (result)
        //    {
        //        return RedirectToAction("Edit", new { id = darkManager.OrganigramaVersion.GetLastId() });
        //    }
        //    else
        //    {
        //        return NotFound();
        //    }
        //}

        //[HttpPost]
        //[AccessDataSession(IdAction = new int[] { 5 })]
        //public ActionResult AddSubLevels(int IdVersion, int IdPuesto, int Subleves)
        //{
        //    try
        //    {
        //        var result = darkManager.OrganigramaStructura.GetOpenquerys($"where IdOrganigramaVersion = {IdVersion} and IdPuesto = {IdPuesto}");
        //        if (result == null)
        //        {
        //            return BadRequest("El existe el puesto dentro del organigrama seleccionado");
        //        }

        //        if (result.IdPuestoParent == 0)
        //        {
        //            return BadRequest("NOse pueden agregar o quitar subniveles a los puestos raiz del organigrama");
        //        }

        //        result.Nivel += Subleves;
        //        darkManager.OrganigramaStructura.Element = result;
        //        if (!darkManager.OrganigramaStructura.Update())
        //        {
        //            return BadRequest("Error, no se actualizaron los subniveles");
        //        }

        //        return Ok("Puesto actualizado!");
        //    }
        //    catch (GPSInformation.Exceptions.GpExceptions ex)
        //    {
        //        darkManager.CloseConnection();
        //        return BadRequest(ex.Message);
        //    }
        //}

        //[HttpPost]
        //[AccessDataSession(IdAction = new int[] { 5 })]
        //public ActionResult AddFirstNode(int IdPuesto, int IdVersion)
        //{
        //    try
        //    {
        //        List<PuestoOrg> puestoOrgs = ListPuestos();


        //        var puestoChild = puestoOrgs.Find(a => a.IdPuesto == IdPuesto);
        //        if (puestoChild == null)
        //            return BadRequest("El puesto hijo no existe");


        //        darkManager.OrganigramaStructura.Element = new OrganigramaStructura();
        //        darkManager.OrganigramaStructura.Element.FechaCreacion = DateTime.Now;
        //        darkManager.OrganigramaStructura.Element.IdOrganigramaVersion = IdVersion;
        //        darkManager.OrganigramaStructura.Element.IdPuesto = IdPuesto;
        //        darkManager.OrganigramaStructura.Element.IdPuestoParent = 0; // add null to the database
        //        darkManager.OrganigramaStructura.Element.DPU = puestoChild.DPU;
        //        darkManager.OrganigramaStructura.Element.Nivel = 1;
        //        darkManager.OrganigramaStructura.Element.Descripcion = puestoChild.Descripcion;

        //        if (darkManager.OrganigramaStructura.Get("IdPuesto", "" + IdPuesto, "IdOrganigramaVersion", IdVersion + "") != null)
        //        {
        //            return BadRequest("ya existe este puesto en el organigrama");
        //        }

        //        var result = darkManager.OrganigramaStructura.Add();
        //        if (result)
        //        {
        //            return Ok("Puesto agregado!");
        //        }
        //        else
        //        {
        //            return BadRequest("Puesto no agregado");
        //        }
        //    }
        //    catch (GPSInformation.Exceptions.GpExceptions ex)
        //    {
        //        darkManager.CloseConnection();
        //        return BadRequest(ex.Message);
        //    }

        //}

        //[HttpPost]
        //[AccessDataSession(IdAction = new int[] { 5 })]
        //public ActionResult AddNode(int IdPuesto, int IdPuestoParent, int IdVersion, int Nivel)
        //{

        //    List<PuestoOrg> puestoOrgs = ListPuestos();


        //    var puestoChild = puestoOrgs.Find(a => a.IdPuesto == IdPuesto);
        //    if (puestoChild == null)
        //        return BadRequest("El puesto hijo no existe");

        //    var puestoparent = puestoOrgs.Find(a => a.IdPuesto == IdPuestoParent);
        //    if (puestoChild == null)
        //        return BadRequest("El puesto padre no existe");

        //    darkManager.OrganigramaStructura.Element = new OrganigramaStructura();
        //    darkManager.OrganigramaStructura.Element.FechaCreacion = DateTime.Now;
        //    darkManager.OrganigramaStructura.Element.IdOrganigramaVersion = IdVersion;
        //    darkManager.OrganigramaStructura.Element.IdPuesto = IdPuesto;
        //    darkManager.OrganigramaStructura.Element.IdPuestoParent = IdPuestoParent;
        //    darkManager.OrganigramaStructura.Element.DPU = puestoChild.DPU;
        //    darkManager.OrganigramaStructura.Element.Nivel = Nivel;
        //    darkManager.OrganigramaStructura.Element.Descripcion = puestoChild.Descripcion;

        //    if (darkManager.OrganigramaStructura.Get("IdPuesto", "" + IdPuesto, "IdOrganigramaVersion", IdVersion + "") != null)
        //    {
        //        return BadRequest("ya existe este puesto en el organigrama");
        //    }

        //    var result = darkManager.OrganigramaStructura.Add();
        //    if (result)
        //    {
        //        return Ok("Puesto agregado!");
        //    }
        //    else
        //    {
        //        return BadRequest("Puesto no agregado");
        //    }
        //}



        //[HttpPost]
        //[AccessDataSession(IdAction = new int[] { 9 })]
        //public ActionResult Autorizar(int IdVersion)
        //{
        //    var result = darkManager.OrganigramaVersion.Get();
        //    var Autorizado = result.Find(a => a.IdOrganigramaVersion == IdVersion);
        //    if (Autorizado == null)
        //    {
        //        return NotFound("No fue contrado la version a autorizar");
        //    }

        //    darkManager.OrganigramaVersion.Element = Autorizado;
        //    darkManager.OrganigramaVersion.Element.Autirizada = 2; // estatus de version autorizada, dicha version se utlizara para el flujo de provaciones en incidencias y otro tipo de solicitudes

        //    if (darkManager.OrganigramaVersion.Update() == false)
        //    {
        //        return NotFound("Error al autorizar esta versión solicitada");
        //    }
        //    result.Where(a => a.Autirizada == 2 && a.IdOrganigramaVersion != IdVersion).ToList().ForEach(organigrama => {
        //        darkManager.OrganigramaVersion.Element = organigrama;
        //        darkManager.OrganigramaVersion.Element.Autirizada = 1; // estatus de version no autorizada

        //        darkManager.OrganigramaVersion.Update();
        //    });

        //    result = darkManager.OrganigramaVersion.Get();
        //    return RedirectToAction("Index");
        //}

        //[HttpPost]
        //[AccessDataSession(IdAction = new int[] { 5 })]
        //public ActionResult ChangeNode(int IdOrganigramaStructura, int IdPuesto, int IdPuestoParent)
        //{
        //    var puestoChild = darkManager.OrganigramaStructura.Get(IdOrganigramaStructura);

        //    if (puestoChild == null)
        //        return BadRequest("El puesto no ha sido agregado al organigrama");


        //    List<PuestoOrg> puestoOrgs = ListPuestos();


        //    var puestoChilds = puestoOrgs.Find(a => a.IdPuesto == IdPuesto);
        //    if (puestoChild == null)
        //        return BadRequest("El puesto hijo no existe");

        //    var puestoparent = puestoOrgs.Find(a => a.IdPuesto == IdPuestoParent);
        //    if (puestoChild == null)
        //        return BadRequest("El puesto padre no existe");



        //    darkManager.OrganigramaStructura.Element = puestoChild;
        //    darkManager.OrganigramaStructura.Element.IdPuesto = IdPuesto;
        //    darkManager.OrganigramaStructura.Element.IdPuestoParent = IdPuestoParent;
        //    darkManager.OrganigramaStructura.Element.FechaCreacion = DateTime.Now;

        //    var result = darkManager.OrganigramaVersion.Update();
        //    if (result)
        //    {
        //        return Ok("Puesto eliminado!");
        //    }
        //    else
        //    {
        //        return BadRequest("Puesto no eliminado!");
        //    }
        //}

        //[HttpPost]
        //[AccessDataSession(IdAction = new int[] { 5 })]
        //public ActionResult Remove(int IdPuesto, int IdVersion)
        //{
        //    var result = darkManager.OrganigramaStructura.Get("" + IdVersion, "IdOrganigramaVersion");
        //    var puestoChild = result.Find(a => a.IdPuesto == IdPuesto);

        //    if (puestoChild == null)
        //        return BadRequest("El puesto no ha sido agregado al organigrama");

        //    darkManager.OrganigramaStructura.Element = puestoChild;

        //    var result2 = darkManager.OrganigramaStructura.Delete();
        //    if (result2)
        //    {
        //        return Ok("Puesto eliminado!");
        //    }
        //    else
        //    {
        //        return BadRequest("Puesto no eliminado!");
        //    }
        //}

        //[AccessDataSession(IdAction = new int[] { 5 })]
        //private List<PuestoOrg> ListPuestos()
        //{
        //    List<PuestoOrg> puestoOrgs = new List<PuestoOrg>();
        //    var departamentos = darkManager.Departamento.Get();

        //    darkManager.Puesto.Get().ForEach(puesto => {
        //        puestoOrgs.Add(new PuestoOrg
        //        {
        //            IdPuesto = puesto.IdPuesto,
        //            DPU = string.Format("{0}-DPU-{1}", departamentos.Find(a => a.IdDepartamento == puesto.IdDepartamento).ClaveDPU, puesto.NumeroDPU),
        //            Descripcion = puesto.Nombre
        //        });
        //    });

        //    return puestoOrgs.OrderBy(a => a.Descripcion).ToList();
        //}
        #endregion
    }
}