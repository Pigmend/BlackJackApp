using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Entities
{
    public class PlayerHand
    {
        public int ID { get; set; }

        public int Score { get; set; }
        public int Cash { get; set; }
        public int CardPoints { get; set; }

        public int PlayerID { get; set; }
        public virtual User User { get; set; }

        public int StepID { get; set; }
        public virtual Step Step { get; set; }

        public virtual ICollection<Card> Cards { get; set; }
    }
}
