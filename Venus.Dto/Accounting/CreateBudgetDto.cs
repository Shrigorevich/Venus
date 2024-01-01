namespace Venus.Dto.Accounting;

/// <summary>
/// Represents required info to create budget
/// </summary>
public class CreateBudgetDto : BudgetDto
{
    /// <summary>
    /// Currency identifier
    /// </summary>
    /// <example>1</example>
    public required string CurrencyId { get; set; }
    
    /// <summary>
    /// Tags linked to the budget
    /// </summary>
    /// <example>[2, 4]</example>
    public required int[] TagIds { get; set; }
}