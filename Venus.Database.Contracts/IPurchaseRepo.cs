using Venus.Database.Models;
using Venus.Dto.Accounting;

namespace Venus.Database.Contracts;

public interface IPurchaseRepo
{
    Task<PurchaseModel> CreatePurchase(string userId, CreatePurchaseDto purchase);

    Task<PurchaseModel> UpdatePurchase(string userId, Guid purchaseId, PurchaseDto purchase);

    Task<List<PurchaseModel>> GetPurchases(string userId);

    Task DeletePurchase(string userId, Guid purchaseId);

    Task UpdatePurchaseTags(Guid purchaseId, int[] tagIds);
}