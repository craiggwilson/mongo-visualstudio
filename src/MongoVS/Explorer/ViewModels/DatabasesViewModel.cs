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
using MongoDB.Driver;

namespace MongoDB.VisualStudio.Explorer.ViewModels
{
    public class DatabasesViewModel : NodeViewModelWithChildren
    {
        private static readonly ImageSource _image = new BitmapImage(new Uri("pack://application:,,,/MongoVS;component/Resources/Images/FolderClosed.png"));
        private static readonly ImageSource _expandedImage = new BitmapImage(new Uri("pack://application:,,,/MongoVS;component/Resources/Images/FolderOpen.png"));

        private readonly MongoClient _client;

        public DatabasesViewModel(MongoClient client)
        {
            _client = client;
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

        protected override IEnumerable<NodeViewModel> LoadChildren()
        {
            var server = _client.GetServer();
            foreach (var dbName in server.GetDatabaseNames())
            {
                var database = server.GetDatabase(dbName);
                yield return new DatabaseViewModel(database);
            }
        }
    }
}