using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using BlackJack.DataAccessLayer.EF;
using BlackJack.Entities;
using BlackJack.DataAccessLayer.Interfaces;
using BlackJack.DataAccessLayer.Repositories.BaseRepository;

namespace BlackJack.DataAccessLayer.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(DatabaseContext context)
            :base(context)
        {

        }

        public User ReturnLastUser()
        {
            User item =_db.Users.LastOrDefault();
            return item;
        }
    }
}


