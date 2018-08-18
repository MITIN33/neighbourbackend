using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace FoodService.Models
{
    public class Flat
    {
       

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public String FlatID
        {
            get;
            set;
        }


        public String FlatNumber
        {
            get;
            set;
        }
       
        [ForeignKey("Apartment")]
        public String apartmentID
        {
            get;
            set;
        }

        public ICollection<User> Users { get; set; }
        public ICollection<SellerItem> sellerItems { get; set; }
    }
}
