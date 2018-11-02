﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Entities
{
    public class PlayerHand
    {
        public long ID { get; set; }

        public int Score { get; set; }
        public int Cash { get; set; }
        public int CardPoints { get; set; }

        public long PlayerID { get; set; }
        public long StepID { get; set; }
    }
}
