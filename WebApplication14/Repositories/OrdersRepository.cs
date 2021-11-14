using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication14.Models;

namespace WebApplication14.Repositories
{
    public static class OrdersRepository
    {
        private static OrderContext db = new OrderContext();

        public static Order GetByID(int? id)
        {
            return db.Orders.Find(id);
        }
        public static List<Order> GetAllToList()
        {
            return db.Orders.ToList();
        }
        public static void Add(Order order)
        {
            db.Orders.Add(order);
            db.SaveChanges();
        }
        public static void Edit(Order order)
        {
            db.Entry(order).State = EntityState.Modified;
            db.SaveChanges();
        }
        public static void Delete(Order order)
        {
            db.Orders.Remove(order);
            db.SaveChanges();
        }
    }
}