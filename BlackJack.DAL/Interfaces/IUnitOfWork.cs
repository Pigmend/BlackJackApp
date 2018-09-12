using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Entities;

namespace BlackJack.DataAccessLayer.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {

        ICardRepository Cards { get; }
        IGameRepository Games { get; }
        IPlayerHandRepository PlayerHands { get; }
        IPlayerInfoRepository PlayerInfos { get; }
        IStepRepository Steps { get; }
        IUserRepository Users { get; }

        void Save();
    }
}
