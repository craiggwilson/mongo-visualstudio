using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDB.VisualStudio.Models
{
    public abstract class TreeItemViewModelWithChildren : ITreeItemViewModel, INotifyPropertyChanged
    {
        private ObservableCollection<ITreeItemViewModel> _children;
        private bool _isExpanded;

        public abstract string Name { get; }

        public IEnumerable<ITreeItemViewModel> Children
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
                        _children = new ObservableCollection<ITreeItemViewModel>(value);
                    }
                    OnPropertyChanged("Children");
                }
            }
        }

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

        public event PropertyChangedEventHandler PropertyChanged;

        protected abstract IEnumerable<ITreeItemViewModel> LoadChildren();

        protected void Refresh()
        {
            Children = null;
            IsExpanded = true;
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
