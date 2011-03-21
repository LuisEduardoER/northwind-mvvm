using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using Northwind.Application.Model;
using Northwind.Interfaces.Data.Model;

namespace Northwind.ViewModel
{
    //TODO: Why does it implement INotifyPropertyChanged instead of inheriting from ViewModelBase?
    public class CustomerViewModel : ICustomerModel, INotifyPropertyChanged
    {
        #region Fields

        private readonly ICustomerModel _model;

        #endregion Fields

        #region Properties

        private ICommand _showCustomerDetails;
        public ICommand ShowCustomerDetailsCommand
        {
            get
            {
                if (_showCustomerDetails == null)
                {
                    _showCustomerDetails =
                        new RelayCommand(
                            () =>
                            ShowCustomerDetails(this,
                                new CustomerEventArgs(
                                    this.CustomerID)));

                }
                return _showCustomerDetails;
            }
        }

        public string CustomerID
        {
            get { return _model.CustomerID; }
            set { _model.CustomerID = value; }
        }

        public string CompanyName
        {
            get { return _model.CompanyName; }
            set { _model.CompanyName = value; }
        }

        public string ContactName
        {
            get { return _model.ContactName; }
            set { _model.ContactName = value; }
        }

        public string ContactTitle
        {
            get { return _model.ContactTitle; }
            set { _model.ContactTitle = value; }
        }

        public string Address
        {
            get { return _model.Address; }
            set { _model.Address = value; }
        }

        public string City
        {
            get { return _model.City; }
            set { _model.City = value; }
        }

        public string Region
        {
            get { return _model.Region; }
            set { _model.Region = value; }
        }

        public string PostalCode
        {
            get { return _model.PostalCode; }
            set { _model.PostalCode = value; }
        }

        public string Country
        {
            get { return _model.Country; }
            set { _model.Country = value; }
        }

        public string Phone
        {
            get { return _model.Phone; }
            set { _model.Phone = value; }
        }

        public ObservableCollection<IOrderModel> Orders
        {
            get { return _model.Orders; }
        }

        #endregion Properties

        #region Events

        public event EventHandler<CustomerEventArgs>
            ShowCustomerDetails = delegate
                                      {
                                      };
        public event PropertyChangedEventHandler 
            PropertyChanged = delegate
                                    {
                                    };

        #endregion Events

        #region Ctor

        public CustomerViewModel(ICustomerModel model)
        {
            _model = model;
            ((INotifyPropertyChanged)_model).PropertyChanged
                += CustomerViewModelPropertyChanged;
        }        

        #endregion Ctor

        #region Helpers

        void CustomerViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            PropertyChanged(sender, e);
        }

        #endregion Helpers

    }
}
