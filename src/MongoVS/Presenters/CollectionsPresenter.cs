using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.VisualStudio.Models;

namespace MongoDB.VisualStudio.Presenters
{
    public class CollectionsPresenter
    {
        public CollectionsPresenter(MongoDatabase database)
        {
            Database = database;
        }

        public MongoDatabase Database { get; private set; }

        public IEnumerable<ITreeItemViewModel> GetChildren()
        {
            foreach (var collectionName in Database.GetCollectionNames())
            {
                yield return new CollectionViewModel { Name = collectionName };
            }
        }
    }
}