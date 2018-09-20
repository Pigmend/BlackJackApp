using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.ViewModels.Game;
using BlackJack.ViewModels.Response;

namespace BlackJack.BusinessLogicLayer.Interfaces
{
    public interface IGameService
    {
        GameDataViewModel GetDataForGame(int id);
    }
}
