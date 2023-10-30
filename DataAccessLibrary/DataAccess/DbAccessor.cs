using Dapper;
using System.Data;
using Microsoft.Data.SqlClient;

namespace MVCSkillsShowcaseDataLibrary.DataAccess
{
    internal class DbAccessor
    {
        private readonly string _dbConnectionString;

        public DbAccessor(string dbConnectionString)
        {
            _dbConnectionString = dbConnectionString;
        }

        public IEnumerable<T> LoadData<T>(string sql)
        {
            using (IDbConnection cnn = new SqlConnection(_dbConnectionString))
            {
                return cnn.Query<T>(sql);
            }
        }

        public int SaveData<T>(string sql, T data)
        {
            using (IDbConnection cnn = new SqlConnection(_dbConnectionString))
            {
                return cnn.Execute(sql,data);
            }
        }

        public IEnumerable<T3> MultiMapLoadData<T1, T2, T3>(string sql, Func<T1, T2, T3> mapper, string splitOn)
        {
            using (IDbConnection cnn = new SqlConnection(_dbConnectionString))
            {
                return cnn.Query(sql, mapper, splitOn: splitOn);
            }
        }

        public void ExecuteSql(string sql)
        {
            using (IDbConnection cnn = new SqlConnection(_dbConnectionString))
            {
                cnn.Execute(sql);
            }
        }
    }
}
