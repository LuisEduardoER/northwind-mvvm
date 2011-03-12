using Northwind.Interfaces.Data.Entity;
using Northwind.Interfaces.Data.Model;

namespace Northwind.Application.Model
{
    public class OrderDetailModel : ModelBase, IOrderDetailModel
    {
        private readonly IOrderDetailEntity _orderDetailsEntity;

        #region Properties

        public static string ProductPropertyName = "Product";
        private IProductModel _product;
        public IProductModel Product
        {
            get
            {
                return _product ??
                       new ProductModel(
                           _orderDetailsEntity.Product);
            }
            set
            {
                _product = value;
                RaisePropertyChanged(ProductPropertyName);
            }
        }

        public static string OrderPropertyName = "Order";
        private IOrderModel _order;
        public IOrderModel Order
        {
            get
            {
                return _order ??
                       new OrderModel(
                           _orderDetailsEntity.Order);
            }
            set
            {
                _order = value;
                RaisePropertyChanged(OrderPropertyName);
            }
        }

        public static string OrderIDPropertyName = "OrderID";
        public int OrderID
        {
            get { return _orderDetailsEntity.OrderID; }
            set
            {
                _orderDetailsEntity.OrderID = value;
                RaisePropertyChanged(OrderIDPropertyName);
            }
        }

        public static string ProductIDPropertyName = "ProductID";
        public int ProductID
        {
            get { return _orderDetailsEntity.ProductID; }
            set
            {
                _orderDetailsEntity.ProductID = value;
                RaisePropertyChanged(ProductIDPropertyName);
            }
        }

        public static string UnitPricePropertyName = "UnitPrice";
        public decimal UnitPrice
        {
            get { return _orderDetailsEntity.UnitPrice; }
            set
            {
                _orderDetailsEntity.UnitPrice = value;
                RaisePropertyChanged(UnitPricePropertyName);
            }
        }

        public static string QuantityPropertyName = "Quantity";
        public short Quantity
        {
            get { return _orderDetailsEntity.Quantity; }
            set
            {
                _orderDetailsEntity.Quantity = value;
                RaisePropertyChanged(QuantityPropertyName);
            }
        }

        public static string DiscountPropertyName = "DiscountPropertyName";
        public float Discount
        {
            get { return _orderDetailsEntity.Discount; }
            set
            {
                _orderDetailsEntity.Discount = value;
                RaisePropertyChanged(DiscountPropertyName);
            }
        }

        #endregion Properties

        public OrderDetailModel(IOrderDetailEntity orderDetailsEntity)
        {
            _orderDetailsEntity = orderDetailsEntity;
        }
    }
}
