using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
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

namespace MongoDB.VisualStudio.Explorer
{
    public partial class ExplorerTree : UserControl
    {
        public ExplorerTree()
        {
            InitializeComponent();

            CommandBindings.Add(new CommandBinding(MongoVSCommands.ViewDatabase, OnViewDatabase));
        }

        public IWindowManager WindowManager { get; set; }

        public ExplorerTreeViewModel ViewModel
        {
            get { return (ExplorerTreeViewModel)DataContext; }
            set { DataContext = value; }
        }

        private void OnViewDatabase(object sender, ExecutedRoutedEventArgs e)
        {
            WindowManager.CreateToolWindow<DatabaseEditorWindow>().Show();
        }

        private void OnItemMouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
            MessageBox.Show(e.ClickCount.ToString());
        }
    }
}