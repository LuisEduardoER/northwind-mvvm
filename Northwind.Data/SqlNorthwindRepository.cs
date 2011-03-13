using System.Collections.Generic;
using System.Linq;
using Northwind.Interfaces;
using Northwind.Interfaces.Data.Entity;

namespace Northwind.Data
{
    public class SqlNorthwindRepository : INorthwindRepository
    {
        private readonly NorthwindEntities _northwindEntities;

        public SqlNorthwindRepository()
        {
            _northwindEntities = new NorthwindEntities();
        }

        public IEnumerable<ICustomerEntity> GetAllCustomersNameAndID()
        {
            List<ICustomerEntity> customerEntities = new List<ICustomerEntity>();
            var customers = from c in _northwindEntities.Customers
                            select new {c.CustomerID, c.CompanyName};
            foreach (var customer in customers)
            {
                customerEntities.Add(new Customer()
                                         {
                                             CustomerID = customer.CustomerID,
                                             CompanyName = customer.CompanyName
                                         });
            }
            return customerEntities;
        }

        public IEnumerable<IOrderEntity> GetOrders(string customerID)
        {
            return (from o in _northwindEntities.Orders
                   where o.CustomerID == customerID
                   select o).ToList<IOrderEntity>();
        }

        public IEnumerable<IOrderDetailEntity> GetOrderDetails(int orderID)
        {
            return (from od in _northwindEntities.Order_Details
                   where od.OrderID == orderID
                   select od).ToList<IOrderDetailEntity>();
        }


        public ICustomerEntity GetCustomerByID(string customerID)
        {
            return (from c in _northwindEntities.Customers
                    where c.CustomerID == customerID
                    select c).FirstOrDefault();
        }


        public void SaveChanges()
        {
            _northwindEntities.SaveChanges();
        }
    }
}
