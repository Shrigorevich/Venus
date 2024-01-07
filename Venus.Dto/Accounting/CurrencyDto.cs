namespace Venus.Dto.Accounting;

/// <summary>
/// Represents currency info
/// </summary>
public class CurrencyDto(int id, string code, string name)
{
    /// <summary>
    /// Currency identifier
    /// </summary>
    public int Id { get; set; } = id;

    /// <summary>
    /// Currency code 
    /// </summary>
    /// <example>UAH</example>
    public string Code { get; set; } = code;

    /// <summary>
    /// Ukrainian Hryvnia 
    /// </summary>
    public string Name { get; set; } = name;
}