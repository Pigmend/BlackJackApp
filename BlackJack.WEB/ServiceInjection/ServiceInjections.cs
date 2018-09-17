using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using Ninject.Modules;
using BlackJack.BusinessLogicLayer.Interfaces;
using BlackJack.BusinessLogicLayer.Services;

namespace BlackJack.WEB.ServiceInjection
{
    public class ServiceInjections: NinjectModule
    {
        public override void Load()
        {
            Bind<ICardService>().To<CardService>();
            Bind<IUserService>().To<UserService>();
            Bind<IGameService>().To<GameService>();
        }
    }
}