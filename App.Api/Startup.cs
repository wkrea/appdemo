using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Hosting;
using App.Api.Modelos;
using Microsoft.EntityFrameworkCore;

namespace App.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.IgnoreNullValues = true;
                options.JsonSerializerOptions.WriteIndented = true;
            });
            services.AddHealthChecks();

            //services.AddDbContext<UdiDbContext>();
            services.AddDbContext<UdiDbContext>(builder =>
                builder.UseInMemoryDatabase("UdiDb-Memory")
                , ServiceLifetime.Singleton);

            //SqlServer
            //services.AddDbContext<UdiDbContext>(options =>
            //    options.UseSqlServer(
            //        Configuration.GetConnectionString("UdiDb"))
            //        , ServiceLifetime.Singleton
            //    );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //UpdateDatabase(app);

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseHealthChecks("/health", new HealthCheckOptions {ResponseWriter = JsonResponseWriter});

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private async Task JsonResponseWriter(HttpContext context, HealthReport report)
        {
            context.Response.ContentType = "application/json";
            await JsonSerializer.SerializeAsync(
                context.Response.Body, 
                new { Status = report.Status.ToString() },
                new JsonSerializerOptions 
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });
        }

        //private static void UpdateDatabase(IApplicationBuilder app)
        //{
        //    using (var serviceScope = app
        //                                .ApplicationServices
        //                                .GetRequiredService<IServiceScopeFactory>()
        //                                .CreateScope())
        //    {
        //        using (var context = serviceScope.ServiceProvider.GetService<UdiDbContext>())
        //        {
        //            context.Database.Migrate();
        //        }
        //    }
        //}
    }
}
