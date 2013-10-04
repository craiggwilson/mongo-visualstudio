using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDB.VisualStudio.Explorer
{
    public interface IExplorerNodeFactory
    {
        IEnumerable<IExplorerNode> CreateChildren(IExplorerNode parent);
    }
}
