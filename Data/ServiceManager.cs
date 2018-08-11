using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Model;

namespace WebApplication1.Data
{
    public class ItemManager : IDataRepository<Item, long>
    {
        FoodserviceContext ctx;
        public ItemManager(FoodserviceContext c)
        {
            ctx = c;
        }

        public Item Get(long id)
        {
            var Item = ctx.Items.FirstOrDefault(b => b.StudentId == id);
            return Item;
        }

        public IEnumerable<Item> GetAll()
        {
            var Items = ctx.Items.ToList();
            return Items;
        }

        public long Add(Item stundent)
        {
            ctx.Items.Add(stundent);
            long ItemID = ctx.SaveChanges();
            return ItemID;
        }

        public long Delete(long id)
        {
            int ItemID = 0;
            var Item = ctx.Items.FirstOrDefault(b => b.StudentId == id);
            if (Item != null)
            {
                ctx.Items.Remove(Item);
                ItemID = ctx.SaveChanges();
            }
            return ItemID;
        }

        public long Update(long id, Item item)
        {
            long ItemID = 0;
            var Item = ctx.Items.Find(id);
            if (Item != null)
            {
                Item.FirstName = item.FirstName;
                Item.LastName = item.LastName;
                Item.Gender = item.Gender;
                Item.PhoneNumber = item.PhoneNumber;
                Item.Email = item.Email;
                Item.DateOfBirth = item.DateOfBirth;
                Item.DateOfRegistration = item.DateOfRegistration;
                Item.Address1 = item.Address1;
                Item.Address2 = item.Address2;
                Item.City = item.City;
                Item.State = item.State;
               

                ItemID = ctx.SaveChanges();
            }
            return ItemID;
        }
    }
}
