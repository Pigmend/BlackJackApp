using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Entities;
using BlackJack.ViewModels;

namespace BlackJack.BusinessLogic.Maper
{
    public static class EntityMapper
    {
        public static UserGameProcessViewlItem MapUserToGameProcessUserViewItem(User user)
        {
            UserGameProcessViewlItem item = new UserGameProcessViewlItem();
            item.ID = user.Id;
            item.Name = user.Name;
            item.Role = user.Role;
            item.CardPoints = 0;
            item.Score = 1000;
            item.IsPlayed = true;

            return item;
        }

        public static UserAllUsersUserViewItem MapUserToUserAllUsersUserViewItem(User user)
        {
            UserAllUsersUserViewItem userViewItem = new UserAllUsersUserViewItem();
            userViewItem.ID = user.Id;
            userViewItem.Name = user.Name;
            userViewItem.SelectedBots = user.SelectedBots;

            return userViewItem;
        }

        public static IEnumerable<CardGameProcessViewItem> MapCardListToGameProcessCardViewItem(IEnumerable<DeckCard> cards)
        {
            List<CardGameProcessViewItem> cardList = new List<CardGameProcessViewItem>();

            foreach(DeckCard item in cards)
            {
                CardGameProcessViewItem cardViewItem = new CardGameProcessViewItem();
                cardViewItem.CardID = item.Id;
                cardViewItem.CardName = item.CardName;
                cardViewItem.CardNumber = item.CardNumber;
                cardViewItem.CardSuit = item.CardSuit;

                cardViewItem.CardScore = item.CardScore;

                cardList.Add(cardViewItem);
            }

            return cardList;
        }

        public static IEnumerable<GameShowHistoryUserViewItem> MapGameToGameShowHistoryUserViewItem (IEnumerable<Game> games)
        {
            List<GameShowHistoryUserViewItem> gameList = new List<GameShowHistoryUserViewItem>();

            foreach(Game item in games)
            {
                GameShowHistoryUserViewItem game = new GameShowHistoryUserViewItem();
                game.GameID = item.Id;
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
                step.StepID = item.Id;
                stepList.Add(step);
            }

            return stepList;
        }

        public static PlayerHandShowStepHistoryViewItem MapPlayerHandToPlayerHandShowStepHistoryViewItem(PlayerHand hand, IEnumerable<DeckCard> cards, string playerName)
        {
            PlayerHandShowStepHistoryViewItem playerHand = new PlayerHandShowStepHistoryViewItem();
            playerHand.PlayerHandID = hand.Id;
            playerHand.PlayerID = hand.PlayerId;
            playerHand.Score = hand.Score;
            playerHand.Cash = hand.Cash;
            playerHand.CardPoints = hand.CardPoints;
            playerHand.PlayerName = playerName;
            playerHand.Cards = MapCardToCardPlayerHandShowStepHistoryViewItem(cards);

            return playerHand;
        }

        public static IEnumerable<CardPlayerHandShowStepHistoryViewItem> MapCardToCardPlayerHandShowStepHistoryViewItem(IEnumerable<DeckCard> cards)
        {
            List<CardPlayerHandShowStepHistoryViewItem> playerCards = new List<CardPlayerHandShowStepHistoryViewItem>();

            foreach(DeckCard item in cards)
            {
                CardPlayerHandShowStepHistoryViewItem card = new CardPlayerHandShowStepHistoryViewItem();
                card.CardID = item.Id;
                card.CardName = item.CardName;

                playerCards.Add(card);
            }

            return playerCards;
        }

        public static CardGameProcessViewItem MapCardToCardGameProcessViewItem(DeckCard card)
        {
            CardGameProcessViewItem view = new CardGameProcessViewItem();

            view.CardID = card.Id;
            view.CardName = card.CardName;
            view.CardNumber = card.CardNumber;
            view.CardSuit = card.CardSuit;

            view.CardScore = card.CardScore;

            return view;
        }

        public static IEnumerable<UserSubmitUserHomeViewItem> MapUserListToUserSubmitUserHomeViewItemList(IEnumerable<User> users)
        {
            List<UserSubmitUserHomeViewItem> items = new List<UserSubmitUserHomeViewItem>();
            foreach (User user in users)
            {
                UserSubmitUserHomeViewItem item = new UserSubmitUserHomeViewItem();
                item.Id = user.Id;
                item.Name = user.Name;
                item.SelectedBots = user.SelectedBots;

                items.Add(item);
            }

            return items;
        }

        public static PlayerHand MapPlayerSaveChangesGameViewItemToPlayerHand(PlayerSaveChangesGameViewItem playerHand)
        {
            PlayerHand item = new PlayerHand();
            item.PlayerId = playerHand.PlayerID;
            item.Score = playerHand.Score;
            item.Cash = playerHand.Cash;
            item.CardPoints = playerHand.CardPoints;

            return item;
        }

        public static IEnumerable<StepShowHistoryUserViewItem> MapStepListToStepShowHistoryUserViewItemList(IEnumerable<Step> steps)
        {
            List<StepShowHistoryUserViewItem> stepList = new List<StepShowHistoryUserViewItem>();
            foreach(var item in steps)
            {
                StepShowHistoryUserViewItem step = new StepShowHistoryUserViewItem();
                step.StepId = item.GameId;
                step.GameProcess = Convert.ToBoolean(item.GameProcess);
                step.WinnerId = item.WinnerId;

                stepList.Add(step);
            }

            return stepList;
        }

        public static IEnumerable<StepShowGameHistoryUserViewItem> MapStepListToStepShowGameHistoryUserViewItemList(IEnumerable<Step> steps)
        {
            List<StepShowGameHistoryUserViewItem> stepList = new List<StepShowGameHistoryUserViewItem>();

            foreach(var item in steps)
            {
                StepShowGameHistoryUserViewItem step = new StepShowGameHistoryUserViewItem();
                step.StepID = item.Id;
                step.WinnerId = item.WinnerId;
                step.GameProcess = Convert.ToBoolean(item.GameProcess);

                stepList.Add(step);
            }

            return stepList;
        }

        public static PlayerHand MapUserGameProcessViewItemToPlayerHand(UserGameProcessViewlItem player)
        {
            PlayerHand item = new PlayerHand();
            item.PlayerId = player.ID;
            item.Score = player.Score;
            item.CardPoints = player.CardPoints;
            item.Cash = player.Cash;
            return item;
        }
    }
}
