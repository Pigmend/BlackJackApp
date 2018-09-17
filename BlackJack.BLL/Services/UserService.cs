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

namespace BlackJack.BusinessLogicLayer.Services
{
    public class UserService: IUserService
    {
        IUnitOfWork Database { get; set; }

        public UserService(IUnitOfWork unitOfWork)
        {
            Database = unitOfWork;
        }

        public void CreateUser(UserViewModel user)
        {
            Database.Users.Create(new User() {Name = user.Name, Role = Entities.Enums.UserRole.Player});
        }

        public UserViewModel GetUser(int id)
        {
            User user = Database.Users.Get(id);
            UserViewModel item = new UserViewModel() { ID = user.ID, Name = user.Name };

            return item;
        }

        public IEnumerable<UserViewModel> GetUsers()
        {
            List<UserViewModel> users = new List<UserViewModel>();

            

            return users;
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public void DeleteUser(int id)
        {
            Database.Users.Delete(id);
            Database.Save();
        }

        public UserViewModel GetLastUser()
        {
            User user = Database.Users.ReturnLastUser();

            UserViewModel lastUser = new UserViewModel() { ID = user.ID, Name = user.Name };

            return lastUser;
        }
    }
}
