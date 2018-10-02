using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.DataAccess.EF;
using BlackJack.Entities;
using BlackJack.DataAccess.Interfaces;
using System.Data.Entity;

namespace BlackJack.DataAccess.Repositories.BaseRepository
{
    public class BaseRepository<T> : IRepository<T>
        where T : class
    {
        private DatabaseContext _db;
        protected DbSet<T> _dbSet;

        public BaseRepository(DatabaseContext context)
        {
            _db = context;
            _dbSet = context.Set<T>();
        }

        public void Create(T item)
        {
            _dbSet.Add(item);
        }

        public T Get(long id)
        {
            return _dbSet.Find(id);
        }

        public void Update(T item)
        {
            _db.Entry(item).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public void Delete(long id)
        {
            T item = _dbSet.Find(id);
            if (item != null)
            {
                _dbSet.Remove(item);
            }
        }

        public IEnumerable<T> GetAll()
        {
            IEnumerable<T> items = _dbSet.ToList();
            return items;
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }

    }
}
