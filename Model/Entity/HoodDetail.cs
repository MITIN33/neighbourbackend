using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodService.Models;

namespace NeighborFoodBackend.Model.Entity
{
    public class HoodDetail
    {
        public List<String> foodItems { get; set; }
        public String flatNumber { get; set; }
        public float rating { get; set; }
        public String sellerName { get; set; }
        public String sellerId { get; set; }   
        public String photoUrl { get; set; }
        public String flatId { get; set; }
        public String apartmentName { get; set; }
    }
}
