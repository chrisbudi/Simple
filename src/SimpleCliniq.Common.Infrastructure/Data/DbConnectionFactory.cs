using Npgsql;
using SimpleCliniq.Common.Application.Data;
using System.Data.Common;

namespace SimpleCliniq.Common.Infrastructure.Data;

internal sealed class DbConnectionFactory(NpgsqlDataSource dataSource) : IDbConnectionFactory
{
    public async ValueTask<DbConnection> OpenConnectionAsync()
    {
        return await dataSource.OpenConnectionAsync();
    }
}
