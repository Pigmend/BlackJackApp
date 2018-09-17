using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.ViewModels.Game;

namespace BlackJack.BusinessLogicLayer.Interfaces
{
    public interface IGameService
    {
        GameDataViewModel GetDataForGame();
    }
}
