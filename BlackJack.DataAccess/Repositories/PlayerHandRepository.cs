using System;
using System.Collections.Generic;
using BlackJack.DataAccess.EF;
using BlackJack.Entities;
using BlackJack.DataAccess.Interfaces;
using System.Data.Entity;
using BlackJack.DataAccess.Repositories.BaseRepository;

namespace BlackJack.DataAccess.Repositories
{
    public class PlayerHandRepository : BaseRepository<PlayerHand>, IPlayerHandRepository
    {
        public PlayerHandRepository(DatabaseContext context)
            :base (context)
        {

        }

        public void AddRange(IEnumerable<PlayerHand> items)
        {
            _dbSet.AddRange(items);
        }
    }
}

