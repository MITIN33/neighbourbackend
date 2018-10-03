using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodService.Models;

namespace NeighborFoodBackend.Model.Entity
{
    public class SellerItemDetails
    {
        public List<FoodItem> FoodItems { get; set; }
        public String flatNumber { get; set; }
        public float rating { get; set; }
        public String sellerName
        {
            get;
            set;
        }
        public String SellerId
        {
            get;
            set;
        }
        
        public String PhotoUrl { get; set; }
    }
}
