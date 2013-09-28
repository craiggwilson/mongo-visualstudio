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
using MongoDB.Driver;

namespace MongoDB.VisualStudio.Explorer.ViewModels
{
    public class ServerViewModel : NodeViewModelWithChildren
    {
        private static readonly ImageSource _image = new BitmapImage(new Uri("pack://application:,,,/MongoVS;component/Resources/Images/Server.png"));

        private readonly string _address;
        private readonly MongoClient _client;

        public ServerViewModel(string address)
        {
            _address = address;
            _client = new MongoClient("mongodb://" + address);
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
            get { return _address; }
        }

        protected override IEnumerable<NodeViewModel> LoadChildren()
        {
            yield return new DatabasesViewModel(_client);
        }
    }
}