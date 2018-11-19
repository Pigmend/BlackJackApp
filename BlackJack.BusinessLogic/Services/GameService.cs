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
using BlackJack.ViewModels;
using BlackJack.BusinessLogic.Maper;

namespace BlackJack.BusinessLogic.Services
{
    public class GameService : IGameService
    {
        private IUserRepository _userRepository { get; set; }
        private IDeckRepository _deckRepository { get; set; }
        private IGameRepository _gameRepository { get; set; }
        private IStepRepository _stepRepository { get; set; }
        private IPlayerHandRepository _playerHandRepository { get; set; }
        private IPlayerHandCardRepository _playerHandCardRepository { get; set; }

        public GameService(IUserRepository userRepository,
            IDeckRepository deckRepository,
            IGameRepository gameRepository,
            IStepRepository stepRepository,
            IPlayerHandRepository playerHandRepository,
            IPlayerHandCardRepository playerHandCardRepository)
        {
            _gameRepository = gameRepository;
            _userRepository = userRepository;
            _deckRepository = deckRepository;
            _stepRepository = stepRepository;
            _playerHandRepository = playerHandRepository;
            _playerHandCardRepository = playerHandCardRepository;
        }

        public ProcessGameView GetGameData(long userID)
        {
            Game game = new Game();
            game.UserId = userID;

            long gameId =_gameRepository.CreateAndReturnId(game);

            User user = _userRepository.Get(userID);
            IEnumerable<DeckCard> cards = _deckRepository.GetAll();

            ProcessGameView viewModel = new ProcessGameView();
            viewModel.GameID = gameId;
            viewModel.User = EntityMapper.MapUserToGameProcessUserViewItem(user);
            viewModel.Cards = EntityMapper.MapCardListToGameProcessCardViewItem(cards);

            return viewModel;
        }

        public bool SaveChanges(SaveChangesGameView model)
        {
            Step step = new Step();
            step.WinnerId = model.WinnerID;
            step.GameId = model.GameID;
            step.GameProcess = model.GameProcess;
            step.Id = _stepRepository.CreateAndReturnId(step);

            List<PlayerHand> playerHands = new List<PlayerHand>();
            foreach (PlayerSaveChangesGameViewItem item in model.Users)
            {
                PlayerHand playerHand = EntityMapper.MapPlayerSaveChangesGameViewItemToPlayerHand(item);
                playerHand.StepId = step.Id;

                long playerHandID = _playerHandRepository.CreateAndReturnId(playerHand);
                foreach(CardSaveChangesGameViewItem handCard in item.Cards)
                {
                    _playerHandCardRepository.BindPlayerHandWithPlayerHandCard(playerHandID, handCard.CardID);
                }
            }
            return true;
        }

        public GetCardGameView GetCard()
        {
            Random rnd = new Random();
            long randomLong = rnd.Next(1, 53);

            DeckCard card = _deckRepository.Get(randomLong);

            return EntityMapper.MapCardToGetCardGameViewModel(card);
        }
    }
}
