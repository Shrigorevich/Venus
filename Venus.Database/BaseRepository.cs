using Microsoft.Extensions.Configuration;
using Npgsql;

namespace Venus.Database;

public abstract class BaseRepository
{

    private readonly NpgsqlDataSource _dataSource;

    protected BaseRepository(IConfiguration configuration)
    {
        var connString = configuration.GetConnectionString("Default");
        _dataSource = NpgsqlDataSource.Create(connString);
    }

    public NpgsqlConnection Connection()
    {
        return _dataSource.OpenConnection();
    }
}