using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Entities;
using BlackJack.ViewModels.EntityViewModel;


namespace BlackJack.ViewModels.Game
{
    public class GameDataViewModel
    {
        public GameViewModel Game { get; set; }
        public UserViewModel CurrentUser { get; set; }
        public IEnumerable<UserViewModel> Users { get; set; }
        public IEnumerable<CardViewModel> Cards { get; set; }

        public GameDataViewModel()
        {

        }

        public GameDataViewModel(UserViewModel currentUser, IEnumerable<UserViewModel> users, IEnumerable<CardViewModel> cards)
        {
            this.CurrentUser = currentUser;
            this.Users = users;
            this.Cards = cards;
        }
    }
}
