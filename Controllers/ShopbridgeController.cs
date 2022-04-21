using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Shopbridge2.Models;

namespace Shopbridge2.Controllers
{
   
    public class ShopbridgeController : ApiController
    {
        shopbridgeEntities db = new shopbridgeEntities();
        public string AddItem(ShopBridge sb)
        {
            try
            {
                db.ShopBridges.Add(sb);
                db.SaveChanges();
                return "Item added to the inventory";
            }
            catch
            {
                return "Item Not added";
            }
        }
        public IEnumerable<ShopBridge> Get()
        {
            List<ShopBridge> lst = new List<ShopBridge>();
            try
            {
                return db.ShopBridges.ToList();
            }
            catch
            {
                return lst;
            }
        }
        public string UpdateItem(int id, ShopBridge sb)
        {
            try
            {
                ShopBridge sc = db.ShopBridges.Find(id);
                sc.Item_Name = sb.Item_Name;
                sc.Item_type = sb.Item_type;
                sc.Price = sb.Price;
                sc.Quantity = sb.Quantity;
                db.Entry(sc).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return "Item updated in inventory";
            }
            catch
            {
                return "Item not updated in Inventory";
            }
        }
        public string Delete(int id)
        {
            try
            {
                ShopBridge sb = db.ShopBridges.Find(id);
                db.ShopBridges.Remove(sb);
                db.SaveChanges();
                return "Item Deleted from inventory";
            }
            catch
            {
                return "Item Not Deleted from Inventory";
            }
        }
    }
}
