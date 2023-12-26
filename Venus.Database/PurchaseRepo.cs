﻿using System.Data;
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

        const string sql = "SELECT * from create_purchase(@user_id, @name, @price, @currency, @tag_ids, @discount, @unit, @quantity, @description)";
        
        var parameter = new DynamicParameters();
        parameter.Add("@user_id", userId, DbType.StringFixedLength);
        parameter.Add("@name", purchase.Name, DbType.StringFixedLength);
        parameter.Add("@price", purchase.Price, DbType.Decimal);
        parameter.Add("@currency", purchase.Currency, DbType.StringFixedLength);
        parameter.Add("@tag_ids", purchase.TagIds, DbType.Object);
        parameter.Add("@discount", purchase.Discount, DbType.Decimal);
        parameter.Add("@unit", purchase.Unit, DbType.StringFixedLength);
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

    public async Task AddPurchaseTag(Guid purchaseId, int tagId)
    {
        await using var conn = Connection();
        var sql = $"INSERT INTO purchase_tag (purchase_id, tag_id) VALUES ('{purchaseId}', {tagId})";
        await conn.ExecuteAsync(sql);
    }
}