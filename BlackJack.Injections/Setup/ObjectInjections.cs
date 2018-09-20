using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Ninject.Modules;
using BlackJack.DataAccessLayer;
using BlackJack.DataAccessLayer.EF;
using BlackJack.DataAccessLayer.Interfaces;
using BlackJack.DataAccessLayer.Repositories;
using BlackJack.BusinessLogicLayer.Interfaces;
using BlackJack.BusinessLogicLayer.Services;
using Ninject.Web.Common;

namespace BlackJack.Ijections.Setup
{
    public class ObjectInjections: NinjectModule
    {
        private string _connectionString;

        public ObjectInjections(string conectionString)
        {
            this._connectionString = conectionString;
        }

        public override void Load()
        {
            //Bind Context with SingletonScope
            Bind<DatabaseContext>().ToSelf().InRequestScope().WithConstructorArgument(_connectionString);

            //Bind Repositories 
            Bind<ICardRepository>().To<CardRepository>();
            Bind<IGameRepository>().To<GameRepository>();
            Bind<IPlayerHandRepository>().To<PlayerHandRepository>();
            Bind<IStepRepository>().To<StepRepository>();
            Bind<IUserRepository>().To<UserRepository>();

            //Bind Services
            Bind<ICardService>().To<CardService>();
            Bind<IGameService>().To<GameService>();
            Bind<IUserService>().To<UserService>();
        }
    }
}
