namespace Venus.Dto.Accounting;

/// <summary>
/// Unit representation
/// </summary>
public class UnitDto
{
    /// <summary>
    /// Unit identifier
    /// </summary>
    /// <example>1</example>
    public int Id { get; set; }
    
    /// <summary>
    /// Unit code (kg, g, L, ml)
    /// </summary>
    /// <example>kg</example>
    public required string Code { get; set; }
    
    /// <summary>
    /// Unit description
    /// </summary>
    /// <example>Kilogram</example>
    public required string Description { get; set; }
}