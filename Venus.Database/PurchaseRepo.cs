using Dapper;
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

    public async Task<PurchaseModel> CreatePurchase(string userId, CreatePurchaseDto purchase)
    {
        throw new NotImplementedException();
    }

    public async Task<List<PurchaseModel>> GetPurchases(string userId)
    {
        await using var conn = Connection();
        var sql = $"SELECT * from get_purchases('{userId}')";
        
        var result = await conn.QueryAsync<PurchaseModel>(sql);
        return result.ToList();
    }

    public async Task AddPurchaseTag(Guid purchaseId, int tagId)
    {
        await using var conn = Connection();
        var sql = $"INSERT INTO purchase_tag (purchase_id, tag_id) VALUES ('{purchaseId}', {tagId})";
        await conn.ExecuteAsync(sql);
    }
}