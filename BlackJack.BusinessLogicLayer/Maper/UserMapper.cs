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

namespace BlackJack.BusinessLogicLayer.Maper
{
    public class UserMapper
    {
        IUserRepository UserRepository { get; set; }

        public UserMapper(IUserRepository userRepository)
        {
            this.UserRepository = userRepository;
        }

        public UserViewModel MapUserToUserViewModel( User user)
        {
            UserViewModel item = new UserViewModel();
            item.ID = user.ID;
            item.Name = user.Name;
            item.Role = user.Role;

            return item;
        }

        public IEnumerable<UserViewModel> MapUserListToUserViewModelList(IEnumerable<User> users)
        {
            List<UserViewModel> items = new List<UserViewModel>();

            foreach( var user in users)
            {
                UserViewModel ViewModel = new UserViewModel();
                ViewModel.ID = user.ID;
                ViewModel.Name = user.Name;
                ViewModel.Role = user.Role;
                items.Add(ViewModel);
            }

            return items;
        }
    }
}
