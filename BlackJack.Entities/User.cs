using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using BlackJack.Entities.Enums;

namespace BlackJack.Entities
{
    public class User:BaseEntity
    {
        public string Name { get; set; }
        public int SelectedBots { get; set; }
        public UserRole Role { get; set; }
    }
}
