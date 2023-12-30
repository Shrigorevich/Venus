using Venus.Dto.Accounting;

namespace Venus.Domain;

public interface IPurchaseService
{
    Task<PurchaseViewDto> CreatePurchase(string userId, CreatePurchaseDto purchase);
    
    Task<PurchaseViewDto> UpdatePurchase(string userId, Guid purchaseId, UpdatePurchaseDto purchase);
    
    Task<List<PurchaseViewDto>> GetPurchases(string userId);
    
    Task DeletePurchase(string userId, Guid purchaseId);

    Task UpdatePurchaseTags(Guid purchaseId, int[] tagIds);
}