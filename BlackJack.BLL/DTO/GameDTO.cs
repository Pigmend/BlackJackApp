using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.BLL.DTO
{
    public class GameDTO
    {
        public int ID { get; set; }

        public int SelectedBots { get; set; }
        //Key to User
        public int UserID { get; set; }
    }
}
