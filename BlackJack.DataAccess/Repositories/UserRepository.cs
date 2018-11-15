using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Data.SqlClient;
using System.Threading.Tasks;
using BlackJack.Entities;
using BlackJack.DataAccess.Interfaces;
using BlackJack.DataAccess.Repositories.BaseRepository;
using Dapper;

namespace BlackJack.DataAccess.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(string connection)
            : base(connection)
        {

        }

        public bool Exists(User user)
        {
            var query = $"SELECT 1 FROM [{typeof(User).Name}] " +
                $"WHERE Name = @Name";
            using (IDbConnection db = _sqlConnectionString.CreateConnection())
            {
                db.Open();
                return db.ExecuteScalar<bool>(query, user);
            }
        }

        public User Get(string Username)
        {
            var query = $"SELECT * FROM [{typeof(User).Name}] " +
                $"WHERE Name = '{Username}'";
            using (IDbConnection db = _sqlConnectionString.CreateConnection())
            {
                db.Open();
                return db.QueryFirstOrDefault<User>(query);
            }
        }
    }
}


