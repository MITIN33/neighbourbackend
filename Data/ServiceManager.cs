using System;
using System.Collections.Generic;
using System.Linq;
using FoodService.Models;
using WebApplication1.Data;
using Microsoft.EntityFrameworkCore;
using NeighborFoodBackend.Model.Entity;
using System.Data.SqlClient;
using FoodService.Models.Entity;

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
            if (UserExists(user.userUid))
            {
                throw new Exception("User Already Exists");
            }
            else
            {
                _context.Users.Add(user);
                _context.SaveChanges();
            }
        }

        public User GetUser(String id)
        {
            var Item = _context.Users.FirstOrDefault(b => b.userUid == id);
            return Item;
        }


        public IEnumerable<User> GetAllUsers()
        {
            try
            {
                var Users = _context.Users.ToList();
                return Users;
            }
            catch (SqlException sq)
            {
                throw new Exception(sq.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public long UpdateUser(String id, User user)
        {
            long userID = 0;
            var userNew = _context.Users.Find(id);
            if (userNew != null)
            {

                userNew.flatID = user.flatID;
                userNew.userName = user.userName;
            }
            _context.SaveChanges();
            return userID;
        }

        public void UpdatePhotoUrl(String id, String Url)
        {
            var userNew = _context.Users.Find(id);
            if (userNew != null)
            {
                userNew.photoUrl = Url;
            }
            _context.SaveChanges();
        }

        public Boolean UserExists(String uid)
        {
            var user = _context.Users.Where(x => x.userUid == uid).FirstOrDefault();
            return user != null;
        }


        public long DeleteUser(String id)
        {
            int userID = 0;
            var user = _context.Users.FirstOrDefault(b => b.userUid == id);
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



        public IEnumerable<SellerItemDetails> GetSellerItemDetailsByApartmentAndUser(String apartmentID, String userId)
        {
            List<SellerItemDetails> sellerItemDetails = new List<SellerItemDetails>();
            var userList = _context.Users.Where(x => x.apartmentID == apartmentID).ToList();
            foreach (var user in userList)
            {
                if (user.userUid != userId)
                {
                    var foodlist = getSellerItemsForFlat(user.userUid).ToList();
                    if (foodlist.Count != 0)
                    {
                        SellerItemDetails sellerItem = new SellerItemDetails()
                        {
                            FoodItems = foodlist,
                            flatNumber = _context.Flats.Where(x => x.FlatID == user.flatID).FirstOrDefault().FlatNumber,
                            rating = user.rating,
                            sellerName = user.fname + " " + user.lname,
                            SellerId = user.userUid,
                            PhotoUrl = user.photoUrl
                        };
                        sellerItemDetails.Add(sellerItem);
                    }
                }
            }

            return sellerItemDetails;
        }


        public IEnumerable<FoodItem> getSellerItemsForFlat(String userID)
        {
            var foods = from sellerItem in _context.SellerItems
                        where sellerItem.sellerID == userID
                        select new FoodItem { itemName = sellerItem.itemName, itemDesc = sellerItem.itemDesc };

            return foods;

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

        public Boolean ApartmentExists(String id)
        {
            var apartment = _context.Apartments.Where(x => x.apartmentID == id).FirstOrDefault();
            return apartment != null;
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
            var Flat = _context.Flats.FirstOrDefault(b => b.FlatNumber == id);
            return Flat;
        }


        public IEnumerable<Flat> GetAllFlats()
        {
            var Flats = _context.Flats.ToList();
            return Flats;
        }


        public IEnumerable<SellerFlat> GetSellerItemsByFlat(String flatID)
        {
            var innerJoinQuery =
            from sellerItem in _context.SellerItems
            join item in _context.FoodItems on sellerItem.itemID equals item.itemID
            where sellerItem.flatID == flatID
            select new SellerFlat
            {
                isAvailable = sellerItem.isAvailable,
                itemID = sellerItem.itemID,
                itemName = item.itemName,
                quantity = sellerItem.quantity,
                servedFor = sellerItem.servedFor,
                sellerID = sellerItem.sellerID,
                price = sellerItem.price
            }; //produces flat sequence

            return innerJoinQuery;

        }
        public List<Flat> GetAllFlatsForApartment(String apartmentID)
        {
            var Flats = _context.Flats
                                .Where(s => s.apartmentID == apartmentID)
                                .ToList();
            return Flats;
        }

        public long UpdateFlat(String id, Flat Flat)
        {
            int flatID = 0;
            var FlatNew = _context.Flats.Find(id);
            if (FlatNew != null)
            {

                FlatNew.FlatNumber = Flat.FlatNumber;
                flatID = _context.SaveChanges();
            }
            return flatID;
        }


        public long DeleteFlat(String id)
        {
            int flatID = 0;
            var Flat = _context.Flats.FirstOrDefault(b => b.FlatNumber == id);
            if (Flat != null)
            {
                _context.Flats.Remove(Flat);
                flatID = _context.SaveChanges();
            }
            return flatID;
        }

        public Boolean FlatExists(String id)
        {
            var flat = _context.Flats.Where(x => x.FlatNumber == id).FirstOrDefault();
            return flat != null;
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
            var FoodItem = _context.FoodItems.Where(b => b.itemID == id).FirstOrDefault();
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

        internal object GetAllFlats()
        {
            throw new NotImplementedException();
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

        public void AddSellerItemDetails(SellerDetails sellerDetails)
        {
            /*var foodItem =  _context.FoodItems.Where(x=> x.itemName == sellerDetails.itemName);
            String guid = Guid.NewGuid().ToString();
            String itemIDNew;
            if (foodItem == null)
            {
                itemIDNew = guid;
                FoodItem fI = new FoodItem
                {
                    itemDesc = sellerDetails.itemDesc,
                    itemName = sellerDetails.itemName,
                    itemID = guid
                };
                _context.FoodItems.Add(fI);
            }
            else{
                itemIDNew = sellerDetails.itemID;
            }*/

            SellerItem sellerItem = new SellerItem
            {
                sellerID = sellerDetails.sellerID,
                isAvailable = sellerDetails.isAvailable,
                price = sellerDetails.price,
                quantity = sellerDetails.quantity,
                servedFor = sellerDetails.servedFor,
                flatID = sellerDetails.flatID,
                itemID = Guid.NewGuid().ToString(),
                itemName = sellerDetails.itemName,
                itemDesc = sellerDetails.itemDesc,
                veg = sellerDetails.veg

            };
            _context.SellerItems.Add(sellerItem);



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
                sellerItemNew.itemDesc = SellerItem.itemDesc;
                sellerItemNew.itemName = SellerItem.itemName;
                sellerItemNew.itemID = SellerItem.itemID;
                sellerItemNew.veg = SellerItem.veg;
                sellerItemNew.price = SellerItem.price;
                sellerItemID = _context.SaveChanges();
            }
            return sellerItemID;
        }

        public long UpdateSellerItemDetails(String id, SellerDetails sellerDetails)
        {
            int sellerItemID = 0;
            var sellerItemNew = _context.SellerItems.Find(id);
            if (sellerItemNew != null)
            {
                sellerItemNew.sellerID = sellerDetails.sellerID;
                sellerItemNew.servedFor = sellerDetails.servedFor;
                sellerItemNew.quantity = sellerDetails.quantity;
                sellerItemNew.price = sellerDetails.price;
                sellerItemNew.isAvailable = sellerDetails.isAvailable;
                sellerItemNew.itemID = sellerDetails.itemID;
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

        public IEnumerable<SellerDetails> GetSellerDetails(String sellerID)
        {
            var innerJoinQuery =
            from sellerItem in _context.SellerItems
            where sellerItem.sellerID == sellerID
            select new SellerDetails
            {
                isAvailable = sellerItem.isAvailable,
                itemID = sellerItem.itemID,
                itemName = sellerItem.itemName,
                quantity = sellerItem.quantity,
                servedFor = sellerItem.servedFor,
                sellerID = sellerItem.sellerID,
                sellerItemID = sellerItem.SellerItemID,
                price = sellerItem.price,
                flatID = sellerItem.flatID,
                itemDesc = sellerItem.itemDesc
            }; //produces flat sequence

            return innerJoinQuery;

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
            List<Order> list = new List<Order>();
            foreach (SellerDetails item in order.sellerItems)
            {
                Order orderItem = new Order();
                orderItem.createTime = order.createTime;
                orderItem.orderID = order.orderID;
                orderItem.orderStatus = order.orderStatus;
                orderItem.sellerItemId = item.sellerItemID;
                orderItem.id = Guid.NewGuid().ToString();
                orderItem.userPlacedBy = order.userPlacedBy;
                orderItem.userPlacedTo = order.userPlacedTo;
                orderItem.quantity = item.quantity;
                list.Add(orderItem);
            }
            _context.Orders.AddRange(list);
            _context.SaveChanges();
        }

        public Order GetOrder(String id)
        {
            var order = _context.Orders.FirstOrDefault(b => b.orderID == id);
            List<Order> items = _context.Orders.Where(o => o.orderID == id).ToList(); 
            List<SellerDetails> sellerItems = new List<SellerDetails>();
            foreach (var item in items)
            {
                var sellerItem = _context.SellerItems.Where(x=>x.SellerItemID == item.sellerItemId).FirstOrDefault();
                sellerItems.Add(new SellerDetails{
                    itemName = sellerItem.itemName,
                    itemDesc = sellerItem.itemDesc,
                    quantity = item.quantity,
                    price = sellerItem.price
                });
            }
            order.sellerItems = sellerItems;
            return order;
        }

        public IEnumerable<OrderHistory> GetOrderbyUser(String id)
        {
            var list = _context.Orders.Where(x => x.userPlacedBy == id).ToList();
            List<OrderHistory> finalList = new List<OrderHistory>();
            var orders1 = from order in list
                          join user in _context.Users
                          on order.userPlacedTo equals user.userUid
                          join flat in _context.Flats
                          on user.flatID equals flat.FlatID
                          join sellerItem in _context.SellerItems
                          on order.sellerItemId equals sellerItem.SellerItemID
                          where order.userPlacedBy == id
                          select new OrderHistory
                          {
                              orderId = order.orderID,
                              orderStatus = order.orderStatus,
                              sellerName = user.fname + " " + user.lname,
                              flatNumber = flat.FlatNumber,
                              totalBill = (int)sellerItem.price * order.quantity,
                              createTime = order.createTime,
                              endTime = order.endTime,
                              orderType = "REQUESTED"
                          };

            finalList.AddRange(orders1.ToList());
            list = _context.Orders.Where(x => x.userPlacedTo == id).ToList();
            var orders2 = from order in list
                          join user in _context.Users
                          on order.userPlacedBy equals user.userUid
                          join flat in _context.Flats
                          on user.flatID equals flat.FlatID
                          join sellerItem in _context.SellerItems
                          on order.sellerItemId equals sellerItem.SellerItemID
                          where order.userPlacedTo == id
                          select new OrderHistory
                          {
                              orderId = order.orderID,
                              orderStatus = order.orderStatus,
                              sellerName = user.fname + " " + user.lname,
                              flatNumber = flat.FlatNumber,
                              totalBill = (int)sellerItem.price * order.quantity,
                              createTime = order.createTime,
                              endTime = order.endTime,
                              orderType = "ACCEPTED"
                          };

            finalList.AddRange(orders2.ToList());
            finalList = finalList.GroupBy(x=>x.orderId).Select(n=>n.First()).ToList();
            return finalList.OrderBy(x => x.createTime);
        }

        public IEnumerable<Order> GetAllOrders()
        {
            var orders = _context.Orders.ToList();
            return orders;
        }

        public long UpdateOrder(String id, String orderStatus)
        {
            int orderID = 0;
            var orderNew = _context.Orders.Where(x => x.orderID == id).FirstOrDefault();
            TimeSpan t = DateTime.UtcNow - new DateTime(1970, 1, 1);
            long epochTime = (long)t.TotalMilliseconds;
            if (orderNew != null)
            {
                orderNew.orderStatus = orderStatus;
                orderNew.endTime = epochTime.ToString();
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
