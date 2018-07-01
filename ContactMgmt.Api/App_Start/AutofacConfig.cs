using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;

namespace ContactMgmt.Api.App_Start
{
    public class AutofacConfig
    {
        public static AutofacWebApiDependencyResolver ApiDependencyResolver { get; private set; }
        public static IContainer Container { get; set; }
        public static void Register(HttpConfiguration config)
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new BaseAutofacModule());
            Container = builder.Build();
            ApiDependencyResolver = new AutofacWebApiDependencyResolver(Container);
            config.DependencyResolver = ApiDependencyResolver;
        }
    }
}