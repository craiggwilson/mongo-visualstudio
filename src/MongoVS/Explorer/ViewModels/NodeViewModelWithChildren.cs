using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MongoDB.VisualStudio.Explorer.ViewModels
{
    public abstract class NodeViewModelWithChildren : NodeViewModel
    {
        private ObservableCollection<NodeViewModel> _children;
        private bool _isExpanded;

        public IEnumerable<NodeViewModel> Children
        {
            get { return _children; }
            set
            {
                if (_children != value)
                {
                    if (value == null)
                    {
                        _children = null;
                    }
                    else
                    {
                        _children = new ObservableCollection<NodeViewModel>(value);
                    }
                    OnPropertyChanged("Children");
                }
            }
        }

        public abstract ImageSource ExpandedImage { get; }

        public bool IsExpanded
        {
            get { return _isExpanded; }
            set
            {
                if (_isExpanded != value)
                {
                    _isExpanded = value;
                    OnPropertyChanged("IsExpanded");
                }

                if (_isExpanded && _children == null)
                {
                    Children = LoadChildren();
                }
            }
        }

        protected abstract IEnumerable<NodeViewModel> LoadChildren();

        protected void ReloadChildren()
        {
            Children = null;
            IsExpanded = true;
        }
    }
}
