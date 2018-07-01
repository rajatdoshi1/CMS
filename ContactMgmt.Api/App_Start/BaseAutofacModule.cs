using System.Reflection;
using Autofac;
using Autofac.Integration.WebApi;
using ContactMgmt.Api.Handlers;
using Module = Autofac.Module;

namespace ContactMgmt.Api.App_Start
{
    public class BaseAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DbHandler>().As<IDbHandler>().InstancePerLifetimeScope();
            builder.RegisterType<ContactHandler>().As<IContactHandler>().InstancePerLifetimeScope();
            builder.RegisterType<ConfigHandler>().As<IConfigHandler>().InstancePerLifetimeScope();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            base.Load(builder);
        }
    }
}