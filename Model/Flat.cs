using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace FoodService.Models
{
    public class Flat
    {
        [Key]
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
    }
}
