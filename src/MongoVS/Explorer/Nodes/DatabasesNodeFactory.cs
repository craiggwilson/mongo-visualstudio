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
    public class DatabasesNodeFactory : TypedParentExplorerNodeFactory<DirectServerNode>
    {
        protected override IEnumerable<IExplorerNode> DoCreateChildren(DirectServerNode parent)
        {
            return new[] { new DatabasesNode(parent, parent.Client) };
        }
    }
}