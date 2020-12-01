using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Api.Modelos;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace App.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //hacer llamado a controladores --> http(s)://localhost:5000/endpoint_XYZ
            services.AddControllers(); 

            // ORM -> EntityFramework (configuración de BD)
            // BD    
            // dotnet add package Microsoft.EntityFrameworkCore.InMemory
            services.AddDbContext<UdiDbContext>(opts => 
                opts.UseInMemoryDatabase("UdiDbContext") //"Memoria"
            );
            // Nuggets paquetes
            // // dotnet add package Microsoft.EntityFrameworkCore.SqlServer
            // services.AddDbContext<AppDBContext>(opts => 
            //     opts.UseSqlServer("ConnString"); // "Real"
            // ); 
            //services.AddScoped<IEstudianteRepo, EstudianteRepo>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
