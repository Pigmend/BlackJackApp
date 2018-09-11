using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    class Step
    {
        public int ID { get; set; }

        //Foreign key to Game
        public int GameID { get; set; }
        public Game Game { get; set; }
    }
}
