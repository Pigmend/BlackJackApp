using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Entities;
using BlackJack.Entities.Enums;
using BlackJack.ViewModels.Response;
using BlackJack.ViewModels.Request;

namespace BlackJack.BusinessLogic.Interfaces
{
    public interface IUserService
    {
        long CreateUser(UserCreateUserViewModel user);
        UserAllUsersViewModel GetUsers();
        void DeleteUser(long id);
        ShowHistoryUserViewModel ShowHistory(long PlayerID);
    }
}
