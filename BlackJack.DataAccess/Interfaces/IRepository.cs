using System;
using System.Collections.Generic;


namespace BlackJack.DataAccess.Interfaces
{
    public interface IRepository<T>
        where T : class
    {

        void Create(T item);
        T Get(long id);
        void Update(T item);
        void Delete(long id);
        IEnumerable<T> GetAll();
        void SaveChanges();
    }
}
