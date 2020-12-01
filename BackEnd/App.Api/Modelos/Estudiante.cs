using System.ComponentModel.DataAnnotations;

namespace App.Api.Modelos
{
    public class Estudiante
    {
        public int Id {get; set;}
        [Required]
        public string Nombre {get; set;}

        public int CursoId {get; set;}

        public Curso Curso {get; set;}
    }
}
