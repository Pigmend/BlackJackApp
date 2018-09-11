using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BlackJack.DAL.EF;
using BlackJack.Entities;
using BlackJack.DAL.Interfaces;

namespace BlackJack.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private DatabaseContext db;

        public UserRepository(DatabaseContext context)
        {
            this.db = context;
        }

        public void Create(User user)
        {
            db.users.Add(user);
        }

        public User Get(int id)
        {
            return db.users.Find(id);
        }

        public void Update(User user)
        {
            db.Entry(user).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            User user = db.users.Find(id);
            if (user != null)
            {
                db.users.Remove(user);
            }
        }

        public IEnumerable<User> GetAll()
        {
            return db.users;
        }


        //Exicting user
        public bool IsExists(User user)
        {
            foreach(User entity in db.users)
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
            foreach(User entity in db.users)
            {
                if(entity.ID == id)
                {
                    return true;
                }
            }
            return false;
        }

        public User ReturnLastUser()
        {
            IEnumerable<User> userTable = db.users;
            int lastUser = userTable.Count();

            return db.users.Find(lastUser - 1);
        }

    }
}


