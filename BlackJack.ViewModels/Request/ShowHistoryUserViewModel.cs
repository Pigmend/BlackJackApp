using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.ViewModels.Request
{
    public class ShowHistoryUserViewModel
    {
        public IEnumerable<GameShowHistoryUserViewItem> Games { get; set; }
    }

    public class GameShowHistoryUserViewItem
    {
        public long GameID { get; set; }
        public int StepsPlayed { get; set; }
    }
}
