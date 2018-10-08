using System;
using System.Collections.Generic;
using System.Linq;
using BlackJack.DataAccess.EF;
using BlackJack.Entities;
using BlackJack.DataAccess.Interfaces;
using System.Data.Entity;
using BlackJack.DataAccess.Repositories.BaseRepository;

namespace BlackJack.DataAccess.Repositories
{
    public class StepRepository : BaseRepository<Step>, IStepRepository
    {
        public StepRepository(DatabaseContext context)
            :base(context)
        {

        }

        public IEnumerable<Step> GetStepByGameID(int id)
        {
            List<Step> steps = _dbSet.Where(e => e.GameID == id).ToList();

            return steps;
        }

    }
}


