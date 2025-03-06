using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mvcapp.Models
{
    public class LoginViewModel
    {

        [Required(ErrorMessage = "El correo es obligatorio")]
        public string Email { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria")]
        public string Password { get; set; }

        public LoginViewModel()
        {
        }

        public LoginViewModel(string email, string password)
        {
            Email = email;
            Password = password;
        }

    }
}