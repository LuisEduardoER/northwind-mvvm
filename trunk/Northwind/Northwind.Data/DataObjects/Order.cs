using System.Collections.Generic;
using System.Linq;
using Northwind.Interfaces.Data.Entity;

namespace Northwind.Data
{
    partial class Order : IOrderEntity
    {

        ICustomerEntity IOrderEntity.Customer
        {
	        get { return Customer; }
	        set 
	        { 
		        Customer = value as Customer; 
	        }
        }

        IEmployeeEntity IOrderEntity.Employee
        {
	        get { return Employee; }
	        set 
	        { 
		        Employee = value as Employee; 
	        }
        }

        public IEnumerable<IOrderDetailEntity> GetOrderDetails()
        {
            return Order_Details.Cast<IOrderDetailEntity>();
        }
    }
}
