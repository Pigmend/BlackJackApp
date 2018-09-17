using System;
using System.Collections.Generic;
using BlackJack.DataAccessLayer.EF;
using BlackJack.Entities;
using BlackJack.DataAccessLayer.Interfaces;
using System.Data.Entity;

namespace BlackJack.DataAccessLayer.Repositories
{
    public class CardRepository : ICardRepository
    {
        private DatabaseContext _db;

        public CardRepository(DatabaseContext context)
        {
            this._db = context;
        }

        public void Create(Card card)
        {
            _db.Cards.Add(card);
        }

        public Card Get(int id)
        {
            return _db.Cards.Find(id);
        }

        public void Update(Card card)
        {
            _db.Entry(card).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Card card = _db.Cards.Find(id);
            if (card != null)
            {
                _db.Cards.Remove(card);
            }
        }

        public IEnumerable<Card> GetAll()
        {
            return _db.Cards;
        }

    }
}

