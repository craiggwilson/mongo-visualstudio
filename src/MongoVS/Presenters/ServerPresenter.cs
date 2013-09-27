using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.VisualStudio.Models;

namespace MongoDB.VisualStudio.Presenters
{
    public class ServerPresenter
    {
        public ServerPresenter(string address)
        {
            Address = address;
            Client = new MongoClient("mongodb://" + address).GetServer();
        }

        public string Address { get; private set; }

        public MongoServer Client { get; private set; }

        public IEnumerable<DatabaseViewModel> GetDatabases()
        {
            foreach (var dbName in Client.GetDatabaseNames())
            {
                var database = Client.GetDatabase(dbName);
                var presenter = new DatabasePresenter(database);
                yield return new DatabaseViewModel(presenter);
            }
        }
    }
}