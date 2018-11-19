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
    public class DeckRepository : BaseRepository<DeckCard>, IDeckRepository
    {
        public DeckRepository(string connection)
            : base(connection)
        {

        }

        public IEnumerable<DeckCard> GetCardsByHandID(long ID)
        {
            IEnumerable<DeckCard> cards;

            var query = $@"SELECT * FROM [{typeof(DeckCard).Name}]
                           WHERE Id IN (SELECT PlayerHandCard.CardId
                           FROM {typeof(PlayerHandCard).Name}
                           WHERE PlayerHandId = {ID});";
            using (IDbConnection db = _sqlConnectionString.CreateConnection())
            {
                db.Open();
                cards = db.Query<DeckCard>(query);
            }
            return cards;
        }
    }
}

