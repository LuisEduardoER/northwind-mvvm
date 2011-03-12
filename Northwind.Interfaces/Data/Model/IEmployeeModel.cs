using System.Collections.ObjectModel;

namespace Northwind.Interfaces.Data.Model
{
    public interface IEmployeeModel : IEmployee
    {
        ObservableCollection<IOrderModel> Orders { get; }
    }
}