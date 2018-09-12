﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.ViewModels;

namespace BlackJack.BusinessLogicLayer.Interfaces
{
    public interface ICardService
    {
        IEnumerable<CardViewModel> GetAllCards();
        CardViewModel GetCard(int id);

        void Dispose();
    }
}
