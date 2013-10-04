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
    public class DirectServerNodeFactory : TypedParentExplorerNodeFactory<ClientNode>
    {
        protected override IEnumerable<IExplorerNode> DoCreateChildren(ClientNode parent)
        {
            if (parent.Client.Settings.Servers.Count() != 1)
                return Enumerable.Empty<IExplorerNode>();

            return new[] { new DirectServerNode(parent, parent.Client) };
        }
    }
}