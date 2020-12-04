using System.Collections.Generic;
namespace App.api.Modelos
{
        public class Escuela
    {
        public int Id { get; set; }
        // [required]
        public string Nombre { get; set; }
        public string Ciudad { get; set; }
        public string Departamento { get; set; }

        public virtual ICollection<Profesor> Profesores { get; set; }
    }
}
