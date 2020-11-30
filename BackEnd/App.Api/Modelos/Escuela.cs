using System.Collections.Generic;
namespace App.api.Modelos
{
        public class Escuela
    {
        public int id { get; set; }
        // [required]
        public string nombre { get; set; }
        // [required]
         public string ciudad{ get; set; }
        // [required]
         public string departamento { get; set; }
        // [required]
        public ICollection<Profesor> Profesores  { get; set; }
        
    }
}
