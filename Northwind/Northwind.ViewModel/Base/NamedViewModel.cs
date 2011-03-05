using GalaSoft.MvvmLight;
using Northwind.Interfaces;

namespace Northwind.ViewModel
{

    public class NamedViewModel : ViewModelBase
    {
        #region Properties

        public const string NamePropertyName = "Name";

        private string _name = string.Empty;

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                if (_name == value)
                {
                    return;
                }
                _name = value;
                RaisePropertyChanged(NamePropertyName);
            }
        }

        #endregion Properties

        public NamedViewModel(string header)
        {
            Name = header;
        }
    }
}