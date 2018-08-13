using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace FoodService.Models
{
    public class Order
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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


        public String userPlacedBy
        {
            get;
            set;
        }
        public String userPlacedTo
        {
            get;
            set;
        }
        public DateTime createTime
        {
            get;
            set;
        }

        [ForeignKey("itemID")]
        public List<SellerItem> foodItem{
            get;
            set;
        }

    }
}
