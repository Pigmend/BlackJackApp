using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using Ninject.Modules;
using BlackJack.BLL.Interfaces;
using BlackJack.BLL.Services;

namespace BlackJack.WEB.Util
{
    public class DatabaseModule: NinjectModule
    {
        public override void Load()
        {
            Bind<ICardService>().To<CardService>();
            Bind<IUserService>().To<UserService>();
        }
    }
}