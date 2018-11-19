using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.ViewModels;

namespace BlackJack.BusinessLogic.Interfaces
{
    public interface IHistoryService
    {
        ShowHistoryUserView ShowHistory(long PlayerID);
        ShowGameHistoryUserView ShowGameHistory(long gameID);
        ShowStepHistoryView ShowStep(long stepID);
    }
}
