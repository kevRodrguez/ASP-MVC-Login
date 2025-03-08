using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mvcapp.Data;
using mvcapp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvcapp.Controllers
{
    public class BusesController : Controller
    {
        private readonly MyAppContext _context;

        public BusesController(MyAppContext context)
        {
            _context = context;
        }

        // GET: Dashboard/Marcas
        // Mapea la URL deseada a este método
        [HttpGet]
        [Route("Dashboard/Marcas")]
        public async Task<IActionResult> GetMarcas()
        {

            // Recuperar datos de la sesión
            var nombre = HttpContext.Session.GetString("Nombre");
            var apellido = HttpContext.Session.GetString("Apellido");
            var email = HttpContext.Session.GetString("Email");
            Console.WriteLine(nombre + " " + apellido + " " + email);

            if (string.IsNullOrEmpty(email)) // Si no hay sesión, redirigir al login
            {
                Console.WriteLine("No hay sesión");
                return RedirectToAction("Index", "Home");
            }
            
            var marcas = await _context.Marcas.ToListAsync();
            return View("~/Views/Dashboard/Bus/Marca/Marcas.cshtml", marcas);
        }

        // POST: Buses/CreateMarca
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateMarca(Marca marca)
        {
            if (ModelState.IsValid)
            {
                _context.Add(marca);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("GetMarcas");
        }

        // POST: Buses/UpdateMarca
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateMarca(Marca marca)
        {
            if (ModelState.IsValid)
            {
                _context.Update(marca);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("GetMarcas");
        }

        // POST: Buses/DeleteMarca
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteMarca(int id)
        {
            var marca = await _context.Marcas.FindAsync(id);
            if (marca != null)
            {
                _context.Marcas.Remove(marca);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("GetMarcas");
        }
    }
}