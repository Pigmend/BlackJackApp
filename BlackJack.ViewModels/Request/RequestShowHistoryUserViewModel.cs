using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.ViewModels.Request
{
    public class RequestShowHistoryUserViewModel
    {
        public IEnumerable<GameShowHistoryUserViewItem> Games { get; set; }
    }

    public class GameShowHistoryUserViewItem
    {
        public long GameID { get; set; }
        public IEnumerable<StepShowHistoryUserViewItem> Steps { get; set; }
    }

    public class StepShowHistoryUserViewItem
    {
        public long StepId { get; set; }
        public long WinnerId { get; set; }
        public bool GameProcess { get; set; }
    }
}
