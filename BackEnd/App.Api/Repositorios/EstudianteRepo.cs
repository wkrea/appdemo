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
            return await _db.estudiantes.FindAsync(id);
        }

        public async Task<List<Estudiante>> obtenerEstudiantes()
        {
            return await _db.estudiantes.ToListAsync();
        }

        public async Task crearEstudiante(Estudiante estudiante)
        {
            _db.estudiantes.Add(estudiante);
            await _db.SaveChangesAsync();
        }

        public async Task editarEstudiante(Estudiante estudiante)
        {
            _db.estudiantes.Update(estudiante);
            await _db.SaveChangesAsync();
        }

        public async Task eliminarEstudiante(int id)
        {
            Estudiante estudiante = await _db.estudiantes.FindAsync(id);
            _db.estudiantes.Remove(estudiante);
            await _db.SaveChangesAsync();
        }
    }
}
