namespace Venus.Dto.Accounting;

public class CreatePurchaseDto
{
    public int? TagId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public string Currency { get; set; }
}