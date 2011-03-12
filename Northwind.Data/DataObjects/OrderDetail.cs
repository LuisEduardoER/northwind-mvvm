using Northwind.Interfaces.Data;
using Northwind.Interfaces.Data.Entity;

namespace Northwind.Data
{
    partial class OrderDetail : IOrderDetailEntity
    {

        IProductEntity IOrderDetailEntity.Product
        {
            get { return Product; }
            set { Product = value as Product; }
        }

        IOrderEntity IOrderDetailEntity.Order
        {
            get { return Order; }
            set { Order = value as Order; }
        }
    }
}
