using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Threading.Tasks;
using BlackJack.DataAccess;
using BlackJack.DataAccess.EF;
using BlackJack.DataAccess.Interfaces;
using BlackJack.DataAccess.Repositories;
using BlackJack.BusinessLogic.Interfaces;
using BlackJack.BusinessLogic.Services;
using System.ComponentModel.DataAnnotations;
using Autofac;
using Autofac.Core;
using Autofac.Util;
using Autofac.Builder;
using Autofac.Integration.Mvc;
using System.Reflection;

namespace BlackJack.Ijections.Setup
{
    public static class AutofacConfig
    {
        public static void Register(ContainerBuilder builder, string conectionString)
        {

            //Bind Repositories
            builder.RegisterType<DeckRepository>().As<IDeckRepository>().WithParameter("connection", conectionString);
            builder.RegisterType<CardRepository>().As<ICardRepository>().WithParameter("connection", conectionString);
            builder.RegisterType<GameRepository>().As<IGameRepository>().WithParameter("connection", conectionString);
            builder.RegisterType<PlayerHandRepository>().As<IPlayerHandRepository>().WithParameter("connection", conectionString);
            builder.RegisterType<StepRepository>().As<IStepRepository>().WithParameter("connection", conectionString);
            builder.RegisterType<UserRepository>().As<IUserRepository>().WithParameter("connection", conectionString);

            //Bind Services
            builder.RegisterType<DeckService>().As<IDeckService>().UsingConstructor(typeof(IDeckRepository));

            builder.RegisterType<GameService>().As<IGameService>().UsingConstructor(typeof(IUserRepository),
                                                                                    typeof(IDeckRepository),
                                                                                    typeof(IGameRepository),
                                                                                    typeof(IStepRepository),
                                                                                    typeof(IPlayerHandRepository));

            builder.RegisterType<UserService>().As<IUserService>().UsingConstructor(typeof(IUserRepository),
                                                                                    typeof(IGameRepository));

            builder.RegisterType<HistoryService>().As<IHistoryService>().UsingConstructor(typeof(IUserRepository),
                                                                                            typeof(ICardRepository),
                                                                                            typeof(IGameRepository),
                                                                                            typeof(IStepRepository),
                                                                                            typeof(IPlayerHandRepository));

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
