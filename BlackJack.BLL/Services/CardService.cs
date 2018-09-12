﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Entities;
using BlackJack.BusinessLogicLayer.Infrastructure;
using BlackJack.BusinessLogicLayer.Interfaces;
using BlackJack.DataAccessLayer.Interfaces;
using BlackJack.ViewModels;

namespace BlackJack.BusinessLogicLayer.Services
{
    public class CardService: ICardService
    {
        IUnitOfWork Database { get; set; }

        public CardService(IUnitOfWork unitOfWork)
        {
            this.Database = unitOfWork;
        }

        public IEnumerable<CardViewModel> GetAllCards()
        {
            List<CardViewModel> cards = new List<CardViewModel>();
            foreach( Card card in Database.Cards.GetAll())
            {
                cards.Add(new CardViewModel() {
                    ID = card.ID,
                    CardName = card.CardName,
                    CardScore = card.CardScore,
                    CardNumber = card.CardNumber,
                    CardSuit = card.CardSuit
                });
            }

            return cards;
        }

        public CardViewModel GetCard(int id)
        {
            Card card = Database.Cards.Get(id);

            return new CardViewModel() { ID = card.ID, CardName = card.CardName, CardNumber = card.CardNumber, CardSuit = card.CardSuit, CardScore = card.CardScore };
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
