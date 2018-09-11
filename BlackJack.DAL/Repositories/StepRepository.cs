using System;
using System.Collections.Generic;
using BlackJack.DAL.EF;
using BlackJack.Entities;
using BlackJack.DAL.Interfaces;
using System.Data.Entity;

namespace BlackJack.DAL.Repositories
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
            db.steps.Add(step);
        }

        public Step Get(int id)
        {
            return db.steps.Find(id);
        }

        public void Update(Step step)
        {
            db.Entry(step).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            Step step = db.steps.Find(id);
            if (step != null)
            {
                db.steps.Remove(step);
            }
        }

        public IEnumerable<Step> GetAll()
        {
            return db.steps;
        }

    }
}


