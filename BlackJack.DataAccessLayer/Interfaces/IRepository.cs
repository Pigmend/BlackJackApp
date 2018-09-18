using System;
using System.Collections.Generic;


namespace BlackJack.DataAccessLayer.Interfaces
{
    public interface IRepository<T>
        where T : class
    {

        void Create(T item);
        T Get(int id);
        void Update(T item);
        void Delete(int id);
        IEnumerable<T> GetAll();
        void SaveChanges();
    }
}
