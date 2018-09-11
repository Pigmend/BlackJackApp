using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Entities;
using BlackJack.ViewModels;
using BlackJack.BLL.DTO;

namespace BlackJack.BLL.Interfaces
{
    public interface IUserService
    {

        void CreateUser(UserDTO userDto);
        UserDTO GetUser(int id);
        IEnumerable<UserDTO> GetUsers();
        void DeleteUser(int id);
        UserDTO GetLastUser();
        void Dispose();
    }
}
