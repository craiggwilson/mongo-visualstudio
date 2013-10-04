using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDB.VisualStudio.Explorer
{
    public interface IRootExplorerNodeFactory
    {
        IRootExplorerNode CreateRootNode(string name, IEnumerable<string> addresses);
    }
}