using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using Northwind.Interfaces;

namespace Northwind.ViewModel
{
    public abstract class ComponentsViewModel : ServiceViewModel
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

        protected ComponentsViewModel(string name, 
                IApplicationServices applicationServices)
            : base(name, applicationServices)
        {
            AddComponents();
        }

        protected abstract void AddComponents();
    }
}