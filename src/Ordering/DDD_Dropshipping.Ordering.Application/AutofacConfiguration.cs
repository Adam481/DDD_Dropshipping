using Autofac;

namespace DDD_Dropshipping.Ordering.Application
{
    public class AutofacConfiguration : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterAssemblyTypes(typeof(AutofacConfiguration).Assembly)
                .AsImplementedInterfaces()
                .InstancePerDependency();

            base.Load(builder);
        }
    }
}
