using Microsoft.Extensions.Configuration;
using Venus.Database.Contracts;
using Venus.Database.Models;
using Venus.Dto.Accounting;

namespace Venus.Database;

public class PurchaseRepo : BaseRepository, IPurchaseRepo
{
    public PurchaseRepo(IConfiguration configuration) : base(configuration)
    {
    }

    public Task<PurchaseModel> CreatePurchase(string userId, CreatePurchaseDto purchase)
    {
        throw new NotImplementedException();
    }

    public Task<List<PurchaseModel>> GetPurchases(string userId)
    {
        throw new NotImplementedException();
    }
}