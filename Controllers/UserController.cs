using System;
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
        public IActionResult Get(String id)
        {
            try
            {
                var user = manager.GetUser(id);
                if (user != null)
                {
                    return Ok(user);
                }
                return StatusCode(404,"User not found");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }



        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]User user)
        {
            try
            {
                manager.AddUser(user);
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }

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
