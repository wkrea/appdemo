using System.Collections.Generic;

namespace App.Api.Modelos
{
    public class Curso
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public int profesorId { get; set; }
        public Profesor profesor { get; set; }
        public ICollection<Estudiante> estudiantes { get; set; }
    }
}
