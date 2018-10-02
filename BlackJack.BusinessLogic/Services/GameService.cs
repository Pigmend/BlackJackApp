using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Entities;
using BlackJack.Entities.Enums;
using BlackJack.BusinessLogic.Infrastructure;
using BlackJack.BusinessLogic.Interfaces;
using BlackJack.DataAccess.Interfaces;
using BlackJack.ViewModels.Game;
using BlackJack.ViewModels.Response;
using BlackJack.BusinessLogic.Maper;

namespace BlackJack.BusinessLogic.Services
{
    public class GameService : IGameService
    {
        IUserRepository UserRepository { get; set; }
        ICardRepository CardRepository { get; set; }
        IGameRepository GameRepository { get; set; }
        IStepRepository StepRepository { get; set; }
        IPlayerHandRepository PlayerHandRepository { get; set; }

        public GameService(IUserRepository userRepository, ICardRepository cardRepository, IGameRepository gameRepository, IStepRepository stepRepository, IPlayerHandRepository playerHandRepository)
        {
            GameRepository = gameRepository;
            UserRepository = userRepository;
            CardRepository = cardRepository;
            StepRepository = stepRepository;
            PlayerHandRepository = playerHandRepository;
        }

        public GameProcessViewModel GetGameData(long userID)
        {
            Game game = new Game();
            game.UserID = userID;

            GameRepository.Create(game);
            GameRepository.SaveChanges();

            User user = UserRepository.Get(userID);
            IEnumerable<Card> cards = CardRepository.GetAll();

            GameProcessViewModel view = new GameProcessViewModel();
            view.GameID = game.ID;
            view.User = EntityMapper.MapUserToGameProcessUserViewItem(user);
            view.Cards = EntityMapper.MapCardListToGameProcessCardViewItem(cards);

            return view;
        }
    }
}
