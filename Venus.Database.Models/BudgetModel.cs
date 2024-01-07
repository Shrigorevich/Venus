namespace Venus.Database.Models;

public class BudgetModel
{
    public Guid Id { get; set; }
    
    public required string Name { get; set; }
    
    public decimal PlannedAmount { get; set; }
    
    public decimal SpentAmount { get; set; }
    
    public int Period { get; set; }
    
    public required string Tags { get; set; }

    public int CurrencyId { get; set; }
    
    public string CurrencyName { get; set; }
    
    public string CurrencyCode { get; set; }
}