using System.Collections.Generic;

namespace Northwind.Interfaces.Data.Entity
{
    public interface IOrderEntity : IOrder
    {
        ICustomerEntity Customer { get; set; }
        IEmployeeEntity Employee { get; set; }
        IEnumerable<IOrderDetailEntity> GetOrderDetails();
    }
}