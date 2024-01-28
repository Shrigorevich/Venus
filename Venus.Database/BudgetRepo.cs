using System.Globalization;
using Dapper;
using Microsoft.Extensions.Configuration;
using Venus.Common;
using Venus.Common.Extensions;
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
        
        var start = DateTime.Now.PeriodStart(budget.Period);
        var end = DateTime.Now.PeriodEnd(budget.Period);
        
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
        
        var start = DateTime.Now.PeriodStart(budget.Period);
        var end = DateTime.Now.PeriodEnd(budget.Period);
        
        var result = await conn.QuerySingleAsync<BudgetModel>(BudgetQueries.UpdateBudget(), new {
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

        var startDates = new string[4];
        var endDates = new string[4];
        var index = 0;
        foreach (BudgetPeriod p in Enum.GetValues(typeof(BudgetPeriod)))
        {
            startDates.SetValue(DateTime.Now.PeriodStart(p), index);
            endDates.SetValue(DateTime.Now.PeriodEnd(p), index);
            index++;
        }
        
        var result = await conn.QueryAsync<BudgetModel>(BudgetQueries.GetBudgets(), new {
            userId,
            startDates,
            endDates
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