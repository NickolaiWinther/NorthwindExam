using NorthwindExam.Dal;
using NorthwindExam.Entities;
using NorthwindExam.Gui.Desktop.ViewModels;
using NorthwindExam.WebService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NorthwindExam.Gui.Desktop.UserControls
{
    /// <summary>
    /// Interaction logic for OrderUserControl.xaml
    /// </summary>
    public partial class OrderUserControl : UserControl
    {
        private OrderViewModel orderViewModel = new OrderViewModel();

        public OrderUserControl()
        {
            InitializeComponent();
            DataContext = orderViewModel;



            //Test for at se at WebService virker
            //Rates rates = new RatesWebService().GetRates().rates;
            //MessageBox.Show(rates.DKK.ToString());
        }

        private void OrderDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            orderViewModel.SelectedOrder = OrderDataGrid.SelectedItem as Order;

            orderViewModel.Invoices = orderViewModel.GetInvoices();

            orderViewModel.TotalPrice = orderViewModel.GetTotalPrice();
        }
    }
}
