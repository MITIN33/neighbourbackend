using System;
using System.Collections.Generic;

namespace NeighborFoodBackend.Model.Entity
{
    public class SellerItemDetail
    {

        public String fName { get; set; }
        public String lName { get; set; }
        public String sellerId { get; set; }
        public String flatNumber { get; set; }
        public IEnumerable<FoodItemDetail> foodItemDetail { get; set; }

    }
}
