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
        public int PlayerInfoID { get; set; }
        public PlayerInfo PlayerInfo { get; set; }

        
        //Many-to-many with Cards
        public virtual ICollection<Card> Cards { get; set; }
    }
}
