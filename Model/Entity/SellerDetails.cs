﻿using System;
namespace NeighborFoodBackend.Model.Entity
{
    public class SellerDetails
    {
        public String itemID { get; set; }
        public String itemName { get; set; }
        public String sellerID { get; set; }
        public int quantity { get; set; }
        public int servedFor { get; set; }
        public String itemDesc { get; set; }
        public float price { get; set; }
        public String flatID { get; set; }
        public Boolean isAvailable { get; set; }
        public String sellerItemID { get; set; }
        public bool veg { get; set; }
    }
}
