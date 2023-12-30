namespace Venus.Dto.Accounting;

public class UpdatePurchaseDto : PurchaseDto
{
    /// <summary>
    /// Date representation in ISO format
    /// </summary>
    /// <example>2023-10-05T14:48:00.000Z</example>
    public string Date { get; set; }
}