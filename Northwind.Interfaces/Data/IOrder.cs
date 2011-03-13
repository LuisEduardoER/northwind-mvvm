using System;
using System.Runtime.Serialization;

namespace Northwind.Interfaces.Data
{
    public interface IOrder
    {
        [DataMember()]
        global::System.Int32 OrderID { get; set; }

        [DataMemberAttribute()]
        global::System.String CustomerID { get; set; }

        [DataMemberAttribute()]
        Nullable<global::System.Int32> EmployeeID { get; set; }

        [DataMemberAttribute()]
        Nullable<global::System.DateTime> OrderDate { get; set; }

        [DataMemberAttribute()]
        Nullable<global::System.DateTime> ShippedDate { get; set; }

        [DataMemberAttribute()]
        Nullable<global::System.Decimal> Freight { get; set; }
    }
}