using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.ViewModels
{
    public class SubmitUserHomeView
    {
        public IEnumerable<UserSubmitUserHomeViewItem> Users { get; set; }

        [Required(ErrorMessage = "Enter Username")]
        [StringLength(maximumLength:15,ErrorMessage ="Incorrect username", MinimumLength = 5)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Select bots")]
        public int SelectedBots { get; set; }
    }

    public class UserSubmitUserHomeViewItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int SelectedBots { get; set; }
    }
}
