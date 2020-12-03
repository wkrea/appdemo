using System.Collections.Generic;
namespace App.api.Modelos
{
        public class Escuela
    {
        public int Id { get; set; }
        // [required]
        public string Nombre { get; set; }
        // [required]
         public string Ciudad{ get; set; }
        // [required]
         public string Departamento { get; set; }
        // [required]
        public virtual ICollection<Profesor> Profesores  { get; set; }
        
    }
}
