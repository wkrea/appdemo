namespace App.api.Controllers.DTOs{
  
  public class EstudianteDto{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string CursoId { get; set; }
    public string ProfesorId { get; set; }
    public string EscuelaId { get; set; }
  }
}
