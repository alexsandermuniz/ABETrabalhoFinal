using System.Collections.Generic;
using WholesaleApi.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using WholesaleApi.Business;

namespace WholesaleApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        OrdersBusiness _OrdersBusiness = new OrdersBusiness();
        BudgetsBusiness _BudgetsBusiness = new BudgetsBusiness();
        [HttpGet]
        public ActionResult<List<Order>> Get()
        {
            return _OrdersBusiness.getOrders();
        }
        [HttpGet("/Orders/{id}")]
        public ActionResult<Order> Get(int id)
        {
            return _OrdersBusiness.getOrder(id);
        }

        [HttpPatch("/Orders/{id}")]
        public ActionResult<Order> Patch(int id,[FromBody] string status)
        {
            return _OrdersBusiness.getOrder(id);
        }
        [HttpPost]
        public ActionResult<OrderResponse> Post([FromBody] List<Order> order)
        {
            Budget budget = _OrdersBusiness.createBudgetWithOrders(order);
            try
            {
                long budgetCode = _BudgetsBusiness.sendBudgetToClient(budget);
                if(budgetCode==-1)
                    return BadRequest("Api lojista não encontrada, para envio do orçamento");
                return new OrderResponse(budgetCode,DateTime.Now);
            }
            catch(Exception ex){
                return BadRequest("Api lojista não encontrada, para envio do orçamento");
            }
            
        }
    }
}
