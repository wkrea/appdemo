// using System.Collections.Generic;
// using System.Threading.Tasks;
// using App.Api.Modelos;
// using Microsoft.EntityFrameworkCore;

// namespace App.Api.Repositorio
// {
//   public class EstudianteRepo : IEstudianteRepo
//   {
//     private readonly UdiDbContext db;
//     public EstudianteRepo(UdiDbContext context)
//     {
//       db = context;
//     }

//     public async Task crearEstudiante(Estudiante estudiante)
//     {
//       db.Estudiantes.Add(estudiante); //agregado
//       await db.SaveChangesAsync(); //commits
//     }

//     public async Task editarEstudiante(Estudiante estudiante)
//     {
//       db.Estudiantes.Update(estudiante);
//       await db.SaveChangesAsync(); //commits
//     }

//     public async Task<List<Estudiante>> obtenerEstudiantes()
//     {
//       return await db.Estudiantes.ToListAsync();
//     }
//     public async Task<Estudiante> obtenerEstudiante(int id)
//     {
//       return await db.Estudiantes.FindAsync(id);
//     }
    
//   }
// }
