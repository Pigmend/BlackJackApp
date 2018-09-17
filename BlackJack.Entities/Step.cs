using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Entities
{
    public class Step
    {
        public int ID { get; set; }
        public int WinnerID { get; set; }
        public int GameID { get; set; }
        public virtual Game Game { get; set; }
    }
}
