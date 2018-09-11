using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Entities;

namespace DataLayer.Entities
{
    class Card
    {
        public int ID { get; set; }
        public CardSuit CardSuit { get; set; }
        public CardNumber CardNumber { get; set; }
        public int CardScore { get; set; }
        public string CardName { get; set; }
    }
}
