using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using Northwind.Application;
using Northwind.Interfaces;
using Northwind.Interfaces.Data.Model;

namespace Northwind.ViewModel
{

    public class CustomerDetailsViewModel : ToolViewModel
    {
        #region Fields

        private bool _isDirty = false;

        #endregion Fields

        #region Properties

        private readonly ICustomerModel _customer;
        public ICustomerModel Customer { get { return _customer; } }
        public IEnumerable<IOrderModel> Orders { get; private set; }

        public const string UpdateCommandViewModelPropertyName 
            = "UpdateCommandViewModel";

        private CommandViewModel _updateCommandViewModel = null;

        public CommandViewModel UpdateCommandViewModel
        {
            get
            {
                return _updateCommandViewModel;
            }

            set
            {
                if (_updateCommandViewModel == value)
                {
                    return;
                }
                _updateCommandViewModel = value;
                RaisePropertyChanged(UpdateCommandViewModelPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="DetailsItemStyle" /> property's name.
        /// </summary>
        public const string DetailsItemStylePropertyName = "DetailsItemStyle";

        private ICommand _detailsItemStyle = null;

        public ICommand DetailsItemStyle
        {
            get
            {
                if (_detailsItemStyle == null)
                {
                    _detailsItemStyle =
                        new RelayCommand<string>(ShowOrderDetails);
                }
                return _detailsItemStyle;
            }
        }

        private static void ShowOrderDetails(string id)
        {
            throw new NotImplementedException();
        }

        #endregion Properties


        public CustomerDetailsViewModel(string customerID)
        {
            _customer = ApplicationServices.Instance
                .NorthwindManager.GetCustomerByID(customerID);
            Name = Strings.CustomerDetailsDisplayName;
            ((INotifyPropertyChanged)_customer).PropertyChanged 
                += CustomerDetailsViewModel_PropertyChanged;
            Orders =
                ApplicationServices.Instance
                    .NorthwindManager.GetOrders(
                        Customer.CustomerID);
            UpdateCommandViewModel = new CommandViewModel(
                Strings.UpdateCommandName,
                new RelayCommand(UpdateCommand_Execute, 
                    UpdateCommand_CanExecute));
        }

        void CustomerDetailsViewModel_PropertyChanged(
            object sender, PropertyChangedEventArgs e)
        {
            _isDirty = true;
            ((RelayCommand)UpdateCommandViewModel.Command)
                .RaiseCanExecuteChanged();
        }

        #region Command Handlers

        public void UpdateCommand_Execute()
        {
            ApplicationServices.Instance.NorthwindManager
                .SaveChanges();
        }

        public bool UpdateCommand_CanExecute()
        {
            return _isDirty;
        }

        #endregion Command Handlers
    }
}