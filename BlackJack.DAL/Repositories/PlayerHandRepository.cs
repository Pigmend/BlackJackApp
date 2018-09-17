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
        private DatabaseContext _db;

        public PlayerHandRepository(DatabaseContext context)
        {
            this._db = context;
        }

        public void Create(PlayerHand playerHand)
        {
            _db.PlayerHands.Add(playerHand);
        }

        public PlayerHand Get(int id)
        {
            return _db.PlayerHands.Find(id);
        }

        public void Update(PlayerHand playerHand)
        {
            _db.Entry(playerHand).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            PlayerHand playerHand = _db.PlayerHands.Find(id);
            if (playerHand != null)
            {
                _db.PlayerHands.Remove(playerHand);
            }
        }

        public IEnumerable<PlayerHand> GetAll()
        {
            return _db.PlayerHands;
        }

    }
}

