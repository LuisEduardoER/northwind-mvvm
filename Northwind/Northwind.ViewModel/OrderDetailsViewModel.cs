using GalaSoft.MvvmLight;
using Northwind.Interfaces.Data.Model;

namespace Northwind.ViewModel
{
    public class OrderDetailsViewModel : ViewModelBase
    {
        private IOrderModel order;                

        public OrderDetailsViewModel(IOrderModel order)
        {
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real": Connect to service, etc...
            ////}
        }
    }
}