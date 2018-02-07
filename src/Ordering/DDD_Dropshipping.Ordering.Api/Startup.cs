using Autofac;
using Autofac.Extensions.DependencyInjection;
using Autofac.Features.Variance;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace DDD_Dropshipping.Ordering.Api
{
    public class Startup
    {
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSwaggerGen(swagger =>
            {
                swagger.DescribeAllEnumsAsStrings();
                swagger.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info()
                {
                    Title = "DDD_Dropshipping - Ordering Api",
                    Version = "v2",
                    Description = "DDD_Dropshipping - Ordering microservice HTTP API"
                });
            });

            IContainer container = BuildContainer(services);

            return new AutofacServiceProvider(container);
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
                c.SwaggerEndpoint(
                    "/swagger/v1/swagger.json", 
                    "Ordering API v1 swagger endpoint");
            });
            
            app.UseMvc();
        }


        private IContainer BuildContainer(IServiceCollection services)
        {

            var builder = new ContainerBuilder();

            // enables contravariant Resolve() for interfaces with single contravariant ("in") arg
            builder.RegisterSource(new ContravariantRegistrationSource());

            // mediator itself
            builder
              .RegisterType<Mediator>()
              .As<IMediator>()
              .InstancePerLifetimeScope();

            // request handlers
            builder
              .Register<SingleInstanceFactory>(ctx => {
                  var c = ctx.Resolve<IComponentContext>();
                  return t => { object o; return c.TryResolve(t, out o) ? o : null; };
              })
              .InstancePerLifetimeScope();

            // notification handlers
            builder
              .Register<MultiInstanceFactory>(ctx => {
                  var c = ctx.Resolve<IComponentContext>();
                  return t => (IEnumerable<object>)c.Resolve(typeof(IEnumerable<>).MakeGenericType(t));
              })
              .InstancePerLifetimeScope();

            // Load assemblies
            var assemblies = ServiceAssemblies();

            // Register autofac modules
            builder.RegisterAssemblyModules(assemblies);

            builder.Populate(services);

            return builder.Build();
        }


        private Assembly[] ServiceAssemblies()
            => Directory
                .EnumerateFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll", SearchOption.TopDirectoryOnly)
                .Where(f => f.Contains("DDD_Dropshipping."))
                .Select(x => Assembly.LoadFrom(x))
                .ToArray();
    }
}
