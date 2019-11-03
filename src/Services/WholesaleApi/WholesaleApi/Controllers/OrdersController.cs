using System.Collections.Generic;
using WholesaleApi.Entities;
using BookStoreApi.Business;
using Microsoft.AspNetCore.Mvc;

namespace WholesaleApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        OrdersBusiness _OrdersBusiness = new OrdersBusiness();
        [HttpGet]
        public ActionResult<List<Order>> Get()
        {
            return _OrdersBusiness.getOrders();
        }
        [HttpGet("{id}")]
        public ActionResult<Order> Get(int id)
        {
            return _OrdersBusiness.getOrder(id);
        }

        [HttpPatch("{id}")]
        public ActionResult<Order> Patch(int id,[FromBody] string status)
        {
            return _OrdersBusiness.getOrder(id);
        }
        [HttpPost]
        public ActionResult<long> Post([FromBody] List<Order> order)
        {
            return _OrdersBusiness.addAllOrders(order);
        }
    }
}
