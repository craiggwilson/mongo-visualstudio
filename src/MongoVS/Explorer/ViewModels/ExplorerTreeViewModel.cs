using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MongoDB.VisualStudio.Explorer.ViewModels
{
    public class ExplorerTreeViewModel
    {
        public ExplorerTreeViewModel()
        {
            Children = new ObservableCollection<NodeViewModel>();
        }

        public ObservableCollection<NodeViewModel> Children { get; private set; }
    }
}