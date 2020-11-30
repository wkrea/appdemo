﻿using System.Collections.Generic;

namespace App.Api.Modelos
{
    public class Profesor
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        /// <summary>
        /// Establecer relación completa (no requiere FluentApi)
        /// </summary>
        public int EscuelaId { get; set; }
        public Escuela Escuela { get; set; }

        public ICollection<Curso> Cursos { get; set; }
    }
}
