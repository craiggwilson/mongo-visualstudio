using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using MongoDB.VisualStudio.Presenters;

namespace MongoDB.VisualStudio.Models
{
    public class ServerViewModel : TreeItemViewModelWithChildren
    {
        private readonly ImageSource _image = new BitmapImage(new Uri("pack://application:,,,/MongoVS;component/Resources/Images/Server.png"));
        private readonly ServerPresenter _presenter;

        public ServerViewModel(ServerPresenter presenter)
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
            get { return _presenter.Address; }
        }

        protected override IEnumerable<TreeItemViewModel> LoadChildren()
        {
            return _presenter.GetChildren();
        }
    }
}