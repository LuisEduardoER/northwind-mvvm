using Northwind.Interfaces.Data.Model;
using System.Collections.ObjectModel;
using Northwind.Interfaces.Data.Entity;

namespace Northwind.Application.Model
{
    public class CategoryModel : ModelBase, ICategoryModel
    {
        private readonly ICategoryEntity _categoryEntity;

        #region Properties

        private ObservableCollection<IProductModel> _products;
        public ObservableCollection<IProductModel> Products
        {
            get
            {
                if (_products == null)
                {
                    _products
                        = new ObservableCollection<IProductModel>();
                    foreach (IProductEntity product
                        in _categoryEntity.GetProducts())
                    {
                        _products.Add(new ProductModel(product));
                    }
                }
                return _products;
            }
        }

        public static string CategoryIDPropertyName = "CategoryID";
        public int CategoryID
        {
            get { return _categoryEntity.CategoryID; }
            set
            {
                _categoryEntity.CategoryID = value;
                RaisePropertyChanged("CategoryIDPropertyName");
            }
        }
        public static string CategoryNamePropertyName = "CategoryName";
        public string CategoryName
        {
            get { return _categoryEntity.CategoryName; }
            set
            {
                _categoryEntity.CategoryName = value;
                RaisePropertyChanged(CategoryNamePropertyName);
            }
        }

        public static string DescriptionPropertyName = "Description";
        public string Description
        {
            get { return _categoryEntity.Description; }
            set
            {
                _categoryEntity.Description = value;
                RaisePropertyChanged(DescriptionPropertyName);
            }
        }

        #endregion Properties

        public CategoryModel(ICategoryEntity categoryEntity)
        {
            _categoryEntity = categoryEntity;
        }
    }
}
