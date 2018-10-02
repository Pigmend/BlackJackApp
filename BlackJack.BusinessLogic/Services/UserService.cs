using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Entities;
using BlackJack.BusinessLogic.Infrastructure;
using BlackJack.BusinessLogic.Interfaces;
using BlackJack.DataAccess.Interfaces;
using BlackJack.BusinessLogic.Maper;
using BlackJack.ViewModels.Response;

namespace BlackJack.BusinessLogic.Services
{
    public class UserService: IUserService
    {
        IUserRepository UserRepository { get; set; }

        public UserService(IUserRepository userRepository)
        {
            UserRepository = userRepository;
        }

        public long CreateUser(UserCreateUserViewModel user)
        {
            User newUser = new User();
            newUser.Name = user.Name;
            newUser.SelectedBots = user.SelectedBots;
            newUser.Role = Entities.Enums.UserRole.Player;

            UserRepository.Create(newUser);
            UserRepository.SaveChanges();

            return newUser.ID;
        }

        public UserAllUsersViewModel GetUsers()
        {
            IEnumerable<User> users = UserRepository.GetAll();
            IEnumerable<UserAllUsersUserViewItem> userList = EntityMapper.MapUserListToUserAllUsersUserViewItemList(users);

            UserAllUsersViewModel viewModel = new UserAllUsersViewModel();
            viewModel.Users = userList;

            return viewModel;
        }

        public void DeleteUser(long id)
        {
            UserRepository.Delete(id);
            UserRepository.SaveChanges();
        }
    }
}
