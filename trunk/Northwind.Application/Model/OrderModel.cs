using System;
using System.Collections.ObjectModel;
using Northwind.Interfaces.Data.Entity;
using Northwind.Interfaces.Data.Model;

namespace Northwind.Application.Model
{
    public class OrderModel : ModelBase, IOrderModel
    {
        private readonly IOrderEntity _orderEntity;

        #region Propeties

        public static string CustomerPropertyName = "Customer";
        private ICustomerModel _customer;
        public ICustomerModel Customer
        {
            get
            {
                return _customer ??
                       new CustomerModel(
                           _orderEntity.Customer);
            }
            set
            {
                _customer = value;
                RaisePropertyChanged(CustomerPropertyName);
            }
        }

        public static string EmployeePropertyName = "Employee";
        public IEmployeeModel _employee;
        public IEmployeeModel Employee
        {
            get
            {
                return _employee ??
                       new EmployeeModel(
                           _orderEntity.Employee);
            }
            set
            {
                _employee = value;
                RaisePropertyChanged(EmployeePropertyName);
            }
        }

        private ObservableCollection<IOrderDetailModel>
            _orderDetails;
        public ObservableCollection<IOrderDetailModel> OrderDetails
        {
            get
            {
                if (_orderDetails == null)
                {
                    _orderDetails
                        = new ObservableCollection<IOrderDetailModel>();
                    foreach (IOrderDetailEntity order
                        in _orderEntity.GetOrderDetails())
                    {
                        _orderDetails.Add(new OrderDetailModel(order));
                    }
                }
                return _orderDetails;
            }
        }

        public static string OrderIDPropertyName = "OrderID";
        public int OrderID
        {
            get { return _orderEntity.OrderID; }
            set
            {
                _orderEntity.OrderID = value;
                RaisePropertyChanged(OrderIDPropertyName);
            }
        }

        public static string CustomerIDPropertyName = "CustomerID";
        public string CustomerID
        {
            get { return _orderEntity.CustomerID; }
            set
            {
                _orderEntity.CustomerID = value;
                RaisePropertyChanged(CustomerIDPropertyName);
            }
        }

        public static string EmployeeIDPropertyName = "EmployeeID";
        public int? EmployeeID
        {
            get { return _orderEntity.EmployeeID; }
            set
            {
                _orderEntity.EmployeeID = value;
                RaisePropertyChanged(EmployeeIDPropertyName);
            }
        }

        public static string OrderDatePropertyName = "OrderDate";
        public DateTime? OrderDate
        {
            get { return _orderEntity.OrderDate; }
            set
            {
                _orderEntity.OrderDate = value;
                RaisePropertyChanged(OrderDatePropertyName);
            }
        }

        public static string ShippedDatePropertyName = "ShippedDate";
        public DateTime? ShippedDate
        {
            get { return _orderEntity.ShippedDate; }
            set
            {
                _orderEntity.ShippedDate = value;
                RaisePropertyChanged(ShippedDatePropertyName);
            }
        }

        public static string FreightPropertyName = "Freight";
        public decimal? Freight
        {
            get { return _orderEntity.Freight; }
            set
            {
                _orderEntity.Freight = value;
                RaisePropertyChanged(FreightPropertyName);
            }
        }

        private decimal _total = decimal.MinValue;
        public decimal Total
        {
            get
            {
                if (_total == decimal.MinValue)
                {
                    _total = 0;
                    foreach(IOrderDetailModel orderDetail 
                        in OrderDetails)
                    {
                        _total += ((orderDetail.UnitPrice -
                                    (decimal)
                                    orderDetail.Discount)*
                                   orderDetail.Quantity);
                    }
                }
                return _total;
            }
        }

        #endregion Properties

        public OrderModel(IOrderEntity orderEntity)
        {
            _orderEntity = orderEntity;
        }
    }
}