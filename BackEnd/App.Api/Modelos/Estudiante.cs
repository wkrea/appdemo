namespace App.Api.Modelos
{
    public class Estudiante
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string cursoId { get; set; }
        public Curso curso { get; set; }
    }
}