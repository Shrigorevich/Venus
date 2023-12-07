using Venus.Dto.Accounting;

namespace Venus.Domain;

public class PurchaseService : IPurchaseService
{
    public Task<PurchaseDto> CreatePurchase(string userId, CreatePurchaseDto purchase)
    {
        throw new NotImplementedException();
    }

    public Task<List<PurchaseDto>> GetPurchases(string userId)
    {
        throw new NotImplementedException();
    }
}