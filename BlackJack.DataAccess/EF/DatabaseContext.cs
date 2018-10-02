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
                    context.Cards.Add(new Card()
                    {   CardSuit = (CardSuit)cardSuit,
                        CardNumber = (CardNumber)cardName,
                        CardScore = cardName + 1,
                        CardName = $"{(CardNumber)cardName} {(CardSuit)cardSuit}"
                    });
                }

                if(cardName > (int)CardNumber.Ten && cardName < (int)CardNumber.Ace)
                {
                    context.Cards.Add(new Card()
                    {
                        CardSuit = (CardSuit)cardSuit,
                        CardNumber = (CardNumber)cardName,
                        CardScore = 10,
                        CardName = $"{(CardNumber)cardName} {(CardSuit)cardSuit}"
                    });
                }

                if(cardName == (int)CardNumber.Ace)
                {
                    context.Cards.Add(new Card()
                    {
                        CardSuit = (CardSuit)cardSuit,
                        CardNumber = (CardNumber)cardName,
                        CardScore = 11,
                        CardName = $"{(CardNumber)cardName} {(CardSuit)cardSuit}"
                    });
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
            context.Users.Add(new User() { Name = "Diller", Role = UserRole.Diller });
            context.Users.Add(new User() { Name = "James Hetfield", Role = UserRole.Player });
            base.Seed(context);
        }
    }
}
