using System;
using FoodService.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NeighborBackend.Data;
using WebApplication1.Data;

namespace WebApplication1.Controllers
{
    [Authorize]
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
        public OrderDetail GetOrderDetail(String id)
        {
            return manager.GetOrder(id);
        }

        /// <summary>
        /// Get the list of all the orders for the user.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
                return StatusCode(500, ex.Message);
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
