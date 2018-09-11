using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.DAL.Entities
{
    public class Step
    {
        public int ID { get; set; }

        //Key to Game
        public int GameID { get; set; }
        public Game Game { get; set; }
    }
}
