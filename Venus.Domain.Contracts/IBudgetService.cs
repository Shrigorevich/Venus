using Venus.Dto.Accounting;

namespace Venus.Domain.Contracts;

public interface IBudgetService
{
    Task<BudgetViewDto> CreateBudget(string userId, CreateBudgetDto budget);

    Task<BudgetViewDto> UpdateBudget(string userId, Guid budgetId, CreateBudgetDto budget);

    Task<List<BudgetViewDto>> GetBudgets(string userId);
    
    Task DeleteBudget(Guid budgetId);
}