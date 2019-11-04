using ShopkeeperApi.Entities;
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
        public Budget getBudget(long budgetCode)
        {
            return budgetsMock.Where(x => x.budgetCode == budgetCode).FirstOrDefault();
        }
        public Budget changeBudget(long budgetCode, RequestChangeStatus status)
        {
            Budget bd = budgetsMock.Where(x => x.budgetCode == budgetCode).FirstOrDefault();
            bd.status = status.status;
            return bd;
        }
        public List<Budget> getBudgets()
        {
            return budgetsMock;
        }
    }

}


