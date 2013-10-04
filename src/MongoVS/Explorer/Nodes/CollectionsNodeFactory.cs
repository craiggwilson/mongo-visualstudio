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
    public class CollectionsNodeFactory : TypedParentExplorerNodeFactory<DatabaseNode>
    {
        protected override IEnumerable<IExplorerNode> DoCreateChildren(DatabaseNode parent)
        {
            return new[] { new CollectionsNode(parent, parent.Database) };
        }
    }
}