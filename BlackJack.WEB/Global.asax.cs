using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;
using BlackJack.BusinessLogicLayer.Infrastructure;
using BlackJack.Ijections.Setup;

namespace BlackJack.WEB
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //NinjectModule databaseModel = new ServiceInjections();
            //NinjectModule ServiceModule = new UnitOfWorkInjection("BlackJackConnection");

            //var karnel = new StandardKernel(databaseModel, ServiceModule);
            //DependencyResolver.SetResolver(new NinjectDependencyResolver(karnel));


            NinjectModule injectionModule = new ObjectInjections("BlackJackConnection");
            var karnel = new StandardKernel(injectionModule);
            karnel.Unbind<StandardKernel>();
            DependencyResolver.SetResolver(new NinjectDependencyResolver(karnel));
            

        }
    }
}
