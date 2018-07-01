using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Http;
using ContactMgmt.Api.App_Start;
using AutoMapper;

namespace ContactMgmt.Api
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            GlobalConfiguration.Configure(AutofacConfig.Register);
            Mapper.Initialize(c => c.AddProfile<AutoMapperMappingProfile>());
        }
    }
}