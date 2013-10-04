using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDB.VisualStudio.Explorer
{
    public abstract class TypedParentExplorerNodeFactory<TParent> : ComposingExplorerNodeFactory
        where TParent : class, IExplorerNode
    {
        protected override IEnumerable<IExplorerNode> DoCreateChildren(IExplorerNode parent)
        {
            var typedParent = parent as TParent;
            if (typedParent != null)
            {
                return DoCreateChildren(typedParent);
            }

            return Enumerable.Empty<IExplorerNode>();
        }

        protected abstract IEnumerable<IExplorerNode> DoCreateChildren(TParent parent);
    }
}