using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace FoodService.Models
{
    public class User
    {
        
        [Key]
        public String userUid
        {
            get;
            set;
     
        }
        public String userName
        {
            get;
            set;
        }

        [ForeignKey("Flat")]
        public String flatID
        {
            get;
            set;
        }

      
        public String fname
        {
            get;
            set;
        }
        public String lname
        {
            get;
            set;
        }
        public String phoneNo
        {
            get;
            set;
        }
        public float rating { get; set; }
        public String photoUrl { get; set; }

        public String status { get; set; }


        [ForeignKey("Apartment")]
        public String apartmentID { get; set; }

        public ICollection<SellerItem> SellerItems { get; set; }

        public ICollection<Order> Orders { get; set; }

    }
}
