using System.Collections.ObjectModel;

namespace Northwind.Interfaces.Data.Model
{
    public interface IProductModel : IProduct
    {
        ICategoryModel Category { get; set; }
        ObservableCollection<IOrderDetailModel> OrderDetails { get; set; }
    }
}