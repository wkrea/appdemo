using System.Collections.Generic;


namespace App.api.Modelos
{
    //[Table("Cursos")]
    public class Curso
    {
        public int Id { get; set; }
        // [required]
        public string Nombre { get; set; }
        // [required]
        public string curso  { get; set; }
        public int ProfesorId  { get; set; }

        /// <summary>
        /// Establecer relación completa (no requiere FluentApi)
        /// https://henriquesd.medium.com/entity-framework-core-relationships-with-fluent-api-8f741c57b881
        /// </summary>
        
        public virtual Profesor Profesor { get; set; }

        public virtual ICollection<Estudiante> Estudiantes { get; set; }
    }
}
