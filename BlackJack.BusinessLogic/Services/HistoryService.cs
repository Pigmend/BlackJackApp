using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Entities;
using BlackJack.DataAccess.Interfaces;
using BlackJack.BusinessLogic.Interfaces;
using BlackJack.ViewModels.Request;
using BlackJack.BusinessLogic.Maper;

namespace BlackJack.BusinessLogic.Services
{
    public class HistoryService: IHistoryService
    {
        private IUserRepository _userRepository { get; set; }
        private ICardRepository _cardRepository { get; set; }
        private IGameRepository _gameRepository { get; set; }
        private IStepRepository _stepRepository { get; set; }
        private IPlayerHandRepository _playerHandRepository { get; set; }

        public HistoryService( 
            IUserRepository userRepository, 
            ICardRepository cardRepository,
            IGameRepository gameRepository, 
            IStepRepository stepRepository, 
            IPlayerHandRepository playerHandRepository
            )
        {
            _userRepository = userRepository;
            _cardRepository = cardRepository;
            _gameRepository = gameRepository;
            _stepRepository = stepRepository;
            _playerHandRepository = playerHandRepository;
        }

        public ShowHistoryUserViewModel ShowHistory(long PlayerID)
        {
            ShowHistoryUserViewModel viewModel = new ShowHistoryUserViewModel();
            viewModel.Games = EntityMapper.MapGameToGameShowHistoryUserViewItem(_gameRepository.SelectGamesByUserId(PlayerID));

            return viewModel;
        }

        public ShowGameHistoryUserViewModel ShowGameHistory(long gameID)
        {
            ShowGameHistoryUserViewModel viewModel = new ShowGameHistoryUserViewModel();

            viewModel.GameID = gameID;
            viewModel.Steps = EntityMapper.MapStepToStepShowGameHistoryUserViewItem(_stepRepository.GetStepByGameID(gameID));

            return viewModel;
        }

        public StepShowGameHistoryUserViewItem ShowStep(long stepID)
        {
            StepShowGameHistoryUserViewItem viewModel = new StepShowGameHistoryUserViewItem();

            Step step = _stepRepository.Get(stepID);

            viewModel.StepID = stepID;
            viewModel.Hands = EntityMapper.MapPlayerHandToPlayerHandShowGameHistoryUserViewItem(step.PlayerHands);

            return viewModel;
        }
    }
}
