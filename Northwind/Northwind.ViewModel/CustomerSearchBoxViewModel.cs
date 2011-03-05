using System;
using System.Collections.ObjectModel;
using Northwind.Interfaces;
using Northwind.Interfaces.Data.Model;

namespace Northwind.ViewModel
{
    public class CustomerSearchBoxViewModel : ServiceViewModel
    {
        #region Properties

        public const string SelectedCustomerPropertyName
        = "SelectedCustomer";

        private ICustomerModel _selectedCustomer = null;

        public ICustomerModel SelectedCustomer
        {
            get
            {
                return _selectedCustomer;
            }

            set
            {
                if (_selectedCustomer == value)
                {
                    return;
                }

                _selectedCustomer = value;

                RaisePropertyChanged(SelectedCustomerPropertyName);
            }
        }

        public const string CustomersPropertyName = "Customers";

        private ObservableCollection<ICustomerModel> _customers 
                    = new ObservableCollection<ICustomerModel>();

        public ObservableCollection<ICustomerModel> Customers
        {
            get
            {
                return _customers;
            }

            set
            {
                if (_customers == value)
                {
                    return;
                }

                _customers = value;

                RaisePropertyChanged(CustomersPropertyName);
            }
        }        

        #endregion Properties

        public CustomerSearchBoxViewModel(
                IApplicationServices applicationServices)
            : base(Strings.CustomerSearchBoxName, applicationServices)
        {
            if (IsInDesignMode)
            {
                // Code runs in Blend --> create design time data.
            }
            else
            {
                foreach (ICustomerModel customer
                    in _applicationServices.NorthwindManager
                        .GetAllCustomersNameAndID())
                {
                    Customers.Add(customer);
                }
            }            
        }
    }
}
