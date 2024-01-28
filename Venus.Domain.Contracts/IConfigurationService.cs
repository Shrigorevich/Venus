using Venus.Dto.Configuration;

namespace Venus.Domain.Contracts;

public interface IConfigurationService
{
    Task<ConfigurationDto> GetConfiguration();
}