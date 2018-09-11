using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.DAL.Entities
{
    public class Game
    {
        public int ID { get; set; }
        
        //Key to User
        public int UserID { get; set; }
        public User User { get; set; }
        
        //Keys from Steps
        public ICollection<Step> Steps { get; set; }
    }
}
