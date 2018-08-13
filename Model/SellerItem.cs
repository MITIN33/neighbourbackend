using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
namespace FoodService.Models
            
{
    public class SellerItem
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public String SellerItemID
        {
            get;
            set;
        }
       
       
        public String itemID
        {
            get;
            set;

        }


        public String sellerID
        {
            get;
            set;
        }

        public int quantity
        {
            get;
            set;
        }
        public int servedFor
        {
            get;
            set;
        }
        public DateTime startTime
        {
            get;
            set;
        }
        public DateTime endTime
        {
            get;
            set;
        }
    }
}
