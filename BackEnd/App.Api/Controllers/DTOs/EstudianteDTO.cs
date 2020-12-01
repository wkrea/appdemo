namespace App.Api.Controllers.DTOs
{
    public class EstudianteDTO
    {
        public int Id {get; set;}
        public string nombre {get; set;}
        public int CursoId {get; set;}
        public int ProfesorId {get; set;}
        public int EscuelaId {get; set;}
    }
}
