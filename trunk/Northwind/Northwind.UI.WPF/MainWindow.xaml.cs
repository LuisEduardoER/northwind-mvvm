using System.Windows;
using Northwind.ViewModel;

namespace Northwind.UI.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //TODO: I have noticed some memory leaks when subscribing to lambda as event handlers
            //as we can not unsubscribe. Should we verify this?
            //Instead of cleaning up using ViewModelLocator, can we use EventTrigger with interaction behavior to
            //call cleanup method in the view model. We will be saving the ViewModelLocator route then
            Closing += (s, e) => ViewModelLocator.Cleanup();
        }
    }
}
