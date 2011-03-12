using System.Runtime.Serialization;

namespace Northwind.Interfaces.Data.Entity
{  
    public interface IOrderDetailEntity : IOrderDetail
    {
        IProductEntity Product { get; set; }
        IOrderEntity Order { get; set; }
    }
}
