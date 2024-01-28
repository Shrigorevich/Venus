using Dapper;
using Microsoft.Extensions.Configuration;
using Venus.Database.Contracts;
using Venus.Dto.Accounting;
using Venus.Dto.Configuration;

namespace Venus.Database;

public class ConfigurationRepo(IConfiguration configuration) : BaseRepository(configuration), IConfigurationRepo
{
    public async Task<ConfigurationDto> GetConfiguration()
    {
        await using var conn = Connection();
        
        var currencies = await conn.QueryAsync<CurrencyDto>("SELECT id, code, name FROM currency");
        var units = await conn.QueryAsync<UnitDto>("SELECT id, code, description FROM unit");

        return new ConfigurationDto
        {
            Currencies = currencies,
            Units = units
        };
    }
}