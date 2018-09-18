using System;
using System.Collections.Generic;
using BlackJack.DataAccessLayer.EF;
using BlackJack.Entities;
using BlackJack.DataAccessLayer.Interfaces;
using System.Data.Entity;
using BlackJack.DataAccessLayer.Repositories.BaseRepository;

namespace BlackJack.DataAccessLayer.Repositories
{
    public class StepRepository : BaseRepository<Step>, IStepRepository
    {
        public StepRepository(DatabaseContext context)
            :base(context)
        {

        }
    }
}


