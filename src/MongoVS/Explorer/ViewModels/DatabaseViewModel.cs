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
    public class DatabaseViewModel : ExpandableNodeViewModel
    {
        private static readonly ImageSource _image = new BitmapImage(new Uri("pack://application:,,,/MongoVS;component/Resources/Images/Database.png"));

        private readonly MongoDatabase _database;

        public DatabaseViewModel(DatabasesViewModel parent, MongoDatabase database)
            : base(parent)
        {
            _database = database;
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
            get { return _database.Name; }
        }

        protected override IEnumerable<NodeViewModel> LoadChildren()
        {
            yield return new CollectionsViewModel(this, _database);
        }
    }
}