using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Entities;
using BlackJack.BLL.Infrastructure;
using BlackJack.BLL.Interfaces;
using BlackJack.DAL.Interfaces;
using BlackJack.BLL.DTO;
using AutoMapper;

namespace BlackJack.BLL.Services
{
    public class CardService: ICardService
    {
        IUnitOfWork Database { get; set; }

        public CardService(IUnitOfWork unitOfWork)
        {
            this.Database = unitOfWork;
        }

        public IEnumerable<CardDTO> GetAllCards()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Card, CardDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Card>, List<CardDTO>>(Database.Cards.GetAll());
        }

        public CardDTO GetCard(int id)
        {
            Card card = Database.Cards.Get(id);

            return new CardDTO() { ID = card.ID, CardName = card.CardName, CardNumber = card.CardNumber, CardSuit = card.CardSuit, CardScore = card.CardScore };
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
