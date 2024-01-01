namespace Venus.Dto.Accounting;

/// <summary>
/// Represents currency info
/// </summary>
public class CurrencyDto
{
    /// <summary>
    /// Currency identifier
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Currency code 
    /// </summary>
    /// <example>UAH</example>
    public required string Code { get; set; }
    
    /// <summary>
    /// Ukrainian Hryvnia 
    /// </summary>
    public required string Name { get; set; }
}