using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
namespace FoodService.Models
{
    public class FoodItem
    {
       
        public String itemName
        {
            get;
            set;

        }
        public String itemDesc
        {
            get;
            set;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public String itemID
        {
            get;
            set;
        }


      
    }
}
