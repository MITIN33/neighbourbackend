using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodService.Models;
using WebApplication1.Data;

namespace NeighborBackend.Data
{
    public class FoodItemManager 
    {
        private readonly FoodserviceContext _context;
        public FoodItemManager(FoodserviceContext context)
        {
            this._context = context;
        }


        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }
}
