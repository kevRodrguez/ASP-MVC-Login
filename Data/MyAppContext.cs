using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using mvcapp.Controllers;
using mvcapp.Models;

namespace mvcapp.Data
{
    public class MyAppContext : DbContext
    {
        public MyAppContext(DbContextOptions<MyAppContext> options) : base(options)
        {

        }

        public DbSet<Item> Items { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}