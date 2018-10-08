using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.ViewModels.Response;
using BlackJack.ViewModels.Request;

namespace BlackJack.BusinessLogic.Interfaces
{
    public interface IGameService
    {
        GameProcessViewModel GetGameData(long UserID);
        bool SaveChanges(SaveChangesGameViewModel model);
    }
}
