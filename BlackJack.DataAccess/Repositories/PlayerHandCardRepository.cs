using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using BlackJack.Entities;
using BlackJack.DataAccess.Interfaces;
using BlackJack.DataAccess.Repositories.BaseRepository;
using Dapper;

namespace BlackJack.DataAccess.Repositories
{
    public class PlayerHandCardRepository: BaseRepository<PlayerHandCard>, IPlayerHandCardRepository
    {
        public PlayerHandCardRepository(string connection)
            :base(connection)
        {

        }

        public void BindPlayerHandWithPlayerHandCard(long PlayerHandID, long CardID)
        {
            var query = $@"INSERT INTO [{typeof(PlayerHandCard).Name}](PlayerHandId, CardId)
                           VALUES({PlayerHandID},{CardID})";
            using (IDbConnection db = _sqlConnectionString.CreateConnection())
            {
                db.Open();
                db.Query(query);
            }
        }
    }
}
