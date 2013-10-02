using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.Shell;
using MongoDB.Driver;

namespace MongoDB.VisualStudio.Editors.Database
{
    [Guid("6E1F4FD8-FD30-4426-8A74-15AC3F175746")]
    public class DatabaseEditorWindow : ToolWindowPane
    {
        private MongoDatabase _database;

        public DatabaseEditorWindow()
            : base(null)
        {
            base.Content = new DatabaseEditor();
        }

        public MongoDatabase Database
        {
            get { return _database; }
            set
            {
                _database = value;
                Caption = _database.Name;
            }
        }
    }
}