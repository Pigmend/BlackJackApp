using System;
using System.Collections.Generic;
using BlackJack.DataAccessLayer.EF;
using BlackJack.Entities;
using BlackJack.DataAccessLayer.Interfaces;
using System.Data.Entity;

namespace BlackJack.DataAccessLayer.Repositories
{
    public class StepRepository : IStepRepository
    {
        private DatabaseContext _db;

        public StepRepository(DatabaseContext context)
        {
            this._db = context;
        }

        public void Create(Step step)
        {
            _db.Steps.Add(step);
        }

        public Step Get(int id)
        {
            return _db.Steps.Find(id);
        }

        public void Update(Step step)
        {
            _db.Entry(step).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Step step = _db.Steps.Find(id);
            if (step != null)
            {
                _db.Steps.Remove(step);
            }
        }

        public IEnumerable<Step> GetAll()
        {
            return _db.Steps;
        }

    }
}


