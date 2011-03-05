using GalaSoft.MvvmLight;
using Northwind.Interfaces;

namespace Northwind.ViewModel
{

    public class ServiceViewModel : NamedViewModel
    {
        #region Fields

        protected IApplicationServices _applicationServices;

        #endregion Fields

        public ServiceViewModel(string header, 
                IApplicationServices applicationServices)
            : base(header)
        {
            _applicationServices = applicationServices;
        }
    }
}