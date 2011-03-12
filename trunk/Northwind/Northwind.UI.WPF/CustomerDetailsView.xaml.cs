using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Northwind.UI.WPF
{
    /// <summary>
    /// Description for CustomerDetailsView.
    /// </summary>
    public partial class CustomerDetailsView : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the CustomerDetailsView class.
        /// </summary>
        public CustomerDetailsView()
        {
            InitializeComponent();
        }

        public void HandleDoubleClick(object sender, MouseButtonEventArgs mouseButtonEventArgs)
        {
            MessageBox.Show("Worked bitch");
        }
    }
}