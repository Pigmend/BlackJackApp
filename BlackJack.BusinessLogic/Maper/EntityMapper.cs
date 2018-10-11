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

        public static IEnumerable<GameShowHistoryUserViewItem> MapGameToGameShowHistoryUserViewItem(IEnumerable<Game> games)
        {
            List<GameShowHistoryUserViewItem> gamesList = new List<GameShowHistoryUserViewItem>();

            foreach(Game item in games)
            {
                GameShowHistoryUserViewItem gameViewItem = new GameShowHistoryUserViewItem();
                gameViewItem.GameID = item.ID;
                gameViewItem.StepsPlayed = item.Steps.Count;

                gamesList.Add(gameViewItem);
            }

            return gamesList;
        }

        public static IEnumerable<StepShowGameHistoryUserViewItem> MapStepToStepShowGameHistoryUserViewItem(IEnumerable<Step> steps)
        {
            List<StepShowGameHistoryUserViewItem> stepsList = new List<StepShowGameHistoryUserViewItem>();

            foreach(Step item in steps)
            {
                StepShowGameHistoryUserViewItem stepViewItem = new StepShowGameHistoryUserViewItem();
                stepViewItem.StepID = item.ID;
                stepViewItem.Hands = EntityMapper.MapPlayerHandToPlayerHandShowGameHistoryUserViewItem(item.PlayerHands);

                stepsList.Add(stepViewItem);
            }

            return stepsList;
        }

        public static IEnumerable<PlayerHandShowGameHistoryUserViewItem> MapPlayerHandToPlayerHandShowGameHistoryUserViewItem(IEnumerable<PlayerHand> playerHands)
        {
            List<PlayerHandShowGameHistoryUserViewItem> playerHandViewItems = new List<PlayerHandShowGameHistoryUserViewItem>();

            foreach(PlayerHand item in playerHands)
            {
                PlayerHandShowGameHistoryUserViewItem handViewItem = new PlayerHandShowGameHistoryUserViewItem();
                handViewItem.PlayerHandID = item.ID;
                handViewItem.PlayerID = item.PlayerID;
                handViewItem.Cash = item.Cash;
                handViewItem.CardPoints = item.CardPoints;
                handViewItem.Score = item.Score;

                UserShowGameHistoryUserViewItem user = new UserShowGameHistoryUserViewItem();
                user.UserID = item.User.ID;
                user.Name = item.User.Name;
                user.Role = item.User.Role;

                handViewItem.User = user;
                handViewItem.HandCards = EntityMapper.MapCardToCardShowGameHistoryUserViewItem(item.Cards);

                playerHandViewItems.Add(handViewItem);
            }

            return playerHandViewItems;
        }

        private static IEnumerable<CardShowGameHistoryUserViewItem> MapCardToCardShowGameHistoryUserViewItem (IEnumerable<Card> cards)
        {
            List<CardShowGameHistoryUserViewItem> playerHandCards = new List<CardShowGameHistoryUserViewItem>();

            foreach(Card item in cards)
            {
                CardShowGameHistoryUserViewItem cardViewItem = new CardShowGameHistoryUserViewItem();
                cardViewItem.CardID = item.CardID;
                cardViewItem.CardName = item.CardName;

                playerHandCards.Add(cardViewItem);
            }

            return playerHandCards;
        }
    }
}
