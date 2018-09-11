using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.DAL.Entities
{
    public class User
    {
        public int ID { get; set; }

        public string Name { get; set; }
        public int SelectedBots { get; set; }


        //Keys from Games
        public ICollection<Game> Games { get; set; }
    }
}
