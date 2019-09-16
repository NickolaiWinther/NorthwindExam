using NorthwindExam.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindExam.Dal
{
    public class Repository
    {
        public NorthwindModel model = new NorthwindModel();

        public List<Order> GetAllOrders()
        {
            return model.Orders.ToList();
        }

        public void Update(Order order)
        {
            model.Orders.AddOrUpdate(order);
            model.SaveChanges();
        }

        public void Insert(Order order)
        {
            model.Orders.Add(order);
            model.SaveChanges();
        }
    }
}
