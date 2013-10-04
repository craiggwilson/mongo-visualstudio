using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using MongoDB.Driver;

namespace MongoDB.VisualStudio.Explorer.Nodes
{
    public class ClientNode : ExpandableExplorerNodeBase, IRootExplorerNode
    {
        private static readonly ImageSource _image = new BitmapImage(new Uri("pack://application:,,,/MongoVS;component/Resources/Images/Server.png"));

        private MongoClient _client;
        private string _name;

        public ClientNode(string name, MongoClient client)
            : base(null)
        {
            _client = client;
            _name = name;
        }

        public MongoClient Client
        {
            get { return _client; }
        }

        public override ImageSource ExpandedImage
        {
            get { return _image; }
        }

        public override ImageSource Image
        {
            get { return _image; }
        }

        public override string Text
        {
            get { return _name; }
        }
    }
}