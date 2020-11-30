namespace App.api.Modelos
{
        public class Estudiante
    {
        public int id { get; set; }
        // [required]
        public string nombre { get; set; }
        // [required]
        public int cursoId { get; set; }
        // [required]
     
      public  Curso  Curso {get ;set; }

        
    }
}
