namespace App.Api.Modelos
{
    public class Estudiante
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        /// <summary>
        /// Establecer relación completa (no requiere FluentApi)
        /// </summary>
        public int CursoId { get; set; }
        public virtual Curso Curso { get; set; }
    }
}
