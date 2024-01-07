using Venus.Common;

namespace Venus.Dto.Accounting;

/// <summary>
/// Represents budget info
/// </summary>
public class BudgetDto
{
    /// <summary>
    /// Budget name
    /// </summary>
    /// <example>Food</example>
    public required string Name { get; set; }

    /// <summary>
    /// Budget planned amount
    /// </summary>
    /// <example>4000</example>
    public decimal PlannedAmount { get; set; }

    /// <summary>
    /// Budget period
    /// Values:
    /// 1 - Week
    /// 2 - Month
    /// 3 - Quarter
    /// 4 - Year
    /// </summary>
    /// <example>2</example>
    public required BudgetPeriod Period { get; set; }
}