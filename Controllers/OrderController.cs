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

        // GET api/values/5
        [HttpGet("{id}")]
        public Order GetOrderDetail(String id)
        {
            return manager.GetOrder(id);
        }


        [HttpGet("user/{id}")]
        public IActionResult GetOrderByBuyerUser(String id)
        {
            try
            {
                return Ok(manager.GetOrderbyUser(id));
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]Order order)
        {
            try
            {
                manager.AddOrder(order);
                return StatusCode(200, "{'status': 'Order Placed'}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        // PUT api/values/5
        [HttpPut("{id}/{status}")]
        public IActionResult Put(String id, String status)
        {
            try
            {
                manager.UpdateOrder(id, status);
                return StatusCode(200, "{'status': 'Updated Successfully'}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(String id)
        {
            try
            {
                manager.DeleteOrder(id);
                return StatusCode(200, "{'status': 'Deleted Successfully'}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}
