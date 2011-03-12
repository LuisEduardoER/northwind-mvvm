using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace Northwind.ViewModel
{
    public class CommandViewModel : NamedViewModel
    {
        public const string CommandPropertyName = "Command";

        private ICommand _command;

        public ICommand Command
        {
            get
            {
                return _command;
            }

            set
            {
                if (_command == value)
                {
                    return;
                }
                _command = value;
                RaisePropertyChanged(CommandPropertyName);
            }
        }        

        public CommandViewModel(string displayName, ICommand command)
            : base(displayName)
        {
            Command = command;
        }

        public void RaiseCanExecuteChanged()
        {
            ((RelayCommand)Command).RaiseCanExecuteChanged();
        }
    }
}