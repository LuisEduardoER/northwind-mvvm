using System.Collections.Generic;

namespace Northwind.Interfaces.Data.Entity
{
    public interface ICategoryEntity : ICategory
    {
        IEnumerable<IProductEntity> GetProducts();
    }
}
