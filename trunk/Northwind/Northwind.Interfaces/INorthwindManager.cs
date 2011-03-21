using System.Collections.Generic;
using Northwind.Interfaces.Data.Model;

namespace Northwind.Interfaces
{
    public interface INorthwindManager
    {
        //TODO: can be more intuitive name as it is returning more than Name and ID
        IEnumerable<ICustomerModel> GetAllCustomersNameAndID(
            bool getOrders = false);

        IEnumerable<IOrderModel> GetOrders(string customerID);
        IEnumerable<IOrderDetailModel> GetOrderDetails(int orderID);

        ICustomerModel GetCustomerByID(string customerID);

        void SaveChanges();
    }
}