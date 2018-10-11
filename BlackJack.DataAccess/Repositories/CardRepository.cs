using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.DataAccess.Interfaces;
using BlackJack.Entities;
using BlackJack.DataAccess.Repositories.BaseRepository;
using BlackJack.DataAccess.EF;

namespace BlackJack.DataAccess.Repositories
{
    public class CardRepository : BaseRepository<Card>, ICardRepository
    {
        public CardRepository(DatabaseContext context) 
            : base(context)
        {

        }


    }
}
