using Venus.Dto.Accounting;

namespace Venus.Dto.Configuration;

/// <summary>
/// Currency representation
/// </summary>
public class ConfigurationDto
{
    /// <summary>
    /// List of supported currencies
    /// </summary>
    public required IEnumerable<CurrencyDto> Currencies { get; set; }
    
    /// <summary>
    /// List of supported units
    /// </summary>
    public required IEnumerable<UnitDto> Units { get; set; }
}