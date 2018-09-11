using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    class PlayerCard
    {
        public int ID { get; set; }

        public ICollection<Card> Cards { get; set; }

        public int PlayerID { get; set; }
        public PlayerInfo Player { get; set; }
    }
}
