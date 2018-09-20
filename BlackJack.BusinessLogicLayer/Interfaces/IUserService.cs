using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Entities;
using BlackJack.Entities.Enums;
using BlackJack.ViewModels.Response;
using BlackJack.ViewModels.EntityViewModel;

namespace BlackJack.BusinessLogicLayer.Interfaces
{
    public interface IUserService
    {
        int CreateUser(GameSubmitNewUser user);
        UserViewModel GetUser(int id);
        IEnumerable<UserViewModel> GetUsers();
        void DeleteUser(int id);
        UserViewModel GetLastUser();
    }
}
