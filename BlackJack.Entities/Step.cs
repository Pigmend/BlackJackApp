using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Entities
{
    public class Step:BaseEntity
    { 
        public long WinnerId { get; set; }
        public long GameId { get; set; }
    }
}
