using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.ViewModels;
using BlackJack.BLL.DTO;

namespace BlackJack.BLL.Interfaces
{
    public interface ICardService
    {
        IEnumerable<CardDTO> GetAllCards();
        CardDTO GetCard(int id);

        void Dispose();
    }
}
