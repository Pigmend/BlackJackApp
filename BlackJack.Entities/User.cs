using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BlackJack.Entities
{
    public class User
    {
        public int ID { get; set; }

        public string Name { get; set; }


        //Keys from Games
        public ICollection<Game> Games { get; set; }
    }
}
