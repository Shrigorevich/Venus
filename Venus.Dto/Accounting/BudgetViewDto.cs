namespace Venus.Dto.Accounting;

/// <summary>
/// Represents budget view info
/// </summary>
public class BudgetViewDto : BudgetDto
{
    /// <summary>
    /// Budget identifier
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Tags linked to the budget
    /// </summary>
    /// <example>[2, 4]</example>
    public required List<TagDto> Tags { get; set; }
    
    /// <summary>
    /// Budget currency
    /// </summary>
    public required CurrencyDto Currency { get; set; }
    
    /// <summary>
    /// Amount spent for a certain period
    /// </summary>
    /// <example>3402</example>
    public decimal SpentAmount { get; set; }
}