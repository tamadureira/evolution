using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace EvolutionAPI.Infrastructure.Dapper
{
    public class EvolutionContextDapper
    {
        private readonly string connectionString;
        public EvolutionContextDapper(string conn)
        {
            connectionString = conn;
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }

        public IEnumerable<T> Query<T>(string sql, object param = null)
        {
            return Connection.Query<T>(sql, param);
        }

        public int Execute(string sql, object param = null)
        {
            return Connection.Execute(sql, param);
        }

        public T ExecuteScalar<T>(string sql, object param = null)
        {
            return Connection.ExecuteScalar<T>(sql, param);
        }
    }
}