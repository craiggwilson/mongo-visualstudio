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
    public class ServerViewModel : ITreeItemViewModel, INotifyPropertyChanged
    {
        private readonly ServerPresenter _presenter;
        private bool _isExpanded;
        private ObservableCollection<DatabaseViewModel> _databases;

        public ServerViewModel(ServerPresenter presenter)
        {
            _presenter = presenter;
        }

        public string Name
        {
            get { return _presenter.Address; }
        }

        public IEnumerable<DatabaseViewModel> Databases
        {
            get { return _databases; }
            set
            {
                if (_databases != value)
                {
                    _databases = new ObservableCollection<DatabaseViewModel>(value);
                    OnPropertyChanged("Databases");
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

                if (_isExpanded)
                {
                    LoadChildren();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void LoadChildren()
        {
            Databases = _presenter.GetDatabases();
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