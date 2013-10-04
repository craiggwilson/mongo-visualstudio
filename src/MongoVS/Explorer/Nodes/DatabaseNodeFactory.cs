using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.VisualStudio.Explorer.Nodes;

namespace MongoDB.VisualStudio.Explorer
{
    [ExplorerNodeFactory]
    public class DatabaseNodeFactory : TypedParentExplorerNodeFactory<DatabasesNode>
    {
        protected override IEnumerable<IExplorerNode> DoCreateChildren(DatabasesNode parent)
        {
            var server = parent.Client.GetServer();
            var dbNames = server.GetDatabaseNames();
            foreach (var dbName in dbNames)
            {
                yield return new DatabaseNode(parent, server.GetDatabase(dbName));
            }
        }
    }
}