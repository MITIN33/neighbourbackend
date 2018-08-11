using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace FoodService.Models
{
    public class User
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public String userID
        {
            get;
            set;
     
        }
        public String userName
        {
            get;
            set;
        }

        public String flatID
        {
            get;
            set;
        }
        public String apartmentID
        {
            get;
            set;
        }

    }
}
