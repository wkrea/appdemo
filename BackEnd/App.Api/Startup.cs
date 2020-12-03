using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Api.Modelos;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
                builder.UseInMemoryDatabase("UdiDb-Memory").UseLazyLoadingProxies()
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

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
