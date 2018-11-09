using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Entities;

namespace BlackJack.DataAccess.Interfaces
{
    public interface IUserRepository: IRepository<User>
    {
        bool Exists(User user);
        User Get(string Name);
    }
}
