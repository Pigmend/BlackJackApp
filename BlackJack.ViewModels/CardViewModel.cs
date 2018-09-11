using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Entities.Enums;

namespace BlackJack.ViewModels
{
    public class CardViewModel
    {
        public int ID { get; set; }

        public int CardScore { get; set; }
        public string CardName { get; set; }
    }
}
