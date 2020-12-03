using App.Api.Controllers.DTOs;
using App.Api.Modelos;
using App.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace App.Api.Repositorios
{
        public class EstudianteRepo : IEstudianteRepo
    {  
        private readonly UdiDbContext _db;
        
        public EstudianteRepo(UdiDbContext context)
        {
            _db = context;
        } 

        public async Task<Estudiante> obtenerEstudiante(int id)
        {
            return await _db.Estudiantes.FirstOrDefaultAsync(e=>e.Id==id);
        } 

        public async Task<IEnumerable<Estudiante>> obtenerEstudiantes()
        {
            return await _db.Estudiantes.ToArrayAsync();
        }

        public async Task<Curso> obtenerCurso(int id)
        {
            return await _db.Cursos.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task crearEstudiante(Estudiante estudiante)
        {
            _db.Estudiantes.Add(estudiante);
            await _db.SaveChangesAsync();
        }

        public async Task editarEstudiante()
        {
            await _db.SaveChangesAsync();
        } 

        public async Task eliminarEstudiante(Estudiante estudiante)
        {
            _db.Estudiantes.Remove(estudiante);
            await _db.SaveChangesAsync();
        } 
    }
}
