using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MongoDB.VisualStudio.Presenters;

namespace MongoDB.VisualStudio.Models
{
    public class TreeViewModel
    {
        public TreeViewModel()
        {
            Children = new ObservableCollection<ITreeItemViewModel>();
        }

        public ObservableCollection<ITreeItemViewModel> Children { get; private set; }
    }
}