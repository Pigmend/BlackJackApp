using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using BlackJack.Entities;
using BlackJack.Entities.Enums;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace BlackJack.DataAccess.EF
{
    public class DatabaseContext : DbContext
    {
        public DbSet<DeckCard> DeckCard { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Game> Game { get; set; }
        public DbSet<Step> Step { get; set; }
        public DbSet<PlayerHand> PlayerHand { get; set; }
        public DbSet<PlayerHandCard> PlayerHandCard { get; set; }

        public DatabaseContext () 
            : base("BlackJackConnection")
        {
            Database.SetInitializer<DatabaseContext >(new DatabaseInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }

    public class DatabaseInitializer: CreateDatabaseIfNotExists<DatabaseContext >
    {
        protected override void Seed(DatabaseContext  context)
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
                    context.DeckCard.Add(deckCard);
                }

                if(cardName > (int)CardNumber.Ten && cardName < (int)CardNumber.Ace)
                {
                    DeckCard deckCard = new DeckCard();
                    deckCard.CardSuit = (CardSuit)cardSuit;
                    deckCard.CardNumber = (CardNumber)cardName;
                    deckCard.CardScore = 10;
                    deckCard.CardName = $"{(CardNumber)cardName} {(CardSuit)cardSuit}";
                    context.DeckCard.Add(deckCard);
                }

                if(cardName == (int)CardNumber.Ace)
                {
                    DeckCard deckCard = new DeckCard();
                    deckCard.CardSuit = (CardSuit)cardSuit;
                    deckCard.CardNumber = (CardNumber)cardName;
                    deckCard.CardScore = 11;
                    deckCard.CardName = $"{(CardNumber)cardName} {(CardSuit)cardSuit}";
                    context.DeckCard.Add(deckCard);
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
                context.User.Add(new User() { Name = $"BOT #{i}", Role = UserRole.Bot });
            }
            context.User.Add(new User() { Name = "Dealer", Role = UserRole.Diller });
            context.User.Add(new User() { Name = "James Hetfield", Role = UserRole.Player });
            base.Seed(context);
        }
    }
}
