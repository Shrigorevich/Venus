namespace Venus.Dto.Accounting;

public class PurchaseDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public decimal Discount { get; set; }
    public string Unit { get; set; }
    public decimal Quantity { get; set; }
    public string Currency { get; set; }
    public List<PurchaseTagDto> Tags { get; set; }
}