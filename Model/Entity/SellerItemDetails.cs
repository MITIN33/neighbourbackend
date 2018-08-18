using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NeighborFoodBackend.Model.Entity
{
    public class SellerItemDetails
    {
        public List<FoodItem> itemIDs { get; set; }
        public String flatNumber { get; set; }
        public float rating { get; set; }



    }
}
