using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Entities;
using BlackJack.ViewModels.EntityViewModel;

namespace BlackJack.ViewModels.Response
{
    public class GameContinueGameViewModel
    {
        public int ID { get; set; }
        public int StepID { get; set; }
        public IEnumerable<PlayerHandViewModel> PlayerHands { get; set; }
    }
}
