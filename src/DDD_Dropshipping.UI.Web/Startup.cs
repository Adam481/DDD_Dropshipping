using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Reflection;
using System.IO;
using DDD_Dropshipping.UI.Web.Routing;

namespace DDD_Dropshipping.UI.Web
{
    public class Startup
    {
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info { Title = "My First Swagger" });
            });

            return new AutofacServiceProvider(CreateContainer(services));
        }


        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler();
            }

            app.UseStatusCodePages();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My First Swagger");
            });

            app.UseMvc();
        }

        
        private IContainer CreateContainer(IServiceCollection services)
        {
            // Load assemblies
            var assemblies = GetAllAssemblies();

            // Create builder
            var builder = new ContainerBuilder();
            
            // Register autofac modules
            builder.RegisterAssemblyModules(assemblies);

            // Find command/quoery mediator
            var mediatorType = assemblies
                .SelectMany(t => t.GetTypes())
                .FirstOrDefault(x => typeof(IMediator)
                .IsAssignableFrom(x));

            var mediator = (IMediator)Activator.CreateInstance(mediatorType);

            // Register mediator
            builder.RegisterInstance(mediator);

            // Register request handler
            builder.RegisterAssemblyTypes(assemblies)
                .Where(t => t.IsClosedTypeOf(typeof(IHandler<,>)))
                .AsImplementedInterfaces()
                .SingleInstance();


            builder.Populate(services);
            var container = builder.Build();

            mediator.Register(container.Resolve);

            return container;
        }


        private Assembly[] GetAllAssemblies()
        {
            var assemblyFilter = typeof(Startup).FullName.Split(".").First() + ".";

            return Directory.EnumerateFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll", SearchOption.TopDirectoryOnly)
                .Where(f => f.Contains(assemblyFilter))
                .Select(x => Assembly.LoadFrom(x))
                .ToArray();
        }
    }
}
