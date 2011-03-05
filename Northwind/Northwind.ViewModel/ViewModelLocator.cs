using GalaSoft.MvvmLight;
using Northwind.Application;
using Northwind.Data;

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

        /// <summary>
        /// Gets the MainWindowViewModelBase property.
        /// </summary>
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

        /// <summary>
        /// Provides a deterministic way to delete the MainWindowViewModelBase property.
        /// </summary>
        public static void ClearMainWindowViewModel()
        {
            _mainWindowViewModelBase.Cleanup();
            _mainWindowViewModelBase = null;
        }

        /// <summary>
        /// Provides a deterministic way to create the MainWindowViewModelBase property.
        /// </summary>
        public static void CreateMainWindowViewModel()
        {
            if (_mainWindowViewModelBase == null)
            {
                if (ViewModelBase.IsInDesignModeStatic)
                {
                    _mainWindowViewModelBase
                        = new MainWindowViewModel(null);                    
                }
                else
                {
                    _mainWindowViewModelBase
                        = new MainWindowViewModel(
                                new ApplicationServices(
                                    new NorthwindManager(
                                        new SqlNorthwindRepository())));
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view models
            ////}
            ////else
            ////{
            ////    // Create run time view models
            ////}
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