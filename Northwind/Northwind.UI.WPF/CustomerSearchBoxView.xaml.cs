using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Northwind.ViewModel;

namespace Northwind.UI.WPF
{
    /// <summary>
    /// Interaction logic for CustomerSearchBoxView.xaml
    /// </summary>
    public partial class CustomerSearchBoxView : UserControl
    {
        public CustomerSearchBoxView()
        {
            InitializeComponent();
        }

        private void CustomerDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ((CustomerSearchBoxViewModel) DataContext).
                RaiseShowCustomerDetails();
        }
    }
}
