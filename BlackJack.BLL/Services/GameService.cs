using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Entities;
using BlackJack.BusinessLogicLayer.Infrastructure;
using BlackJack.BusinessLogicLayer.Interfaces;
using BlackJack.DataAccessLayer.Interfaces;
using BlackJack.ViewModels.EntityViewModel;
using BlackJack.ViewModels.Game;

namespace BlackJack.BusinessLogicLayer.Services
{
    public class GameService : IGameService
    {
        IUnitOfWork Database { get; set; }

        public GameService(IUnitOfWork unitOfWork)
        {
            this.Database = unitOfWork;
        }

        public GameDataViewModel GetDataForGame()
        {
            User lastSignedUser = Database.Users.ReturnLastUser();
            UserViewModel insertUser = new UserViewModel() { ID = lastSignedUser.ID, Name = lastSignedUser.Name };

            List<UserViewModel> users = new List<UserViewModel>();
            foreach(User user in Database.Users.GetAll())
            {
                users.Add(new UserViewModel() { ID = user.ID, Name = user.Name });
            }

            List<CardViewModel> cards = new List<CardViewModel>();

            foreach(Card card in Database.Cards.GetAll())
            {
                cards.Add(new CardViewModel() {
                    ID = card.ID,
                    CardName = card.CardName,
                    CardScore = card.CardScore,
                    CardNumber = card.CardNumber,
                    CardSuit = card.CardSuit
                });
            }

            return new GameDataViewModel(insertUser, users, cards);
        }

    }
}
