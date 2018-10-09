using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using BlackJack.Entities;
using BlackJack.Entities.Enums;

namespace BlackJack.DataAccess.EF
{
    public class DatabaseContext: DbContext
    {
        public DbSet<DeckCard> Deck { get; set; }

        public DbSet<User> Users { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Game> Games { get; set; }

        public DbSet<Step> Steps { get; set; }
        public DbSet<PlayerHand> PlayerHands { get; set; }

        public DatabaseContext(string connectionString) 
            : base(connectionString)
        {
            Database.SetInitializer<DatabaseContext>(new DatabaseInitializer());
        }
    }

    public class DatabaseInitializer: CreateDatabaseIfNotExists<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            int cardName = (int)CardNumber.Two;
            int cardSuit = (int)CardSuit.Clubs;

            while (cardSuit <= (int)CardSuit.Hearts)
            {
                if (cardName < (int)CardNumber.Jack)
                {
                    DeckCard deckCard = new DeckCard();
                    deckCard.CardSuit = (CardSuit)cardSuit;
                    deckCard.CardNumber = (CardNumber)cardName;
                    deckCard.CardScore = cardName + 1;
                    deckCard.CardName = $"{(CardNumber)cardName} {(CardSuit)cardSuit}";
                    context.Deck.Add(deckCard);
                }

                if(cardName > (int)CardNumber.Ten && cardName < (int)CardNumber.Ace)
                {
                    DeckCard deckCard = new DeckCard();
                    deckCard.CardSuit = (CardSuit)cardSuit;
                    deckCard.CardNumber = (CardNumber)cardName;
                    deckCard.CardScore = 10;
                    deckCard.CardName = $"{(CardNumber)cardName} {(CardSuit)cardSuit}";
                    context.Deck.Add(deckCard);
                }

                if(cardName == (int)CardNumber.Ace)
                {
                    DeckCard deckCard = new DeckCard();
                    deckCard.CardSuit = (CardSuit)cardSuit;
                    deckCard.CardNumber = (CardNumber)cardName;
                    deckCard.CardScore = 11;
                    deckCard.CardName = $"{(CardNumber)cardName} {(CardSuit)cardSuit}";
                    context.Deck.Add(deckCard);
                }

                cardName++;
                if (cardName > (int)CardNumber.Ace)
                {
                    cardName = (int)CardNumber.Two;
                    cardSuit++;
                }
            }

            for (int i = 1; i <= 5; i++)
            {
                context.Users.Add(new User() { Name = $"BOT #{i}", Role = UserRole.Bot });
            }
            context.Users.Add(new User() { Name = "Dealer", Role = UserRole.Diller });
            context.Users.Add(new User() { Name = "James Hetfield", Role = UserRole.Player });
            base.Seed(context);
        }
    }
}
