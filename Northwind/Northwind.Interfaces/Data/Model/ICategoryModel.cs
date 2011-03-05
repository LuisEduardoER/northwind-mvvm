using System.Collections.ObjectModel;

namespace Northwind.Interfaces.Data.Model
{
    public interface ICategoryModel : ICategory
    {
        ObservableCollection<IProductModel> Products { get; }
    }
}
