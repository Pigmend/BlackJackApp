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
        private DatabaseContext db;

        public UserRepository(DatabaseContext context)
        {
            this.db = context;
        }

        public void Create(User user)
        {
            db.Users.Add(user);
        }

        public User Get(int id)
        {
            return db.Users.Find(id);
        }

        public void Update(User user)
        {
            db.Entry(user).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            User user = db.Users.Find(id);
            if (user != null)
            {
                db.Users.Remove(user);
            }
        }

        public IEnumerable<User> GetAll()
        {
            return db.Users;
        }


        //Exicting user
        public bool IsExists(User user)
        {
            foreach(User entity in db.Users)
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
            foreach(User entity in db.Users)
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
            IEnumerable<User> userTable = db.Users;
            int lastUser = userTable.Count();

            return db.Users.ElementAt(lastUser - 1);
        }

    }
}


