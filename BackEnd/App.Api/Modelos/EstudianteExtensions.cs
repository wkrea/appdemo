using System;
using App.Api.Controllers.DTOs;

namespace App.Api.Modelos
{
<<<<<<< HEAD
    public static class EstudianteDTOExtensions
    {
        
        public static void Update(this Estudiante EstudianteToUpdate, EstudianteDTO EstudianteDto, Curso curso)
        {
            if (EstudianteDto.Id != EstudianteToUpdate.Id) throw new NotSupportedException();
            EstudianteToUpdate.Nombre = EstudianteDto.Nombre;
            EstudianteToUpdate.Curso = curso;
        }

        public static Estudiante ToModel(this EstudianteDTO EstudianteDto, Curso curso)
        {
            if (curso.Id != EstudianteDto.CursoId) throw new NotSupportedException();
            return new Estudiante
            {
                Id = EstudianteDto.Id,
                Nombre = EstudianteDto.Nombre,
                Curso = curso
            };
        }

        public static EstudianteDTO ToDTO(this Estudiante Estudiante)
        {
            return new EstudianteDTO
            {
                Id = Estudiante.Id,
                Nombre = Estudiante.Nombre,
                CursoId = Estudiante.CursoId,
                ProfesorId = Estudiante.Curso.Profesor.Id,
                EscuelaId = Estudiante.Curso.Profesor.Escuela.Id
=======
    public static class EstudianteExtensions
    {
        /// <summary>
        /// Permite transferir la información desde FrontEnd hacia la Entidad en la base de datos
        ///    In:  Instancia DTO, recibida desde el FrontEnd
        ///    Out: Instancia de Modelo (representa estructura de Entidad en la base de datos) 
        /// </summary>
        /// <param name="objEstudianteDto"></param>
        /// <param name="objCurso"></param>
        /// <returns></returns>
        public static Estudiante ToModel(this EstudianteDTO objEstudianteDto, Curso objCurso)
        {
            // Información desde FrontEnd (Postman -> JSON), hacia la base de datos (Modelos/Estudiante.cs)
            // crear un estudiante con los datos (Id, Nombre y Curso) que vienen en el objEstDTO
            if (objCurso.Id != objEstudianteDto.CursoId) throw new NotSupportedException();
            return new Estudiante
            {
                Id = objEstudianteDto.Id,
                Nombre = objEstudianteDto.Nombre,
                Curso = objCurso
            };
        }
        /// <summary>
        /// Facilita la edición de un registro disponible en la base de datos
        /// </summary>
        /// <param name="objEstudianteToUpdate">Instancia con datos provenientes desde FrontEnd(Postman -> JSON)</param>
        /// <param name="objEstudianteDto">Instancia proveniente de la Base de datos</param>
        /// <param name="objCurso">Instancia con datos provenientes desde FrontEnd</param>
        public static void Update(this Estudiante objEstudianteToUpdate, EstudianteDTO objEstudianteDto, Curso objCurso)
        {
            // verificar que la entidad existe en la base
            // actualizar los campos Nombre y Curso, sobre la instancia objEstUpdate
            if (objEstudianteDto.Id != objEstudianteToUpdate.Id) throw new NotSupportedException();
            objEstudianteToUpdate.Nombre = objEstudianteDto.Nombre;
            objEstudianteToUpdate.Curso = objCurso;
        }
        /// <summary>
        /// Permite tranferir la información desde: 
        ///    In:  Instancia de Modelo (representa estructura de Entidad en la base de datos) 
        ///    Out: Instancia DTO, para responder al FrontEnd
        /// </summary>
        /// <param name="objEstudiante"></param>
        /// <returns></returns>
        public static EstudianteDTO ToDTO(this Estudiante objEstudiante)
        {
            // retornar información adicional desde las relaciones existentes
            // propiedades de navegación
            return new EstudianteDTO
            {
                Id = objEstudiante.Id,
                Nombre = objEstudiante.Nombre,
                CursoId = objEstudiante.CursoId,
                ProfesorId = objEstudiante.Curso.Profesor.Id,
                EscuelaId = objEstudiante.Curso.Profesor.Escuela.Id
>>>>>>> main
            };
        }
    }
}
