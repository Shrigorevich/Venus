namespace Venus.Dto.Accounting;

/// <summary>
/// Represents info needed to create a purchase
/// </summary>
public class CreatePurchaseDto : PurchaseDto
{
    /// <summary>
    /// Ids of tags attached to this purchase
    /// </summary>
    /// <example>[1, 4, 7]</example>
    public int[]? TagIds { get; set; } = Array.Empty<int>();
    
    /// <summary>
    /// Date representation in ISO format
    /// </summary>
    /// <example>2023-10-05</example>
    public string Date { get; set; }
}