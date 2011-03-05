using Northwind.Application;
using Northwind.Interfaces.Data.Model;

namespace Northwind.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Northwind Console...");
            
            WriteOutCustomers();
        }

        private static void WriteOutCustomers()
        {
            System.Console.WriteLine("Customers: ");
            foreach (ICustomerModel customer 
                in ApplicationServices.Instance
                    .NorthwindManager.GetAllCustomersNameAndID())
            {
                System.Console.WriteLine(customer.CompanyName);
            }
        }
    }
}
