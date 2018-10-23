using System.Configuration;
using System.Data;
using System.Data.SqlClient;    

namespace BlackJack.DataAccess.Repositories.BaseRepository
{
    public class DatabaseConnection
    {
        private string _sqlConnection;

        public DatabaseConnection(string name)
        {
            _sqlConnection = GetConnectionStringByName(name);
        }

        private string GetConnectionStringByName(string name)
        {
            string connectionstring = null;
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[name];
            if (settings != null)
            {
                connectionstring = settings.ConnectionString;
            }

            return connectionstring;
        }

        public SqlConnection CreateConnection()
        {
            var connection = new SqlConnection(_sqlConnection);

            return connection;
        }
    }
}
