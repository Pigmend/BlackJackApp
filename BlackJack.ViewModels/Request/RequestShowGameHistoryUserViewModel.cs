using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Entities.Enums;

namespace BlackJack.ViewModels.Request
{
    public class RequestShowGameHistoryUserViewModel
    {
        public long GameID { get; set; }
        public IEnumerable<StepShowGameHistoryUserViewItem> Steps { get; set; }
    }

    public class StepShowGameHistoryUserViewItem
    {
        public long StepID { get; set; }
        public long WinnerId { get; set; }
        public bool GameProcess { get; set; }
    }
}
