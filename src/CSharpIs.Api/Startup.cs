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

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
