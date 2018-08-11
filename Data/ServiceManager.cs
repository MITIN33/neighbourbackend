﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodService.Models;
using WebApplication1.Data;

namespace NeighborBackend.Data
{
    public class UserManager
    {

        private readonly FoodserviceContext _context;
        public UserManager(FoodserviceContext context)
        {
            this._context = context;
        }


        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public User GetUser(String id)
        {
            var Item = _context.Users.FirstOrDefault(b => b.userID == id);
            return Item;
        }


        public IEnumerable<User> GetAllUsers()
        {
            var Users = _context.Users.ToList();
            return Users;
        }

        public long UpdateUser(String id, User user)
        {
            long userID = 0;
            var userNew = _context.Users.Find(id);
            if (userNew != null)
            {
                userNew.apartmentID = user.apartmentID;
                userNew.flatID = user.flatID;
                userNew.userName = user.userName;
                userID = _context.SaveChanges();
            }
            return userID;
        }


        public long DeleteUser(String id)
        {
            int userID = 0;
            var user = _context.Users.FirstOrDefault(b => b.userID == id);
            if (user != null)
            {
                _context.Users.Remove(user);
                userID = _context.SaveChanges();
            }
            return userID;
        }

    }

    public class ApartmentManager
    {

        private readonly FoodserviceContext _context;
        public ApartmentManager(FoodserviceContext context)
        {
            this._context = context;
        }


        public void AddApartment(Apartment apartment)
        {
            _context.Apartments.Add(apartment);
            _context.SaveChanges();
        }

        public Apartment GetApartment(String id)
        {
            var apartment = _context.Apartments.FirstOrDefault(b => b.apartmentID == id);
            return apartment;
        }


        public IEnumerable<Apartment> GetAllApartments()
        {
            var apartments = _context.Apartments.ToList();
            return apartments;
        }

        public long UpdateApartment(String id, Apartment apartment)
        {
            int apartmentID = 0;
            var apartmentNew = _context.Apartments.Find(id);
            if (apartmentNew != null)
            {
                apartmentNew.apartmentID = apartment.apartmentID;
                apartmentNew.apartmentName = apartment.apartmentName;
                apartmentID = _context.SaveChanges();
            }
            return apartmentID;
        }


        public long DeleteApartment(String id)
        {
            int apartmentID = 0;
            var apartment = _context.Apartments.FirstOrDefault(b => b.apartmentID == id);
            if (apartment != null)
            {
                _context.Apartments.Remove(apartment);
                apartmentID = _context.SaveChanges();
            }
            return apartmentID;
        }



    }

    public class FlatManager
    {

        private readonly FoodserviceContext _context;
        public FlatManager(FoodserviceContext context)
        {
            this._context = context;
        }


        public void AddFlat(Flat Flat)
        {
            _context.Flats.Add(Flat);
            _context.SaveChanges();
        }

        public Flat GetFlat(String id)
        {
            var Flat = _context.Flats.FirstOrDefault(b => b.flatID == id);
            return Flat;
        }


        public IEnumerable<Flat> GetAllFlats()
        {
            var Flats = _context.Flats.ToList();
            return Flats;
        }

        public IEnumerable<Flat> GetAllFlatsForApartment(String apartmentID)
        {
            var Flats = _context.Flats.ToList();
            return Flats;
        }

        public long UpdateFlat(String id, Flat Flat)
        {
            int flatID = 0;
            var FlatNew = _context.Flats.Find(id);
            if (FlatNew != null)
            {
                FlatNew.flatID = Flat.flatID;
                FlatNew.FlatNumber = Flat.FlatNumber;
                flatID = _context.SaveChanges();
            }
            return flatID;
        }


        public long DeleteFlat(String id)
        {
            int flatID = 0;
            var Flat = _context.Flats.FirstOrDefault(b => b.flatID == id);
            if (Flat != null)
            {
                _context.Flats.Remove(Flat);
                flatID = _context.SaveChanges();
            }
            return flatID;
        }

    }

    public class FoodItemManager
    {

        private readonly FoodserviceContext _context;
        public FoodItemManager(FoodserviceContext context)
        {
            this._context = context;
        }


