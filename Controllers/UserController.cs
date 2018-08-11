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
    public class UserController : Controller
    {
        // GET api/values
        UserManager manager;

        public UserController(FoodserviceContext context)
        {
            manager = new UserManager(context);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(manager.GetAllUsers());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public User Get(String id)
        {
            return manager.GetUser(id);
        }



        // POST api/values
        [HttpPost]
        public void Post([FromBody]User user)
        {
            manager.AddUser(user);
                   
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(String id, [FromBody]User user)
        {
            manager.UpdateUser(id, user);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(String id)
        {
            manager.DeleteUser(id);
        }
    }
}
