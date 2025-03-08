using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mvcapp.Models
{
    public class Transporte
    {
        [Key]
        public int id_transporte { get; set; }
        public int id_tipo_servicio { get; set; }
        public int id_marca { get; set; }
        public int id_modelo { get; set; }
        public int id_ruta { get; set; }
        public int id_conductor { get; set; }
        public string? descripcion { get; set; }
        public int? kilometraje { get; set; }
        public string placa { get; set; }
        public string documento { get; set; }
        public string? estado { get; set; }
        public int? capacidad { get; set; }

        public Transporte()
        {
        }

        public Transporte(int id_transporte, int id_tipo_servicio, int id_marca, int id_modelo, int id_ruta, int id_conductor, string descripcion, int kilometraje, string placa, string documento, string estado, int capacidad)
        {
            this.id_transporte = id_transporte;
            this.id_tipo_servicio = id_tipo_servicio;
            this.id_marca = id_marca;
            this.id_modelo = id_modelo;
            this.id_ruta = id_ruta;
            this.id_conductor = id_conductor;
            this.descripcion = descripcion;
            this.kilometraje = kilometraje;
            this.placa = placa;
            this.documento = documento;
            this.estado = estado;
            this.capacidad = capacidad;
        }



    }
}