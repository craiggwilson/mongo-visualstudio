using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace MongoDB.VisualStudio.Explorer.ViewModels
{
    public abstract class NodeViewModel : INotifyPropertyChanged
    {
        private readonly int _depth;
        private readonly NodeViewModel _parent;

        protected NodeViewModel(NodeViewModel parent)
        {
            _parent = parent;
            _depth = _parent == null ? 0 : _parent.Depth + 1;
        }

        public int Depth
        {
            get { return _depth; }
        }

        public abstract ImageSource Image { get; }

        public NodeViewModel Parent
        {
            get { return _parent; }
        }

        public abstract string Text { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}