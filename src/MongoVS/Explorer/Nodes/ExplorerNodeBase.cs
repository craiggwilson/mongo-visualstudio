using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MongoDB.VisualStudio.Explorer.Nodes
{
    public abstract class ExplorerNodeBase : IExplorerNode, INotifyPropertyChanged
    {
        private IExplorerNode _parent;

        protected ExplorerNodeBase(IExplorerNode parent)
        {
            _parent = parent;
        }

        public int Depth
        {
            get { return Parent == null ? 0 : ((ExplorerNodeBase)Parent).Depth + 1; }
        }

        public abstract ImageSource Image { get; }

        public IExplorerNode Parent 
        {
            get { return _parent; }
        }

        public abstract string Text { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}