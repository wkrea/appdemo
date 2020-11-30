using System.Collections.Generic;

namespace App.Api.Modelos
{
    public class Profesor
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int EscuelaId { get; set; }
        public Escuela Escuela { get; set; }
        public ICollection<curso> cursos { get; set; } 
    }
}
