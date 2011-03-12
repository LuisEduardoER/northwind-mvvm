using System.Runtime.Serialization;

namespace Northwind.Interfaces.Data
{
    public interface ICategory
    {
        [DataMember()]
        global::System.Int32 CategoryID { get; set; }

        [DataMemberAttribute()]
        global::System.String CategoryName { get; set; }

        [DataMemberAttribute()]
        global::System.String Description { get; set; }
    }
}
