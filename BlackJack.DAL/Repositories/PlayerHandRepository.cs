using System;
using System.Collections.Generic;
using BlackJack.DataAccessLayer.EF;
using BlackJack.Entities;
using BlackJack.DataAccessLayer.Interfaces;
using System.Data.Entity;

namespace BlackJack.DataAccessLayer.Repositories
{
    public class PlayerHandRepository : IPlayerHandRepository
    {
        private DatabaseContext db;

        public PlayerHandRepository(DatabaseContext context)
        {
            this.db = context;
        }

        public void Create(PlayerHand playerHand)
        {
            db.PlayerHands.Add(playerHand);
        }

        public PlayerHand Get(int id)
        {
            return db.PlayerHands.Find(id);
        }

        public void Update(PlayerHand playerHand)
        {
            db.Entry(playerHand).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            PlayerHand playerHand = db.PlayerHands.Find(id);
            if (playerHand != null)
            {
                db.PlayerHands.Remove(playerHand);
            }
        }

        public IEnumerable<PlayerHand> GetAll()
        {
            return db.PlayerHands;
        }

    }
}

