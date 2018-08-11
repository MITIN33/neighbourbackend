using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace FoodService.Models
{
    public class Apartment
    {
        
        public String apartmentName
        {
            get;
            set;

        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public String apartmentID
        {
            get;
            set;
        }

        [ForeignKey("flatID")]
        public ICollection<Flat> Flats { get; set; }
    }
}
