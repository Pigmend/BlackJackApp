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
        IUnitOfWork Database { get; set; }

        public UserMapper(IUnitOfWork unitOfWork)
        {
            this.Database = unitOfWork;
        }

        public UserViewModel MapUserToUserViewModel( User user)
        {
            var item = new UserViewModel() { ID = user.ID, Name = user.Name, Role = user.Role };

            return item;
        }

        public IEnumerable<UserViewModel> MapUserListToUserViewModelList(IEnumerable<User> users)
        {
            List<UserViewModel> items = new List<UserViewModel>();

            foreach( var user in users)
            {
                var ViewModel = new UserViewModel();
                ViewModel.ID = user.ID;
                ViewModel.Name = user.Name;
                ViewModel.Role = user.Role;
                items.Add(ViewModel);
            }
            return items;
        }
    }
}
