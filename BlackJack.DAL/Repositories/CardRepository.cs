using System;
using System.Collections.Generic;
using BlackJack.DAL.EF;
using BlackJack.Entities;
using BlackJack.DAL.Interfaces;
using System.Data.Entity;

namespace BlackJack.DAL.Repositories
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
            db.cards.Add(card);
        }

        public Card Get(int id)
        {
            return db.cards.Find(id);
        }

        public void Update(Card card)
        {
            db.Entry(card).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Card card = db.cards.Find(id);
            if (card != null)
            {
                db.cards.Remove(card);
            }
        }

        public IEnumerable<Card> GetAll()
        {
            return db.cards;
        }

    }
}

