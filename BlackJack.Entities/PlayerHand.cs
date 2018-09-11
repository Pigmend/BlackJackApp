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

        //FK to PlayerInfo
        public int PlayerID { get; set; }
        public PlayerInfo Player { get; set; }
        
        //Many-to-manywith Cards
        public virtual ICollection<Card> Cards { get; set; }
    }
}
