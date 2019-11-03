using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WholesaleApi.Entities;
using BookStoreApi.Business;
using Microsoft.AspNetCore.Mvc;

namespace WholesaleApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BudgetsController : ControllerBase
    {
        BudgetsBusiness _BudgetBusiness = new BudgetsBusiness();
        [HttpGet("{id}")]
        public ActionResult<Budget> Get(int id)
        {
            return _BudgetBusiness.getBudget(id);
        }
    }
}
