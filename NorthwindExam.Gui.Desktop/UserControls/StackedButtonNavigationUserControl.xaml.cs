using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Interaction logic for StackedButtonNavigationUserControl.xaml
    /// </summary>
    public partial class StackedButtonNavigationUserControl : UserControl
    {
        MainWindow mainWindow;
        public StackedButtonNavigationUserControl(MainWindow mainWindow)
        {
            InitializeComponent();
            this.mainWindow = mainWindow;
        }

        private void ToggleButtonOrder_Checked(object sender, RoutedEventArgs e)
        {
            if (((ToggleButton)sender).IsChecked ?? false)
                mainWindow.DetailsUserControl.Content = new OrderUserControl();
            else
                mainWindow.DetailsUserControl.Content = new UserControl();
        }
    }
}
