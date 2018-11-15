using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Entities.Enums;

namespace BlackJack.ViewModels.Request
{
    public class RequestSaveChangesGameViewModel
    {
        public long GameID { get; set; }
        public long WinnerID { get; set; }
        public long GameProcess { get; set; }
        public IEnumerable<PlayerSaveChangesGameViewItem> Users { get; set; }

    }

    public class PlayerSaveChangesGameViewItem
    {
        public long PlayerID { get; set; }
        public string Name { get; set; }
        public int Role { get; set; }

        public int Score { get; set; }
        public int Cash { get; set; }
        public int CardPoints { get; set; }

        public IEnumerable<CardSaveChangesGameViewItem> Cards { get; set; }
    }
    public class CardSaveChangesGameViewItem
    {
        public long CardID { get; set; }
        public CardNumber CardNumber { get; set; }
        public CardSuit CardSuit { get; set; }
        public string CardName { get; set; }

        public int CardScore { get; set; }
    }

}
