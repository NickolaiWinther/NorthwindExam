using NorthwindExam.Dal;
using NorthwindExam.Entities;
using NorthwindExam.WebService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindExam.Gui.Desktop.ViewModels
{
    public class OrderViewModel : INotifyPropertyChanged
    {
        private List<Order> orders;
        private Order selectedOrder;
        private List<Invoice> invoices;
        private decimal totalPrice;


        public List<Order> Orders
        {
            get => OrdersSortedByRequiredDate();
            set => orders = value;
        }

        public Order SelectedOrder
        {
            get => selectedOrder;
            set
            {
                selectedOrder = value;
                OnPropertyChanged(nameof(SelectedOrder));
            }
        }

        public List<Invoice> Invoices
        {
            get => invoices;
            set
            {
                invoices = value;
                OnPropertyChanged(nameof(Invoices));
            }
        }
        public decimal TotalPrice
        {
            get => totalPrice;
            set
            {
                totalPrice = value;
                OnPropertyChanged(nameof(TotalPrice));
            }
        }

        public decimal GetTotalPrice()
        {
            decimal price = 0;
            foreach (Invoice invoice in Invoices)
            {
                price += (decimal)(invoice.Freight + invoice.ExtendedPrice);
            }
            return price;
        }

        public List<Invoice> GetInvoices()
        {
            return new Repository().GetInvoicesById(SelectedOrder.OrderID);
        }

        public List<Order> OrdersSortedByRequiredDate()
        {
            return new Repository().GetAllOrders().Where(e => e.ShippedDate == null).OrderBy(e => e.RequiredDate).ToList();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
