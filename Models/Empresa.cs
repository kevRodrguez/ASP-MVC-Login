using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mvcapp.Models
{
    public class Empresa
    {
        [Key] 
        public int id_empresa { get; set; }
        [Required]
        public string nombre_empresa { get; set; }
        public string? direccion { get; set; }
        public string? email { get; set; }
        public string? telefono { get; set; }

        public string? razonsocial { get; set; }
        public string? NIT { get; set; }
        public string? Representante { get; set; }

        public Empresa(int id_empresa, string nombre_empresa, string direccion, string email, string telefono, string razonsocial, string NIT, string Representante)
        {
            this.id_empresa = id_empresa;
            this.nombre_empresa = nombre_empresa;
            this.direccion = direccion;
            this.email = email;
            this.telefono = telefono;
            this.razonsocial = razonsocial;
            this.NIT = NIT;
            this.Representante = Representante;
        }

    }
}