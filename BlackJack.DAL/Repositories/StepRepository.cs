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
        private DatabaseContext db;

        public StepRepository(DatabaseContext context)
        {
            this.db = context;
        }

        public void Create(Step step)
        {
            db.Steps.Add(step);
        }

        public Step Get(int id)
        {
            return db.Steps.Find(id);
        }

        public void Update(Step step)
        {
            db.Entry(step).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Step step = db.Steps.Find(id);
            if (step != null)
            {
                db.Steps.Remove(step);
            }
        }

        public IEnumerable<Step> GetAll()
        {
            return db.Steps;
        }

    }
}


