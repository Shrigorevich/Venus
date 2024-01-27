using System.Globalization;
using Dapper;
using Microsoft.Extensions.Configuration;
using Venus.Common;
using Venus.Common.Extentions;
using Venus.Database.Contracts;
using Venus.Database.Models;
using Venus.Database.Queries;
using Venus.Dto.Accounting;

namespace Venus.Database;

public class BudgetRepo(IConfiguration configuration) : BaseRepository(configuration), IBudgetRepo
{
    public async Task<BudgetModel> CreateBudget(string userId, CreateBudgetDto budget)
    {
        await using var conn = Connection();
        
        var ci = new CultureInfo("uk");
        var start = DateTime.Now.PeriodStart(ci, budget.Period);
        var end = DateTime.Now.PeriodEnd(ci, budget.Period);
        
        var result = await conn.QuerySingleAsync<BudgetModel>(BudgetQueries.CreateBudget(), new {
            userId,
            start,
            end,
            name = budget.Name,
            amount = budget.PlannedAmount,
            period = (int) budget.Period,
            currencyId = budget.CurrencyId,
            tagIds = budget.TagIds,
        });
        
        return result;
    }

    public async Task<BudgetModel> UpdateBudget(string userId, Guid budgetId, CreateBudgetDto budget)
    {
        await using var conn = Connection();
        
        var ci = new CultureInfo("uk");
        var start = DateTime.Now.PeriodStart(ci, budget.Period);
        var end = DateTime.Now.PeriodEnd(ci, budget.Period);
        
        var result = await conn.QuerySingleAsync<BudgetModel>(BudgetQueries.CreateBudget(), new {
            userId,
            start,
            end,
            id = budgetId,
            name = budget.Name,
            amount = budget.PlannedAmount,
            period = (int) budget.Period,
            currencyId = budget.CurrencyId,
            tagIds = budget.TagIds,
        });
        
        return result;
    }

    public async Task<List<BudgetModel>> GetBudgets(string userId)
    {
        await using var conn = Connection();
        
        var result = await conn.QueryAsync<BudgetModel>(BudgetQueries.GetBudgets(), new {
            userId
        });
        
        return result.ToList();
    }

    public async Task DeleteBudget(Guid budgetId)
    {
        await using var conn = Connection();
        
        await conn.ExecuteAsync("DELETE FROM budget WHERE id = @budgetId", new
        { 
            budgetId
        });
    }
}