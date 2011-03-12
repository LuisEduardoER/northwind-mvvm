using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Northwind.Interfaces.Data.Entity
{
    public interface ICustomerEntity : ICustomer
    {
        IEnumerable<IOrderEntity> GetOrders();
    }
}