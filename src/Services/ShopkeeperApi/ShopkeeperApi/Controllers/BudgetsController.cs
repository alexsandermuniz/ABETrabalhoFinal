using ShopkeeperApi.Entities;
using ShopkeeperApi.Business;
using Microsoft.AspNetCore.Mvc;

namespace ShopkeeperApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BudgetsController : ControllerBase
    {
        BudgetsBusiness _BudgetBusiness = new BudgetsBusiness();
        [HttpGet("/Budgets/{budgetCode}")]
        public ActionResult<Budget> Get(long budgetCode)
        {
            return _BudgetBusiness.getBudget(budgetCode);
        }
        [HttpPatch("/Budgets/{budgetCode}")]
        public ActionResult<Budget> Patch(long budgetCode, [FromBody] RequestChangeStatus status)
        {
            return _BudgetBusiness.changeBudget(budgetCode, status);
        }
        [HttpPost]
        public ActionResult<long> Post([FromBody] Budget budget)
        {
            return _BudgetBusiness.addBudget(budget);
        }
    }
}
