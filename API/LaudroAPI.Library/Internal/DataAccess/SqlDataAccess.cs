using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace LaundroAPI.Library.Internal.DataAccess
{
    internal class SqlDataAccess : IDisposable
    {
        private readonly IConfiguration _config;

        public SqlDataAccess(IConfiguration config)
        {
            _config = config;
        }

        public string GetConnectionString(string name)
        {
            return _config.GetConnectionString(name);
        }

        public async Task<List<T>> LoadDataAsync<T, U>(string storedProcedure, U parameters, string connectionsStringName)
        {
            string connectionString = GetConnectionString(connectionsStringName);
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                List<T> rows = (await connection.QueryAsync<T>(storedProcedure, parameters,
                    commandType: CommandType.StoredProcedure))
                    .ToList();
                return rows;
            }
        }

        public async Task SaveDataAsync<T>(string storedProcedure, T parameters, string connectionsStringName)
        {
            string connectionString = GetConnectionString(connectionsStringName);
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                await connection.ExecuteAsync(storedProcedure, parameters,
                    commandType: CommandType.StoredProcedure);

            }
        }

        public async Task<int> SaveDataReturnIdAsync<T>(string storedProcedure, T parameters, string connectionsStringName)
        {
            string connectionString = GetConnectionString(connectionsStringName);
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                int id = await connection.QueryFirstAsync<int>(storedProcedure, parameters,
                    commandType: CommandType.StoredProcedure);
                return id;

            }
        }

        private IDbConnection _connection;
        private IDbTransaction _transaction;
        public void StartTransaction(string connectionStringName)
        {
            string connectionString = GetConnectionString(connectionStringName);

            _connection = new SqlConnection(connectionString);
            _connection.Open();

            _transaction = _connection.BeginTransaction();

            isClosed = false;
        }

        public void SaveDataInTransaction<T>(string storedProcedure, T parameters)
        {
            _connection.Execute(storedProcedure, parameters,
               commandType: CommandType.StoredProcedure, transaction: _transaction);

        }
        private bool isClosed = false;

        public List<T> LoadDataInTransaction<T, U>(string storedProcedure, U parameters)
        {
            List<T> rows = _connection.Query<T>(storedProcedure, parameters,
                commandType: CommandType.StoredProcedure, transaction: _transaction).ToList();
            return rows;
        }
        public void CommitTransaction()
        {
            _transaction?.Commit();
            _connection?.Close();

            isClosed = true;
        }

        public void RollbackTransaction()
        {
            _transaction?.Rollback();
            _connection?.Close();

            isClosed = true;
        }

        public void Dispose()
        {
            if (!isClosed)
            {
                try
                {
                    CommitTransaction();

                }
                catch
                {
                    // TODO - Log this issue
                }
            }

            _transaction = null;
            _connection = null;
        }
    }
}
