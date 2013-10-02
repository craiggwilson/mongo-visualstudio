using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell.Interop;
using MongoDB.Driver;
using MongoDB.VisualStudio.Editors.Database;
using MongoDB.VisualStudio.Utilities;

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

        public ICommand ActivatedCommand
        {
            get { return MongoVSCommands.ViewDatabase; }
        }

        public object ActivatedCommandParameter
        {
            get { return _database; }
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