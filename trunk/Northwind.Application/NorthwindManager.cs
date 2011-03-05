using System.Collections.Generic;
using System.Linq;
using Northwind.Interfaces;
using Northwind.Interfaces.Data.Model;
using Northwind.Application.Model;

namespace Northwind.Application
{
    public class NorthwindManager : INorthwindManager
    {
        private readonly INorthwindRepository _dataProvider;

        public NorthwindManager(INorthwindRepository dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public IEnumerable<ICustomerModel> GetAllCustomersNameAndID(
            bool getOrders = false)
        {
            return _dataProvider.GetAllCustomersNameAndID()
                .Select(
                    customerEntity => 
                        new CustomerModel(customerEntity))
                .ToList();
        }

        public IEnumerable<IOrderModel> GetOrders(string customerID)
        {
            return _dataProvider.GetOrders(customerID)
                .Select(
                    orderEntity => new OrderModel(orderEntity))
                .ToList();
        }

        public IEnumerable<IOrderDetailModel> GetOrderDetails(int orderID)
        {
            return _dataProvider.GetOrderDetails(orderID)
                .Select(
                    orderDetailsEntity =>
                    new OrderDetailModel(orderDetailsEntity))
                .ToList();
        }


        public ICustomerModel GetCustomerByID(string customerID)
        {
            return new CustomerModel(_dataProvider.GetCustomerByID(customerID));
        }


        public void SaveChanges()
        {
            _dataProvider.SaveChanges();
        }
    }
}
