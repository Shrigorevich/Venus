using Venus.Dto.Accounting;

namespace Venus.Domain;

public interface IPurchaseService
{
    Task<PurchaseDto> CreatePurchase(string userId, CreatePurchaseDto purchase);

    Task<List<PurchaseDto>> GetPurchases(string userId);

    Task AddPurchaseTag(Guid purchaseId, int tagId);
}