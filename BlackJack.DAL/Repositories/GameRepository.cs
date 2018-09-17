using System;
using System.Collections.Generic;
using BlackJack.DataAccessLayer.EF;
using BlackJack.Entities;
using BlackJack.DataAccessLayer.Interfaces;
using System.Data.Entity;


namespace BlackJack.DataAccessLayer.Repositories
{
    public class GameRepository :IGameRepository
    {
        private DatabaseContext _db;

        public GameRepository(DatabaseContext context)
        {
            this._db = context;
        }

        public void Create(Game game)
        {
            _db.Games.Add(game);
        }

        public Game Get(int id)
        {
            return _db.Games.Find(id);
        }

        public void Update(Game game)
        {
            _db.Entry(game).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Game game = _db.Games.Find(id);
            if (game != null)
            {
                _db.Games.Remove(game);
            }
        }

        public IEnumerable<Game> GetAll()
        {
            return _db.Games;
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
