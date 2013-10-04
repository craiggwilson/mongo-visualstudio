using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDB.VisualStudio.Explorer
{
    public abstract class ComposingExplorerNodeFactory : IExplorerNodeFactory
    {
        [Import]
        public ICompositionService CompositionService { get; set; }

        public IEnumerable<IExplorerNode> CreateChildren(IExplorerNode parent)
        {
            foreach (var child in DoCreateChildren(parent))
            {
                CompositionService.SatisfyImportsOnce(child);
                yield return child;
            }
        }

        protected abstract IEnumerable<IExplorerNode> DoCreateChildren(IExplorerNode parent);
    }
}