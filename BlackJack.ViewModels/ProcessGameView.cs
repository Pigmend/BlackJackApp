using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Entities.Enums;

namespace BlackJack.ViewModels
{
    public class ProcessGameView
    {
        public ProcessGameView()
        {
            Players = new List<UserGameProcessViewlItem>();
        }

        public long GameID { get; set; }
        public long WinnerID { get; set; }
        public bool GameProcess { get; set; }
        public List<UserGameProcessViewlItem> Players { get; set; }
    }

    public class UserGameProcessViewlItem
    {
        public UserGameProcessViewlItem()
        {
            PlayerCards = new List<CardGameProcessViewItem>();
        }

        public long ID { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
        public int CardPoints { get; set; }
        public int Cash { get; set; }
        public bool IsPlayed { get; set; }
        public UserRole Role { get; set; }
        public List<CardGameProcessViewItem> PlayerCards { get; set; }
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
