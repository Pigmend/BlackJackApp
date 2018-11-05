using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Entities
{
    public class PlayerHand:BaseEntity
    {
        public int Score { get; set; }
        public int Cash { get; set; }
        public int CardPoints { get; set; }
        public long PlayerId { get; set; }
        public long StepId { get; set; }
    }
}
