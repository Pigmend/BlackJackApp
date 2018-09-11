using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using BlackJack.DAL.Entities;
using BlackJack.DAL.Interfaces;

namespace BlackJack.DAL.EF
{
    public class DatabaseContext: DbContext
    {

        public DbSet<User> users { get; set; }
        public DbSet<Card> cards { get; set; }
        public DbSet<Game> games { get; set; }

        public DbSet<Step> steps { get; set; }
        public DbSet<PlayerInfo> playerInfos { get; set; }
        public DbSet<PlayerHand> playerHands { get; set; }


        static DatabaseContext()
        {
            Database.SetInitializer<DatabaseContext>(new DatabaseInitializer());
        }

        public DatabaseContext(string connectionString) 
            : base(connectionString)
        {
            
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
                    context.cards.Add(new Card() { CardSuit = (CardSuit)cardSuit, CardNumber = (CardNumber)cardName, CardScore = cardName + 1 });
                    cardName++;
                }
                if(cardName > (int)CardNumber.Jack && cardName < (int)CardNumber.Ace)
                {
                    context.cards.Add(new Card() { CardSuit = (CardSuit)cardSuit, CardNumber = (CardNumber)cardName, CardScore = 10 });
                }
                if(cardName == (int)CardNumber.Ace)
                {
                    context.cards.Add(new Card() { CardSuit = (CardSuit)cardSuit, CardNumber = (CardNumber)cardName, CardScore = 11 });
                }

                if (cardName > (int)CardNumber.Ace)
                {
                    cardName = (int)CardNumber.Two;
                    cardSuit++;
                }
            }

            base.Seed(context);
        }
    }


}
