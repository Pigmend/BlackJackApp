using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.Entities;
using BlackJack.BusinessLogic.Infrastructure;
using BlackJack.BusinessLogic.Interfaces;
using BlackJack.DataAccess.Interfaces;
using BlackJack.BusinessLogic.Maper;

namespace BlackJack.BusinessLogic.Services
{
    public class DeckService : IDeckService
    {
        IDeckRepository _cardService { get; set; }

        public DeckService(IDeckRepository cardService)
        {
            _cardService = cardService;
        }
    }
}
