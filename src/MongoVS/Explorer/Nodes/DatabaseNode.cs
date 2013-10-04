using System;
using System.ComponentModel.Composition;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.VisualStudio.Shell;
using MongoDB.Driver;
using MongoDB.VisualStudio.Editors.Database;
using MongoDB.VisualStudio.Utilities;

namespace MongoDB.VisualStudio.Explorer.Nodes
{
    public class DatabaseNode : ExpandableExplorerNodeBase
    {
        private static readonly ImageSource _image = new BitmapImage(new Uri("pack://application:,,,/MongoVS;component/Resources/Images/Database.png"));

        private readonly ICommand _activatedCommand;
        private readonly MongoDatabase _database;

        [Import]
        private IWindowManager _windowManager;

        public DatabaseNode(IExplorerNode parent, MongoDatabase database)
            : base(parent)
        {
            _database = database;
            _activatedCommand = new RelayCommand(_ => OpenDatabase());
        }

        public ICommand ActivatedCommand
        {
            get { return MongoVSCommands.ViewDatabase; }
        }

        public MongoDatabase Database
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

        private void OpenDatabase()
        {
            _windowManager.CreateToolWindow<DatabaseEditorWindow>().Show();
        }
    }
}