using WholesaleApi.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ShopkeeperApi.Business
{
    
    public class BudgetsBusiness
    {
        private static long contMockId = 100;
        public static List<Budget> budgetsMock = new List<Budget>();
        public long addBudget(Budget budget)
        {
            budget.id = contMockId;
            budgetsMock.Add(budget);
            return contMockId++;
        }
        public Budget getBudget(long budgetId)
        {
            return budgetsMock.Where(x => x.id == budgetId).FirstOrDefault();
        }
        public List<Budget> getBudgets()
        {
            return budgetsMock;
        }
    }

}


