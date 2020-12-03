using System.Collections.Generic;

namespace App.Api.Modelos
{
    public class Curso
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        /// <summary>
        /// Establecer relación completa (no requiere FluentApi)
        /// https://henriquesd.medium.com/entity-framework-core-relationships-with-fluent-api-8f741c57b881
        /// </summary>
        public int ProfesorId { get; set; }
        public virtual Profesor Profesor { get; set; }

        public virtual ICollection<Estudiante> Estudiantes { get; set; }
    }
}
