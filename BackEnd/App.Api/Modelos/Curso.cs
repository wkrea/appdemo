using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace App.Api.Modelos
{
    public class Curso
    {
        public int Id;
        [Required]
        public string Nombre;
        public int ProfesorId;
        public Profesor Profesor { get; set; }
        public ICollection<Estudiante> Estudiantes { get; set; }
    }
}
