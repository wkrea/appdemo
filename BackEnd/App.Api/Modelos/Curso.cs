using System.Collections.Generic;

namespace App.Api.Modelos
{
    public class Curso
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        /// <summary>
        /// Establecer relación completa (no requiere FluentApi)
        /// </summary>
        public int ProfesorId { get; set; }
        public Profesor Profesor { get; set; }

        public ICollection<Estudiante> Estudiantes { get; set; }
    }
}
