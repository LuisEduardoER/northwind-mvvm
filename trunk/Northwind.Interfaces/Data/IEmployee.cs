using System.Runtime.Serialization;

namespace Northwind.Interfaces.Data
{
    public interface IEmployee
    {
        [DataMember()]
        global::System.Int32 EmployeeID { get; set; }

        [DataMemberAttribute()]
        global::System.String LastName { get; set; }

        [DataMemberAttribute()]
        global::System.String FirstName { get; set; }

        [DataMemberAttribute()]
        global::System.String Title { get; set; }
    }
}