using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Entities;
using BlackJack.ViewModels.Response;
using BlackJack.ViewModels.Request;

namespace BlackJack.BusinessLogic.Maper
{
    public static class EntityMapper
    {
        public static UserGameProcessViewlItem MapUserToGameProcessUserViewItem(User user)
        {
            UserGameProcessViewlItem item = new UserGameProcessViewlItem();
            item.ID = user.ID;
            item.Name = user.Name;
            item.SelectedBots = user.SelectedBots;
            item.Role = user.Role;

            return item;
        }

        public static IEnumerable<UserAllUsersUserViewItem> MapUserListToUserAllUsersUserViewItemList(IEnumerable<User> users)
        {
            List<UserAllUsersUserViewItem> userList = new List<UserAllUsersUserViewItem>();

            foreach(User item in users)
            {
                UserAllUsersUserViewItem userViewItem = new UserAllUsersUserViewItem();
                userViewItem.ID = item.ID;
                userViewItem.Name = item.Name;
                userViewItem.SelectedBots = item.SelectedBots;
                userList.Add(userViewItem);
            }

            return userList;
        }

        public static IEnumerable<CardGameProcessViewItem> MapCardListToGameProcessCardViewItem(IEnumerable<DeckCard> cards)
        {
            List<CardGameProcessViewItem> cardList = new List<CardGameProcessViewItem>();

            foreach(DeckCard item in cards)
            {
                CardGameProcessViewItem cardViewItem = new CardGameProcessViewItem();
                cardViewItem.CardID = item.ID;
                cardViewItem.CardName = item.CardName;
                cardViewItem.CardNumber = item.CardNumber;
                cardViewItem.CardSuit = item.CardSuit;

                cardViewItem.CardScore = item.CardScore;

                cardList.Add(cardViewItem);
            }

            return cardList;
        }

        public static ICollection<Card> MapCardSaveChangesGameViewItemToCard(IEnumerable<CardSaveChangesGameViewItem> cards)
        {
            List<Card> cardList = new List<Card>();

            foreach(CardSaveChangesGameViewItem item in cards)
            {
                Card card = new Card();
                card.CardID = item.CardID;
                card.CardName = item.CardName;
                card.CardNumber = item.CardNumber;
                card.CardSuit = item.CardSuit;
                card.CardScore = item.CardScore;

                cardList.Add(card);
            }

            return cardList;
        }

        public static IEnumerable<GameShowHistoryUserViewItem> MapGameToGameShowHistoryUserViewItem (IEnumerable<Game> games)
        {
            List<GameShowHistoryUserViewItem> gameList = new List<GameShowHistoryUserViewItem>();

            foreach(Game item in games)
            {
                GameShowHistoryUserViewItem game = new GameShowHistoryUserViewItem();
                game.GameID = item.ID;
                gameList.Add(game);
            }

            return gameList;
        }

        public static IEnumerable<StepShowGameHistoryUserViewItem> MapStepToStepShowGameHistoryUserViewItem(IEnumerable<Step> steps)
        {
            List<StepShowGameHistoryUserViewItem> stepList = new List<StepShowGameHistoryUserViewItem>();

            foreach(Step item in steps)
            {
                StepShowGameHistoryUserViewItem step = new StepShowGameHistoryUserViewItem();
                step.StepID = item.ID;
                stepList.Add(step);
            }

            return stepList;
        }

        public static PlayerHandShowStepHistoryViewItem MapPlayerHandToPlayerHandShowStepHistoryViewItem(PlayerHand hand, IEnumerable<Card> cards)
        {
            PlayerHandShowStepHistoryViewItem playerHand = new PlayerHandShowStepHistoryViewItem();
            playerHand.PlayerHandID = hand.ID;
            playerHand.PlayerID = hand.PlayerID;
            playerHand.Score = hand.Score;
            playerHand.Cash = hand.Cash;
            playerHand.CardPoints = hand.CardPoints;
            playerHand.Cards = MapCardToCardPlayerHandShowStepHistoryViewItem(cards);

            return playerHand;
        }

        public static IEnumerable<CardPlayerHandShowStepHistoryViewItem> MapCardToCardPlayerHandShowStepHistoryViewItem(IEnumerable<Card> cards)
        {
            List<CardPlayerHandShowStepHistoryViewItem> playerCards = new List<CardPlayerHandShowStepHistoryViewItem>();

            foreach(Card item in cards)
            {
                CardPlayerHandShowStepHistoryViewItem card = new CardPlayerHandShowStepHistoryViewItem();
                card.CardID = item.CardID;
                card.CardName = item.CardName;

                playerCards.Add(card);
            }

            return playerCards;
        }
    }
}
