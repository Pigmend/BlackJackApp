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
        ShowHistoryUserViewModel ShowHistory(long PlayerID);
        ShowGameHistoryUserViewModel ShowGameHistory(long gameID);
        ShowStepHistoryViewModel ShowStep(long stepID);
    }
}
