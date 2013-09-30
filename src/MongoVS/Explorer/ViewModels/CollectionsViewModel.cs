using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using MongoDB.Driver;

namespace MongoDB.VisualStudio.Explorer.ViewModels
{
    public class CollectionsViewModel : ExpandableNodeViewModel
    {
        private static readonly ImageSource _image = new BitmapImage(new Uri("pack://application:,,,/MongoVS;component/Resources/Images/FolderClosed.png"));
        private static readonly ImageSource _expandedImage = new BitmapImage(new Uri("pack://application:,,,/MongoVS;component/Resources/Images/FolderOpen.png"));

        private readonly MongoDatabase _database;

        public CollectionsViewModel(DatabaseViewModel parent, MongoDatabase database)
            : base(parent)
        {
            _database = database;
        }

        public override ImageSource ExpandedImage
        {
            get { return _expandedImage; }
        }

        public override ImageSource Image
        {
            get { return _image; }
        }

        public override string Text
        {
            get { return "Collections"; }
        }

        protected override IEnumerable<NodeViewModel> LoadChildren()
        {
            foreach (var collectionName in _database.GetCollectionNames())
            {
                var collection = _database.GetCollection(collectionName);
                yield return new CollectionViewModel(this, collection);
            }
        }
    }
}