using System.Collections.Generic;

namespace App.Api.Modelos{
    public class Escuela{
        public int Id {get; set;}
        public string Nombre {get; set;}
        public string Ciudad {get; set;}
        public string Departamento {get; set;}
        public ICollection<Profesor> Profesor {get; set;}

    }

}