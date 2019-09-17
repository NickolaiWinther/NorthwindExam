using NorthwindExam.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindExam.Dal
{
    /// <summary>
    /// Used to get data from the database
    /// </summary>
    ///  
    public class Repository
    {
        public NorthwindModel model = new NorthwindModel();

        /// <summary>
        /// Get a list of all the orders from the database
        /// </summary>
        /// <returns>A list of Orders</returns>
        public List<Order> GetAllOrders()
        {
            return model.Orders.ToList();
        }

        /// <summary>
        /// Get a list of all the Invoices from the database by the ID from an Orders object
        /// </summary>
        /// <param name="id">The ID of the Order</param>
        /// <returns>A list of Invoices</returns>
        public List<Invoice> GetInvoicesById(int id)
        {
            return model.Invoices.Where(i => i.OrderID == id).ToList();
        }
    }
}
