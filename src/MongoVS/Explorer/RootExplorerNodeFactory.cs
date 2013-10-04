using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.VisualStudio.Explorer.Nodes;

namespace MongoDB.VisualStudio.Explorer
{
    [Export(typeof(IRootExplorerNodeFactory))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class RootExplorerNodeFactory : IRootExplorerNodeFactory
    {
        [Import]
        public ICompositionService CompositionService { get; set; }

        public IRootExplorerNode CreateRootNode(string name, IEnumerable<string> addresses)
        {
            var clientSettings = new MongoClientSettings
            {
                Servers = addresses.Select(x => MongoServerAddress.Parse(x))
            };

            var client = new MongoClient(clientSettings);
            var node = new ClientNode(name, client);
            CompositionService.SatisfyImportsOnce(node);
            return node;
        }
    }
}