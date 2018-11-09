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
    public class PlayerHandRepository : BaseRepository<PlayerHand>, IPlayerHandRepository
    {
        public PlayerHandRepository(string connection)
            : base(connection)
        {

        }

        public void AddRange(IEnumerable<PlayerHand> items)
        {
            var columns = GetColumns();
            var stringOfColumns = string.Join(", ", columns);
            var stringOfParameters = string.Join(", ", columns.Select(e => "@" + e));

            var query = $"INSERT INTO [{typeof(PlayerHandRepository).Name}] ({stringOfColumns}) VALUES ({stringOfParameters})";
            using(IDbConnection db = _sqlConnectionString.CreateConnection())
            {
                db.Open();
                db.Query(query, items);
            }
        }

        public IEnumerable<PlayerHand> GetHandsByStepID(long StepID)
        {
            IEnumerable<PlayerHand> playerHands;

            var query = $"SELECT * FROM [{typeof(PlayerHand).Name}] WHERE StepId = {StepID}";
            using (IDbConnection db = _sqlConnectionString.CreateConnection())
            {
                db.Open();
                playerHands = db.Query<PlayerHand>(query);
            }

            return playerHands;
        }

        //Join Card with PlayerHand
        public void JoinCardWithHand(long PlayerHandID, long CardID)
        {
            var query = $"INSERT INTO [{typeof(PlayerHandCard).Name}](PlayerHandId, CardId) VALUES({PlayerHandID},{CardID})";
            using(IDbConnection db = _sqlConnectionString.CreateConnection())
            {
                db.Open();
                db.Query(query);
            }
        }
    }
}