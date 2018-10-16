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
using BlackJack.ViewModels.Request;

namespace BlackJack.BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository { get; set; }
        private IGameRepository _gameRepository { get; set; } 

        public UserService(IUserRepository userRepository, IGameRepository gameRepository)
        {
            _userRepository = userRepository;
            _gameRepository = gameRepository;
        }

        public long CreateUser(UserCreateUserViewModel user)
        {
            User newUser = new User();
            newUser.Name = user.Name;
            newUser.SelectedBots = user.SelectedBots;
            newUser.Role = Entities.Enums.UserRole.Player;

            _userRepository.Create(newUser);
            _userRepository.SaveChanges();

            return newUser.ID;
        }

        public UserAllUsersViewModel AllUsers()
        {
            IEnumerable<User> users = _userRepository.GetAll();
            IEnumerable<UserAllUsersUserViewItem> userList = EntityMapper.MapUserListToUserAllUsersUserViewItemList(users);

            UserAllUsersViewModel viewModel = new UserAllUsersViewModel();
            viewModel.Users = userList;

            return viewModel;
        }

        public void DeleteUser(long id)
        {
            _userRepository.Delete(id);
            _userRepository.SaveChanges();
        }
    }
}
