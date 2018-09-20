using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Entities;
using BlackJack.BusinessLogicLayer.Infrastructure;
using BlackJack.BusinessLogicLayer.Interfaces;
using BlackJack.DataAccessLayer.Interfaces;
using BlackJack.ViewModels.EntityViewModel;
using BlackJack.BusinessLogicLayer.Maper;
using BlackJack.ViewModels.Response;

namespace BlackJack.BusinessLogicLayer.Services
{
    public class UserService: IUserService
    {
        IUserRepository UserRepository { get; set; }
        UserMapper Mapper { get; set; }

        public UserService(IUserRepository userRepository, UserMapper mapper)
        {
            this.UserRepository = userRepository;
            this.Mapper = mapper;
        }

        public int CreateUser(GameSubmitNewUser User)
        {
            User user = new User();
            user.Name = User.Name;
            user.SelectedBots = User.SelectedBots;
            user.Role = Entities.Enums.UserRole.Player;

            UserRepository.Create(user);
            UserRepository.SaveChanges();

            return user.ID;
        }

        public UserViewModel GetUser(int id)
        {
            User user = UserRepository.Get(id);
            UserViewModel item = new UserViewModel() { ID = user.ID, Name = user.Name };

            return item;
        }

        public IEnumerable<UserViewModel> GetUsers()
        {
            IEnumerable<User> users = UserRepository.GetAll();
            IEnumerable<UserViewModel> items = Mapper.MapUserListToUserViewModelList(users);

            return items;
        }

        public void DeleteUser(int id)
        {
            UserRepository.Delete(id);
            UserRepository.SaveChanges();
        }

        public UserViewModel GetLastUser()
        {
            User user = UserRepository.ReturnLastUser();

            UserViewModel lastUser = new UserViewModel() { ID = user.ID, Name = user.Name };

            return lastUser;
        }
    }
}
