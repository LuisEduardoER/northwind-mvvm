using System;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using Northwind.Interfaces;

namespace Northwind.ViewModel
{
    public class ToolViewModel : ServiceViewModel
    {
        public event EventHandler RequestClose = delegate { };

        private ICommand _closeCommand = null;

        public ICommand CloseCommand
        {
            get {
                return _closeCommand ??
                       (_closeCommand =
                        new RelayCommand(OnRequestClose));
            }
        }

        private void OnRequestClose()
        {
            RequestClose(this, EventArgs.Empty);
        }        


        public ToolViewModel(string displayName, 
                IApplicationServices applicationServices)
            : base(displayName, applicationServices)
        {
        }
    }
}