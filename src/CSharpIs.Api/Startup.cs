using System;
using System.IO;
using System.Linq;
using System.Reflection;
using CSharpIs.Domain.DAL;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace CSharpIs.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        [UsedImplicitly]
        public IConfiguration Configuration { get; }

        [UsedImplicitly]
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddCors();
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Title = "CSharp.Is API", 
                    Version = "v1"
                });
            });

            var assemblies = Directory.EnumerateFiles(AppDomain.CurrentDomain.BaseDirectory, "CSharpIs.*.dll", SearchOption.AllDirectories)
                .Select(Assembly.LoadFrom);

            services.Scan(x => x.FromAssemblies(assemblies).AddClasses().AsImplementedInterfaces());

            services.AddDbContext<EntityContext>(options => options.UseSqlServer(Configuration.GetConnectionString("CSharpIs")));
        }

        [UsedImplicitly]
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors(builder => builder
                .WithOrigins("http://localhost:4200", "https://csharp.is")
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials()
            );

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "CSharp.Is API V1");
                c.RoutePrefix = string.Empty;
            });
            
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
