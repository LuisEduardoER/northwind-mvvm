using System.Collections.Generic;
using System.Linq;
using Northwind.Interfaces.Data.Entity;

namespace Northwind.Data
{
    partial class Category : ICategoryEntity
    {
        public IEnumerable<IProductEntity> GetProducts()
        {
            return Products.Cast<IProductEntity>();
        }
    }
}
