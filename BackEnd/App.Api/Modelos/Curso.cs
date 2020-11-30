using System.Collections.Generic;


namespace App.api.Modelos
{
    //[Table("Cursos")]
    public class Curso
    {
        public int id { get; set; }
        // [required]
        public string nombre { get; set; }
        // [required]
        public string curso  { get; set; }
        public int ProfesorId  { get; set; }

        public Profesor Profesor  { get; set; }

        public ICollection<Estudiante> Estudiantes  { get; set; }
    }
}
