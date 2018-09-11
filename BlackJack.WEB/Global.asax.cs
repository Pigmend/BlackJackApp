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
using BlackJack.BLL.Infrastructure;
using BlackJack.WEB.Util;

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

            ////Bind interfaces with <NAME>Service realisation
            //NinjectModule userModel = new UserModule();

            ////Bind EFUnitOfWork with IUnitOfWork (abstraction with interfaces)
            //NinjectModule userServiceModule = new ServiceModule("BlackJackConnection");

            ////Bind userModule to serviceModule
            //var kernel_userModel = new StandardKernel(userModel, userServiceModule);
            //DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel_userModel));


            NinjectModule databaseModel = new DatabaseModule();

            NinjectModule ServiceModule = new ServiceModule("BlackJackConnection");

            var karnel = new StandardKernel(databaseModel, ServiceModule);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(karnel));

        }
    }
}
