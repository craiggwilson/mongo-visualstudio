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
    public class CollectionsViewModel : TreeItemViewModelWithChildren
    {
        private readonly CollectionsPresenter _presenter;

        public CollectionsViewModel(CollectionsPresenter presenter)
        {
            _presenter = presenter;
        }

        public override string Name
        {
            get { return "Collections"; }
        }

        protected override IEnumerable<ITreeItemViewModel> LoadChildren()
        {
            return _presenter.GetChildren();
        }
    }
}