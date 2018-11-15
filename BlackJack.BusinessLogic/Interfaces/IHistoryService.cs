using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.ViewModels.Request;

namespace BlackJack.BusinessLogic.Interfaces
{
    public interface IHistoryService
    {
        RequestShowHistoryUserViewModel ShowHistory(long PlayerID);
        RequestShowGameHistoryUserViewModel ShowGameHistory(long gameID);
        RequestShowStepHistoryViewModel ShowStep(long stepID);
    }
}
