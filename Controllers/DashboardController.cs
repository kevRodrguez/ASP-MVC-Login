using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mvcapp.Data;
using mvcapp.Models;

namespace mvcapp.Controllers
{
    public class DashboardController : Controller
    {
        private readonly MyAppContext _context;

        public DashboardController(MyAppContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // Recuperar datos de la sesión
            var nombre = HttpContext.Session.GetString("Nombre");
            var apellido = HttpContext.Session.GetString("Apellido");
            var email = HttpContext.Session.GetString("Email");

            if (string.IsNullOrEmpty(email)) // Si no hay sesión, redirigir al login
            {
                Console.WriteLine("No hay sesión");
                return RedirectToAction("Index", "Home");
            }

            var model = new Usuario
            {
                Nombre = nombre,
                Apellido = apellido,
                Email = email
            };

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }

        public IActionResult VerBus()
        {
            return View("bus/VerBus");
        }

        public IActionResult CrearBus()
        {
            return View("bus/CrearBus");
        }


        public IActionResult Modelos()
        {
            return View("Bus/Marca/Modelos");
        }

        
    }
}