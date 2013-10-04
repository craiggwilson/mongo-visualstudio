using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDB.VisualStudio.Explorer
{
    public interface IExplorerNodeMetadata
    {
        Type ParentType { get; }
    }
}