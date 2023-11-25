namespace Venus.Dto.Accounting;

public class CreatePurchaseDto
{
    public int? CategoryId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string Currency { get; set; }
}