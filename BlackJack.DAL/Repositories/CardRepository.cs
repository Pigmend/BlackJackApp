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
        private DatabaseContext db;

        public CardRepository(DatabaseContext context)
        {
            this.db = context;
        }

        public void Create(Card card)
        {
            db.Cards.Add(card);
        }

        public Card Get(int id)
        {
            return db.Cards.Find(id);
        }

        public void Update(Card card)
        {
            db.Entry(card).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Card card = db.Cards.Find(id);
            if (card != null)
            {
                db.Cards.Remove(card);
            }
        }

        public IEnumerable<Card> GetAll()
        {
            return db.Cards;
        }

    }
}

