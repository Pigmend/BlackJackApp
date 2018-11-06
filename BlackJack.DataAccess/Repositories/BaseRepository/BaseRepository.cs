using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Data.SqlClient;
using System.Threading.Tasks;
using BlackJack.Entities;
using BlackJack.DataAccess.Interfaces;
using BlackJack.DataAccess.EF;
using Dapper;

namespace BlackJack.DataAccess.Repositories.BaseRepository
{
    public class BaseRepository<T> : IRepository<T>
        where T : class
    {
        protected DatabaseConnection _sqlConnectionString;

        public BaseRepository(string connection)
        {
            DatabaseConnection DbConnection = new DatabaseConnection(connection);
            _sqlConnectionString = DbConnection;
        }

        public long CreateAndReturnId(T item)
        {
            long id;
            var columns = GetColumns();
            var stringOfColumns = string.Join(", ", columns);
            var stringOfParameters = string.Join(", ", columns.Select(e => "@" + e));
            var query = $"INSERT INTO [{typeof(T).Name}] ({stringOfColumns}) VALUES ({stringOfParameters}) SELECT CAST(SCOPE_IDENTITY() as int)";

            using (IDbConnection db = _sqlConnectionString.CreateConnection())
            {
                db.Open();
                id = db.Query<int>(query, item).Single();
            }
            return id;
        }

        public T Get(long id)
        {
            var query = $"SELECT * FROM [{typeof(T).Name}] WHERE Id = {id}";
            using(IDbConnection db = _sqlConnectionString.CreateConnection())
            {
                db.Open();
                return db.QueryFirstOrDefault<T>(query);
            }
        }

        public void Update(T item)
        {
            var columns = GetColumns();
            var stringOfColumns = string.Join(", ", columns.Select(e => $"{e} = @{e}"));
            var query = $"UPDATE [{typeof(T).Name}] SET {stringOfColumns} WHERE Id = @Id";

            using(IDbConnection db = _sqlConnectionString.CreateConnection())
            {
                db.Open();
                db.Query(query, item);
            }
        }

        public void Delete(long id)
        {
            var query = $"DELETE FROM [{typeof(T).Name}] where Id = @Id";

            using(IDbConnection db = _sqlConnectionString.CreateConnection())
            {
                db.Open();
                db.Query(query, id);
            }
        }

        public IEnumerable<T> GetAll()
        {
            var query = $"SELECT * FROM [{typeof(T).Name}]";
            IEnumerable<T> allEntities;

            using(IDbConnection db = _sqlConnectionString.CreateConnection())
            {
                db.Open();
                allEntities = db.Query<T>(query);
            }
            return allEntities;
        }

        protected IEnumerable<string> GetColumns()
        {
            return typeof(T)
                .GetProperties()
                .Where(e => e.Name != "Id" && !e.PropertyType.GetTypeInfo().IsGenericType)
                .Select(e => e.Name);
        }
    }
}
