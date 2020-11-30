using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using App.Api.Controllers.DTOs;
using App.Api.Modelos;
using Xunit;
using App.Api;

namespace App.Tests
{
    [Collection("Tests de Integración")]
    public class EstudiantesControllerTests : IClassFixture<EstudiantesControllerTests.DbSetup>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        // This class provides setup before all class tests, then clean-up after
        [Collection("Tests de Integración")]
        public class DbSetup : IDisposable
        {
            private UdiDbContext _dbContext;

            public DbSetup(WebApplicationFactory<Startup> factory)
            {
                // This fetches the same single lifetime instantiation used by Controller classes
                //_dbContext = factory.Services.GetRequiredService<UdiDbContext>();
                _dbContext =  factory.Services.GetService<UdiDbContext>();

                // Seed in-memory database with some data needed for tests
                var Escuela = new Escuela
                {
                    Id = 1,
                    Nombre = "Escuela Ing. de Sistemas",
                    Ciudad = "Bucaramanga",
                    Departamento = "Santander"
                };
                _dbContext.Escuelas.Add(Escuela);
                var Profesor = new Profesor
                {
                    Id = 1,
                    Nombre = "William Trigos",
                    Escuela = Escuela
                };
                _dbContext.Profesores.Add(Profesor);
                var @class = new Curso
                {
                    Id = 1,
                    Nombre = "Servicios Web GNU",
                    Profesor = Profesor
                };
                _dbContext.Cursos.Add(@class);
                var Estudiante1 = new Estudiante
                {
                    Id = 1,
                    Nombre = "Alix Villalba",
                    Curso = @class
                };
                _dbContext.Estudiantes.Add(Estudiante1);
                var Estudiante2 = new Estudiante
                {
                    Id = 2,
                    Nombre = "Luisa Duarte",
                    Curso = @class
                };
                _dbContext.Estudiantes.Add(Estudiante2);
                _dbContext.SaveChanges();
            }

            public void Dispose()
            {
                var Estudiantes = _dbContext.Estudiantes.ToArray();
                _dbContext.Estudiantes.RemoveRange(Estudiantes);
                var classes = _dbContext.Cursos.ToArray();
                _dbContext.Cursos.RemoveRange(classes);
                var Profesores = _dbContext.Profesores.ToArray();
                _dbContext.Profesores.RemoveRange(Profesores);
                var Escuelass = _dbContext.Escuelas.ToArray();
                _dbContext.Escuelas.RemoveRange(Escuelass);
                _dbContext.SaveChanges();
            }
        }

