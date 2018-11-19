using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Entities.Enums;

namespace BlackJack.ViewModels.Response
{
    public class ResponseGameProcessViewModel
    {
        public long GameID { get; set; }
        public UserGameProcessViewlItem User { get; set; }
        public IEnumerable<CardGameProcessViewItem> Cards { get; set; }
    }

    public class UserGameProcessViewlItem
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public int SelectedBots { get; set; }
        public UserRole Role { get; set; }
    }

    public class CardGameProcessViewItem
    {
        public long CardID { get; set; }
        public string CardName { get; set; }
        public CardNumber CardNumber { get; set; }
        public CardSuit CardSuit { get; set; }

        public int CardScore { get; set; }
    }
}
