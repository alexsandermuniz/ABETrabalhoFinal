using WholesaleApi.Entities;
using ShopkeeperApi.Business;
using Microsoft.AspNetCore.Mvc;

namespace WholesaleApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BudgetController : ControllerBase
    {
        BudgetsBusiness _BudgetBusiness = new BudgetsBusiness();
        [HttpGet("{id}")]
        public ActionResult<Budget> Get(int id)
        {
            return _BudgetBusiness.getBudget(id);
        }
        [HttpPatch("{id}")]
        public ActionResult<Budget> Patch(int id, [FromBody] string status)
        {
            return _BudgetBusiness.getBudget(id);
        }
        [HttpPost]
        public ActionResult<long> Post([FromBody] Budget budget)
        {
            return _BudgetBusiness.addBudget(budget);
        }
    }
}
