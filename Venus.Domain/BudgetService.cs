using AutoMapper;
using Venus.Database.Contracts;
using Venus.Database.Models;
using Venus.Domain.Contracts;
using Venus.Dto.Accounting;

namespace Venus.Domain;

public class BudgetService(IBudgetRepo repo, IMapper mapper) : IBudgetService
{
    public async Task<BudgetViewDto> CreateBudget(string userId, CreateBudgetDto budget)
    {
        var result = await repo.CreateBudget(userId, budget);
        return mapper.Map<BudgetModel, BudgetViewDto>(result);
    }

    public async Task<BudgetViewDto> UpdateBudget(string userId, Guid budgetId, CreateBudgetDto budget)
    {
        var result = await repo.UpdateBudget(userId, budgetId, budget);
        return mapper.Map<BudgetModel, BudgetViewDto>(result);
    }

    public async Task<List<BudgetViewDto>> GetBudgets(string userId)
    {
        var result = await repo.GetBudgets(userId);
        return mapper.Map<List<BudgetModel>, List<BudgetViewDto>>(result);
    }

    public async Task DeleteBudget(Guid budgetId)
    {
        await repo.DeleteBudget(budgetId);
    }
}