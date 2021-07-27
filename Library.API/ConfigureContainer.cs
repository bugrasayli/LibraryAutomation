using Autofac;
using Library.Domain.IRepository;
using Library.Domain.IServices;
using Library.Domain.Service;
using Library.Infrastructure.Repository;

namespace Library.API
{
    public static class ConfigureContainer
    {
        public static IContainer container()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<WriterService>().As<IWriterService>();
            builder.RegisterType<WriterRepository>().As<IWriterRepository>();
            return builder.Build();
        }
    }
}
