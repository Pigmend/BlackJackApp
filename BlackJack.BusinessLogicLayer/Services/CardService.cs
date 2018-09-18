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
using BlackJack.BusinessLogicLayer.Maper;

namespace BlackJack.BusinessLogicLayer.Services
{
    public class CardService: ICardService
    {
        ICardRepository _cardService { get; set; }
        private CardMaper _cardMaper;

        public CardService(ICardRepository cardService, CardMaper cardMaper)
        {
            this._cardService = cardService;
            this._cardMaper = cardMaper;
        }

        public IEnumerable<CardViewModel> GetAllCards()
        {

            List<CardViewModel> cards = _cardMaper.MapCardListToCardViewModelList(_cardService.GetAll());
           
            return cards;
        }
    }
}
