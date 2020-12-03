
using System.Collections.Generic;

namespace App.api.Modelos
{
    
    public class Profesor
    {
        public int Id { get; set; }
        // [required]
        public string Nombre { get; set; }
        // [required]
         public virtual Escuela Escuela { get; set; }
        // [required]
         public int EscuelaId { get; set; }
        // [required]
        public virtual ICollection<Curso> Cursos  { get; set; }
    }
    }

