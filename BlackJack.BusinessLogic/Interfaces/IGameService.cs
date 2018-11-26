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
        ResponseProcessGameView GetGameData(long UserID);
        ResponseProcessGameView StartGame(RequestProcessGameView model);
        ResponseProcessGameView Step(RequestProcessGameView model);
        ResponseProcessGameView EndGame(RequestProcessGameView model);
    }
}
