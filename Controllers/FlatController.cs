using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodService.Models;
using Microsoft.AspNetCore.Mvc;
using NeighborBackend.Data;
using NeighborFoodBackend;
using WebApplication1.Data;
using NeighborFoodBackend.Model.Entity;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    public class FlatController : Controller
    {
        // GET api/values
        FlatManager manager;

        public FlatController(FoodserviceContext context)
        {
            manager = new FlatManager(context);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(manager.GetAllFlats());

        }

        [HttpGet("{id}")]
        public Flat Get(String id)
        {
            return manager.GetFlat(id);
        }


        [Route("apartments/{id}")]
        [HttpGet]
        public List<Flat> GetAllFlatsByApartment(String id)
        {
            return manager.GetAllFlatsForApartment(id);

        }


        [Route("seller/{userId}")]
        [HttpGet]
        public SellerItemDetail GetSellerItemsByUserId(String userId)
        {
            return manager.GetSellerItemsByUserId(userId);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Flat flat)
        {
            manager.AddFlat(flat);

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(String id, [FromBody]Flat flat)
        {
            manager.UpdateFlat(id, flat);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(String id)
        {
            manager.DeleteFlat(id);
        }
    }
}
