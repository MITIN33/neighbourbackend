using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace FoodService.Models
{
    public class Flat
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public String flatID
        {
            get;
            set;

        }
        public String FlatNumber
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
