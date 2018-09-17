using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using BlackJack.DataAccessLayer.Interfaces;
using BlackJack.DataAccessLayer.Repositories;

namespace BlackJack.BusinessLogicLayer.Infrastructure
{
    public class UnitOfWorkInjection : NinjectModule
    {
        private string connectionString;

        public UnitOfWorkInjection(string connection)
        {
            connectionString = connection;
        }
        public override void Load()
        {
            Bind<IUnitOfWork>().To<EFUnitOfWork>().WithConstructorArgument(connectionString);
        }
    }
}
