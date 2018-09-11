using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Entities.Enums;

namespace BlackJack.BLL.DTO
{
    public class CardDTO
    {
        public int ID { get; set; }

        public CardSuit CardSuit { get; set; }
        public CardNumber CardNumber { get; set; }
        public int CardScore { get; set; }
        public string CardName { get; set; }

    }
}
