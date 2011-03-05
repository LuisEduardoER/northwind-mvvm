using System;
using System.Collections.Specialized;
using System.ComponentModel;
using GalaSoft.MvvmLight.Command;
using Northwind.Interfaces;
using Northwind.Interfaces.Data.Model;

namespace Northwind.ViewModel
{
    public class CustomerEventArgs : EventArgs
    {
        public string CustomerID { get; set; }

        public CustomerEventArgs(string customerID)
        {
            CustomerID = customerID;
        }
    }

    public class CustomerControlPanelViewModel : ComponentsViewModel
    {
        #region Fields

        private CustomerSearchBoxViewModel _customerSearchBoxViewModel = null;
        private CommandViewModel _showDetailsCommandViewModel = null;

        #endregion Fields

        public event EventHandler<CustomerEventArgs>
            ShowCustomerDetails = delegate {};

        public const string SelectedCustomerPropertyName 
                = "SelectedCustomer";

        public ICustomerModel SelectedCustomer
        {
            get
            {
                return _customerSearchBoxViewModel.SelectedCustomer;
            }
        }

        public CustomerControlPanelViewModel(
                IApplicationServices applicationServices)
            : base(Strings.CustomerDetailsDisplayName, 
                applicationServices)
        {
            _applicationServices = applicationServices;
        }

        protected override void AddComponents()
        {
            _customerSearchBoxViewModel
                = new CustomerSearchBoxViewModel(_applicationServices);
            _customerSearchBoxViewModel.PropertyChanged 
                += _customerSearchBoxViewModel_PropertyChanged;
            Components.Add(_customerSearchBoxViewModel);
            _showDetailsCommandViewModel = new CommandViewModel(
                Strings.CustomerShowDetails,
                new RelayCommand(
                    OnShowCustomerDetails,
                    IsCustomerSelected));
            Components.Add(_showDetailsCommandViewModel);
        }

        void _customerSearchBoxViewModel_PropertyChanged(
            object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case CustomerSearchBoxViewModel
                    .SelectedCustomerPropertyName:
                    {
                        _showDetailsCommandViewModel
                            .RaiseCanExecuteChanged();
                    }
                    break;
            }
        }

        #region Command Handlers

        public void OnShowCustomerDetails()
        {
            ShowCustomerDetails(this, 
                new CustomerEventArgs(SelectedCustomer.CustomerID));
        }

        bool IsCustomerSelected()
        {
            return SelectedCustomer != null;
        }

        #endregion Command Handlers

    }
}