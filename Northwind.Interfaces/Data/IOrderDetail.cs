using System.Runtime.Serialization;

namespace Northwind.Interfaces.Data
{
    public interface IOrderDetail
    {
        [DataMember()]
        global::System.Int32 OrderID { get; set; }

        [DataMemberAttribute()]
        global::System.Int32 ProductID { get; set; }

        [DataMemberAttribute()]
        global::System.Decimal UnitPrice { get; set; }

        [DataMemberAttribute()]
        global::System.Int16 Quantity { get; set; }

        [DataMemberAttribute()]
        global::System.Single Discount { get; set; }
    }
}
