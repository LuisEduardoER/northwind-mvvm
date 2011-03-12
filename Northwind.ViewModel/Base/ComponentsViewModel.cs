using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using Northwind.Interfaces;

namespace Northwind.ViewModel
{
    public abstract class ComponentsViewModel : NamedViewModel
    {
        #region Properties
        
        public const string ComponentsPropertyName 
            = "Components";

        private ObservableCollection<NamedViewModel> _components
                    = new ObservableCollection<NamedViewModel>();

        public ObservableCollection<NamedViewModel> Components
        {
            get
            {
                return _components;
            }

            set
            {
                if (_components == value)
                {
                    return;
                }

                _components = value;
                RaisePropertyChanged(ComponentsPropertyName);
            }
        }

        #endregion Properties

        protected ComponentsViewModel(string name)
            : base(name)
        {
            AddComponents();
        }

        protected abstract void AddComponents();
    }
}