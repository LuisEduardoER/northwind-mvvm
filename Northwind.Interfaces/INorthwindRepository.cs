using System.Collections.Generic;
using Northwind.Interfaces.Data.Entity ;

namespace Northwind.Interfaces
{
    public interface INorthwindRepository
    {
        IEnumerable<ICustomerEntity> GetAllCustomersNameAndID();
        IEnumerable<IOrderEntity> GetOrders(string customerID);
        IEnumerable<IOrderDetailEntity> GetOrderDetails(int orderID);
        ICustomerEntity GetCustomerByID(string customerID);
        void SaveChanges();
    }
}