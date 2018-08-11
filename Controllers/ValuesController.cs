using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NeighborBackend.Data;
using WebApplication1.Data;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        FoodItemManager manager;

        public ValuesController(FoodserviceContext context)
        {
            manager = new FoodItemManager(context);
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            manager.AddUser(new FoodService.Models.User() { apartmentID = "7865", flatID = "122", userName = "archit" });
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // GET api/values/5
        [HttpGet]
        [Route("getbyId/{id}")]
        public string GetByID(int id)
        {
            return "12345";
        }


        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
