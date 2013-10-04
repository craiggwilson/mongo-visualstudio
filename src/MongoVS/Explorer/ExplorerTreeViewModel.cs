using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MongoDB.VisualStudio.Explorer
{
    public class ExplorerTreeViewModel
    {
        public ExplorerTreeViewModel()
        {
            Children = new ObservableCollection<IRootExplorerNode>();
        }

        public ObservableCollection<IRootExplorerNode> Children { get; private set; }
    }
}