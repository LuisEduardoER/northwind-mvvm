using System.Collections.Generic;
using System.Linq;
using Northwind.Interfaces.Data.Entity;

namespace Northwind.Data
{
    partial class Customer : ICustomerEntity
    {
        public IEnumerable<IOrderEntity> GetOrders()
        {
            return Orders.Cast<IOrderEntity>();
        }
    }
}
