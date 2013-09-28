using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MongoDB.VisualStudio.Presenters;

namespace MongoDB.VisualStudio.Models
{
    public class DatabasesViewModel : TreeItemViewModelWithChildren
    {
        private readonly DatabasesPresenter _presenter;
        private readonly ObservableCollection<ContextMenuItemViewModel> _contextMenuCommands;

        public DatabasesViewModel(DatabasesPresenter presenter)
        {
            _presenter = presenter;

            var refresh = new ContextMenuItemViewModel
            {
                Name = "Refresh",
                Command = new RelayCommand(_ => Refresh())
            };

            _contextMenuCommands = new ObservableCollection<ContextMenuItemViewModel>
            {
                refresh
            };
        }

        public override string Name
        {
            get { return "Databases"; }
        }

        public IEnumerable<ContextMenuItemViewModel> ContextMenuItems
        {
            get { return _contextMenuCommands; }
        }

        protected override IEnumerable<ITreeItemViewModel> LoadChildren()
        {
            return _presenter.GetChildren();
        }
    }
}