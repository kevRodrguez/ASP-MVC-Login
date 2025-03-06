using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mvcapp.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public Usuario()
        {
        }


        public Usuario(int id, string nombre, string apellido, string email, string password)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            Email = email;
            Password = password;
        }

    }
}