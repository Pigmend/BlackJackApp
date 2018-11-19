using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Entities;
using BlackJack.DataAccess.Interfaces;
using BlackJack.BusinessLogic.Interfaces;
using BlackJack.ViewModels;
using BlackJack.BusinessLogic.Maper;

namespace BlackJack.BusinessLogic.Services
{
    public class HistoryService: IHistoryService
    {
        private IUserRepository _userRepository { get; set; }
        private IGameRepository _gameRepository { get; set; }
        private IStepRepository _stepRepository { get; set; }
        private IPlayerHandRepository _playerHandRepository { get; set; }
        private IDeckRepository _deckRepository { get; set; }

        public HistoryService( 
            IUserRepository userRepository, 
            IGameRepository gameRepository, 
            IStepRepository stepRepository, 
            IDeckRepository deckRepository,
            IPlayerHandRepository playerHandRepository)
        {
            _userRepository = userRepository;
            _gameRepository = gameRepository;
            _stepRepository = stepRepository;
            _deckRepository = deckRepository;
            _playerHandRepository = playerHandRepository;
        }

        public ShowHistoryUserView ShowHistory(long PlayerID)
        {
            ShowHistoryUserView viewModel = new ShowHistoryUserView();
            viewModel.Games = EntityMapper.MapGameToGameShowHistoryUserViewItem(_gameRepository.SelectGamesByUserId(PlayerID));

            foreach(var item in viewModel.Games)
            {
                item.Steps = EntityMapper.MapStepListToStepShowHistoryUserViewItemList(_stepRepository.GetStepByGameID(item.GameID));
            }

            return viewModel;
        }

        public ShowGameHistoryUserView ShowGameHistory(long gameID)
        {
            ShowGameHistoryUserView viewModel = new ShowGameHistoryUserView();

            viewModel.GameID = gameID;
            viewModel.Steps = EntityMapper.MapStepListToStepShowGameHistoryUserViewItemList(_stepRepository.GetStepByGameID(gameID));
            return viewModel;
        }

        public ShowStepHistoryView ShowStep(long stepID)
        {
            ShowStepHistoryView viewModel = new ShowStepHistoryView();

            Step step = _stepRepository.Get(stepID);
            viewModel.StepID = stepID;

            IEnumerable<PlayerHand> playerHands = _playerHandRepository.GetHandsByStepID(stepID);
            List<PlayerHandShowStepHistoryViewItem> playerHandList = new List<PlayerHandShowStepHistoryViewItem>();
            foreach(PlayerHand item in playerHands)
            {
                string playerName = _userRepository.Get(item.PlayerId).Name;
                IEnumerable<DeckCard> cards = _deckRepository.GetCardsByHandID(item.Id);
                playerHandList.Add(EntityMapper.MapPlayerHandToPlayerHandShowStepHistoryViewItem(item, cards, playerName));
            }
            viewModel.PlayerHands = playerHandList;

            return viewModel;
        }
    }
}
