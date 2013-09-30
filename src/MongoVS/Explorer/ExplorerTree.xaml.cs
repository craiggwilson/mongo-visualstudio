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
using Microsoft.VisualStudio.PlatformUI;
using MongoDB.VisualStudio.Explorer.ViewModels;

namespace MongoDB.VisualStudio.Explorer
{
    public partial class ExplorerTree : UserControl
    {
        public ExplorerTree(ExplorerTreeViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }

        private void OnItemMouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
            MessageBox.Show(e.ClickCount.ToString());
        }
    }
}