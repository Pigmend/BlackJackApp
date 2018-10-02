using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using BlackJack.Entities.Enums;

namespace BlackJack.Entities
{
    public class User
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public int SelectedBots { get; set; }
        public UserRole Role { get; set; }
        public virtual ICollection<Game> Games { get; set; }
        public virtual ICollection<PlayerHand> Hands { get; set; }
    }
}
