using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Entities;


namespace BlackJack.ViewModels
{
    public class GameDataViewModel
    {
        public UserViewModel lastSignedUser { get; set; }
        public IEnumerable<UserViewModel> users { get; set; }
        public IEnumerable<CardViewModel> cards { get; set; }

        public GameDataViewModel(UserViewModel lastSignedUser, IEnumerable<UserViewModel> users, IEnumerable<CardViewModel> cards)
        {
            this.lastSignedUser = lastSignedUser;
            this.users = users;
            this.cards = cards;
        }
    }
}
