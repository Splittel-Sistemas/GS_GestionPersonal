using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GestionPersonal.Models;
using Microsoft.AspNetCore.Http;

namespace GestionPersonal.Controllers
{
    public class HomeController : Controller
    {
        [AccessView]
        public IActionResult Index()
        {
            return View();
        }
        [AccessView]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }
        [AccessView]
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }
        [AccessView]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult NotFoundPage()
        {
            return View();
        }

        public IActionResult CheckSession()
        {
            if(HttpContext.Session.IsAvailable && HttpContext.Session.GetInt32("user_id_permiss") != null)
            {
                return Ok("Session activa");
            }
            else
            {
                return Unauthorized("Inicia session de nuevo");
            }
        }
    }
}
