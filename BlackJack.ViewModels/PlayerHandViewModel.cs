using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.ViewModels
{
    public class PlayerHandViewModel
    {
        public int ID { get; set; }

        //FK to PlayerInfo
        public int PlayerID { get; set; }
    }
}
