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
using BlackJack.Entities.Enums;

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

        public long CreateUser(ResponseSubmitUserHomeViewModel user)
        {
            User newUser = new User();
            newUser.Name = user.Name;
            newUser.SelectedBots = user.SelectedBots;
            newUser.Role = Entities.Enums.UserRole.Player;

            long userID = 0;
            //Exists
            if (_userRepository.Exists(newUser))
            {
                User existedUser = _userRepository.Get(newUser.Name);
                existedUser.SelectedBots = user.SelectedBots;
                _userRepository.Update(existedUser);
                userID = existedUser.Id;
            }
            //Not exists
            if (!_userRepository.Exists(newUser))
            {
                userID = _userRepository.CreateAndReturnId(newUser);
            }
            return userID;
        }

        public ResponseUserAllUsersViewModel AllUsers()
        {
            IEnumerable<User> users = _userRepository.GetAll();
            IEnumerable<UserAllUsersUserViewItem> userList = EntityMapper.MapUserListToUserAllUsersUserViewItemList(users);

            ResponseUserAllUsersViewModel viewModel = new ResponseUserAllUsersViewModel();
            viewModel.Users = userList;

            return viewModel;
        }

        public void DeleteUser(long id)
        {
            _userRepository.Delete(id);
        }

        public ResponseSubmitUserHomeViewModel Index()
        {
            ResponseSubmitUserHomeViewModel viewModel = new ResponseSubmitUserHomeViewModel();
            IEnumerable<User> employees = _userRepository.GetAll();

            List<User> employeesList = new List<User>();
            foreach(User item in employees)
            {
                if(item.Role == UserRole.Player)
                {
                    employeesList.Add(item);
                }
            }
            viewModel.Users = EntityMapper.MapUserListToUserSubmitUserHomeViewItemList(employeesList);
            return viewModel;
        }
    }
}
