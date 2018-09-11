using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.DAL.Entities;

namespace BlackJack.DAL.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        IRepository<Card> cards { get; }
        IRepository<Game> games { get; }
        IRepository<PlayerHand> playerHands { get; }
        IRepository<PlayerInfo> playerInfos { get; }
        IRepository<Step> steps { get; }
        IRepository<User> users { get; }
    }
}
