using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using BlackJack.DataAccessLayer.EF;
using BlackJack.Entities;
using BlackJack.DataAccessLayer.Interfaces;

namespace BlackJack.DataAccessLayer.Repositories
{
    public class UserRepository : IUserRepository
    {
        private DatabaseContext _db;

        public UserRepository(DatabaseContext context)
        {
            this._db = context;
        }

        public void Create(User user)
        {
            _db.Users.Add(user);
            _db.SaveChanges();
        }

        public User Get(int id)
        {
            return _db.Users.Find(id);
        }

        public void Update(User user)
        {
            _db.Entry(user).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            User user = _db.Users.Find(id);
            if (user != null)
            {
                _db.Users.Remove(user);
            }
        }

        public IEnumerable<User> GetAll()
        {
            return _db.Users;
        }

        public bool IsExists(User user)
        {
            foreach(User entity in _db.Users)
            {
                if(entity.Name == user.Name)
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsExists(int id)
        {
            

            return true;
        }

        public User ReturnLastUser()
        {
            User user = _db.Users.LastOrDefault();

            return user;
        }
    }
}


