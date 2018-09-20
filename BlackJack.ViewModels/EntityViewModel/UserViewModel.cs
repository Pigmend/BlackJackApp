using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using BlackJack.Entities.Enums;

namespace BlackJack.ViewModels.EntityViewModel
{
    public class UserViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public NumberOfBots SelectedBots { get; set; }
        public UserRole Role { get; set; }
    }
}
