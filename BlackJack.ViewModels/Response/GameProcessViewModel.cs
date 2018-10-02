using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.ViewModels.Response
{
    public class GameProcessViewModel
    {
        public long GameID { get; set; }
        public GameProcessUserViewlItem User { get; set; }
        public IEnumerable<GameProcessCardViewItem> Cards { get; set; }
    }

    public class GameProcessUserViewlItem
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public int SelectedBots { get; set; }
    }

    public class GameProcessCardViewItem
    {
        public long CardID { get; set; }
        public string CardName { get; set; }
        public long CardScore { get; set; }
    }
}
