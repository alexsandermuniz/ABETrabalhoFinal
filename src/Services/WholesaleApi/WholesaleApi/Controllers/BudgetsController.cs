using WholesaleApi.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WholesaleApi.Business;

namespace WholesaleApi.Controllers
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
        [HttpGet]
        public ActionResult<List<Budget>> Get()
        {
            return _BudgetBusiness.getBudgets();
        }
        [HttpPatch("/Budgets/{budgetCode}")]
        public ActionResult<Budget> Patch(long budgetCode, [FromBody] RequestChangeStatus status)
        {
            return _BudgetBusiness.changeBudget(budgetCode, status);
        }
    }
}
