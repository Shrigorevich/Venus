namespace Venus.Dto.Accounting;

/// <summary>
/// Represents budget view info
/// </summary>
public class BudgetViewDto : BudgetDto
{
    /// <summary>
    /// Tags linked to the budget
    /// </summary>
    /// <example>[2, 4]</example>
    public required List<TagDto> Tags { get; set; }
    
    /// <summary>
    /// Budget currency
    /// </summary>
    public required CurrencyDto Currency { get; set; }
}