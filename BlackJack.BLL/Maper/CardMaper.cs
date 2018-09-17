using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Entities;
using BlackJack.BusinessLogicLayer.Infrastructure;
using BlackJack.BusinessLogicLayer.Interfaces;
using BlackJack.DataAccessLayer.Interfaces;
using BlackJack.ViewModels.EntityViewModel;

namespace BlackJack.BusinessLogicLayer.Maper
{
    public class CardMaper
    {
        IUnitOfWork Database { get; set; }

        public CardMaper(IUnitOfWork unitOfWork)
        {
            this.Database = unitOfWork;
        }

        public List<CardViewModel> MapCardListToCardViewModelList (IEnumerable<Card> item)
        {
            var result = new List<CardViewModel>();

            foreach (var card in item)
            {
                var ViewModel = new CardViewModel();
                ViewModel.ID = card.ID;
                ViewModel.CardName = card.CardName;
                ViewModel.CardNumber = card.CardNumber;
                ViewModel.CardSuit = card.CardSuit;
                ViewModel.CardScore = card.CardScore;
                result.Add(ViewModel);
            }
            return result;
        }
    }
}
