using Dapper;
using Microsoft.Extensions.Configuration;
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
        
        var result = await conn.QuerySingleAsync<BudgetModel>(BudgetQueries.CreateBudget(), new {
            userId,
            name = budget.Name,
            amount = budget.PlannedAmount,
            period = (int) budget.Period,
            currencyId = budget.CurrencyId,
            tagIds = budget.TagIds
        });
        
        return result;
    }

    public Task<BudgetModel> UpdateBudget(int budgetId, CreateBudgetDto budget)
    {
        throw new NotImplementedException();
    }

    public async Task<List<BudgetModel>> GetBudgets(string userId)
    {
        await using var conn = Connection();
        
        var result = await conn.QueryAsync<BudgetModel>(BudgetQueries.GetBudgets(), new {
            userId
        });
        
        return result.ToList();
    }

    public async Task DeleteBudget(int budgetId)
    {
        await using var conn = Connection();
        
        await conn.ExecuteAsync("DELETE FROM budget WHERE id = @budgetId", new
        { 
            budgetId
        });
    }
}