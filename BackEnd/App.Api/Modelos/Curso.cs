using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace App.Api.Modelos
{
    public class Curso
    {
        public int Id {get; set;}
        [Required]
        public string Nombre {get; set;}
        
        public int ProfesorId {get; set;}
        
        public Profesor profesor {get; set;}
        
        public ICollection<Estudiante> Estudiantes {get; set;}
    }
}
