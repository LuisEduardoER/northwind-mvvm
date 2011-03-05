using System;
using Northwind.Interfaces;

namespace Northwind.ViewModel
{
    public class ControlPanelViewModel : ComponentsViewModel
    {
        #region Events

        public event EventHandler<CustomerEventArgs>
            ShowCustomerDetails = delegate { };

        #endregion Events

        public ControlPanelViewModel(
                IApplicationServices applicationServices)
            : base(Strings.ControlPanelHeader, applicationServices)
        {}

        protected override void AddComponents()
        {
            CustomerControlPanelViewModel
                customerControlPanelViewModel
                    = new CustomerControlPanelViewModel(
                        _applicationServices);
            customerControlPanelViewModel.ShowCustomerDetails 
                += customerControlPanelViewModel_ShowCustomerDetails;
            Components.Add(customerControlPanelViewModel);
            Components.Add(
                new OrderControlPanelViewModel(
                    _applicationServices));
        }

        void customerControlPanelViewModel_ShowCustomerDetails(
                object sender, CustomerEventArgs e)
        {
            ShowCustomerDetails(sender, e);
        }
    }
}