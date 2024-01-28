using Venus.Database.Contracts;
using Venus.Domain.Contracts;
using Venus.Dto.Configuration;

namespace Venus.Domain;

public class ConfigurationService(IConfigurationRepo configurationRepo) : IConfigurationService
{
    public async Task<ConfigurationDto> GetConfiguration()
    {
        return await configurationRepo.GetConfiguration();
    }
}