using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using MongoDB.Driver;

namespace MongoDB.VisualStudio.Explorer.ViewModels
{
    public class CollectionViewModel : NodeViewModel
    {
        private static readonly ImageSource _image = new BitmapImage(new Uri("pack://application:,,,/MongoVS;component/Resources/Images/Collection.png"));

        private readonly MongoCollection _collection;

        public CollectionViewModel(MongoCollection collection)
        {
            _collection = collection;
        }

        public override ImageSource Image
        {
            get { return _image; }
        }

        public override string Name
        {
            get { return _collection.Name; }
        }
    }
}