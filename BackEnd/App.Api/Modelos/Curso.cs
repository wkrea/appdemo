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

        public virtual Profesor Profesor  { get; set; }

        public virtual ICollection<Estudiante> Estudiantes  { get; set; }
    }
}
