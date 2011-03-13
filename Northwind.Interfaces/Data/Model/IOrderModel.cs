using System.Collections.ObjectModel;

namespace Northwind.Interfaces.Data.Model
{
    public interface IOrderModel : IOrder
    {
        decimal Total { get; }
        ICustomerModel Customer { get; set; }
        IEmployeeModel Employee { get; set; }
        ObservableCollection<IOrderDetailModel> OrderDetails { get; }
    }
}