using Venus.Dto.Configuration;

namespace Venus.Database.Contracts;

public interface IConfigurationRepo
{ 
    Task<ConfigurationDto> GetConfiguration();
}