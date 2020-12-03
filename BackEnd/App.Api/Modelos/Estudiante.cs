namespace App.api.Modelos
{
        public class Estudiante
    {
        public int Id { get; set; }
        // [required]
        public string Nombre { get; set; }

        /// <summary>
        /// Establecer relación completa (no requiere FluentApi)
        /// https://henriquesd.medium.com/entity-framework-core-relationships-with-fluent-api-8f741c57b881
        /// </summary>
        public int CursoId { get; set; }
        // [required]
     
      public  virtual Curso  Curso {get ;set; }

        
    }
}
