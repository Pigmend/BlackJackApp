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
        private IDeckRepository _deckRepository { get; set; }
        private IGameRepository _gameRepository { get; set; }
        private IStepRepository _stepRepository { get; set; }
        private IPlayerHandRepository _playerHandRepository { get; set; }
        private ICardRepository _cardRepository { get; set; }

        public GameService(IUserRepository userRepository, IDeckRepository deckRepository, IGameRepository gameRepository, IStepRepository stepRepository, IPlayerHandRepository playerHandRepository, ICardRepository cardRepository)
        {
            _gameRepository = gameRepository;
            _userRepository = userRepository;
            _deckRepository = deckRepository;
            _stepRepository = stepRepository;
            _playerHandRepository = playerHandRepository;
            _cardRepository = cardRepository;
        }

        public GameProcessViewModel GetGameData(long userID)
        {
            Game game = new Game();
            game.UserId = userID;

            long gameId =_gameRepository.CreateAndReturnId(game);

            User user = _userRepository.Get(userID);
            IEnumerable<DeckCard> cards = _deckRepository.GetAll();

            GameProcessViewModel view = new GameProcessViewModel();
            view.GameID = gameId;
            view.User = EntityMapper.MapUserToGameProcessUserViewItem(user);
            view.Cards = EntityMapper.MapCardListToGameProcessCardViewItem(cards);

            return view;
        }

        public bool SaveChanges(SaveChangesGameViewModel model)
        {
            //**********************Insert Step**********************
            Step step = new Step();
            step.WinnerId = model.WinnerID;
            step.GameId = model.GameID;
            step.GameProcess = model.GameProcess;

            step.Id = _stepRepository.CreateAndReturnId(step);
            //********************************************************


            //**********************InsertPlayerHand**********************
            List<PlayerHand> playerHands = new List<PlayerHand>();
            foreach (PlayerSaveChangesGameViewItem item in model.Users)
            {
                PlayerHand playerHand = new PlayerHand();
                playerHand.PlayerId = item.PlayerID;
                playerHand.Score = item.Score;
                playerHand.Cash = item.Cash;
                playerHand.CardPoints = item.CardPoints;
                playerHand.StepId = step.Id;

                // SAVE CARDS
                long playerHandID = _playerHandRepository.CreateAndReturnId(playerHand);
                foreach(CardSaveChangesGameViewItem card in item.Cards)
                {
                    Card cr = new Card();
                    cr.CardId = card.CardID;
                    cr.CardName = card.CardName;
                    cr.CardNumber = card.CardNumber;
                    cr.CardSuit = card.CardSuit;
                    cr.CardScore = card.CardScore;

                    long cardID = _cardRepository.CreateAndReturnId(cr);

                    _playerHandRepository.JoinCardWithHand(playerHandID, cardID);
                }
            }
            //********************************************************
            return true;
        }

        public GetCardGameViewModel GetCard()
          {
            Random rnd = new Random();
            long randomLong = rnd.Next(1, 53);

            DeckCard card = _deckRepository.Get(randomLong);

            return EntityMapper.MapCardToGetCardGameViewModel(card);
        }

    }
}
