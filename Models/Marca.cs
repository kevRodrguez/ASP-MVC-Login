using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mvcapp.Models
{
    public class Marca
    {
        [Key]
        public int id_marca { get; set; }
        public string nombre_marca { get; set; }
        public string? descripcion { get; set; }

        public Marca()
        {
        }

        public Marca(int id_marca, string nombre_marca, string descripcion)
        {
            this.id_marca = id_marca;
            this.nombre_marca = nombre_marca;
            this.descripcion = descripcion;
        }
    }
}