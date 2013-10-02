using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.PlatformUI;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using MongoDB.Driver;
using MongoDB.VisualStudio.Editors.Database;
using MongoDB.VisualStudio.Explorer.ViewModels;

namespace MongoDB.VisualStudio.Explorer
{
    public partial class ExplorerTree : UserControl
    {
        private readonly ExplorerWindow _window;

        public ExplorerTree(ExplorerWindow window, ExplorerTreeViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;

            CommandBindings.Add(new CommandBinding(MongoVSCommands.ViewDatabase, ViewDatabase));

            _window = window;
        }

        private void ViewDatabase(object sender, ExecutedRoutedEventArgs e)
        {
            var package = (Package)_window.Package;
            var window = (DatabaseEditorWindow)package.FindToolWindow(typeof(DatabaseEditorWindow), 0, true);
            if (window == null || window.Frame == null)
            {
                throw new NotSupportedException("oops");
            }
            window.Database = (MongoDatabase)e.Parameter;
            var windowFrame = (IVsWindowFrame)window.Frame;
            ErrorHandler.ThrowOnFailure(windowFrame.Show());
        }

        private void OnItemMouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
            MessageBox.Show(e.ClickCount.ToString());
        }
    }
}