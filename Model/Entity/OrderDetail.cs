using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NeighborFoodBackend.Model.Entity;

namespace FoodService.Models
{
    public class OrderDetail
    {
          
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

        public UserInfo userPlacedBy
        {
            get;
            set;
        }

        public UserInfo userPlacedTo
        {
            get;
            set;
        }

       
        public String createTime
        {
            get;
            set;
        }

        public String endTime { get; set; }

        public List<FoodItemDetail> sellerItems { get; set; }

    }
}
