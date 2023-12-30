namespace Venus.Dto.Accounting;

public class PurchaseViewDto : PurchaseDto
{
    /// <summary>
    /// Purchase identifier
    /// </summary>
    /// <example>1c1e8535-4693-40da-9b5b-f7a172493964</example>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Purchase Date 
    /// </summary>
    /// <example>2023-10-05T14:48:00.000Z</example>
    public DateTime Date { get; set; }
    
    /// <summary>
    /// List of tags attached to this purchase
    /// </summary>
    /// <example>[1, 4, 7]</example>
    public List<PurchaseTagDto> Tags { get; set; }
}