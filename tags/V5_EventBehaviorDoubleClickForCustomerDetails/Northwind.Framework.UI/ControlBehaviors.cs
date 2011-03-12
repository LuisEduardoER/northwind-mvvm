using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Northwind.Framework.UI
{
    public static class ControlBehaviors
    {
        public static readonly DependencyProperty 
            MouseDoubleClickCommand
                = EventBehaviorFactory.CreateCommandExecutionEventBehavior(
                    Control.MouseDoubleClickEvent, "MouseDoubleClickCommand", 
                    typeof(ControlBehaviors));

        public static void SetMouseDoubleClickCommand(DependencyObject o, 
            ICommand value)
        {
            o.SetValue(MouseDoubleClickCommand, value);
        }

        public static ICommand GetMouseDoubleClickCommand(
            DependencyObject o)
        {
            return o.GetValue(MouseDoubleClickCommand) as ICommand;
        }
    }
}