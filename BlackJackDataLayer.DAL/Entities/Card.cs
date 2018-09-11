﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.DAL.Interfaces;

namespace BlackJack.DAL.Entities
{
    public class Card
    {

        public int ID { get; set; }

        public CardSuit CardSuit { get; set; }
        public CardNumber CardNumber { get; set; }
        public int CardScore { get; set; }
        public string CardName { get; set; }

        //Many-to-Many with PlayerHand
        public virtual ICollection<PlayerHand> PlayerHands { get; set; }
    }
}
