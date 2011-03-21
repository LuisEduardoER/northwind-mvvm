using Northwind.Application;

namespace Northwind.ViewModel
{
    //TODO: Why not implement Service Locator like singleton with MainViewModel as instance member instead
    //Otherwise we can keep it as is and use ObjectDataProvider to get the instance of view models
    //In that case we would not have to keep MainWindowViewModel instance as static. We would be creating a resource
    //in the Resources section of MainWindowViewModel and use it as DataContext
    public class ViewModelLocator
    {

        private static MainWindowViewModel _mainWindowViewModelBase;
        public static MainWindowViewModel MainWindowViewModelBaseStatic
        {
            get
            {
                if (_mainWindowViewModelBase == null)
                {
                    CreateMainWindowViewModel();
                }

                return _mainWindowViewModelBase;
            }
        }

        //TODO: Don't seem to need this after MainwWindowViewModelBaseStatic property which is static
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public MainWindowViewModel MainWindowViewModelBase
        {
            get
            {
                return MainWindowViewModelBaseStatic;
            }
        }

        //TODO: This method can be turned into a private static method
        public static void ClearMainWindowViewModel()
        {
            _mainWindowViewModelBase.Cleanup();
            _mainWindowViewModelBase = null;
        }

        //TODO: This method can be turned into a private static method
        public static void CreateMainWindowViewModel()
        {
            _mainWindowViewModelBase
                = ApplicationServices.Instance
                    .ObjectFactory.Get
                    <MainWindowViewModel>();
        }

        //TODO: can be turned into private if singleton is implemented
        public ViewModelLocator()
        {
        }

        //TODO: Why doesn't view directly calls the cleanup to view model using DataContext in 
        //the Closing Event using interaction behavior
        /// <summary>
        /// Cleans up all the resources.
        /// </summary>
        public static void Cleanup()
        {
            ClearMainWindowViewModel();
        }
    }
}