using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace FoodService.Models
{
    public class UserInfo
    {
        
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

        public String flatId { get; set; }
        public String flatNumber
        {
            get;
            set;
        }

      
        public String fName
        {
            get;
            set;
        }
        public String lName
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
        public String apartmentName { get; set; }
    }
}
