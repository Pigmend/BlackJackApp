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
        IUnitOfWork Database { get; set; }
        private CardMaper _cardMaper;

        public CardService(IUnitOfWork unitOfWork, CardMaper cardMaper)
        {
            this.Database = unitOfWork;
            this._cardMaper = cardMaper;
        }

        public IEnumerable<CardViewModel> GetAllCards()
        {
            List<CardViewModel> cards = _cardMaper.MapCardListToCardViewModelList(Database.Cards.GetAll());
           
            return cards;
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
