using System;
using System.Collections.Generic;
using BlackJack.DataAccess.EF;
using BlackJack.Entities;
using BlackJack.DataAccess.Interfaces;
using System.Data.Entity;
using BlackJack.DataAccess.Repositories.BaseRepository;

namespace BlackJack.DataAccess.Repositories
{
    public class DeckRepository : BaseRepository<DeckCard>, IDeckRepository
    {
        public DeckRepository(DatabaseContext context)
            : base(context)
        {

        }

    }
}

