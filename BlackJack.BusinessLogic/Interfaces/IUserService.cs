using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Entities;
using BlackJack.Entities.Enums;
using BlackJack.ViewModels;

namespace BlackJack.BusinessLogic.Interfaces
{
    public interface IUserService
    {
        long CreateUser(SubmitUserHomeView user);
        AllUsersUserView AllUsers();
        void DeleteUser(long id);
        SubmitUserHomeView Submit();
    }
}
