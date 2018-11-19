using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.ViewModels
{
    public class ShowStepHistoryView
    {
        public long StepID { get; set; }

        public IEnumerable<PlayerHandShowStepHistoryViewItem> PlayerHands { get; set; }
    }

    public class PlayerHandShowStepHistoryViewItem
    {
        public long PlayerHandID { get; set; }
        public long PlayerID { get; set; }
        public int Score { get; set; }
        public int Cash { get; set; }
        public int CardPoints { get; set; }
        public string PlayerName { get; set; }

        public IEnumerable<CardPlayerHandShowStepHistoryViewItem> Cards { get;set; }
    }

    public class CardPlayerHandShowStepHistoryViewItem
    {
        public long CardID { get; set; }
        public string CardName { get; set; }
    }


}
