using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mvcapp.Models;

namespace mvcapp.Controllers
{
    public class ItemsController : Controller
    {

        public IActionResult Overview()
        {
            var item = new Item()
            {
                Id = 1,
                Name = "keyboard"
            };

            return View(item);
        }

        public IActionResult Edit(int id)
        {
            return Content("id=" + id);

        }

    }
}