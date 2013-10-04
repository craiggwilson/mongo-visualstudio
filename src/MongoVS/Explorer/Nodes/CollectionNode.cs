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
    public class CollectionNode : ExplorerNodeBase
    {
        private static readonly ImageSource _image = new BitmapImage(new Uri("pack://application:,,,/MongoVS;component/Resources/Images/Collection.png"));

        private readonly MongoCollection _collection;

        public CollectionNode(IExplorerNode parent, MongoCollection collection)
            : base(parent)
        {
            _collection = collection;
        }

        public override ImageSource Image
        {
            get { return _image; }
        }

        public override string Text
        {
            get { return _collection.Name; }
        }
    }
}