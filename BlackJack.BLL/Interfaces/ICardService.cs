using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.ViewModels.EntityViewModel;

namespace BlackJack.BusinessLogicLayer.Interfaces
{
    public interface ICardService
    {
        IEnumerable<CardViewModel> GetAllCards();

        void Dispose();
    }
}
