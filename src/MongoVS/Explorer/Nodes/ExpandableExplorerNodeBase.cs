using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace MongoDB.VisualStudio.Explorer.Nodes
{
    public abstract class ExpandableExplorerNodeBase : ExplorerNodeBase
    {
        private ObservableCollection<IExplorerNode> _children;
        private bool _isExpanded;
        private bool _isLoaded;

        protected ExpandableExplorerNodeBase()
            : this(null)
        { }

        protected ExpandableExplorerNodeBase(IExplorerNode parent)
            : base(parent)
        {
            _children = new ObservableCollection<IExplorerNode>
            {
                new DummyNode()
            };
        }

        public IEnumerable<IExplorerNode> Children
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
                        _children = new ObservableCollection<IExplorerNode>(value);
                    }
                    OnPropertyChanged("Children");
                }
            }
        }

        public abstract ImageSource ExpandedImage { get; }

        [ImportMany]
        public IEnumerable<IExplorerNodeFactory> NodeFactories { get; set; }

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
                        ((ExpandableExplorerNodeBase)Parent).IsExpanded = true;
                    }
                    if (!_isLoaded)
                    {
                        Children = LoadChildren();
                        _isLoaded = true;
                    }
                }
            }
        }

        protected IEnumerable<IExplorerNode> LoadChildren()
        {
            return NodeFactories.SelectMany(x => x.CreateChildren(this));
        }

        private class DummyNode : ExplorerNodeBase
        {
            public DummyNode()
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
