using System;
using System.Linq;
using System.Collections.ObjectModel;
using Northwind.Interfaces.Data.Entity;
using Northwind.Interfaces.Data.Model;

namespace Northwind.Application.Model
{
    public class CustomerModel : ModelBase, ICustomerModel
    {
        private readonly ICustomerEntity _customerEntity;

        public CustomerModel(ICustomerEntity customerEntity)
        {
            _customerEntity = customerEntity;
        }

        public static string CustomerIDPropertyName = "CustomerID";
        public string CustomerID
        {
            get { return _customerEntity.CustomerID; }
            set
            {
                _customerEntity.CustomerID = value;
                RaisePropertyChanged(CustomerIDPropertyName);
            }
        }

        public static string CompanyNamePropertyName = "CompanyName";
        public string CompanyName
        {
            get { return _customerEntity.CompanyName; }
            set
            {
                _customerEntity.CompanyName = value;
                RaisePropertyChanged(CompanyNamePropertyName);
            }
        }

        public static string ContactNamePropertyName = "ContactName";
        public string ContactName
        {
            get { return _customerEntity.ContactName; }
            set
            {
                _customerEntity.ContactName = value;
                RaisePropertyChanged(ContactNamePropertyName);
            }
        }

        public static string ContactTitlePropertyName = "ContactTitle";
        public string ContactTitle
        {
            get { return _customerEntity.ContactTitle; }
            set
            {
                _customerEntity.ContactTitle = value;
                RaisePropertyChanged(ContactTitlePropertyName);
            }
        }

        public static string AddressPropertyName = "Address";
        public string Address
        {
            get { return _customerEntity.Address; }
            set
            {
                _customerEntity.Address = value;
                RaisePropertyChanged(AddressPropertyName);
            }
        }

        public static string CityPropertyName = "City";
        public string City
        {
            get { return _customerEntity.City; }
            set
            {
                _customerEntity.City = value;
                RaisePropertyChanged(CityPropertyName);
            }
        }

        public static string RegionPropertyName = "Region";
        public string Region
        {
            get { return _customerEntity.Region; }
            set
            {
                _customerEntity.Region = value;
                RaisePropertyChanged(RegionPropertyName);
            }
        }

        public static string PostalCodePropertyName = "PostalCode";
        public string PostalCode
        {
            get { return _customerEntity.PostalCode; }
            set
            {
                _customerEntity.PostalCode = value;
                RaisePropertyChanged(PostalCodePropertyName);
            }
        }

        public static string CountryPropertyName = "Country";
        public string Country
        {
            get { return _customerEntity.Country; }
            set
            {
                _customerEntity.Country = value;
                RaisePropertyChanged(CountryPropertyName);
            }
        }

        public static string PhonePropertyName = "Phone";
        public string Phone
        {
            get { return _customerEntity.Phone; }
            set
            {
                _customerEntity.Phone = value;
                RaisePropertyChanged(PhonePropertyName);
            }
        }

        public static string OrdersPropertyName = "Orders";
        private ObservableCollection<IOrderModel> _orders;
        public ObservableCollection<IOrderModel> Orders
        {
            get
            {
                if (_orders == null)
                {
                    _orders = new ObservableCollection<IOrderModel>();
                    foreach (var order in _customerEntity.GetOrders())
                         _orders.Add(new OrderModel(order));
                }
                return _orders;
            }
        }
    }
}