namespace Venus.Dto.Accounting;

/// <summary>
/// Basic purchase info
/// </summary>
public class PurchaseDto
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
    public string? Description { get; set; }
    
    /// <summary>
    /// Price
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Discount amount
    /// </summary>
    public decimal Discount { get; set; } = 0;

    /// <summary>
    /// Item quantity
    /// </summary>
    public decimal Quantity { get; set; } = 0;
    
    /// <summary>
    /// Unit measurement (kg, g, L, etc.)
    /// </summary>
    /// <example>L</example>
    public string? Unit { get; set; }
    
    /// <summary>
    /// Currency code (USD, UAH, EUR etc.)
    /// </summary>
    /// <example>UAH</example>
    public string Currency { get; set; }
}