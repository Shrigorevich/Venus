using Venus.Dto.Accounting;

namespace Venus.Domain;

public interface IBudgetService
{
    Task<BudgetViewDto> CreateBudget(string userId, CreateBudgetDto budget);

    Task<BudgetViewDto> UpdateBudget(int budgetId, CreateBudgetDto budget);

    Task<List<BudgetViewDto>> GetBudgets(string userId);
    
    Task DeleteBudget(int budgetId);
}