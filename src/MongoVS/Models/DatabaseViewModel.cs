using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.VisualStudio.Presenters;

namespace MongoDB.VisualStudio.Models
{
    public class DatabaseViewModel : ITreeItemViewModel, INotifyPropertyChanged
    {
        private readonly DatabasePresenter _presenter;
        private ObservableCollection<CollectionViewModel> _collections;
        private bool _isExpanded;

        public DatabaseViewModel(DatabasePresenter presenter)
        {
            _presenter = presenter;
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

                if (_isExpanded)
                {
                    LoadChildren();
                }
            }
        }

        public string Name
        {
            get { return _presenter.Database.Name; }
        }

        public IEnumerable<CollectionViewModel> Collections
        {
            get { return _collections; }
            set
            {
                if (_collections != value)
                {
                    _collections = new ObservableCollection<CollectionViewModel>(value);
                    OnPropertyChanged("Collections");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void LoadChildren()
        {
            Collections = _presenter.GetCollections();
        }

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
