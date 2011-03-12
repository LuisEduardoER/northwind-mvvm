using Northwind.Application;

namespace Northwind.ViewModel
{
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

        public static void ClearMainWindowViewModel()
        {
            _mainWindowViewModelBase.Cleanup();
            _mainWindowViewModelBase = null;
        }

        public static void CreateMainWindowViewModel()
        {
            _mainWindowViewModelBase
                = ApplicationServices.Instance
                    .ObjectFactory.Get
                    <MainWindowViewModel>();
        }

        public ViewModelLocator()
        {
        }

        /// <summary>
        /// Cleans up all the resources.
        /// </summary>
        public static void Cleanup()
        {
            ClearMainWindowViewModel();
        }
    }
}