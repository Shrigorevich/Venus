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
        await using var conn = Connection();
        string sql;
        
        sql = string.Format("SELECT * from create_challenge({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8})", 
            $"'{userId}'", 
            $"'{purchase.Name}'", 
            $"{purchase.Price}", 
            string.IsNullOrEmpty(purchase.Currency) ? "null" : $"'{purchase.Currency}'",
            $"{purchase.TagIds}",
            $"{purchase.Discount}",
            string.IsNullOrEmpty(purchase.Unit) ? "null" : $"'{purchase.Unit}'",
            purchase.Quantity,
            string.IsNullOrEmpty(purchase.Description) ? "null" : $"'{purchase.Description}'");
        
        var result = await conn.QuerySingleAsync<PurchaseModel>(sql);
        return result;
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