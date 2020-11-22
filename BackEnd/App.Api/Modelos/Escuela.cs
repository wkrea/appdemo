using System.Collections.Generic;

namespace App.Api.Modelos
{
    public class Escuela
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string ciudad { get; set; }
        public string departamento { get; set; }
        public ICollection<Profesor> profesores { get; set; }
    }
}