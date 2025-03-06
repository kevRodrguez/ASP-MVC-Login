using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using mvcapp.Data;
using mvcapp.Models;

namespace mvcapp.Controllers
{
    public class AccountController : Controller
    {
        private readonly MyAppContext _context;

        public AccountController(MyAppContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            Console.WriteLine(model.Email);
            Console.WriteLine(model.Password);

            if (!ModelState.IsValid)
            {
                var errors = string.Join("; ", ModelState.Values
                                    .SelectMany(x => x.Errors)
                                    .Select(x => x.ErrorMessage));
                return Content("Modelo no válido: " + errors);
            }

            // Busca al usuario por correo usando una consulta LINQ
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == model.Email);
            Console.WriteLine(usuario?.Nombre);

            if (usuario == null)
            {
                ModelState.AddModelError(string.Empty, "Credenciales inválidas.");
                return Content("Credenciales inválidas.");
            }

            // Compara la contraseña (en producción, utiliza hash en lugar de texto plano)
            if (usuario.Password != model.Password)
            {
                ModelState.AddModelError(string.Empty, "Credenciales inválidas.");
                return Content("Credenciales inválidas.");
            }

            // Guardar datos en sesión
            //los datos pueden ser null, por eso se usa el operador de coalescencia nula
            HttpContext.Session.SetString("Nombre", usuario?.Nombre ?? string.Empty);
            HttpContext.Session.SetString("Apellido", usuario?.Apellido ?? string.Empty);
            HttpContext.Session.SetString("Email", usuario?.Email ?? string.Empty);

            return RedirectToAction("Dashboard"); // Redirige a la vista de perfil

        }

        public IActionResult Dashboard()
        {
            // Recuperar datos de la sesión
            var nombre = HttpContext.Session.GetString("Nombre");
            var apellido = HttpContext.Session.GetString("Apellido");
            var email = HttpContext.Session.GetString("Email");

            if (string.IsNullOrEmpty(email)) // Si no hay sesión, redirigir al login
            {
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

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear(); // Limpiar sesión
            return RedirectToAction("Index", "Home"); // Redirigir al inicio
        }


    }
}