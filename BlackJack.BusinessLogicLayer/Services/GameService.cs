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
        IUserRepository UserRepository { get; set; }
        ICardRepository CardRepository { get; set; }

        public GameService(IUserRepository userRepository, ICardRepository cardRepository)
        {
            this.UserRepository = userRepository;
            this.CardRepository = cardRepository;
        }

        public GameDataViewModel GetDataForGame()
        {
            User lastSignedUser = UserRepository.ReturnLastUser();
            UserViewModel insertUser = new UserViewModel() { ID = lastSignedUser.ID, Name = lastSignedUser.Name };

            List<UserViewModel> users = new List<UserViewModel>();
            foreach(User user in UserRepository.GetAll())
            {
                users.Add(new UserViewModel() { ID = user.ID, Name = user.Name });
            }

            List<CardViewModel> cards = new List<CardViewModel>();

            foreach(Card card in CardRepository.GetAll())
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
