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

        public ResponseProcessGameView GetGameData(long userID)
        {
            Game game = new Game();
            game.UserId = userID;

            long gameId =_gameRepository.CreateAndReturnId(game);

            User user = _userRepository.Get(userID);             //Get User from DB
            User dealer = _userRepository.Get(6);             //Get Dealer from DB

            ResponseProcessGameView viewModel = new ResponseProcessGameView();
            viewModel.GameID = gameId;

            List<UserResponseGameProcessViewlItem> players = new List<UserResponseGameProcessViewlItem>();
            players.Add(EntityMapper.MapUserToUserResponseGameProcessUserViewItem(user));             // [0] - User
            players.Add(EntityMapper.MapUserToUserResponseGameProcessUserViewItem(dealer));             // [1] - Dealer
            for (int i = 0; i<user.SelectedBots; i++)
            {
                UserResponseGameProcessViewlItem bot = new UserResponseGameProcessViewlItem();
                bot = EntityMapper.MapUserToUserResponseGameProcessUserViewItem(_userRepository.Get(i + 1));
                players.Add(bot);             // [2+] - Bots
            }
            viewModel.Players = players;
            viewModel.WinnerID = 0;

            foreach (var player in viewModel.Players)
            {
                if (player.Role != UserRole.Diller && player.Score >= 100)
                {
                    CardResponseGameProcessViewItem card = GetCard();
                    player.PlayerCards.Add(card);
                    player.CardPoints += card.CardScore;

                    card = GetCard();
                    player.PlayerCards.Add(card);
                    player.CardPoints += card.CardScore;

                    if (player.CardPoints > 21)
                    {
                        player.CardPoints = 21;
                    }

                    player.IsPlayed = true;
                    player.Cash = 100;
                    player.Score -= 100;
                }

                if (player.Role == UserRole.Diller)
                {
                    CardResponseGameProcessViewItem card = GetCard();
                    player.PlayerCards.Add(card);

                    player.CardPoints += card.CardScore;
                }
            }

            return viewModel;
        }

        public ResponseProcessGameView StartGame(RequestProcessGameView model)
        {
            ResponseProcessGameView response = EntityMapper.MapRequestProcessGameViewToResponseProcessGameView(model);

            response.GameProcess = false;
            response.WinnerID = 0;

            Game game = new Game();
            game.UserId = model.Players[0].ID;
            response.GameID = _gameRepository.CreateAndReturnId(game);

            foreach(var player in response.Players)
            {
                if (player.Role != UserRole.Diller && player.Score >= 100)
                {
                    player.PlayerCards = new List<CardResponseGameProcessViewItem>();
                    player.CardPoints = 0;

                    CardResponseGameProcessViewItem card = GetCard();
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
                    player.PlayerCards = new List<CardResponseGameProcessViewItem>();
                    player.CardPoints = 0;

                    CardResponseGameProcessViewItem card= GetCard();
                    player.PlayerCards.Add(card);

                    player.CardPoints += card.CardScore;
                }
            }
            SaveChanges(response);

            return response;
        }

        private UserResponseGameProcessViewlItem PlayerStep(UserResponseGameProcessViewlItem viewItem)
        {
            if(viewItem.Role == UserRole.Player && viewItem.IsPlayed)
            {
                CardResponseGameProcessViewItem card = GetCard();
                viewItem.PlayerCards.Add(card);

                if(card.CardNumber != CardNumber.Ace)
                {
                    viewItem.CardPoints += card.CardScore;
                }
                if (card.CardNumber == CardNumber.Ace && viewItem.CardPoints + card.CardScore > 21)
                {
                    viewItem.CardPoints += 1;
                }
                if (card.CardNumber == CardNumber.Ace && viewItem.CardPoints + card.CardScore <=21)
                {
                    viewItem.CardPoints += card.CardScore;
                }
                if(viewItem.CardPoints >= 21)
                {
                    viewItem.IsPlayed = false;
                }
            }
            if(viewItem.Role == UserRole.Bot && viewItem.IsPlayed)
            {
                CardResponseGameProcessViewItem card = GetCard();
                viewItem.PlayerCards.Add(card);

                if (card.CardNumber != CardNumber.Ace)
                {
                    viewItem.CardPoints += card.CardScore;
                }
                if (card.CardNumber == CardNumber.Ace && viewItem.CardPoints + card.CardScore > 21)
                {
                    viewItem.CardPoints += 1;
                }
                if (card.CardNumber == CardNumber.Ace && viewItem.CardPoints + card.CardScore <= 21)
                {
                    viewItem.CardPoints += card.CardScore;
                }
                if(viewItem.CardPoints >= 19)
                {
                    viewItem.IsPlayed = false;
                }
            }
            return viewItem;
        }

        private static readonly Random random = new Random();
        private static readonly object syncLock = new object();
        private CardResponseGameProcessViewItem GetCard()
        {
            lock (syncLock)
            {
                long randomLong = random.Next(1, 53);

                DeckCard card = _deckRepository.Get(randomLong);

                return EntityMapper.MapCardToCardGameProcessViewItem(card);
            }
        }

        public ResponseProcessGameView Step(RequestProcessGameView request)
        {
            ResponseProcessGameView response = EntityMapper.MapRequestProcessGameViewToResponseProcessGameView(request);

            List<UserResponseGameProcessViewlItem> players = new List<UserResponseGameProcessViewlItem>();
            foreach(var player in response.Players)
            {
                UserResponseGameProcessViewlItem user = PlayerStep(player);
                players.Add(user);
            }
            response.Players = players;
            SaveChanges(response);

            return response;
        }

        private void SaveChanges(ResponseProcessGameView model)
        {
            Step step = new Step();
            step.WinnerId = model.WinnerID;
            step.GameId = model.GameID;
            step.GameProcess = Convert.ToInt32(model.GameProcess);
            step.Id = _stepRepository.CreateAndReturnId(step);
            List<PlayerHand> playerHands = new List<PlayerHand>();
            foreach (UserResponseGameProcessViewlItem item in model.Players)
            {
                PlayerHand playerHand = EntityMapper.MapUserResponseGameProcessViewItemToPlayerHand(item);
                playerHand.StepId = step.Id;

                long playerHandId = _playerHandRepository.CreateAndReturnId(playerHand);
                foreach (CardResponseGameProcessViewItem handCard in item.PlayerCards)
                {
                    _playerHandCardRepository.BindPlayerHandWithPlayerHandCard(playerHandId, handCard.CardID);
                }
            }
        }

        public ResponseProcessGameView EndGame(RequestProcessGameView model)
        {
            ResponseProcessGameView response = EntityMapper.MapRequestProcessGameViewToResponseProcessGameView(model);
            response.Players[0].IsPlayed = false;

            bool anyoneIsPlayed = true;
            while (anyoneIsPlayed)
            {
                int numberOfCurrentPlayers = 0;
                List<UserResponseGameProcessViewlItem> players = new List<UserResponseGameProcessViewlItem>();
                foreach (var item in response.Players)
                {
                    if(item.Role == UserRole.Player)
                    {
                        players.Add(item);
                    }
                    if (item.Role == UserRole.Bot)
                    {
                        UserResponseGameProcessViewlItem player = PlayerStep(item);
                        players.Add(player);
                    }
                    if(item.Role== UserRole.Diller)
                    {
                        UserResponseGameProcessViewlItem player = DealerStep(item);
                        players.Add(player);
                    }
                    if (item.IsPlayed)
                    {
                        numberOfCurrentPlayers++;
                    }
                }
                response.Players = players;

                if (numberOfCurrentPlayers == 0)
                {
                    anyoneIsPlayed = false;
                }
            }

            response.GameProcess = true; // set Game process are (END)
            response = EndGameValidation(response); //endgame validation
            SaveChanges(response); //Save changes in response view

            return response;
        }

        private UserResponseGameProcessViewlItem DealerStep(UserResponseGameProcessViewlItem dealer)
        {
            CardResponseGameProcessViewItem card = GetCard();
            dealer.PlayerCards.Add(card);

            if (card.CardNumber != CardNumber.Ace)
            {
                dealer.CardPoints += card.CardScore;
            }
            if (card.CardNumber == CardNumber.Ace && dealer.CardPoints + card.CardScore > 21)
            {
                dealer.CardPoints += 1;
            }
            if (card.CardNumber == CardNumber.Ace && dealer.CardPoints + card.CardScore <= 21)
            {
                dealer.CardPoints += card.CardScore;
            }
            if (dealer.CardPoints >= 17)
            {
                dealer.IsPlayed = false;
            }

            return dealer;
        }

        private ResponseProcessGameView EndGameValidation(ResponseProcessGameView response)
        {
            foreach(var item in response.Players)
            {
                if(item.Role != UserRole.Diller && item.CardPoints < 22 && response.Players[1].CardPoints > 21)
                {
                    item.Score += item.Cash*2;
                    item.Cash = 0;
                }
                if(item.Role != UserRole.Diller && item.CardPoints > response.Players[1].CardPoints && item.CardPoints < 22 && response.Players[1].CardPoints < 22)
                {
                    item.Score += item.Cash*2;
                    item.Cash = 0;
                }
                if(item.Role != UserRole.Diller && item.CardPoints < response.Players[1].CardPoints && item.CardPoints < 22 && response.Players[1].CardPoints < 22)
                {
                    item.Cash = 0;
                }
                if(item.Role != UserRole.Diller && item.CardPoints > 21 && response.Players[1].CardPoints > 21)
                {
                    item.Cash = 0;
                }
                if (item.Role != UserRole.Diller && item.CardPoints > 21)
                {
                    item.Cash = 0;
                }
                if(item.Role != UserRole.Diller && item.CardPoints == response.Players[1].CardPoints)
                {
                    item.Score += item.Cash;
                    item.Cash = 0;
                }
            }

            return response;
        }

    }
}
