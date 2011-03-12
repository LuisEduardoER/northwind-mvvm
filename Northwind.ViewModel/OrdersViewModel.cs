using System.Collections.Generic;
using System.Collections.ObjectModel;
using Northwind.Application;
using Northwind.Interfaces;
using Northwind.Interfaces.Data.Model;

namespace Northwind.ViewModel
{
    public class OrdersViewModel : ToolViewModel
    {
        #region Fields

        private readonly ICustomerModel _customer;

        #endregion Fields

        #region Properties

        private ObservableCollection<IOrderModel> _orders = null;

        public ObservableCollection<IOrderModel> Orders
        {
            get
            {
                if (_orders == null)
                {
                    IEnumerable<IOrderModel> orders =
                        ApplicationServices.Instance.NorthwindManager.GetOrders(
                            _customer.CustomerID);
                    _orders 
                        = new ObservableCollection<IOrderModel>(orders);
                }
                return _orders;
            }
        }

        #endregion Properties

        #region Ctors

        public OrdersViewModel(ICustomerModel customer)
            : base(customer.CompanyName)
        {
            _customer = customer;
            if (IsInDesignMode)
            {
                // Code runs in Blend --> create design time data.
            }
            else
            {
                // Code runs "for real": Connect to service, etc...
            }
        }

        #endregion Ctors

        #region EventHandlers



        #endregion EventHandlers

        #region CommandHandlers



        #endregion CommandHandlers

        #region Helpers



        #endregion Helpers
    }
}