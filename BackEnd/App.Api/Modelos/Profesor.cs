using System.Collections.Generic;

namespace App.Api.Modelos
{
    public class Profesor
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public int escuelaId { get; set; }
        public Escuela escuela { get; set; }
        public ICollection<Curso> cursos { get; set; }
    }
}