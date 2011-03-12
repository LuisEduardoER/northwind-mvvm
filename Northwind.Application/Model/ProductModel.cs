using System.Collections.ObjectModel;
using Northwind.Interfaces.Data.Entity;
using Northwind.Interfaces.Data.Model;

namespace Northwind.Application.Model
{
    public class ProductModel : ModelBase, IProductModel
    {
        private readonly IProductEntity _productEntity;

        #region Propeties

        public static string OrderDetailsPropertyName = "OrderDetails";
        private ObservableCollection<IOrderDetailModel>
            _orderDetails;
        public ObservableCollection<IOrderDetailModel> OrderDetails
        {
            get
            {
                if (_orderDetails == null)
                {
                    _orderDetails
                        = new ObservableCollection<IOrderDetailModel>();
                    foreach (IOrderDetailEntity orderDetail
                        in _productEntity.GetOrderDetails())
                    {
                        _orderDetails.Add(new OrderDetailModel(orderDetail));
                    }
                }
                return _orderDetails;
            }
            set { _orderDetails = value; RaisePropertyChanged(OrderDetailsPropertyName);}
        }

        public static string ProductIDPropertyName = "ProductID";
        public int ProductID
        {
            get { return _productEntity.ProductID; }
            set
            {
                _productEntity.ProductID = value;
                RaisePropertyChanged(ProductIDPropertyName);
            }
        }

        public static string SupplierIDPropertyName = "SupplierID";
        public int? SupplierID
        {
            get { return _productEntity.SupplierID; }
            set
            {
                _productEntity.SupplierID = value;
                RaisePropertyChanged(SupplierIDPropertyName);
            }
        }

        public static string CategoryIDPropertyName = "CategoryID";
        public int? CategoryID
        {
            get { return _productEntity.CategoryID; }
            set
            {
                _productEntity.CategoryID = value;
                RaisePropertyChanged(CategoryIDPropertyName);
            }
        }

        public static string ProductNamePropertyName = "ProductName";
        public string ProductName
        {
            get { return _productEntity.ProductName; }
            set
            {
                _productEntity.ProductName = value;
                RaisePropertyChanged(ProductNamePropertyName);
            }
        }

        public static string UnitPricePropertyName = "UnitPrice";
        public decimal? UnitPrice
        {
            get { return _productEntity.UnitPrice; }
            set
            {
                _productEntity.UnitPrice = value;
                RaisePropertyChanged(UnitPricePropertyName);
            }
        }

        public static string CategoryPropertyName = "Category";
        private ICategoryModel _category;
        public ICategoryModel Category
        {
            get
            {
                return _category ??
                       new CategoryModel(
                           _productEntity.Category);
            }
            set
            {
                _category = value;
                RaisePropertyChanged(CategoryPropertyName);
            }
        }

        #endregion Propeties

        public ProductModel(IProductEntity productEntity)
        {
            _productEntity = productEntity;
        }
    }
}