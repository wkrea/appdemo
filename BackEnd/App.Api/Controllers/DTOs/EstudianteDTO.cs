namespace App.Api.Controllers.DTOs
{
    public class EstudianteDTO
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public int cursoId { get; set; }
        public int profesorId { get; set; }
        public int escuelaId { get; set; }
    }
}
