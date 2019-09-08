using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using Dapper;

namespace StoryTale.Core.Database
{
    public class Queries
    {
        private readonly ConnectionManager _connectionManager;

        public Queries(ConnectionManager connectionManager)
        {
            _connectionManager = connectionManager;
        }

        public Task<IEnumerable<T>> QueryAsync<T>(string sql, object parameters = default, CancellationToken token = default)
        {
            return With(connection => connection.QueryAsync<T>(sql, parameters), token);
        }

        public Task<IEnumerable<T>> QuerySpAsync<T>(string sql, object parameters = default, CancellationToken token = default)
        {
            return With(connection => connection.QueryAsync<T>(sql, parameters, commandType: CommandType.StoredProcedure), token);
        }

        private async Task<T> With<T>(Func<IDbConnection, Task<T>>  func, CancellationToken token)
        {
            using var connection = _connectionManager.GetDb();

            connection.Open();

            token.ThrowIfCancellationRequested();

            return await func(connection);
        }
    }
}