using System.Collections.ObjectModel;
using Northwind.Interfaces.Data.Model;
using Northwind.Interfaces.Data.Entity;

namespace Northwind.Application.Model
{
    public class EmployeeModel : ModelBase, IEmployeeModel
    {
        private readonly IEmployeeEntity _employeeEntity;

        #region Properties

        private ObservableCollection<IOrderModel> _orders;
        public ObservableCollection<IOrderModel> Orders
        {
            get
            {
                if (_orders == null)
                {
                    _orders
                        = new ObservableCollection<IOrderModel>();
                    foreach (IOrderEntity order
                        in _employeeEntity.GetOrders())
                    {
                        _orders.Add(new OrderModel(order));
                    }
                }
                return _orders;
            }
        }

        public static string EmployeeIDPropertyName = "EmployeeID";
        public int EmployeeID
        {
            get { return _employeeEntity.EmployeeID; }
            set
            {
                _employeeEntity.EmployeeID = value;
                RaisePropertyChanged(EmployeeIDPropertyName);
            }
        }

        public static string LastNamePropertyName = "LastName";
        public string LastName
        {
            get { return _employeeEntity.LastName; }
            set
            {
                _employeeEntity.LastName = value;
                RaisePropertyChanged(LastNamePropertyName);
            }
        }

        public static string FirstNamePropertyName = "FirstName";
        public string FirstName
        {
            get { return _employeeEntity.FirstName; }
            set
            {
                _employeeEntity.FirstName = value;
                RaisePropertyChanged(FirstName);
            }
        }

        public static string TitlePropertyName = "Title";
        public string Title
        {
            get { return _employeeEntity.Title; }
            set
            {
                _employeeEntity.Title = value;
                RaisePropertyChanged(TitlePropertyName);
            }
        }

        #endregion Properties

        public EmployeeModel(IEmployeeEntity employeeEntity)
        {
            _employeeEntity = employeeEntity;
        }
    }
}