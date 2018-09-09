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
    public class UserNotificationController : Controller
    {
        // GET api/values
        UserNotificationManager manager;

        public UserNotificationController(FoodserviceContext context)
        {
            manager = new UserNotificationManager(context);
        }

        [HttpGet("{id}")]
        public IActionResult Get(String id)
        {
            try
            {
                String token = manager.GetTokenForUserId(id);
                return Ok(new ResponseObject(token));
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex);
            }
        }


        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]UserNotification data)
        {
            
             try
             {
                manager.AddUserTokenEntry(data);
                 return Ok(new ResponseObject("Success"));
             }
             catch (System.Exception ex)
             {
                return BadRequest(ex.Message);
             }   

        }

        // PUT api/values/5
        [HttpPut]
        public IActionResult Put([FromBody]UserNotification flat)
        {
           
             try
             {
                 manager.UpdateUser(flat.userUid, flat.tokenId);
                 return Ok(new ResponseObject("Success"));
             }
             catch (System.Exception ex)
             {
                return BadRequest(ex.Message);
             } 
        }
    }
}
