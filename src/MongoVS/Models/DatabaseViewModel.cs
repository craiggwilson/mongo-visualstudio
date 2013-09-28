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
    public class DatabaseViewModel : TreeItemViewModelWithChildren
    {
        private readonly DatabasePresenter _presenter;

        public DatabaseViewModel(DatabasePresenter presenter)
        {
            _presenter = presenter;
        }

        public override string Name
        {
            get { return _presenter.Database.Name; }
        }

        protected override IEnumerable<ITreeItemViewModel> LoadChildren()
        {
            return _presenter.GetChildren();
        }
    }
}