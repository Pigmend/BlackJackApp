using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BlackJack.ViewModels.Response
{
    public class UserCreateUserViewModel
    {
        [Required(ErrorMessage = "Enter Username")]
        [StringLength(15, ErrorMessage = "Incorrect, plaese check Username length", MinimumLength = 5)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Select number of Bots")]
        public int SelectedBots { get; set; }
    }
}
