using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.VisualStudio.Models;

namespace MongoDB.VisualStudio.Presenters
{
    public class DatabasePresenter
    {
        public DatabasePresenter(MongoDatabase database)
        {
            Database = database;
        }

        public MongoDatabase Database { get; private set; }

        public IEnumerable<TreeItemViewModel> GetChildren()
        {
            yield return new CollectionsViewModel(new CollectionsPresenter(Database));
        }
    }
}