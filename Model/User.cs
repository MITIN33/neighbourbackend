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

       
        public String flatNumber
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
        public ICollection<SellerItem> SellerItems { get; set; }

    }
}
