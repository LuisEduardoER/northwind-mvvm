using System;
using Northwind.Application;
using Northwind.Interfaces;

namespace Northwind.ViewModel
{
    public class ControlPanelViewModel : ComponentsViewModel
    {
        #region Events

        public event EventHandler<CustomerEventArgs>
            ShowCustomerDetails = delegate { };

        #endregion Events

        public ControlPanelViewModel()
            : base(Strings.ControlPanelHeader)
        {}

        protected override void AddComponents()
        {
            CustomerControlPanelViewModel
                customerControlPanelViewModel
                    = new CustomerControlPanelViewModel();
            customerControlPanelViewModel.ShowCustomerDetails 
                += CustomerControlPanelViewModelShowCustomerDetails;
            Components.Add(customerControlPanelViewModel);
            Components.Add(
                new OrderControlPanelViewModel());
        }

        void CustomerControlPanelViewModelShowCustomerDetails(
                object sender, CustomerEventArgs e)
        {
            ShowCustomerDetails(sender, e);
        }
    }
}