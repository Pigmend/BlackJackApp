using System;
using System.Collections.Generic;
using BlackJack.DAL.EF;
using BlackJack.Entities;
using BlackJack.DAL.Interfaces;
using System.Data.Entity;


namespace BlackJack.DAL.Repositories
{
    public class GameRepository :IGameRepository
    {
        private DatabaseContext db;

        public GameRepository(DatabaseContext context)
        {
            this.db = context;
        }

        public void Create(Game game)
        {
            db.games.Add(game);
        }

        public Game Get(int id)
        {
            return db.games.Find(id);
        }

        public void Update(Game game)
        {
            db.Entry(game).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Game game = db.games.Find(id);
            if (game != null)
            {
                db.games.Remove(game);
            }
        }

        public IEnumerable<Game> GetAll()
        {
            return db.games;
        }

        public IEnumerable<Game> SelectGamesByUserId(int userId)
        {

            List<Game> games = new List<Game>();
            foreach(Game tmpGame in db.games)
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
