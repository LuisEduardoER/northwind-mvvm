using System;
using System.Collections.ObjectModel;
using Northwind.Application;
using Northwind.Interfaces;
using Northwind.Interfaces.Data.Model;

namespace Northwind.ViewModel
{
    public class CustomerSearchBoxViewModel : NamedViewModel
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

        private ObservableCollection<CustomerViewModel> _customers
                    = new ObservableCollection<CustomerViewModel>();

        public ObservableCollection<CustomerViewModel> Customers
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

        #region Events

        public event EventHandler ShowCustomerDetails 
            = delegate {};

        #endregion Events

        public CustomerSearchBoxViewModel()
            : base(Strings.CustomerSearchBoxName)
        {
            if (IsInDesignMode)
            {
                // Code runs in Blend --> create design time data.
            }
            else
            {
                foreach (ICustomerModel customer
                    in ApplicationServices.Instance.NorthwindManager
                        .GetAllCustomersNameAndID())
                {
                    CustomerViewModel customerViewModel =
                        new CustomerViewModel(customer);
                    customerViewModel.ShowCustomerDetails 
                        += CustomerViewModelShowCustomerDetails;
                    Customers.Add(customerViewModel);
                }
            }
        }

        void CustomerViewModelShowCustomerDetails(
            object sender, CustomerEventArgs e)
        {
            ShowCustomerDetails(this, EventArgs.Empty);
        }
    }
}
