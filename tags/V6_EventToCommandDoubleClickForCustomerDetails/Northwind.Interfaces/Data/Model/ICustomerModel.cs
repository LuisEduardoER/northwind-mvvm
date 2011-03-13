using System.Collections.ObjectModel;

namespace Northwind.Interfaces.Data.Model
{
    public interface ICustomerModel : ICustomer
    {
        ObservableCollection<IOrderModel> Orders { get; }
    }
}