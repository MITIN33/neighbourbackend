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
    public class FlatController : Controller
    {
        // GET api/values
        FlatManager manager;

        public FlatController(FoodserviceContext context)
        {
            manager = new FlatManager(context);
        }

        [HttpGet]
        public IEnumerable<Flat> GetAll()
        {
            return manager.GetAllFlats();

        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Flat Get(String id)
        {
            return manager.GetFlat(id);
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
