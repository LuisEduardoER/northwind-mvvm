using GalaSoft.MvvmLight;
using Northwind.Interfaces;

namespace Northwind.ViewModel
{
    public class OrderControlPanelViewModel : ComponentsViewModel
    {
        public OrderControlPanelViewModel(
                IApplicationServices applicationServices)
            : base(Strings.OrderControlPanelName, applicationServices)
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

        protected override void AddComponents()
        {
            // TODO: Implement me
        }
    }
}