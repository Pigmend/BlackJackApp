using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.ViewModels;

namespace BlackJack.BusinessLogic.Interfaces
{
    public interface IGameService
    {
        ProcessGameView GetGameData(long UserID);
        bool SaveChanges(SaveChangesGameView model);
        GetCardGameView GetCard();
    }
}
