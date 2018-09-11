using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject.Modules;
using BlackJack.BLL.Interfaces;
using BlackJack.BLL.Services;

namespace BlackJack.WEB.Util
{
    public class UserModule: NinjectModule
    {
        public override void Load()
        {
            Bind<IUserService>().To<UserService>();
        }
    }
}