using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Northwind.Interfaces.Data.Entity
{
    public interface IEmployeeEntity : IEmployee
    {
        IEnumerable<IOrderEntity> GetOrders();
    }
}