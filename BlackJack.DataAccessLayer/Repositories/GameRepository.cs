using System;
using System.Collections.Generic;
using BlackJack.DataAccessLayer.EF;
using BlackJack.Entities;
using BlackJack.DataAccessLayer.Interfaces;
using System.Data.Entity;
using BlackJack.DataAccessLayer.Repositories.BaseRepository;


namespace BlackJack.DataAccessLayer.Repositories
{
    public class GameRepository : BaseRepository<Game>, IGameRepository
    {
        public GameRepository(DatabaseContext context)
            : base(context)
        {

        }

        public IEnumerable<Game> SelectGamesByUserId(int userId)
        {
            List<Game> games = new List<Game>();
            foreach(Game tmpGame in _db.Games)
            {
                if(tmpGame.UserID == userId)
                {
                    games.Add(tmpGame);
                }
            }

            return games;
        }
    }
}
