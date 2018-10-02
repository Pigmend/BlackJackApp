using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.ViewModels.Response
{
    public class UserAllUsersViewModel
    {
        public IEnumerable<UserAllUsersUserViewItem> Users { get; set; }
    }

    public class UserAllUsersUserViewItem
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public int SelectedBots { get; set; }
    }
}
