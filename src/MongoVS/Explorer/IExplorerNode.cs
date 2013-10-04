using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDB.VisualStudio.Explorer
{
    public interface IExplorerNode
    {
        IExplorerNode Parent { get; }
    }
}