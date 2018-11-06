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
    public class GameRepository : BaseRepository<Game>, IGameRepository
    {
        public GameRepository(string connection)
            : base(connection)
        {

        }

        public IEnumerable<Game> SelectGamesByUserId(long userId)
        {
            IEnumerable<Game> games;
            var query = $"SELECT * FROM [{typeof(Game).Name}] WHERE UserId = {userId}";

            using(IDbConnection db = _sqlConnectionString.CreateConnection())
            {
                db.Open();
                games = db.Query<Game>(query);
            }

            return games;
        }


    }
}
