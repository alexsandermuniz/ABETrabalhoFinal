using WholesaleApi.Entities;
using System.Collections.Generic;
using System.Linq;
using WholesaleApi.Utils;
using Newtonsoft.Json;

namespace WholesaleApi.Business
{
    
    public class BudgetsBusiness
    {
        private static long contMockId = 100;
        private static List<Budget> budgetsMock = new List<Budget>();
        public static long addBudget(Budget budget)
        {
            budget.id = contMockId;
            budget.budgetCode = (int)contMockId;
            budgetsMock.Add(budget);
            return contMockId++;
        }
        public Budget getBudget(long budgetCode)
        {
            return budgetsMock.Where(x => x.budgetCode == budgetCode).FirstOrDefault();
        }
        public List<Budget> getBudgets()
        {
            return budgetsMock;
        }
        public Budget changeBudget(long budgetCode, RequestChangeStatus status)
        {
            Budget bd = budgetsMock.Where(x => x.budgetCode == budgetCode).FirstOrDefault();
            bd.status = status.status;
            return bd;
        }
        public long sendBudgetToClient(Budget budget)
        {
            long retornoApi = CallApi.PostRequest(JsonConvert.SerializeObject(budget), Constants.BASE_SHOPKEEP_API + Constants.PATH_POST_BUDGET, false);
            if (retornoApi == -1)
                return -1;
            return budget.budgetCode;
        }
       
    }

}


