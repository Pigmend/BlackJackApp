using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    class PlayerInfo
    {
        public int ID { get; set; }
        public int Score { get; set; }

        //Foreign Key to Step
        public int StepID { get; set; }
        public Step Step { get; set; }

        //Keys from PlayerCards
        public ICollection<PlayerCard> PlayerCards { get; set; }
    }
}
