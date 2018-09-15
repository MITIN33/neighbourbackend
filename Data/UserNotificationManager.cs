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
            var tokenobj = context.UserNotification.Where(x => x.tokenId == token).FirstOrDefault();
            var userobj = context.UserNotification.Where(x => x.userUid == user).FirstOrDefault();
            if (tokenobj != null)  // if token present then update user
            {
                tokenobj.userUid = user;
                context.SaveChanges();
            }
            else if (userobj != null)
            {
                context.UserNotification.Remove(userobj);
                context.SaveChanges();
                AddUserTokenEntry(user, token);
            }
            else
            {
                AddUserTokenEntry(user, token);
            }
        }
    }
}