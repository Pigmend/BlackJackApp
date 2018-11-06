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
    public class CardRepository : BaseRepository<Card>, ICardRepository
    {
        public CardRepository(string connection)
            :base(connection)
        {

        }

        public IEnumerable<Card> GetCardsByHandID(long ID)
        {
            IEnumerable<Card> cards;

            var query = $"SELECT * FROM [Card] WHERE Id IN (SELECT PlayerHandCard.CardId FROM PlayerHandCard WHERE PlayerHandId = {ID}); ";
            using (IDbConnection db = _sqlConnectionString.CreateConnection())
            {
                db.Open();
                cards = db.Query<Card>(query);
            }
            return cards;
        }
    }
}
