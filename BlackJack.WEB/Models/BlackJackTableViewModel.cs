using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BlackJack.ViewModels;

namespace BlackJack.WEB.Models
{
    public class BlackJackTableViewModel
    {
        public UserViewModel lastUserViewModel;
        public IEnumerable<CardViewModel> cardTable;

        public BlackJackTableViewModel(UserViewModel lastUserViewModel, IEnumerable<CardViewModel> cardTable)
        {
            this.lastUserViewModel = lastUserViewModel;
            this.cardTable = cardTable;
        }
    }
}