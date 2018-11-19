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
using BlackJack.ViewModels;
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

        public long CreateUser(SubmitUserHomeView user)
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

        public AllUsersUserView AllUsers()
        {
            AllUsersUserView viewModel = new AllUsersUserView();
            IEnumerable<User> users = _userRepository.GetAll();

            List<UserAllUsersUserViewItem> players = new List<UserAllUsersUserViewItem>();
            foreach(User item in users)
            {
                if(item.Role == UserRole.Player)
                {
                    UserAllUsersUserViewItem player = EntityMapper.MapUserToUserAllUsersUserViewItem(item);
                    players.Add(player);
                }
            }

            viewModel.Users = players;

            return viewModel;
        }

        public void DeleteUser(long id)
        {
            _userRepository.Delete(id);
        }

        public SubmitUserHomeView Submit()
        {
            SubmitUserHomeView viewModel = new SubmitUserHomeView();
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
