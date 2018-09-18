using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJack.DataAccessLayer.EF;
using BlackJack.Entities;
using BlackJack.DataAccessLayer.Interfaces;
using System.Data.Entity;

namespace BlackJack.DataAccessLayer.Repositories.BaseRepository
{
    public class BaseRepository<T> : IRepository<T>
        where T : class
    {
        protected DatabaseContext _db;

        public BaseRepository(DatabaseContext context)
        {
            this._db = context;
        }

        public void Create(T item)
        {
            _db.Set<T>().Add(item);
        }

        public T Get(int id)
        {
            return _db.Set<T>().Find(id);
        }

        public void Update(T item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            T item = _db.Set<T>().Find(id);
            if (item != null)
            {
                _db.Set<T>().Remove(item);
            }
        }

        public IEnumerable<T> GetAll()
        {
            IEnumerable<T> items = _db.Set<T>();
            return items;
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }

    }
}
