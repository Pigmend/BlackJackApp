using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Entities.Enums;

namespace BlackJack.ViewModels
{
    public class RequestProcessGameView
    {
        public RequestProcessGameView()
        {
            Players = new List<UserRequestGameProcessViewlItem>();
        }

        public long GameID { get; set; }
        public long WinnerID { get; set; }
        public bool GameProcess { get; set; }
        public List<UserRequestGameProcessViewlItem> Players { get; set; }
    }

    public class UserRequestGameProcessViewlItem
    {
        public UserRequestGameProcessViewlItem()
        {
            PlayerCards = new List<CardRequestGameProcessViewItem>();
        }

        public long ID { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
        public int CardPoints { get; set; }
        public int Cash { get; set; }
        public bool IsPlayed { get; set; }
        public UserRole Role { get; set; }
        public List<CardRequestGameProcessViewItem> PlayerCards { get; set; }
    }

    public class CardRequestGameProcessViewItem
    {
        public long CardID { get; set; }
        public string CardName { get; set; }
        public CardNumber CardNumber { get; set; }
        public CardSuit CardSuit { get; set; }

        public int CardScore { get; set; }
    }
}
