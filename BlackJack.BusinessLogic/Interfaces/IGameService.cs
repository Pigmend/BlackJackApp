using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.ViewModels.Game;
using BlackJack.ViewModels.Response;

namespace BlackJack.BusinessLogic.Interfaces
{
    public interface IGameService
    {
        GameProcessViewModel GetGameData(long UserID);

    }
}
