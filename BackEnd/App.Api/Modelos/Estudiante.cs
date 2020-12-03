namespace App.api.Modelos
{
        public class Estudiante
    {
        public int Id { get; set; }
        // [required]
        public string Nombre { get; set; }
        // [required]
        public int CursoId { get; set; }
        // [required]
     
      public  virtual Curso  Curso {get ;set; }

        
    }
}
