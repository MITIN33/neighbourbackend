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
    public class SellerItemController : Controller
    {
        // GET api/values
        SellerItemManager manager;

        public SellerItemController(FoodserviceContext context)
        {
            manager = new SellerItemManager(context);
        }

        [HttpGet]
        public IEnumerable<SellerItem> GetAll()
        {
            return manager.GetAllSellerItems();

        }

        // GET api/values/5
        [HttpGet("{id}")]
        public SellerItem Get(String id)
        {
            return manager.GetSellerItem(id);
        }



        // POST api/values
        [HttpPost]
        public void Post([FromBody]SellerItem sellerItem)
        {
            manager.AddSellerItem(sellerItem);

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(String id, [FromBody]SellerItem sellerItem)
        {
            manager.UpdateSellerItem(id, sellerItem);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(String id)
        {
            manager.DeleteSellerItem(id);
        }
    }
}
