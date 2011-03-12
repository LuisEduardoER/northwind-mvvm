using System.Collections.Generic;
using System.Linq;
using Northwind.Interfaces.Data;
using Northwind.Interfaces.Data.Entity;

namespace Northwind.Data
{
    partial class Employee : IEmployeeEntity
    {
        public IEnumerable<IOrderEntity> GetOrders()
        {
            return Orders.Cast<IOrderEntity>();
        }
    }
}
