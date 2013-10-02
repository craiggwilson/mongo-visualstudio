using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MongoDB.VisualStudio.Controls
{
    public class CommandTreeViewItem : TreeViewItem, ICommandSource
    {
        public static readonly DependencyProperty CommandProperty =DependencyProperty.Register
        (
            "Command",
            typeof(ICommand),
            typeof(CommandTreeViewItem),
            new PropertyMetadata((ICommand)null, new PropertyChangedCallback(CommandChanged))
        );

        public static readonly DependencyProperty CommandParameterProperty =
            DependencyProperty.Register
            (
                "CommandParameter",
                typeof(object),
                typeof(CommandTreeViewItem),
                new PropertyMetadata((object)null)
            );

        public static readonly DependencyProperty CommandTargetProperty =
            DependencyProperty.Register
            (
                "CommandTarget",
                typeof(IInputElement),
                typeof(CommandTreeViewItem),
                new PropertyMetadata((IInputElement)null)
            );

        private static void CommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            CommandTreeViewItem commandTreeViewItem = (CommandTreeViewItem)d;
            commandTreeViewItem.HookUpCommand((ICommand)e.OldValue, (ICommand)e.NewValue);
        }

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public object CommandParameter
        {
            get { return GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }

        public IInputElement CommandTarget
        {
            get { return (IInputElement)GetValue(CommandTargetProperty); }
            set { SetValue(CommandTargetProperty, value); }
        }

        protected override DependencyObject GetContainerForItemOverride()
        {
            return new CommandTreeViewItem();
        }

        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return item is CommandTreeViewItem;
        }

        private void CanExecuteChanged(object sender, EventArgs e)
        {
            if (Command != null)
            {
                RoutedCommand routedCommand = Command as RoutedCommand;

                if (routedCommand != null)
                {
                    IsEnabled = routedCommand.CanExecute(CommandParameter, CommandTarget);
                }
                else
                {
                    IsEnabled = Command.CanExecute(CommandParameter);
                }
            }
        }

        private void HookUpCommand(ICommand oldCommand, ICommand newCommand)
        {
            if (oldCommand != null)
            {
                oldCommand.CanExecuteChanged -= CanExecuteChanged;
            }
            if (newCommand != null)
            {
                newCommand.CanExecuteChanged += CanExecuteChanged;
                KeyDown += OnKeyDown;
                MouseDoubleClick += OnMouseDoubleClick;
            }
            else
            {
                KeyDown -= OnKeyDown;
                MouseDoubleClick -= OnMouseDoubleClick;
            }
        }

        void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (IsSelected && e.Key == Key.Enter)
            {
                ExecuteCommand();
                e.Handled = true;
            }
        }

        private void OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (IsSelected && e.ChangedButton == MouseButton.Left)
            {
                ExecuteCommand();
                e.Handled = true;
            }
        }

        private bool ExecuteCommand()
        {
            var routedCommand = Command as RoutedCommand;
            if (routedCommand != null)
            {
                routedCommand.Execute(CommandParameter, CommandTarget);
            }
            else
            {
                Command.Execute(CommandParameter);
            }
            return true;
        }
    }
}