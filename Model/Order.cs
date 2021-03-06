﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NeighborFoodBackend.Model.Entity;

namespace FoodService.Models
{
    public class Order
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public String id { get; set; }
        
        
        public String orderID
        {
            get;
            set;

        }
        public String orderStatus
        {
            get;
            set;
        }

        [ForeignKey("User")]
        public String userPlacedBy
        {
            get;
            set;
        }

        [ForeignKey("User")]
        public String userPlacedTo
        {
            get;
            set;
        }

       
        public String createTime
        {
            get;
            set;
        }

        [ForeignKey("SellerItem")]
        public String sellerItemId { get; set; }

        public int quantity { get; set; }

        public String endTime { get; set; }

        [NotMapped]
        public List<FoodItemDetail> foodItems { get; set; }

    }
}
