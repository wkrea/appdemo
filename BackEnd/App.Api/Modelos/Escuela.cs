using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace App.Api.Modelos
{
    public class Escuela
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Ciudad { get; set; }
        [Required]
        public string Departamento { get; set; }
        public ICollection<Profesor> Profesores { get; set; }
    }
}
