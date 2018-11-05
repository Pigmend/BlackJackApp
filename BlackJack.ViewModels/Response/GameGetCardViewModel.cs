using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Entities.Enums;

namespace BlackJack.ViewModels.Response
{
    public class GameGetCardViewModel
    {
        public long CardID { get; set; }
        public CardNumber CardNumber { get; set; }
        public CardSuit CardSuit { get; set; }
        public string CardName { get; set; }

        public int CardScore { get; set; }
    }
}
