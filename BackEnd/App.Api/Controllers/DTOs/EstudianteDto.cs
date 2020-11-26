namespace App.Api.Controllers.DTOs{
  
  public class EstudianteDto{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public int CursoId { get; set; }
    public int ProfesorId { get; set; }
    public int EscuelaId { get; set; }
  }
}
