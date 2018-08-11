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
    public class FoodItemController : Controller
    {
        // GET api/values
        FoodItemManager manager;

        public FoodItemController(FoodserviceContext context)
        {
            manager = new FoodItemManager(context);
        }

        [HttpGet]
        public IEnumerable<FoodItem> GetAll()
        {
            return manager.GetAllFoodItems();

        }

        // GET api/values/5
        [HttpGet("{id}")]
        public FoodItem Get(String id)
        {
            return manager.GetFoodItem(id);
        }



        // POST api/values
        [HttpPost]
        public void Post([FromBody]FoodItem foodItem)
        {
            manager.AddFoodItem(foodItem);

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(String id, [FromBody]FoodItem foodItem)
        {
            manager.UpdateFoodItem(id, foodItem);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(String id)
        {
            manager.DeleteFoodItem(id);
        }
    }
}
