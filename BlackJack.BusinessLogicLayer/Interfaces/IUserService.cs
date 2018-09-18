using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Entities;
using BlackJack.ViewModels.EntityViewModel;

namespace BlackJack.BusinessLogicLayer.Interfaces
{
    public interface IUserService
    {
        void CreateUser(UserViewModel userDto);
        UserViewModel GetUser(int id);
        IEnumerable<UserViewModel> GetUsers();
        void DeleteUser(int id);
        UserViewModel GetLastUser();
    }
}
