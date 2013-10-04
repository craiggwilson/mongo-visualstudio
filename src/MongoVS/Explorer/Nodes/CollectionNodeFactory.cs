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
    public class CollectionNodeFactory : TypedParentExplorerNodeFactory<CollectionsNode>
    {
        protected override IEnumerable<IExplorerNode> DoCreateChildren(CollectionsNode parent)
        {
            foreach (var collectionName in parent.Database.GetCollectionNames())
            {
                yield return new CollectionNode(parent, parent.Database.GetCollection(collectionName));
            }
        }
    }
}