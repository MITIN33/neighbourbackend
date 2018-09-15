using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NeighborFoodBackend.Model.Entity;

namespace FoodService.Models.Entity
{
    public class OrderHistory
    {
        private int bill;

        public String orderId { get; set; }
        public String flatNumber { get; set; }
        public int totalBill
        {
            get { return bill;}
            set { bill += value; }
        }
        public String createTime { get; set; }
        public String orderStatus { get; set; }
        public String sellerName { get; set; }
    }
}