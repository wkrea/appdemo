using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.Api.Modelos
{
    public class Estudiante
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Cursoid {get; set;}
        public Curso Curso { get; set; } // Relación one to many

    }
}
