using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Entities
{
    public class PlayerInfo
    {
        public int ID { get; set; }

        public string Name { get; set; }
        public int Score { get; set; }
        public int Cash { get; set; }
        public int CardPoints { get; set; }

        //Foreign Key to Step
        public int StepID { get; set; }
        public Step Step { get; set; }

        //Keys from PlayerCards
        public ICollection<PlayerHand> PlayerHand { get; set; }
    }
}
