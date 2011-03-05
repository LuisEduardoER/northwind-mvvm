using System.Collections.Generic;
using System.Linq;
using Northwind.Interfaces;
using Northwind.Interfaces.Data.Model;
using Northwind.Application.Model;

namespace Northwind.Application
{
    public class NorthwindManager : INorthwindManager
    {
        private readonly INorthwindRepository _repository;

        public NorthwindManager()
        {
            _repository = ApplicationServices.Instance
                .ObjectFactory.Get<INorthwindRepository>();
        }

        public IEnumerable<ICustomerModel> GetAllCustomersNameAndID(
            bool getOrders = false)
        {
            return _repository.GetAllCustomersNameAndID()
                .Select(
                    customerEntity => 
                        new CustomerModel(customerEntity))
                .ToList();
        }

        public IEnumerable<IOrderModel> GetOrders(string customerID)
        {
            return _repository.GetOrders(customerID)
                .Select(
                    orderEntity => new OrderModel(orderEntity))
                .ToList();
        }

        public IEnumerable<IOrderDetailModel> GetOrderDetails(int orderID)
        {
            return _repository.GetOrderDetails(orderID)
                .Select(
                    orderDetailsEntity =>
                    new OrderDetailModel(orderDetailsEntity))
                .ToList();
        }


        public ICustomerModel GetCustomerByID(string customerID)
        {
            return new CustomerModel(_repository.GetCustomerByID(customerID));
        }


        public void SaveChanges()
        {
            _repository.SaveChanges();
        }
    }
}
