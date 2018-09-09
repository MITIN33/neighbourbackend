using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NeighborFoodBackend.Model.Entity;

namespace FoodService.Models
{
  public class UserNotification
  {
      public String userUid { get; set; }   
      [Key]
      public String tokenId { get; set; }
  }
}