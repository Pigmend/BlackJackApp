using System;
using System.Collections.Generic;
using BlackJack.DataAccessLayer.EF;
using BlackJack.Entities;
using BlackJack.DataAccessLayer.Interfaces;
using System.Data.Entity;
using BlackJack.DataAccessLayer.Repositories.BaseRepository;

namespace BlackJack.DataAccessLayer.Repositories
{
    public class PlayerHandRepository : BaseRepository<PlayerHand>, IPlayerHandRepository
    {
        public PlayerHandRepository(DatabaseContext context)
            :base (context)
        {

        }
    }
}

