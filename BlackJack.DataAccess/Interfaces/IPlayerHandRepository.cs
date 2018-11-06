﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Entities;

namespace BlackJack.DataAccess.Interfaces
{
    public interface IPlayerHandRepository: IRepository<PlayerHand>
    {
        void AddRange(IEnumerable<PlayerHand> items);
        IEnumerable<PlayerHand> GetHandsByStepID(long StepID);
        void JoinCardWithHand(long PlayerHandID, long CardID);
    }
}
