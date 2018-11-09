using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.ViewModels.Response
{
    public class SubmitUserHomeViewModel
    {
        public IEnumerable<UsersSubmitUserHomeViewItem> Users { get; set; }
        public string Name { get; set; }
        public int SelectedBots { get; set; }
    }

    public class UsersSubmitUserHomeViewItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int SelectedBots { get; set; }
    }
}
