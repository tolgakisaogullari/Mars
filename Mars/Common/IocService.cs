using Autofac;
using Mars.Services;

namespace Mars.Common
{
    public static class IocService
    {
        public static IContainer GetContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<CommandService>().As<ICommandService>().InstancePerLifetimeScope();

            return builder.Build();
        }
    }
}
