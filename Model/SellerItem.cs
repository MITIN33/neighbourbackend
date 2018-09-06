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
       
        [ForeignKey("FoodItem")]
        public String itemID
        {
            get;
            set;

        }

        [ForeignKey("User")]
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
                
        public String itemDesc
        {
            get;
            set;
        }

        public String itemName
        {
            get;
            set;
        }
       
        public float price { get; set; }

        public Boolean isAvailable { get; set; }

        [ForeignKey("Flat")]
        public String flatID { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
