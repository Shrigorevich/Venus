using System.Data;
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

        var sql = $"SELECT * from create_purchase(@user_id, '{purchase.Date}', @name, @price, @currency_id, @tag_ids, @discount, @unit_id, @quantity, @description)";
        
        var parameter = new DynamicParameters();
        parameter.Add("@user_id", userId, DbType.StringFixedLength);
        parameter.Add("@name", purchase.Name, DbType.StringFixedLength);
        parameter.Add("@price", purchase.Price, DbType.Decimal);
        parameter.Add("@currency_id", purchase.CurrencyId, DbType.Int32);
        parameter.Add("@tag_ids", purchase.TagIds, DbType.Object);
        parameter.Add("@discount", purchase.Discount, DbType.Decimal);
        parameter.Add("@unit_id", purchase.UnitId, DbType.Int32);
        parameter.Add("@quantity", purchase.Quantity, DbType.Decimal);
        parameter.Add("@description", purchase.Description, DbType.StringFixedLength);

        var result = await conn.QuerySingleAsync<PurchaseModel>(sql, parameter);
        
        return result;
    }

    public async Task<PurchaseModel> UpdatePurchase(string userId, Guid purchaseId, UpdatePurchaseDto purchase)
    {
        await using var conn = Connection();

        var sql = $"SELECT * from update_purchase(@userId, @purchaseId, '{purchase.Date}', @name, @price, @currency_id, @discount, @unit_id, @quantity, @description)";
        
        var parameter = new DynamicParameters();
        parameter.Add("@userId", userId, DbType.StringFixedLength);
        parameter.Add("@purchaseId", purchaseId, DbType.Guid);
        parameter.Add("@name", purchase.Name, DbType.StringFixedLength);
        parameter.Add("@price", purchase.Price, DbType.Decimal);
        parameter.Add("@currency_id", purchase.CurrencyId, DbType.Int32);
        parameter.Add("@discount", purchase.Discount, DbType.Decimal);
        parameter.Add("@unit_id", purchase.UnitId, DbType.Int32);
        parameter.Add("@quantity", purchase.Quantity, DbType.Decimal);
        parameter.Add("@description", purchase.Description, DbType.StringFixedLength);

        var result = await conn.QuerySingleAsync<PurchaseModel>(sql, parameter);
        
        return result;
    }

    public async Task<List<PurchaseModel>> GetPurchases(string userId)
    {
        await using var conn = Connection();
        var sql = $"SELECT * from get_purchases('{userId}')";
        
        var result = await conn.QueryAsync<PurchaseModel>(sql);
        return result.ToList();
    }

    public async Task DeletePurchase(string userId, Guid purchaseId)
    {
        await using var conn = Connection();
        const string sql = $"DELETE FROM purchase WHERE user_id = @userId and id = @purchaseId";
        
        var parameter = new DynamicParameters();
        parameter.Add("@purchaseId", purchaseId, DbType.Guid);
        parameter.Add("@userId", userId, DbType.String);
        
        await conn.ExecuteAsync(sql, parameter);
    }

    public async Task UpdatePurchaseTags(Guid purchaseId, int[] tagIds)
    {
        await using var conn = Connection();

        const string sql = "SELECT * from update_purchase_tags(@purchaseId, @tagIds)";
        
        var parameter = new DynamicParameters();
        parameter.Add("@purchaseId", purchaseId, DbType.Guid);
        parameter.Add("@tagIds", tagIds, DbType.Object);

        await conn.ExecuteAsync(sql, parameter);
    }
}