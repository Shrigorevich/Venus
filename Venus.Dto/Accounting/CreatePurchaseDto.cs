namespace Venus.Dto.Accounting;

/// <summary>
/// Represents info needed to create a purchase
/// </summary>
public class CreatePurchaseDto
{
    /// <summary>
    /// Purchase name
    /// </summary>
    /// <example>Chicken</example>
    public string Name { get; set; }
    
    /// <summary>
    /// Purchase description
    /// </summary>
    /// <example>Good purchase</example>
    public string Description { get; set; }
    
    /// <summary>
    /// Price
    /// </summary>
    public decimal Price { get; set; }
    
    /// <summary>
    /// Discount amount
    /// </summary>
    public decimal Discount { get; set; }
    
    /// <summary>
    /// Item quantity
    /// </summary>
    public decimal Quantity { get; set; }
    
    /// <summary>
    /// Unit measurement (kg, g, L, etc.)
    /// </summary>
    /// <example>L</example>
    public string Unit { get; set; }
    
    /// <summary>
    /// Currency code (USD, UAH, EUR etc.)
    /// </summary>
    /// <example>UAH</example>
    public string Currency { get; set; }
    
    /// <summary>
    /// Ids of tags attached to this purchase
    /// </summary>
    /// <example>[1, 4, 7]</example>
    public int[] TagIds { get; set; }
}