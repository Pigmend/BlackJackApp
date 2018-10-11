using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Entities.Enums;

namespace BlackJack.ViewModels.Request
{
    public class ShowGameHistoryUserViewModel
    {
        public long GameID { get; set; }
        public IEnumerable<StepShowGameHistoryUserViewItem> Steps { get; set; }
    }

    public class StepShowGameHistoryUserViewItem
    {
        public long StepID { get; set; }
        public IEnumerable<PlayerHandShowGameHistoryUserViewItem> Hands { get; set; }
    }

    public class PlayerHandShowGameHistoryUserViewItem
    {
        public long PlayerHandID { get; set; }

        public int Score { get; set; }
        public int Cash { get; set; }
        public int CardPoints { get; set; }

        public long PlayerID { get; set; }
        public UserShowGameHistoryUserViewItem User { get; set; }

        public IEnumerable<CardShowGameHistoryUserViewItem> HandCards { get; set; }
    }

    public class UserShowGameHistoryUserViewItem
    {
        public long UserID { get; set; }
        public string Name { get; set; }
        public UserRole Role { get; set; }
        
    }

    public class CardShowGameHistoryUserViewItem
    {
        public long CardID { get; set; }
        public string CardName { get; set; }
    }
}
