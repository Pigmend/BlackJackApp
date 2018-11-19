using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.DataAccess.Interfaces
{
    public interface IPlayerHandCardRepository
    {
        void BindPlayerHandWithPlayerHandCard(long PlayerHandID, long CardID);
    }
}
