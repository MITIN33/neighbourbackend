using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodService.Models;
using Microsoft.AspNetCore.Mvc;
using NeighborBackend.Data;
using WebApplication1.Data;
using NeighborFoodBackend.Model.Entity;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    public class ApartmentController : Controller
    {
        // GET api/values
        ApartmentManager manager;

        public ApartmentController(FoodserviceContext context)
        {
            manager = new ApartmentManager(context);
        }

        [HttpGet]
        public IEnumerable<Apartment> GetAll()
        {
            return manager.GetAllApartments();

        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Apartment Get(String id)
        {
            return manager.GetApartment(id);
        }

        // GET api/values/5
        [Route("{apartmentID}/user/{userID}")]
        [HttpGet]
        public IEnumerable<SellerItemDetails> GetSellerItemDetailsByApartmentAndUser(String apartmentID,String userID)
        {
            return manager.GetSellerItemDetailsByApartmentAndUser(apartmentID,userID);
        }




        // POST api/values
        [HttpPost]
        public void Post([FromBody]Apartment apartment)
        {
            manager.AddApartment(apartment);

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(String id, [FromBody]Apartment apartment)
        {
            manager.UpdateApartment(id, apartment);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(String id)
        {
            manager.DeleteApartment(id);
        }
    }
}