        public void AddFoodItem(FoodItem FoodItem)
        {
            _context.FoodItems.Add(FoodItem);
            _context.SaveChanges();
        }

        public FoodItem GetFoodItem(String id)
        {
            var FoodItem = _context.FoodItems.FirstOrDefault(b => b.itemID == id);
            return FoodItem;
        }


        public IEnumerable<FoodItem> GetAllFoodItems()
        {
            var FoodItems = _context.FoodItems.ToList();
            return FoodItems;
        }

        public long UpdateFoodItem(String id, FoodItem FoodItem)
        {
            int foodItemID = 0;
            var FoodItemNew = _context.FoodItems.Find(id);
            if (FoodItemNew != null)
            {
                FoodItemNew.itemName = FoodItem.itemName;
                FoodItemNew.itemDesc = FoodItem.itemDesc;
                foodItemID = _context.SaveChanges();
            }
            return foodItemID;
        }


        public long DeleteFoodItem(String id)
        {
            int foodItemID = 0;
            var FoodItem = _context.FoodItems.FirstOrDefault(b => b.itemID == id);
            if (FoodItem != null)
            {
                _context.FoodItems.Remove(FoodItem);
                foodItemID = _context.SaveChanges();
            }
            return foodItemID;
        }
    }
    public class SellerItemManager
    {

        private readonly FoodserviceContext _context;
        public SellerItemManager(FoodserviceContext context)
        {
            this._context = context;
        }


        public void AddSellerItem(SellerItem SellerItem)
        {
            _context.SellerItems.Add(SellerItem);
            _context.SaveChanges();
        }

        public SellerItem GetSellerItem(String id)
        {
            var SellerItem = _context.SellerItems.FirstOrDefault(b => b.SellerItemID == id);
            return SellerItem;
        }


        public IEnumerable<SellerItem> GetAllSellerItems()
        {
            var sellerItems = _context.SellerItems.ToList();
            return sellerItems;
        }

        public long UpdateSellerItem(String id, SellerItem SellerItem)
        {
            int sellerItemID = 0;
            var sellerItemNew = _context.SellerItems.Find(id);
            if (sellerItemNew != null)
            {
                sellerItemNew.sellerID = SellerItem.sellerID;
                sellerItemNew.servedFor = SellerItem.servedFor;
                sellerItemNew.quantity = SellerItem.quantity;
                sellerItemNew.endTime = SellerItem.endTime;
                sellerItemNew.itemID = SellerItem.itemID;
                sellerItemNew.startTime = SellerItem.startTime;
                sellerItemID = _context.SaveChanges();
            }
            return sellerItemID;
        }


        public long DeleteSellerItem(String id)
        {
            int sellerItemID = 0;
            var SellerItem = _context.SellerItems.FirstOrDefault(b => b.SellerItemID == id);
            if (SellerItem != null)
            {
                _context.SellerItems.Remove(SellerItem);
                sellerItemID = _context.SaveChanges();
            }
            return sellerItemID;
        }
    }

    public class OrderManager
    {

        private readonly FoodserviceContext _context;
        public OrderManager(FoodserviceContext context)
        {
            this._context = context;
        }


        public void AddOrder(Order order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
        }

        public Order GetOrder(String id)
        {
            var order = _context.Orders.FirstOrDefault(b => b.orderID == id);
            return order;
        }


        public IEnumerable<Order> GetAllOrders()
        {
            var orders = _context.Orders.ToList();
            return orders;
        }

        public long UpdateOrder(String id, Order order)
        {
            int orderID = 0;
            var orderNew = _context.Orders.Find(id);
            if (orderNew != null)
            {
                orderNew.orderStatus = order.orderStatus;
                orderNew.userPlacedBy = order.userPlacedBy;
                orderNew.userPlacedTo = order.userPlacedTo;
                orderID = _context.SaveChanges();
            }
            return orderID;
        }


        public long DeleteOrder(String id)
        {
            int orderID = 0;
            var order = _context.Orders.FirstOrDefault(b => b.orderID == id);
            if (order != null)
            {
                _context.Orders.Remove(order);
                orderID = _context.SaveChanges();
            }
            return orderID;
        }
    }


}