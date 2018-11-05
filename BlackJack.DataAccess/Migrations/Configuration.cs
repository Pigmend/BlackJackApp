namespace BlackJack.DataAccess.Migrations
{
    using BlackJack.DataAccess.EF;
    using BlackJack.Entities;
    using BlackJack.Entities.Enums;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BlackJack.DataAccess.EF.DatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(BlackJack.DataAccess.EF.DatabaseContext context)
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

                if (cardName > (int)CardNumber.Ten && cardName < (int)CardNumber.Ace)
                {
                    DeckCard deckCard = new DeckCard();
                    deckCard.CardSuit = (CardSuit)cardSuit;
                    deckCard.CardNumber = (CardNumber)cardName;
                    deckCard.CardScore = 10;
                    deckCard.CardName = $"{(CardNumber)cardName} {(CardSuit)cardSuit}";
                    context.DeckCard.Add(deckCard);
                }

                if (cardName == (int)CardNumber.Ace)
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
            context.SaveChanges();
        }
    }
}
