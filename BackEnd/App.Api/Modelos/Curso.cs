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
    }
}