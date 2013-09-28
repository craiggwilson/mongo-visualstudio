using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using MongoDB.VisualStudio.Presenters;

namespace MongoDB.VisualStudio.Models
{
    public class DatabasesViewModel : TreeItemViewModelWithChildren
    {
        private static readonly ImageSource _image = new BitmapImage(new Uri("pack://application:,,,/MongoVS;component/Resources/Images/FolderClosed.png"));
        private static readonly ImageSource _expandedImage = new BitmapImage(new Uri("pack://application:,,,/MongoVS;component/Resources/Images/FolderOpen.png"));

        private readonly DatabasesPresenter _presenter;

        public DatabasesViewModel(DatabasesPresenter presenter)
        {
            _presenter = presenter;
        }

        public override ImageSource ExpandedImage
        {
            get { return _expandedImage; }
        }

        public override ImageSource Image
        {
            get { return _image; }
        }

        public override string Name
        {
            get { return "Databases"; }
        }

        protected override IEnumerable<TreeItemViewModel> LoadChildren()
        {
            return _presenter.GetChildren();
        }
    }
}