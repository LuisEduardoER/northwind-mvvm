namespace Northwind.Interfaces.Data.Model
{
    public interface IOrderDetailModel : IOrderDetail
    {
        IProductModel Product { get; set; }
        IOrderModel Order { get; set; }
    }
}
