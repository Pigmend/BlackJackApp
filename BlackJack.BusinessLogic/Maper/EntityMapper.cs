using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Entities;
using BlackJack.ViewModels.Response;

namespace BlackJack.BusinessLogic.Maper
{
    public static class EntityMapper
    {
        public static GameProcessUserViewlItem MapUserToGameProcessUserViewItem(User user)
        {
            GameProcessUserViewlItem item = new GameProcessUserViewlItem();
            item.ID = user.ID;
            item.Name = user.Name;
            item.SelectedBots = user.SelectedBots;

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

        public static IEnumerable<GameProcessCardViewItem> MapCardListToGameProcessCardViewItem(IEnumerable<Card> cards)
        {
            List<GameProcessCardViewItem> cardList = new List<GameProcessCardViewItem>();

            foreach(Card item in cards)
            {
                GameProcessCardViewItem cardViewItem = new GameProcessCardViewItem();
                cardViewItem.CardID = item.ID;
                cardViewItem.CardName = item.CardName;
                cardViewItem.CardScore = item.CardScore;
                cardList.Add(cardViewItem);
            }

            return cardList;
        }
    }
}
