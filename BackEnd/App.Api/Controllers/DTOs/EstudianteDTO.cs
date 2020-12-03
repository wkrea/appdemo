<<<<<<< HEAD
﻿using System;
using App.Api.Modelos;

namespace App.Api.Controllers.DTOs
=======
﻿namespace App.Api.Controllers.DTOs
>>>>>>> main
{
    public class EstudianteDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int CursoId { get; set; }
        public int ProfesorId { get; set; }
        public int EscuelaId { get; set; }
<<<<<<< HEAD

        internal static Estudiante ToModel(Curso cur)
        {
            throw new NotImplementedException();
        }
=======
>>>>>>> main
    }
}
