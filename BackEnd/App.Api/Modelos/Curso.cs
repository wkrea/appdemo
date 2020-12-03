<<<<<<< HEAD
﻿
using System.Collections.Generic;
=======
﻿using System.Collections.Generic;
>>>>>>> main

namespace App.Api.Modelos
{
    public class Curso
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
<<<<<<< HEAD
        public int ProfesorId { get; set; }
        public Profesor Profesor { get; set; }
        public ICollection<Estudiante> Estudiantes { get; set; }

=======

        /// <summary>
        /// Establecer relación completa (no requiere FluentApi)
        /// https://henriquesd.medium.com/entity-framework-core-relationships-with-fluent-api-8f741c57b881
        /// </summary>
        public int ProfesorId { get; set; }
        public virtual Profesor Profesor { get; set; }

        public virtual ICollection<Estudiante> Estudiantes { get; set; }
>>>>>>> main
    }
}
