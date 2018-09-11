using System;
using System.Collections.Generic;
using BlackJack.DAL.EF;
using BlackJack.Entities;
using BlackJack.DAL.Interfaces;
using System.Data.Entity;

namespace BlackJack.DAL.Repositories
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
            db.playerHands.Add(playerHand);
        }

        public PlayerHand Get(int id)
        {
            return db.playerHands.Find(id);
        }

        public void Update(PlayerHand playerHand)
        {
            db.Entry(playerHand).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            PlayerHand playerHand = db.playerHands.Find(id);
            if (playerHand != null)
            {
                db.playerHands.Remove(playerHand);
            }
        }

        public IEnumerable<PlayerHand> GetAll()
        {
            return db.playerHands;
        }

    }
}

