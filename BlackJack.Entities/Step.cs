using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Entities
{
    public class Step
    {
        public long ID { get; set; }
        public long WinnerID { get; set; }
        public long GameID { get; set; }
        public virtual Game Game { get; set; }
        public virtual ICollection<PlayerHand> PlayerHands { get; set; }
    }
}
