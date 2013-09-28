using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using MongoDB.VisualStudio.Presenters;

namespace MongoDB.VisualStudio.Models
{
    public class DatabaseViewModel : TreeItemViewModelWithChildren
    {
        private static readonly ImageSource _image = new BitmapImage(new Uri("pack://application:,,,/MongoVS;component/Resources/Images/Database.png"));

        private readonly DatabasePresenter _presenter;

        public DatabaseViewModel(DatabasePresenter presenter)
        {
            _presenter = presenter;
        }

        public override ImageSource ExpandedImage
        {
            get { return _image; }
        }

        public override ImageSource Image
        {
            get { return _image; }
        }

        public override string Name
        {
            get { return _presenter.Database.Name; }
        }

        protected override IEnumerable<TreeItemViewModel> LoadChildren()
        {
            return _presenter.GetChildren();
        }
    }
}