using System.Collections.Generic;

namespace App.Api.Modelos
{
    public class Curso
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int ProfesorId { get; set; }
        public Profesor estudiantes { get; set; }
        public ICollection<Estudiante> Profesor { get; set; }
    }
}
