using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace App.Api.Modelos
{
    public class Profesor
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public int EscuelaId { get; set; }
        public Escuela Escuela{get;set;}
        public ICollection<Curso> Cursos {get; set;}
    }
}
