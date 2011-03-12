using System.Collections.Generic;
using Northwind.Interfaces.Data.Model;

namespace Northwind.Interfaces
{
    public interface INorthwindManager
    {
        IEnumerable<ICustomerModel> GetAllCustomersNameAndID(
            bool getOrders = false);

        IEnumerable<IOrderModel> GetOrders(string customerID);
        IEnumerable<IOrderDetailModel> GetOrderDetails(int orderID);

        ICustomerModel GetCustomerByID(string customerID);

        void SaveChanges();
    }
}