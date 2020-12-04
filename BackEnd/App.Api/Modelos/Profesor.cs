
using System.Collections.Generic;

namespace App.api.Modelos
{
    
    public class Profesor
    {
        public int Id { get; set; }
        // [required]
        public string Nombre { get; set; }

        /// <summary>
        /// Establecer relación completa (no requiere FluentApi)
        /// https://henriquesd.medium.com/entity-framework-core-relationships-with-fluent-api-8f741c57b881
        /// </summary>
        public int EscuelaId { get; set; }
        public virtual Escuela Escuela { get; set; }

        public virtual ICollection<Curso> Cursos { get; set; }
    }
    }

