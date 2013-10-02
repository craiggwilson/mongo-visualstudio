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
    public abstract class ExpandableNodeViewModel : NodeViewModel
    {
        private ObservableCollection<NodeViewModel> _children;
        private bool _isExpanded;
        private bool _isLoaded;

        protected ExpandableNodeViewModel(NodeViewModel parent)
            : base(parent)
        {
            _children = new ObservableCollection<NodeViewModel>
            {
                new DummyViewModel()
            };
        }

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

                if (_isExpanded)
                {
                    if (Parent != null)
                    {
                        ((ExpandableNodeViewModel)Parent).IsExpanded = true;
                    }
                    if (!_isLoaded)
                    {
                        Children = LoadChildren();
                        _isLoaded = true;
                    }
                }
            }
        }

        protected abstract IEnumerable<NodeViewModel> LoadChildren();

        protected void ReloadChildren()
        {
            _isLoaded = false;
            IsExpanded = true;
        }

        private class DummyViewModel : NodeViewModel
        {
            public DummyViewModel()
                : base(null)
            { }

            public override System.Windows.Media.ImageSource Image
            {
                get { throw new NotImplementedException(); }
            }

            public override string Text
            {
                get { throw new NotImplementedException(); }
            }
        }
    }
}
