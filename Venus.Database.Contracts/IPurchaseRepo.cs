using Venus.Database.Models;
using Venus.Dto.Accounting;

namespace Venus.Database.Contracts;

public interface IPurchaseRepo
{
    Task<PurchaseModel> CreatePurchase(string userId, CreatePurchaseDto purchase);

    Task<List<PurchaseModel>> GetPurchases(string userId);

    Task AddPurchaseTag(Guid purchaseId, int tagId);
}