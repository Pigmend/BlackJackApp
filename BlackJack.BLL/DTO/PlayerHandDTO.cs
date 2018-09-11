using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.BLL.DTO
{
    public class PlayerHandDTO
    {
        public int ID { get; set; }

        //FK to PlayerInfo
        public int PlayerID { get; set; }
    }
}
