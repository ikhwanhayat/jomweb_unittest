using App.Infra;
using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace App
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            //
            // IoC setup
            //

            var builder = new ContainerBuilder();

            var connStr = ConfigurationManager.ConnectionStrings["conn1"].ConnectionString;
            builder.RegisterType<EFRepository>()
                .As<IRepository>()
                .WithParameter(new NamedParameter("connectionString", connStr))
                .InstancePerHttpRequest();
            
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            
            var container = builder.Build();

            // Tell ASP.NET MVC to use this resolver
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}