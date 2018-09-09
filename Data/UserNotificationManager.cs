using System;
using System.Collections.Generic;
using System.Linq;
using FoodService.Models;
using WebApplication1.Data;
using Microsoft.EntityFrameworkCore;
using NeighborFoodBackend.Model.Entity;
using System.Data.SqlClient;

namespace NeighborBackend.Data
{

    public class UserNotificationManager
    {
        private FoodserviceContext context;
        public UserNotificationManager(FoodserviceContext context)
        {
            this.context = context;
        }

        public void AddUserTokenEntry(UserNotification UserNotification)
        {
            context.UserNotification.Add(UserNotification);
            context.SaveChanges();
        }

        public void AddUserTokenEntry(String user, String token)
        {
            AddUserTokenEntry(new UserNotification
            {
                userUid = user,
                tokenId = token
            });
        }

        public String GetTokenForUserId(string id)
        {
            return context.UserNotification.Where(x => x.userUid == id).FirstOrDefault().tokenId;
        }

        public void UpdateUser(String user, String token)
        {
            var result = context.UserNotification.Where(x => x.tokenId == token).FirstOrDefault();
            if (result != null)
            {
                result.userUid = user;
                context.SaveChanges();
            }
            else
            {
                AddUserTokenEntry(user, token);
            }
        }
    }
}