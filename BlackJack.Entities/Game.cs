using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Entities
{
    public class Game
    {
        public int ID { get; set; }
        //Key to User
        public int UserID { get; set; }
        public virtual User User { get; set; }

        //Keys from Steps
        public virtual ICollection<Step> Steps { get; set; }
    }
}
