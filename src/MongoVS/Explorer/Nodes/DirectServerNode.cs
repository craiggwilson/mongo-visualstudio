using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using MongoDB.Driver;

namespace MongoDB.VisualStudio.Explorer.Nodes
{
    [Export(typeof(IRootExplorerNode))]
    public class DirectServerNode : ExpandableExplorerNodeBase
    {
        private static readonly ImageSource _image = new BitmapImage(new Uri("pack://application:,,,/MongoVS;component/Resources/Images/Server.png"));

        private MongoClient _client;
        private string _text;

        public DirectServerNode(IExplorerNode parent, MongoClient client)
            : base(parent)
        {
            _client = client;
            _text = client.Settings.Servers.Single().ToString();
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
            get { return _text; }
        }
    }
}