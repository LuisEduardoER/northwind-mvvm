using System.Runtime.Serialization;

namespace Northwind.Interfaces.Data
{
    public interface ICustomer
    {
        [DataMember()]
        global::System.String CustomerID { get; set; }

        [DataMemberAttribute()]
        global::System.String CompanyName { get; set; }

        [DataMemberAttribute()]
        global::System.String ContactName { get; set; }

        [DataMemberAttribute()]
        global::System.String ContactTitle { get; set; }

        [DataMemberAttribute()]
        global::System.String Address { get; set; }

        [DataMemberAttribute()]
        global::System.String City { get; set; }

        [DataMemberAttribute()]
        global::System.String Region { get; set; }

        [DataMemberAttribute()]
        global::System.String PostalCode { get; set; }

        [DataMemberAttribute()]
        global::System.String Country { get; set; }

        [DataMemberAttribute()]
        global::System.String Phone { get; set; }
    }
}