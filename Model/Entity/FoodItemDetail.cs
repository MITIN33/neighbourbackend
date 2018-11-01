using System;
namespace NeighborFoodBackend.Model.Entity
{
    public class FoodItemDetail
    {
        public String itemID { get; set; }
        public String itemName { get; set; }
        public int servedFor { get; set; }
        public String itemDesc { get; set; }
        public float price { get; set; }
        public Boolean available { get; set; }
        
    }
}
