using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Api.Modelos
{
    public class Curso
    {
        public int Id { get; set; }
        public string Nombre{ get; set; }
        public int ProfesorId { get; set; }
        public Profesor Profesor { get; set; } //one
        public ICollection<Estudiante> Estudiantes { get; set; }  //many to one
    }
}
