﻿using System;
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

        public RequestShowHistoryUserViewModel ShowHistory(long PlayerID)
        {
            RequestShowHistoryUserViewModel viewModel = new RequestShowHistoryUserViewModel();
            viewModel.Games = EntityMapper.MapGameToGameShowHistoryUserViewItem(_gameRepository.SelectGamesByUserId(PlayerID));

            foreach(var item in viewModel.Games)
            {
                item.Steps = EntityMapper.MapStepListToStepShowHistoryUserViewItemList(_stepRepository.GetStepByGameID(item.GameID));
            }

            return viewModel;
        }

        public RequestShowGameHistoryUserViewModel ShowGameHistory(long gameID)
        {
            RequestShowGameHistoryUserViewModel viewModel = new RequestShowGameHistoryUserViewModel();

            viewModel.GameID = gameID;
            viewModel.Steps = EntityMapper.MapStepListToStepShowGameHistoryUserViewItemList(_stepRepository.GetStepByGameID(gameID));
            return viewModel;
        }

        public RequestShowStepHistoryViewModel ShowStep(long stepID)
        {
            RequestShowStepHistoryViewModel viewModel = new RequestShowStepHistoryViewModel();

            Step step = _stepRepository.Get(stepID);
            viewModel.StepID = stepID;

            IEnumerable<PlayerHand> playerHands = _playerHandRepository.GetHandsByStepID(stepID);
            List<PlayerHandShowStepHistoryViewItem> playerHandList = new List<PlayerHandShowStepHistoryViewItem>();
            foreach(PlayerHand item in playerHands)
            {
                string playerName = _userRepository.Get(item.PlayerId).Name;
                IEnumerable<Card> cards = _cardRepository.GetCardsByHandID(item.Id);
                playerHandList.Add(EntityMapper.MapPlayerHandToPlayerHandShowStepHistoryViewItem(item, cards, playerName));
            }
            viewModel.PlayerHands = playerHandList;

            return viewModel;
        }
    }
}
