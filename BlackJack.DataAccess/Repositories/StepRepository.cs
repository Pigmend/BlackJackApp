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
    public class StepRepository : BaseRepository<Step>, IStepRepository
    {
        public StepRepository(string connection)
            : base(connection)
        {

        }

        public IEnumerable<Step> GetStepByGameID(long id)
        {
            IEnumerable<Step> steps;

            var query = $@"SELECT * FROM [{typeof(Step).Name}]
                           WHERE GameId = {id}";
            using(IDbConnection db = _sqlConnectionString.CreateConnection())
            {
                db.Open();
                steps = db.Query<Step>(query);
            }

            return steps;
        }

    }
}


