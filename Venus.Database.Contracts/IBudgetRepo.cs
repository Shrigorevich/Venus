using Venus.Database.Models;
using Venus.Dto.Accounting;

namespace Venus.Database.Contracts;

public interface IBudgetRepo
{
    Task<BudgetModel> CreateBudget(string userId, CreateBudgetDto budget);

    Task<BudgetModel> UpdateBudget(string userId, Guid budgetId, CreateBudgetDto budget);

    Task<List<BudgetModel>> GetBudgets(string userId);
    
    Task DeleteBudget(Guid budgetId);
}