        public EstudiantesControllerTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GetEstudiante_ReturnsSuccessAndEstudiante()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("/Estudiantes/1");

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.NotNull(response.Content);
            var responseEstudiante = JsonSerializer.Deserialize<EstudianteDTO>(
                await response.Content.ReadAsStringAsync(),
                new JsonSerializerOptions {PropertyNameCaseInsensitive = true});
            Assert.NotNull(responseEstudiante);
            Assert.Equal(1, responseEstudiante.Id);
            Assert.Equal("Alix Villalba", responseEstudiante.Nombre);
            Assert.Equal(1, responseEstudiante.CursoId);
            Assert.Equal(1, responseEstudiante.ProfesorId);
            Assert.Equal(1, responseEstudiante.EscuelaId);
        }

        [Fact]
        public async Task GetEstudiante_ReturnsNotFound()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("/Estudiantes/999");

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task GetAllEstudiantes_ReturnsSuccessAndEstudiantes()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("/Estudiantes");

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.NotNull(response.Content);
            var responseEstudiantes = JsonSerializer.Deserialize<IEnumerable<EstudianteDTO>>(
                await response.Content.ReadAsStringAsync(),
                new JsonSerializerOptions {PropertyNameCaseInsensitive = true});
            Assert.NotNull(responseEstudiantes);
            Assert.Equal(2, responseEstudiantes.Count());
            Assert.Contains(responseEstudiantes, Estudiante => Estudiante.Id == 1);
            Assert.Contains(responseEstudiantes, Estudiante => Estudiante.Id == 2);
        }

        [Fact]
        public async Task CreateEstudiante_ReturnsSuccessNewEstudianteAndLocationHeader()
        {
            // Arrange
            var client = _factory.CreateClient();
            var EstudianteDto = new EstudianteDTO
            {
                Id = 3,
                Nombre = "John Duarte",
                CursoId = 1
            };
            var content = new StringContent(JsonSerializer.Serialize(EstudianteDto, 
                new JsonSerializerOptions{IgnoreNullValues = true}), Encoding.UTF8, "application/json");

            try
            {
                // Act
                var response = await client.PostAsync("/Estudiantes", content);

                // Assert
                response.EnsureSuccessStatusCode();
                Assert.NotNull(response.Content);
                var responseEstudiante = JsonSerializer.Deserialize<EstudianteDTO>(
                    await response.Content.ReadAsStringAsync(),
                    new JsonSerializerOptions {PropertyNameCaseInsensitive = true});
                Assert.NotNull(responseEstudiante);
                Assert.Equal(EstudianteDto.Id, responseEstudiante.Id);
                Assert.Equal(EstudianteDto.Nombre, responseEstudiante.Nombre);
                Assert.Equal(EstudianteDto.CursoId, responseEstudiante.CursoId);
                Assert.Equal(1, responseEstudiante.ProfesorId);
                Assert.Equal(1, responseEstudiante.EscuelaId);
                //Assert.Equal(new Uri(client.BaseAddress, "/Estudiantes/3"), response.Headers.Location);
            }
            finally
            {
                // Clean-up (so it Duartesn't mess up other tests)
                var dbContext = _factory.Services.GetRequiredService<UdiDbContext>();
                var Estudiante = await dbContext.Estudiantes.FindAsync(EstudianteDto.Id);
                dbContext.Estudiantes.Remove(Estudiante);
                await dbContext.SaveChangesAsync();
            }
        }

        [Theory]
        [InlineData(1, "John Duarte", 1, HttpStatusCode.Conflict)]  // Id already exists
        [InlineData(3, null, 1, HttpStatusCode.BadRequest)]      // missing (null) Name
        [InlineData(3, "", 1, HttpStatusCode.BadRequest)]        // missing (empty) Name
        [InlineData(3, "John Duarte", 2, HttpStatusCode.NotFound)]  // Class Duartesn't exist
        public async Task CreateEstudiante_ReturnsErrorCode(int id, string name, int CursoId, HttpStatusCode expectedStatusCode)
        {
            // Arrange
            var client = _factory.CreateClient();
            var EstudianteDto = new EstudianteDTO
            {
                Id = id,
                Nombre = name,
                CursoId = CursoId
            };
            var content = new StringContent(JsonSerializer.Serialize(EstudianteDto, 
                new JsonSerializerOptions{IgnoreNullValues = true}), Encoding.UTF8, "application/json");

            // Act
            var response = await client.PostAsync("/Estudiantes", content);

            // Assert
            Assert.Equal(expectedStatusCode, response.StatusCode);
        }

        [Fact]
        public async Task UpdateEstudiante_ReturnsSuccess()
        {
            // Arrange
            var client = _factory.CreateClient();
            var EstudianteDto = new EstudianteDTO
            {
                Id = 2,
                Nombre = "Juan Sandoval",
                CursoId = 1
            };
            var content = new StringContent(JsonSerializer.Serialize(EstudianteDto, 
                new JsonSerializerOptions{IgnoreNullValues = true}), Encoding.UTF8, "application/json");

            // Act
            var response = await client.PutAsync("/Estudiantes/2", content);

            // Assert
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }

        [Theory]
        [InlineData(2, 999, "Juan Sandoval", 1, HttpStatusCode.BadRequest)] // url and dto Id's don't match
        [InlineData(2, 2, null,  1, HttpStatusCode.BadRequest)]           // missing (null) Name
        [InlineData(2, 2, "",  1, HttpStatusCode.BadRequest)]             // missing (empty) Name
        [InlineData(999, 999, "Juan Sandoval", 1, HttpStatusCode.NotFound)] // Estudiante not found
        [InlineData(2, 2, "Juan Sandoval", 2, HttpStatusCode.NotFound)]     // Class not found
        public async Task UpdateEstudiante_ReturnsErrorCode(int urlId, int dtoId, string name, int CursoId, HttpStatusCode expectedStatusCode)
        {
            // Arrange
            var client = _factory.CreateClient();
            var EstudianteDto = new EstudianteDTO
            {
                Id = dtoId,
                Nombre = name,
                CursoId = CursoId
            };
            var content = new StringContent(JsonSerializer.Serialize(EstudianteDto, 
                new JsonSerializerOptions{IgnoreNullValues = true}), Encoding.UTF8, "application/json");

            // Act
            var response = await client.PutAsync($"/Estudiantes/{urlId}", content);

            // Assert
            Assert.Equal(expectedStatusCode, response.StatusCode);

        }

        [Fact]
        public async Task DeleteEstudiante_ReturnsSuccessAndEstudiante()
        {
            // Arrange
            var client = _factory.CreateClient();
            var dbContext = _factory.Services.GetRequiredService<UdiDbContext>();
            var Estudiante = new Estudiante
            {
                Id = 4,
                Nombre = "Yenny Vargas",
                Curso = await dbContext.Cursos.FindAsync(1)
            };
            dbContext.Estudiantes.Add(Estudiante);
            await dbContext.SaveChangesAsync();

            // Act
            var response = await client.DeleteAsync("/Estudiantes/4");

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.NotNull(response.Content);
            var responseEstudiante = JsonSerializer.Deserialize<EstudianteDTO>(
                await response.Content.ReadAsStringAsync(),
                new JsonSerializerOptions {PropertyNameCaseInsensitive = true});
            Assert.NotNull(responseEstudiante);
            Assert.Equal(Estudiante.Id, responseEstudiante.Id);
            Assert.Equal(Estudiante.Nombre, responseEstudiante.Nombre);
            Assert.Equal(Estudiante.Curso.Id, responseEstudiante.CursoId);
            Assert.Equal(Estudiante.Curso.Profesor.Id, responseEstudiante.ProfesorId);
            Assert.Equal(Estudiante.Curso.Profesor.Escuela.Id, responseEstudiante.EscuelaId);
        }

        [Fact]
        public async Task DeleteEstudiante_ReturnsNotFound()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.DeleteAsync("/Estudiantes/999");

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
