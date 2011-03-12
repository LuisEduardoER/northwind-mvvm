using System.Collections.Generic;

namespace Northwind.Interfaces.Data.Entity
{
    public interface IProductEntity : IProduct
    {
        ICategoryEntity Category { get; set; }
        IEnumerable<IOrderDetailEntity> GetOrderDetails();
    }
}