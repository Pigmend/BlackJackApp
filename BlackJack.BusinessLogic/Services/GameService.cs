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
using BlackJack.ViewModels.Response;
using BlackJack.ViewModels.Request;
using BlackJack.BusinessLogic.Maper;

namespace BlackJack.BusinessLogic.Services
{
    public class GameService : IGameService
    {
        private IUserRepository _userRepository { get; set; }
        private ICardRepository _cardRepository { get; set; }
        private IGameRepository _gameRepository { get; set; }
        private IStepRepository _stepRepository { get; set; }
        private IPlayerHandRepository _playerHandRepository { get; set; }

        public GameService(IUserRepository userRepository, ICardRepository cardRepository, IGameRepository gameRepository, IStepRepository stepRepository, IPlayerHandRepository playerHandRepository)
        {
            _gameRepository = gameRepository;
            _userRepository = userRepository;
            _cardRepository = cardRepository;
            _stepRepository = stepRepository;
            _playerHandRepository = playerHandRepository;
        }

        public GameProcessViewModel GetGameData(long userID)
        {
            Game game = new Game();
            game.UserID = userID;

            _gameRepository.Create(game);
            _gameRepository.SaveChanges();

            User user = _userRepository.Get(userID);
            IEnumerable<Card> cards = _cardRepository.GetAll();

            GameProcessViewModel view = new GameProcessViewModel();
            view.GameID = game.ID;
            view.User = EntityMapper.MapUserToGameProcessUserViewItem(user);
            view.Cards = EntityMapper.MapCardListToGameProcessCardViewItem(cards);

            return view;
        }

        public bool SaveChanges(SaveChangesGameViewModel model)
        {
            Step step = new Step();
            step.WinnerID = model.WinnerID;
            step.GameID = model.GameID;

            _stepRepository.Create(step);
            _stepRepository.SaveChanges();

            List<PlayerHand> playerHands = new List<PlayerHand>();

            foreach(PlayerSaveChangesGameViewItem item in model.Users)
            {
                PlayerHand playerHand = new PlayerHand();
                playerHand.PlayerID = item.PlayerID;
                playerHand.Score = item.Score;
                playerHand.Cash = item.Cash;
                playerHand.CardPoints = item.CardPoints;
                playerHand.StepID = step.ID;

                playerHand.Cards = EntityMapper.MapCardSaveChangesGameViewItemToCard(item.Cards);

                playerHands.Add(playerHand);
            }

            _playerHandRepository.AddRange(playerHands);

            return true;
        }
    }
}
