using System;
using System.Linq;
using System.Collections.Generic;
using BlackJack.DataAccess.EF;
using BlackJack.Entities;
using BlackJack.DataAccess.Interfaces;
using System.Data.Entity;
using BlackJack.DataAccess.Repositories.BaseRepository;


namespace BlackJack.DataAccess.Repositories
{
    public class GameRepository : BaseRepository<Game>, IGameRepository
    {
        public GameRepository(DatabaseContext context)
            : base(context)
        {

        }

        public IEnumerable<Game> SelectGamesByUserId(long userId)
        {
            List<Game> games = _dbSet.Where(e => e.UserID == userId).ToList();

            return games;
        }
    }
}
