using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Ninject.Modules;
using BlackJack.DataAccess;
using BlackJack.DataAccess.EF;
using BlackJack.DataAccess.Interfaces;
using BlackJack.DataAccess.Repositories;
using BlackJack.BusinessLogic.Interfaces;
using BlackJack.BusinessLogic.Services;
using Ninject.Web.Common;
using System.ComponentModel.DataAnnotations;

namespace BlackJack.Ijections.Setup
{
    public class ObjectInjections: NinjectModule
    {
        private string _connectionString;

        public ObjectInjections(string conectionString)
        {
            _connectionString = conectionString;
        }

        public override void Load()
        {
            //Bind Context with SingletonScope
            Bind<DatabaseContext>().ToSelf().InRequestScope().WithConstructorArgument(_connectionString);

            //Bind Repositories 
            Bind<IDeckRepository>().To<DeckRepository>();
            Bind<ICardRepository>().To<CardRepository>();
            Bind<IGameRepository>().To<GameRepository>();
            Bind<IPlayerHandRepository>().To<PlayerHandRepository>();
            Bind<IStepRepository>().To<StepRepository>();
            Bind<IUserRepository>().To<UserRepository>();

            //Bind Services
            Bind<IDeckService>().To<DeckService>();
            Bind<IGameService>().To<GameService>();
            Bind<IUserService>().To<UserService>();
            Bind<IHistoryService>().To<HistoryService>();
        }
    }
}
