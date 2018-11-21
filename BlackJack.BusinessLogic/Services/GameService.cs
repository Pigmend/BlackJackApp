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

            User user = _userRepository.Get(userID);             //Get User from DB
            User dealer = _userRepository.Get(6);             //Get Dealer from DB

            ProcessGameView viewModel = new ProcessGameView();
            viewModel.GameID = gameId;

            List<UserGameProcessViewlItem> players = new List<UserGameProcessViewlItem>();
            players.Add(EntityMapper.MapUserToGameProcessUserViewItem(user));             // [0] - User
            players.Add(EntityMapper.MapUserToGameProcessUserViewItem(dealer));             // [1] - Dealer
            for (int i = 0; i<user.SelectedBots; i++)
            {
                UserGameProcessViewlItem bot = new UserGameProcessViewlItem();
                bot = EntityMapper.MapUserToGameProcessUserViewItem(_userRepository.Get(i + 1));
                players.Add(bot);             // [2+] - Bots
            }
            viewModel.Players = players;
            viewModel.WinnerID = 0;

            return viewModel;
        }

        public ProcessGameView StartGame(ProcessGameView model)
        {
            foreach(var player in model.Players)
            {
                if (player.Role != UserRole.Diller && player.Score >= 100)
                {
                    CardGameProcessViewItem card = GetCard();
                    player.PlayerCards.Add(card);
                    player.CardPoints += card.CardScore;

                    card = GetCard();
                    player.PlayerCards.Add(card);
                    player.CardPoints += card.CardScore;

                    if(player.CardPoints > 21)
                    {
                        player.CardPoints = 21;
                    }

                    player.IsPlayed = true;
                    player.Cash = 100;
                    player.Score -= 100;
                }

                if(player.Role == UserRole.Diller)
                {
                    CardGameProcessViewItem card= GetCard();
                    player.PlayerCards.Add(card);

                    player.CardPoints += card.CardScore;
                }
            }
            SaveChanges(model);

            return model;
        }

        private UserGameProcessViewlItem PlayerStep(UserGameProcessViewlItem viewItem)
        {
            if(viewItem.Role != UserRole.Diller && viewItem.IsPlayed)
            {
                CardGameProcessViewItem card = GetCard();
                viewItem.PlayerCards.Add(card);

                if(card.CardNumber != CardNumber.Ace)
                {
                    viewItem.CardPoints += card.CardScore;
                }
                if(card.CardNumber == CardNumber.Ace && viewItem.CardPoints + card.CardScore <=21)
                {
                    viewItem.CardPoints += card.CardScore;
                }
                if(card.CardNumber == CardNumber.Ace && viewItem.CardPoints + card.CardScore > 21)
                {
                    viewItem.CardPoints += 1;
                }
            }

            return viewItem;
        }

        private static readonly Random random = new Random();
        private static readonly object syncLock = new object();
        private CardGameProcessViewItem GetCard()
        {
            lock (syncLock)
            {
                long randomLong = random.Next(1, 53);

                DeckCard card = _deckRepository.Get(randomLong);

                return EntityMapper.MapCardToCardGameProcessViewItem(card);
            }
        }

        public ProcessGameView Step(ProcessGameView model)
        {
            List<UserGameProcessViewlItem> players = new List<UserGameProcessViewlItem>();
            foreach(var player in model.Players)
            {
                players.Add(PlayerStep(player));
            }
            model.Players = players;
            SaveChanges(model);

            return model;
        }

        public void SaveChanges(ProcessGameView model)
        {
            Step step = new Step();
            step.WinnerId = model.WinnerID;
            step.GameId = model.GameID;
            step.GameProcess = Convert.ToInt32(model.GameProcess);
            step.Id = _stepRepository.CreateAndReturnId(step);
            List<PlayerHand> playerHands = new List<PlayerHand>();
            foreach (UserGameProcessViewlItem item in model.Players)
            {
                PlayerHand playerHand = EntityMapper.MapUserGameProcessViewItemToPlayerHand(item);
                playerHand.StepId = step.Id;

                long playerHandId = _playerHandRepository.CreateAndReturnId(playerHand);
                foreach (CardGameProcessViewItem handCard in item.PlayerCards)
                {
                    _playerHandCardRepository.BindPlayerHandWithPlayerHandCard(playerHandId, handCard.CardID);
                }
            }
        }
    }
}
