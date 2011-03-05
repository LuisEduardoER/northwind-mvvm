using System;
using System.Runtime.Serialization;

namespace Northwind.Interfaces.Data
{
    public interface IProduct
    {
        [DataMember()]
        global::System.Int32 ProductID { get; set; }

        [DataMemberAttribute()]
        Nullable<global::System.Int32> SupplierID { get; set; }

        [DataMemberAttribute()]
        Nullable<global::System.Int32> CategoryID { get; set; }

        [DataMemberAttribute()]
        global::System.String ProductName { get; set; }

        [DataMemberAttribute()]
        Nullable<global::System.Decimal> UnitPrice { get; set; }
    }
}