using System;
using System.Windows;
using System.Windows.Input;

namespace Northwind.Framework.UI
{
    public static class EventBehaviorFactory
    {
        public static DependencyProperty
            CreateCommandExecutionEventBehavior(
                RoutedEvent routedEvent,
                string propertyName,
                Type ownerType)
        {
            DependencyProperty property 
                = DependencyProperty.RegisterAttached(
                    propertyName, typeof(ICommand), ownerType, 
                    new PropertyMetadata(
                        null, 
                        new ExecuteCommandOnRoutedEventBehaviour(
                            routedEvent).PropertyChangedHandler)
                    );
            return property;
        }

        private class ExecuteCommandOnRoutedEventBehaviour 
            : ExecuteCommandBehaviour
        {
            private readonly RoutedEvent _routedEvent;
            public ExecuteCommandOnRoutedEventBehaviour(
                RoutedEvent routedEvent)
            {
                _routedEvent = routedEvent;
            }

            /// <summary>             
            /// Handles attaching or Detaching Event handlers 
            /// when a Command is assigned or unassigned             
            /// </summary>                          
            protected override void AdjustEventHandlers(
                DependencyObject sender, object oldValue, 
                object newValue)
            {
                UIElement element = sender as UIElement;
                if (element == null)
                {
                    return;
                }
                if (oldValue != null)
                {
                    element.RemoveHandler(_routedEvent, 
                        new RoutedEventHandler(EventHandler));
                } 
                if (newValue != null)
                {
                    element.AddHandler(_routedEvent, 
                        new RoutedEventHandler(EventHandler));
                }
            }

            private void EventHandler(object sender, 
                RoutedEventArgs e)
            {
                HandleEvent(sender, e);
            }
        }

        internal abstract class ExecuteCommandBehaviour
        {
            protected DependencyProperty _property;

            protected abstract void AdjustEventHandlers(
                DependencyObject sender, object oldValue, 
                object newValue);
            
            protected void HandleEvent(object sender, EventArgs e)
            {
                DependencyObject dp = sender as DependencyObject;
                if (dp == null)
                {
                    return;
                }
                ICommand command = dp.GetValue(_property) as ICommand;
                if (command == null)
                {
                    return;
                }
                if (command.CanExecute(e))
                {
                    command.Execute(e);
                }
            }
            /// <summary>
            /// Listens for a change in the DependencyProperty 
            /// that we are assigned to, and
            /// adjusts the EventHandlers accordingly
            /// </summary>
            public void PropertyChangedHandler(DependencyObject sender, 
                DependencyPropertyChangedEventArgs e)
            {
                // the first time the property changes,                 
                // make a note of which property we are supposed                 
                // to be watching                 

                if (_property == null)
                {
                    _property = e.Property;
                }

                object oldValue = e.OldValue;
                object newValue = e.NewValue;
                
                AdjustEventHandlers(sender, oldValue, newValue);
            }
        }
    }
}
