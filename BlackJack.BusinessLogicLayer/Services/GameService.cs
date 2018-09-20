using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Entities;
using BlackJack.Entities.Enums;
using BlackJack.BusinessLogicLayer.Infrastructure;
using BlackJack.BusinessLogicLayer.Interfaces;
using BlackJack.DataAccessLayer.Interfaces;
using BlackJack.ViewModels.EntityViewModel;
using BlackJack.ViewModels.Game;
using BlackJack.ViewModels.Response;

namespace BlackJack.BusinessLogicLayer.Services
{
    public class GameService : IGameService
    {
        IUserRepository UserRepository { get; set; }
        ICardRepository CardRepository { get; set; }
        IGameRepository GameRepository { get; set; }
        IStepRepository stepRepository { get; set; }
        IPlayerHandRepository PlayerHandRepository { get; set; }

        public GameService(IUserRepository userRepository, ICardRepository cardRepository, IGameRepository gameRepository, IStepRepository stepRepository, IPlayerHandRepository playerHandRepository)
        {
            this.GameRepository = gameRepository;
            this.UserRepository = userRepository;
            this.CardRepository = cardRepository;
        }

        public GameDataViewModel GetDataForGame(int currentUserID)
        {
            Game newGame = new Game();
            newGame.UserID = currentUserID;

            GameRepository.Create(newGame);
            GameRepository.SaveChanges();

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

            User CurrentUserInDb = UserRepository.Get(currentUserID);
            UserViewModel currentUser = new UserViewModel();
            currentUser.ID = CurrentUserInDb.ID;
            currentUser.Name = CurrentUserInDb.Name;
            currentUser.Role = CurrentUserInDb.Role;
            currentUser.SelectedBots = (NumberOfBots)CurrentUserInDb.SelectedBots;

            GameDataViewModel gameData = new GameDataViewModel(currentUser ,users, cards);
            return gameData;
        }

    }
}
