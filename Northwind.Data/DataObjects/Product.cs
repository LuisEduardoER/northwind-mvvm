using System.Collections.Generic;
using System.Linq;
using Northwind.Interfaces.Data.Entity;

namespace Northwind.Data
{
    partial class Product : IProductEntity
    {

        ICategoryEntity IProductEntity.Category
        {
            get { return Category; }
            set { Category = value as Category; }
        }

        public IEnumerable<IOrderDetailEntity> GetOrderDetails()
        {
            return Order_Details.Cast<IOrderDetailEntity>();
        }
    }
}
