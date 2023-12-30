namespace Venus.Database.Models;

public class PurchaseModel
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public decimal Discount { get; set; }
    public string Unit { get; set; }
    public decimal Quantity { get; set; }
    public string Currency { get; set; }
    public string Tags { get; set; }
}