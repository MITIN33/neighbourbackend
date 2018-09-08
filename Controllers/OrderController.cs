using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodService.Models;
using Microsoft.AspNetCore.Mvc;
using NeighborBackend.Data;
using WebApplication1.Data;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        // GET api/values
        OrderManager manager;

        public OrderController(FoodserviceContext context)
        {
            manager = new OrderManager(context);
        }

        [HttpGet]
        public IEnumerable<Order> GetAll()
        {
            return manager.GetAllOrders();

        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Order Get(String id)
        {
            return manager.GetOrder(id);
        }



        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Order order)
        {
            try{
                manager.AddOrder(order);
                return StatusCode(200, "{'status': 'Order Placed'}");
            }
            catch(Exception ex)
            {
                return StatusCode(500,ex);
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(String id, [FromBody]Order order)
        {
            manager.UpdateOrder(id, order);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(String id)
        {
            manager.DeleteOrder(id);
        }
    }
}
