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
    public class DatabasesViewModel : TreeItemViewModelWithChildren
    {
        private readonly DatabasesPresenter _presenter;

        public DatabasesViewModel(DatabasesPresenter presenter)
        {
            _presenter = presenter;
        }

        public override string Name
        {
            get { return "Databases"; }
        }

        protected override IEnumerable<ITreeItemViewModel> LoadChildren()
        {
            return _presenter.GetChildren();
        }
    }
}